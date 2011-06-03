using System;
using NHibernate;
using NHibernate.Metadata;
using NHibernate.Proxy;

namespace ORM.Persistance
{
    public static class NHibernateProxyUtils
    {
        /// <summary>
        /// Force initialization of a proxy or persistent collection.
        /// </summary>
        /// <param name="persistentObject">a persistable object, proxy, persistent collection or null</param>
        /// <exception cref="HibernateException">if we can't initialize the proxy at this time, eg. the Session was closed</exception>
        public static T Unproxy<T>(this T persistentObject)
        {
            var proxy = persistentObject as INHibernateProxy;

            if (proxy != null)
                return (T)proxy.HibernateLazyInitializer.GetImplementation();

            return persistentObject;
        }

        /// <summary>
        /// Gets the underlying class type of a persistent object that may be proxied
        /// </summary>
        public static Type GetUnproxiedType<T>(this T persistentObject)
        {
            var proxy = persistentObject as INHibernateProxy;
            if (proxy != null)
                return proxy.HibernateLazyInitializer.PersistentClass;

            return persistentObject.GetType();
        }

        /// <summary>
        /// Force initialzation of a possibly proxied object tree up to the maxDepth.
        /// Once the maxDepth is reached, entity properties will be replaced with
        /// placeholder objects having only the identifier property populated.
        /// </summary>
        public static T UnproxyObjectTree<T>(this T persistentObject, ISessionFactory sessionFactory, int maxDepth)
        {
            // Determine persistent type of the object
            var persistentType = persistentObject.GetUnproxiedType();

            var classMetadata = sessionFactory.GetClassMetadata(persistentType);

            // If we've already reached the max depth, we will return a placeholder object
            if (maxDepth < 0)
                return CreatePlaceholder(persistentObject, persistentType, classMetadata);

            // Now lets go ahead and make sure everything is unproxied
            var unproxiedObject = persistentObject.Unproxy();

            // Iterate through each property and unproxy entity types
            for (int i = 0; i < classMetadata.PropertyTypes.Length; i++)
            {
                var nhType = classMetadata.PropertyTypes[i];
                var propertyName = classMetadata.PropertyNames[i];
                var propertyInfo = persistentType.GetProperty(propertyName);

                // Unproxy of collections is not currently supported.  We set the collection property to null.
                if (nhType.IsCollectionType)
                {
                    propertyInfo.SetValue(unproxiedObject, null, null);
                    continue;
                }

                if (nhType.IsEntityType)
                {
                    var propertyValue = propertyInfo.GetValue(unproxiedObject, null);

                    if (propertyValue == null)
                        continue;

                    propertyInfo.SetValue(
                        unproxiedObject,
                        propertyValue.UnproxyObjectTree(sessionFactory, maxDepth - 1),
                        null
                        );
                }
            }

            return unproxiedObject;
        }

        /// <summary>
        /// Return an empty placeholder object with the Identifier set.  We can safely access the identifier
        /// property without the object being initialized.
        /// </summary>
        private static T CreatePlaceholder<T>(T persistentObject, Type persistentType, IClassMetadata classMetadata)
        {
            var placeholderObject = (T)Activator.CreateInstance(persistentType);

            if (classMetadata.HasIdentifierProperty)
            {
                var identifier = classMetadata.GetIdentifier(persistentObject, EntityMode.Poco);
                classMetadata.SetIdentifier(placeholderObject, identifier, EntityMode.Poco);
            }

            return placeholderObject;
        }
    }
}
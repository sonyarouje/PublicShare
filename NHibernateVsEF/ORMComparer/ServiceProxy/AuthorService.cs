﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ORM.Domain
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Author", Namespace="http://schemas.datacontract.org/2004/07/ORM.Domain")]
    public partial class Author : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string AddressField;
        
        private string FirstNameField;
        
        private string IdField;
        
        private string LastNameField;
        
        private string PhoneField;
        
        private System.Collections.Generic.List<ORM.Domain.Titles> TitlesAuthoredField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Address
        {
            get
            {
                return this.AddressField;
            }
            set
            {
                if ((object.ReferenceEquals(this.AddressField, value) != true))
                {
                    this.AddressField = value;
                    this.RaisePropertyChanged("Address");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FirstName
        {
            get
            {
                return this.FirstNameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.FirstNameField, value) != true))
                {
                    this.FirstNameField = value;
                    this.RaisePropertyChanged("FirstName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                if ((object.ReferenceEquals(this.IdField, value) != true))
                {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LastName
        {
            get
            {
                return this.LastNameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.LastNameField, value) != true))
                {
                    this.LastNameField = value;
                    this.RaisePropertyChanged("LastName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Phone
        {
            get
            {
                return this.PhoneField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PhoneField, value) != true))
                {
                    this.PhoneField = value;
                    this.RaisePropertyChanged("Phone");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.List<ORM.Domain.Titles> TitlesAuthored
        {
            get
            {
                return this.TitlesAuthoredField;
            }
            set
            {
                if ((object.ReferenceEquals(this.TitlesAuthoredField, value) != true))
                {
                    this.TitlesAuthoredField = value;
                    this.RaisePropertyChanged("TitlesAuthored");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Titles", Namespace="http://schemas.datacontract.org/2004/07/ORM.Domain")]
    public partial class Titles : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private double AdvanceField;
        
        private System.Collections.Generic.List<ORM.Domain.Author> AuthorsField;
        
        private ORM.Domain.Publisher BookPublisherField;
        
        private string IdField;
        
        private double PriceField;
        
        private System.DateTime PublishedDateField;
        
        private int RoyaltyField;
        
        private string TitleField;
        
        private string TypeField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Advance
        {
            get
            {
                return this.AdvanceField;
            }
            set
            {
                if ((this.AdvanceField.Equals(value) != true))
                {
                    this.AdvanceField = value;
                    this.RaisePropertyChanged("Advance");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.List<ORM.Domain.Author> Authors
        {
            get
            {
                return this.AuthorsField;
            }
            set
            {
                if ((object.ReferenceEquals(this.AuthorsField, value) != true))
                {
                    this.AuthorsField = value;
                    this.RaisePropertyChanged("Authors");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ORM.Domain.Publisher BookPublisher
        {
            get
            {
                return this.BookPublisherField;
            }
            set
            {
                if ((object.ReferenceEquals(this.BookPublisherField, value) != true))
                {
                    this.BookPublisherField = value;
                    this.RaisePropertyChanged("BookPublisher");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                if ((object.ReferenceEquals(this.IdField, value) != true))
                {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Price
        {
            get
            {
                return this.PriceField;
            }
            set
            {
                if ((this.PriceField.Equals(value) != true))
                {
                    this.PriceField = value;
                    this.RaisePropertyChanged("Price");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime PublishedDate
        {
            get
            {
                return this.PublishedDateField;
            }
            set
            {
                if ((this.PublishedDateField.Equals(value) != true))
                {
                    this.PublishedDateField = value;
                    this.RaisePropertyChanged("PublishedDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Royalty
        {
            get
            {
                return this.RoyaltyField;
            }
            set
            {
                if ((this.RoyaltyField.Equals(value) != true))
                {
                    this.RoyaltyField = value;
                    this.RaisePropertyChanged("Royalty");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Title
        {
            get
            {
                return this.TitleField;
            }
            set
            {
                if ((object.ReferenceEquals(this.TitleField, value) != true))
                {
                    this.TitleField = value;
                    this.RaisePropertyChanged("Title");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Type
        {
            get
            {
                return this.TypeField;
            }
            set
            {
                if ((object.ReferenceEquals(this.TypeField, value) != true))
                {
                    this.TypeField = value;
                    this.RaisePropertyChanged("Type");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Publisher", Namespace="http://schemas.datacontract.org/2004/07/ORM.Domain")]
    public partial class Publisher : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private System.Collections.Generic.List<ORM.Domain.Titles> BooksPublishedField;
        
        private string CityField;
        
        private string CountryField;
        
        private string IdField;
        
        private string NameField;
        
        private string StateField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.List<ORM.Domain.Titles> BooksPublished
        {
            get
            {
                return this.BooksPublishedField;
            }
            set
            {
                if ((object.ReferenceEquals(this.BooksPublishedField, value) != true))
                {
                    this.BooksPublishedField = value;
                    this.RaisePropertyChanged("BooksPublished");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string City
        {
            get
            {
                return this.CityField;
            }
            set
            {
                if ((object.ReferenceEquals(this.CityField, value) != true))
                {
                    this.CityField = value;
                    this.RaisePropertyChanged("City");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Country
        {
            get
            {
                return this.CountryField;
            }
            set
            {
                if ((object.ReferenceEquals(this.CountryField, value) != true))
                {
                    this.CountryField = value;
                    this.RaisePropertyChanged("Country");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                if ((object.ReferenceEquals(this.IdField, value) != true))
                {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name
        {
            get
            {
                return this.NameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.NameField, value) != true))
                {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string State
        {
            get
            {
                return this.StateField;
            }
            set
            {
                if ((object.ReferenceEquals(this.StateField, value) != true))
                {
                    this.StateField = value;
                    this.RaisePropertyChanged("State");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName="IAuthorService")]
public interface IAuthorService
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthorService/GetAllAuthors", ReplyAction="http://tempuri.org/IAuthorService/GetAllAuthorsResponse")]
    System.Collections.Generic.List<ORM.Domain.Author> GetAllAuthors();
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthorService/GetAuthor", ReplyAction="http://tempuri.org/IAuthorService/GetAuthorResponse")]
    ORM.Domain.Author GetAuthor(string id);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthorService/Save", ReplyAction="http://tempuri.org/IAuthorService/SaveResponse")]
    void Save(ORM.Domain.Author author);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface IAuthorServiceChannel : IAuthorService, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class AuthorServiceClient : System.ServiceModel.ClientBase<IAuthorService>, IAuthorService
{
    
    public AuthorServiceClient()
    {
    }
    
    public AuthorServiceClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public AuthorServiceClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public AuthorServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public AuthorServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public System.Collections.Generic.List<ORM.Domain.Author> GetAllAuthors()
    {
        return base.Channel.GetAllAuthors();
    }
    
    public ORM.Domain.Author GetAuthor(string id)
    {
        return base.Channel.GetAuthor(id);
    }
    
    public void Save(ORM.Domain.Author author)
    {
        base.Channel.Save(author);
    }
}
using ORM.Application;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ORM.Domain;
using System.Collections.Generic;
using ORM.Application.ServiceContracts;
using ORM.Application;
namespace ORM.Application.Test
{
    
    
    /// <summary>
    ///This is a test class for AuthorServiceTest and is intended
    ///to contain all AuthorServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AuthorServiceTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for GetAllAuthors
        ///</summary>
        [TestMethod()]
        public void GetAllAuthorsTest()
        {
            AuthorService target = new AuthorService();
            List<Author> expected = null;
            List<Author> actual;
            actual = target.GetAllAuthors();
            Assert.AreNotEqual(actual.Count,0);
        }

        [TestMethod()]
        public void SaveAuthorTest()
        {
            IAuthorService authorService = new AuthorService();
            Author author = authorService.GetAuthor("172-32-1176");
            Assert.AreNotEqual(author, null,"Author fetched Successfully");

            author.FirstName = "Johns";
            authorService.Save(author);
            Author author1 = authorService.GetAuthor("172-32-1176");
            Assert.AreEqual(author1.FirstName, author.FirstName, "Changes to Author saved and validated"); ;
        }

        [TestMethod()]
        public void AddTitlesTest()
        {
            IAuthorService authorService = new AuthorService();
            //Titles titles=new Titles
        }
    }
}

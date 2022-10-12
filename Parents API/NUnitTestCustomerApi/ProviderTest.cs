using ParentsApi.Models;
using ParentsApi.Provider;
using ParentsApi.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUnitTestCustomerApi
{
    class ProviderTest
    {
        private Mock<IRepository<Parents>> _config;
        private ParentsProvider TokenObj;


        [SetUp]
        public void Setup()
        {
            _config = new Mock<IRepository<Parents>>();
            TokenObj = new ParentsProvider(_config.Object);

        }
        [Test]
        public void getParentAccounts_Called_When_Given_Valid_ParentId()
        {
            _config.Setup(p => p.Get(1)).Returns(new Parents { });

            var result = TokenObj.Get(1);

            Assert.That(result, Is.Not.Null);
        }

        
        [Test]
        public void Get_WhenCalled_ReturnsListOfParentDetails()
        {

            _config.Setup(repo => repo.GetAll()).Returns(new List<Parents> {new Parents()
                {
                    RegId = 1,
                    ParentName = "Mansi",
                    StudentName = "Sumana",
                    StudentRegNum = "SPA003",
                    Address = "Dehradun",
                    Country = "India",
                    State = "Maharastra",
                    City = "Pune",
                    ZipCode = 800001,
                    Email = "mansi@gmail.com",
                    PrimaryContactPerson = "Manu",
                    PrimaryContactNum = 985623582,
                    SecondaryContactPerson = "mansi",
                    SecondaryContactNumber = 865826916,
                    Pwd = "Mansi@123"
                } });

            var result = TokenObj.GetAll();
            Assert.That(result.Count, Is.EqualTo(1));
        }
        [Test]
        public void GetAll_Called_When_Throws_Exception()
        {
            _config.Setup(repo => repo.GetAll()).Returns((new List<Parents> { }));
            Assert.That(() => TokenObj.GetAll(), Throws.ArgumentNullException);
        }
    }
}

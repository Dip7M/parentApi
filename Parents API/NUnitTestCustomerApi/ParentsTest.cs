using ParentsApi.Controllers;
using ParentsApi.Models;
using ParentsApi.Provider;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUnitTestParentsApi
{
    class ParentsTest
    {
        private Mock<IProvider<Parents>> _config;
        private ParentsController _controller;


        [SetUp]
        public void Setup()
        {
            _config = new Mock<IProvider<Parents>>();
            _controller = new ParentsController(_config.Object);

        }
        [Test]
        public void Get_WhenCalled_ReturnsListOfParentsDetails()
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

            var result = _controller.Get();
            Assert.That(result, Is.InstanceOf<OkObjectResult>());

        }

        [Test]
        public void Called_When_Given_Valid_ParentId()
        {
            _config.Setup(p => p.Get(1)).Returns(new Parents { });


            var result = _controller.getParentDetails(1);

            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public void Called_When_Given_ParentId_Notinthelist()
        {
            var result = _controller.getParentDetails(0);

            Assert.That(result, Is.InstanceOf<BadRequestResult>());
        }

        [Test]
        public void returnValidCreateParent_Is_Valid()
        {
            Parents customer = new Parents();
            _config.Setup(p => p.Add(customer)).Returns(true);
            var result = _controller.createParents(customer);
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public void Called_When_CreateParent_Is_NULL()
        {
            
            var result = _controller.createParents(null) as StatusCodeResult;

            Assert.AreEqual(409,result.StatusCode);
        }

    }
}

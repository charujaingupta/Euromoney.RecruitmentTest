﻿using ContentAPI;
using ContentAPI.Entities;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole.Test.Unit
{
    [TestFixture]
    public class UserContentServiceTest
    {
        Mock<IContentRepository<AllContent>> _contentRep;
        Mock<IContentRepository<NegativeWords>> _negContentRep;
        UserContentService _svc;

        [SetUp]
        public void SetupData()
        {
            _contentRep = new Mock<IContentRepository<AllContent>>();
            _negContentRep = new Mock<IContentRepository<NegativeWords>>();
        }

        [Test]
        public void TestGetContentForUser()
        {
            string con = "This is bad content.";
            _contentRep.Setup(x => x.Content).Returns(con);
            _svc = new UserContentService(_contentRep.Object, _negContentRep.Object);
            Assert.AreEqual(_svc.GetContent(), con);

        }

        [Test]
        public void TestNegContentCountForUser()
        {
            string con = "This is bad content.";
            _contentRep.Setup(x => x.Content).Returns(con);
            _negContentRep.Setup(x => x.Content).Returns("bad swine");
            _svc = new UserContentService(_contentRep.Object, _negContentRep.Object);
            Assert.AreEqual(_svc.CountNegativeWords(), 1);

        }

        [TearDown]
        public void ClearData()
        {
            _contentRep = null;
            _negContentRep = null;
            _svc = null;
        }
    }
}

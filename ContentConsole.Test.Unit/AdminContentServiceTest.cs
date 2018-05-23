using ContentAPI;
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
    public class AdminContentServiceTest
    {
        Mock<IContentRepository<AllContent>> _contentRep;
        Mock<IContentRepository<NegativeWords>> _negContentRep;
        AdminContentService _svc;

        [SetUp]
        public void SetupData()
        {
            _contentRep = new Mock<IContentRepository<AllContent>>();
            _negContentRep = new Mock<IContentRepository<NegativeWords>>();
        }

        [Test]
        public void TestGetContentForAdmin()
        {
            string con = "This is bad content.";
            _contentRep.Setup(x => x.Content).Returns(con);
            _svc = new AdminContentService(_contentRep.Object, _negContentRep.Object);
            Assert.AreEqual(_svc.GetContent(), con);

        }

        [Test]
        public void TestNegContentCountForAdmin()
        {
            string con = "This is bad content.";
            _contentRep.Setup(x => x.Content).Returns(con);
            _negContentRep.Setup(x => x.Content).Returns("bad swine");
            _svc = new AdminContentService(_contentRep.Object, _negContentRep.Object);
            Assert.AreEqual(_svc.CountNegativeWords(), 2);

        }

        [Test]
        public void TestFindNegContentForAdmin()
        {
            string con = "This is a horrible bad weather.";
            _contentRep.Setup(x => x.Content).Returns(con);
            _negContentRep.Setup(x => x.Content).Returns("bad horrible");
            _svc = new AdminContentService(_contentRep.Object, _negContentRep.Object);
            var words = _svc.FindNegativeWordsInContent();
            Assert.AreEqual(words[0], "horrible");
            Assert.AreEqual(words[1], "bad");

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

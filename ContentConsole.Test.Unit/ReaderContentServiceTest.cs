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
    public class ReaderContentServiceTest
    {
        Mock<IContentRepository<AllContent>> _contentRep;
        Mock<IContentRepository<NegativeWords>> _negContentRep;
        ReaderContentService _svc;

        [SetUp]
        public void SetupData()
        {
            _contentRep = new Mock<IContentRepository<AllContent>>();
            _negContentRep = new Mock<IContentRepository<NegativeWords>>();
        }

        [Test]
        public void TestGetContentForReader()
        {
            string con = "This is such a horrible bad content.";
            string expected = "This is such a h######e b#d content.";
            string expected2 = "This is such a #### #### content.";
            _negContentRep.Setup(x => x.Content).Returns("horrible bad");
            _contentRep.Setup(x => x.Content).Returns(con);
            _svc = new ReaderContentService(_contentRep.Object, _negContentRep.Object);
            Assert.AreEqual(_svc.GetContent(), expected);

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

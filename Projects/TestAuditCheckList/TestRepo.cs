using AuditCheckList.Models;
using AuditCheckList.Repository;
using AuditCheckList.ServiceProvider;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestAuditCheckList
{
    public class TestRepo
    {
        private List<Questions> _list;

        [SetUp]
        public void setup()
        {

            _list = new List<Questions>()
            {
                new Questions
                {
                    QuestionNo=1,
                    Question="Have all Change requests followed SDLC before PROD move?"
                },
                new Questions
                {
                    QuestionNo=2,
                    Question="Have all Change requests been approved by the application owner?"
                }
            };
        }

        [TestCase("Internal")]
        [TestCase("SOX")]
        public void GetQuestions_ValidData_ReturnsList(string type)
        {
            Mock<IChecklistRepo> mock = new Mock<IChecklistRepo>();
            mock.Setup(p => p.GetQuestions(type)).Returns(_list);
            ChecklistProvider provider = new ChecklistProvider(mock.Object);
            List<Questions> result = provider.QuestionsProvider(type);
            Assert.AreEqual(2, result.Count);
        }

        [TestCase("Internal123")]
        [TestCase("SOX123")]
        public void GetQuestions_InvalidData_ReturnsNoContent(string type)
        {
            
            Mock<IChecklistRepo> repo = new Mock<IChecklistRepo>();
            repo.Setup(p => p.GetQuestions(type)).Returns((List<Questions>)null);
            ChecklistProvider cp = new ChecklistProvider(repo.Object);
            List<Questions> result = cp.QuestionsProvider(type);
            Assert.IsNull(result);
        }

        [TestCase("Internal")]
        [TestCase("SOX")]
        public void GetQuestions_ValidData_ReturnsNoContent(string type)
        {
            Mock<IChecklistRepo> mock = new Mock<IChecklistRepo>();
            mock.Setup(p => p.GetQuestions(type)).Returns((List<Questions>)null);
            ChecklistProvider provider = new ChecklistProvider(mock.Object);
            List<Questions> result = provider.QuestionsProvider(type);
            Assert.IsNull(result);
        }
    }
}
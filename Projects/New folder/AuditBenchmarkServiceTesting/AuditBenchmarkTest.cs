using AuditBenchmarkMicroservice.Controllers;
using AuditBenchmarkMicroservice.Models;
using AuditBenchmarkMicroservice.Repository;
using AuditBenchmarkMicroservice.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace AuditBenchmarkServiceTesting
{
  
    public class Tests
    {
        public List<AuditBenchmark> BenchmarksList = new List<AuditBenchmark>();
        [SetUp]
        public void Setup()
        {
            BenchmarksList = new List<AuditBenchmark>()
            {
               new AuditBenchmark
            {
                AuditType="Internal",
                BenchmarkNoAnswers=3
            },
                new AuditBenchmark
            {
                AuditType="SOX",
                BenchmarkNoAnswers=1
            }
            };
        }
    

    [Test]
    public void ServiceTest()
    {

        Mock<IAuditBenchmarkRepo> mock = new Mock<IAuditBenchmarkRepo>();
        mock.Setup(p => p.GetBenchmarksList()).Returns(BenchmarksList);
        AuditBenchmarkService cp = new AuditBenchmarkService(mock.Object);
        List<AuditBenchmark> result = cp.GetBenchmarksList();
        Assert.AreEqual(BenchmarksList.Count, result.Count);

    }
    [Test]
    public void OkResult_AuditBenchmarkController()
    {
        Mock<IAuditBenchmarkService> mock = new Mock<IAuditBenchmarkService>();
        mock.Setup(p => p.GetBenchmarksList()).Returns(BenchmarksList);
        AuditBenchmarkController cp = new AuditBenchmarkController(mock.Object);
        OkObjectResult result = cp.GetBenchmarksList() as OkObjectResult;
        Assert.AreEqual(200, result.StatusCode);
    }

}
}
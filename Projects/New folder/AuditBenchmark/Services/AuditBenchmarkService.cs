using AuditBenchmarkMicroservice.Models;
using AuditBenchmarkMicroservice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditBenchmarkMicroservice.Services
{
    public class AuditBenchmarkService: IAuditBenchmarkService
    {
        private readonly IAuditBenchmarkRepo _BenchmarkRepo;
        private readonly log4net.ILog _log4net;
        public AuditBenchmarkService(IAuditBenchmarkRepo BenchmarkRepo)
        {
            _log4net = log4net.LogManager.GetLogger(typeof(AuditBenchmarkService));
            _BenchmarkRepo = BenchmarkRepo;
        }

        public List<AuditBenchmark> GetBenchmarksList()
        {

            _log4net.Info("Message:" +nameof(AuditBenchmarkService));
            List<AuditBenchmark> listOfRepository = new List<AuditBenchmark>();
            try
            {
                listOfRepository = _BenchmarkRepo.GetBenchmarksList();
                return listOfRepository;
            }
            catch (Exception e)
            {
                _log4net.Error("Exception here" + e.Message + " " + nameof(AuditBenchmarkService));
                return null;
            }

        }
    }
}

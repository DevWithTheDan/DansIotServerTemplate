using SeededDatabase.Context;
using SeededDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.CalculationDataRepositories
{
    public class CalculationDataRepository : ICalculationDataRepository
    {
        private readonly SeededDatabaseContext _context;

        public CalculationDataRepository(SeededDatabaseContext context)
        {
            _context = context;
        }

        public List<CalculationData> GetCalculations(int referenceId, DateTime from, DateTime to)
        {
            return _context.CalculationData.Where(x => x.ReferenceId.Equals(referenceId) && x.Timestamp >= from && x.Timestamp <= to).ToList();
        }

        public CalculationData? GetLatest()
        {
            return _context.CalculationData.OrderByDescending(x => x.Timestamp).LastOrDefault();
        }

        public void InsertCalculationData(CalculationData data)
        {
            _context.CalculationData.Add(data);
            _context.SaveChanges();
        }
    }
}

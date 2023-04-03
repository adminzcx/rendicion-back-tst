using System;

namespace Prome.Viaticos.Server.Domain.ValueObjects.LunchAggregate
{
    public class FileImported
    {
        public FileImported(string employeeRecord, DateTime? startDate, DateTime? endDate)
        {
            EmployeeRecord = employeeRecord;
            StartDate = startDate;
            EndDate = endDate;
        }


        public string EmployeeRecord { get; private set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }

}
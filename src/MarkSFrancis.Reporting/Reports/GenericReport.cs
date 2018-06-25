using MarkSFrancis.Reporting.Reports.Interfaces;
using System.Collections;

namespace MarkSFrancis.Reporting.Reports
{
    public abstract class GenericReport<TRecord> : IReport
    {
        public abstract string DisplayName { get; }

        IEnumerable IReport.GenerateReport(IReportSettings settings)
        {
            return GenerateReport((GenericReportSettings<TRecord>)settings);
        }

        public abstract IEnumerable GenerateReport(GenericReportSettings<TRecord> settings);
    }
}

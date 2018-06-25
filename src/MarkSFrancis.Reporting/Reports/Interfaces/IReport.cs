using System.Collections;

namespace MarkSFrancis.Reporting.Reports.Interfaces
{
    public interface IReport
    {
        string DisplayName { get; }

        IEnumerable GenerateReport(IReportSettings settings);
    }
}

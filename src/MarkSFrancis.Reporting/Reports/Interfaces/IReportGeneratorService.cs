using MarkSFrancis.Reporting.Exporters.Interfaces;
using System.IO;

namespace MarkSFrancis.Reporting.Reports.Interfaces
{
    public interface IReportGeneratorService
    {
        void ExportReport(Stream exportTo, string reportName, IReportSettings reportSettings, IExporter exporter);
        void ExportReport(Stream exportTo, IReport report, IReportSettings reportSettings, IExporter exporter);

        void AddReport(IReport report);
        bool TryAddReport(IReport report);
    }
}

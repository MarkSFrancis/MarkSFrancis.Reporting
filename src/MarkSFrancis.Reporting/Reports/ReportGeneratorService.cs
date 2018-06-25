using MarkSFrancis.Reporting.Exporters.Interfaces;
using MarkSFrancis.Reporting.Reports.Interfaces;
using System.Collections.Generic;
using System.IO;

namespace MarkSFrancis.Reporting.Reports
{
    public class ReportGeneratorService : IReportGeneratorService
    {
        private static readonly Dictionary<string, IReport> Reports
            = new Dictionary<string, IReport>();

        /// <summary>
        /// Searches through the known reports to find one with a matching name
        /// </summary>
        /// <param name="exportTo"></param>
        /// <param name="reportName"></param>
        /// <param name="reportSettings"></param>
        /// <param name="exporter"></param>
        public void ExportReport(Stream exportTo, string reportName, IReportSettings reportSettings, IExporter exporter)
        {
            var report = Reports[reportName];

            var data = report.GenerateReport(reportSettings);
            exporter.WriteData(exportTo, data, reportSettings.Columns);
        }

        public void ExportReport(Stream exportTo, IReport report, IReportSettings reportSettings, IExporter exporter)
        {
            var data = report.GenerateReport(reportSettings);
            exporter.WriteData(exportTo, data, reportSettings.Columns);
        }

        public void AddReport(IReport report)
        {
            Reports.Add(report.DisplayName, report);
        }

        public bool TryAddReport(IReport report)
        {
            if (Reports.ContainsKey(report.DisplayName))
            {
                return false;
            }

            Reports.Add(report.DisplayName, report);
            return true;
        }
    }
}

using NUnit.Framework;
using MarkSFrancis.Reporting.Exporters.Csv;
using MarkSFrancis.Reporting.Reports;
using MarkSFrancis.Reporting.Tests.Exporters;
using System.IO;

namespace MarkSFrancis.Reporting.Tests.Reports
{
    public class ReportGeneratorServiceTests
    {
        [Test]
        public void RunningAReport_OnFilteredData_DoesNotThrow()
        {
            // Arrange
            var report = new TestCompanyProductsInfoReport(1);

            var settings = new GenericReportSettings<TestExportModel>(true);

            var exporter = new CsvExporter();

            var generator = new ReportGeneratorService();
            generator.AddReport(report);

            // Act
            Assert.DoesNotThrow(() =>
            {
                using (var stream = new MemoryStream())
                {
                    generator.ExportReport(stream, report.DisplayName, settings, exporter);
                }
            });
        }
    }
}

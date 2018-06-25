using MarkSFrancis.Reflection.Extensions;
using NUnit.Framework;
using MarkSFrancis.Reporting.Exporters.Excel;
using MarkSFrancis.Reporting.Reports;
using System.IO;

namespace MarkSFrancis.Reporting.Tests.Exporters.Excel
{
    public class ExcelExporterTests
    {
        [Test]
        public void ExportingAnExcelFile_WithData_ShouldWriteSomething()
        {
            // Arrange
            var exportColumns = typeof(TestExportModel).GetPropertyFieldInfos();
            var reportSettings = new GenericReportSettings<TestExportModel>(true);

            var fakes = TestExportModel.GetFakes();

            // Act
            using (var stream = new MemoryStream())
            {
                var exporter = new ExcelExporter();
                exporter.WriteData(stream, fakes, reportSettings.Columns);

                Assert.AreNotEqual(0, stream.Length);
            }
        }
    }
}

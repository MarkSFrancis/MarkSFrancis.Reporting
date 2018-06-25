using MarkSFrancis.Reflection.Extensions;
using NUnit.Framework;
using MarkSFrancis.Reporting.Exporters.Csv;
using System.IO;

namespace MarkSFrancis.Reporting.Tests.Exporters.Csv
{
    public class CsvExporterTests
    {
        [Test]
        public void ExportingACsvFile_WithData_ShouldWriteSomething()
        {
            // Arrange
            var exportColumns = typeof(TestExportModel).GetPropertyFieldInfos();

            var fakes = TestExportModel.GetFakes();

            // Act
            using (var stream = new MemoryStream())
            {
                var exporter = new CsvExporter();

                exporter.WriteData(stream, fakes, exportColumns);

                Assert.AreNotEqual(0, stream.Length);
            }
        }
    }
}

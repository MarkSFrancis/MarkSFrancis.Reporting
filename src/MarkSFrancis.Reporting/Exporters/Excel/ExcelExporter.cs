using MarkSFrancis;
using MarkSFrancis.Reflection;
using MarkSFrancis.Reflection.Extensions;
using OfficeOpenXml;
using MarkSFrancis.Reporting.Exporters.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MarkSFrancis.Reporting.Exporters.Excel
{
    public class ExcelExporter : IExporter
    {
        private readonly ExcelCellFormatter _formatter;

        public ExcelExporter()
        {
            _formatter = new ExcelCellFormatter();
        }

        private void WriteColumns(ExcelWorksheet sheet, IEnumerable<PropertyFieldInfo> columnsToExport)
        {
            var colIndex = 1;

            foreach (var column in columnsToExport)
            {
                sheet.Column(colIndex).Style.Numberformat.Format =
                    _formatter.GetFormatFor(column.Type);

                sheet.Cells[1, colIndex].Value = column.Member.GetDisplayName();

                ++colIndex;
            }
        }

        public void WriteData(Stream exportTo, IEnumerable data, IEnumerable<PropertyFieldInfo> columns)
        {
            if (exportTo == null)
            {
                throw ErrorFactory.Default.ArgumentNull(nameof(exportTo));
            }
            if (data == null)
            {
                throw ErrorFactory.Default.ArgumentNull(nameof(data));
            }
            if (columns == null)
            {
                throw ErrorFactory.Default.ArgumentNull(nameof(columns));
            }

            IEnumerable<PropertyFieldInfo> columnsList = columns.ToList();

            using (var document = new ExcelPackage(exportTo))
            {
                var worksheet = document.Workbook.Worksheets.Add("Sheet1");

                WriteColumns(worksheet, columnsList);

                var rowIndex = 2;

                foreach (var record in data)
                {
                    var colIndex = 1;
                    foreach (var column in columnsList)
                    {
                        var curCellValue = column.GetValue(record);

                        worksheet.Cells[rowIndex, colIndex].Value = curCellValue;

                        ++colIndex;
                    }

                    ++rowIndex;
                }

                document.Save();
            }
        }
    }
}


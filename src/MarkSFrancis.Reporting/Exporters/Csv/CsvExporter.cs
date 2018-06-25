using CsvHelper;
using MarkSFrancis;
using MarkSFrancis.Reflection;
using MarkSFrancis.Reflection.Extensions;
using MarkSFrancis.Reporting.Exporters.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MarkSFrancis.Reporting.Exporters.Csv
{
    public class CsvExporter : IExporter
    {
        private void WriteColumns(CsvWriter csv, IEnumerable<PropertyFieldInfo> columnsToExport)
        {
            foreach (var curColumn in columnsToExport)
            {
                csv.WriteField(curColumn.Member.GetDisplayName());
            }

            csv.NextRecord();
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

            var streamWriter = new StreamWriter(exportTo);

            using (var csv = new CsvWriter(streamWriter, true))
            {
                WriteColumns(csv, columnsList);

                foreach (var record in data)
                {
                    foreach (PropertyFieldInfo field in columnsList)
                    {
                        var curCellValue = field.GetValue(record);

                        csv.WriteField(curCellValue);
                    }
                    csv.NextRecord();
                }
            }

            streamWriter.Flush();
        }
    }
}

using System;

namespace MarkSFrancis.Reporting.Exporters.Excel
{
    internal class ExcelCellFormatter
    {
        public string GetFormatFor(Type type)
        {
            if (type == typeof(DateTime))
            {
                return "ddd mmm yyyy, hh:mm";
            }
            else if (
                type == typeof(int) || type == typeof(uint) ||
                type == typeof(long) || type == typeof(ulong) ||
                type == typeof(short) || type == typeof(ushort) ||
                type == typeof(sbyte) || type == typeof(byte))
            {
                return "";
            }
            else if (type == typeof(decimal) || type == typeof(double) || type == typeof(float))
            {
                return "";
            }
            else
            {
                return "@";
            }
        }
    }
}

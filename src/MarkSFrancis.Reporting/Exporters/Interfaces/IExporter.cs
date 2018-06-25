using MarkSFrancis.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace MarkSFrancis.Reporting.Exporters.Interfaces
{
    public interface IExporter
    {
        void WriteData(Stream exportTo, IEnumerable data, IEnumerable<PropertyFieldInfo> columns);
    }
}

using MarkSFrancis.Reflection;
using System;
using System.Collections;
using System.Collections.Generic;

namespace MarkSFrancis.Reporting.Reports.Interfaces
{
    public interface IReportSettings
    {
        IEnumerable<PropertyFieldInfo> Columns { get; }

        IEnumerable Filter(IEnumerable items);
    }
}

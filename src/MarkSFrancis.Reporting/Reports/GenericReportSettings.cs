using MarkSFrancis.Reflection;
using MarkSFrancis.Reflection.Extensions;
using MarkSFrancis.Reporting.Reports.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MarkSFrancis.Reporting.Reports
{
    public class GenericReportSettings<TRecord> : IReportSettings
    {
        public GenericReportSettings(bool includeAllPublicProperties)
        {
            if (includeAllPublicProperties)
            {
                Columns = typeof(TRecord).GetPropertyFieldInfos<TRecord>(getFields: false).ToList();
            }
            else
            {
                Columns = new List<PropertyFieldInfo<TRecord, object>>();
            }
        }

        public List<PropertyFieldInfo<TRecord, object>> Columns { get; set; }

        public IEnumerable Filter(IEnumerable items)
        {
            var casted = (IEnumerable<TRecord>)items;

            return Filter(casted);
        }

        public virtual IEnumerable<TRecord> Filter(IEnumerable<TRecord> items)
        {
            return items;
        }

        IEnumerable<PropertyFieldInfo> IReportSettings.Columns => Columns;
    }
}

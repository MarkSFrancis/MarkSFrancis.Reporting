using MarkSFrancis.Reporting.Reports;
using MarkSFrancis.Reporting.Tests.Exporters;
using System.Collections;
using System.Linq;

namespace MarkSFrancis.Reporting.Tests.Reports
{
    public class TestCompanyProductsInfoReport : GenericReport<TestExportModel>
    {
        public int CompanyId { get; }

        public TestCompanyProductsInfoReport(int companyId)
        {
            CompanyId = companyId;
        }

        public override string DisplayName => "Company Products Information";

        public override IEnumerable GenerateReport(GenericReportSettings<TestExportModel> settings)
        {
            var data = TestExportModel.GetFakes().Where(entry => entry.CompanyId == CompanyId);

            return settings.Filter(data);
        }
    }
}

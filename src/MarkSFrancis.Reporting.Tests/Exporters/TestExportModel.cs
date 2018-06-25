using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MarkSFrancis.Reporting.Tests.Exporters
{
    public class TestExportModel
    {
        [DisplayName("Name")]
        public string ProductName { get; set; }

        [DisplayName("Id")]
        public int ProductId { get; set; }

        [Display(Name = "Price (£)")]
        public double ProductPrice { get; set; }

        [DisplayName("Created On")]
        public DateTime CreatedOn { get; set; }

        [DisplayName("Company")]
        public string CompanyName { get; set; }

        [DisplayName("Company Id")]
        public int CompanyId { get; set; }

        public static IEnumerable<TestExportModel> GetFakes()
        {
            yield return new TestExportModel
            {
                ProductName = "Test 1",
                ProductId = 1,
                ProductPrice = 19.99,
                CreatedOn = new DateTime(2000, 1, 1, 0, 0, 0),
                CompanyId = 1,
                CompanyName = "Contoso"
            };

            yield return new TestExportModel
            {
                ProductName = "Second Test",
                ProductId = 2,
                ProductPrice = 299.73,
                CreatedOn = new DateTime(2012, 3, 17, 12, 34, 0),
                CompanyId = 1,
                CompanyName = "Contoso"
            };

            yield return new TestExportModel
            {
                ProductName = null,
                ProductId = 3,
                ProductPrice = 0,
                CreatedOn = new DateTime(2014, 7, 4, 10, 53, 50),
                CompanyId = 2,
                CompanyName = "I Made This Up"
            };
        }
    }
}

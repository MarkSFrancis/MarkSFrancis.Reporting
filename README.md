# MarkSFrancis.Reporting
A configurable reporting tool for .NET to help with generating reports for datasets.
This is built for dependacy injection, and can be used with or without type safety.
It allows you to filter the data you get from your database (including sorting), and choose which columns to export

## Setup

### Data Source Models for the Report
``` cs
// The exporters support both DisplayName and Display attributes for getting column names
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
}
```

### Example Report
```cs
// Inheriting from GenericReport<TRecord> makes it easy to keep type safety in our report.
// All reports must inherit from IReport
public class TestCompanyProductsInfoReport : GenericReport<TestExportModel>
{
    // The CompanyId to filter the results to
    public int CompanyId { get; }

    public TestCompanyProductsInfoReport(int companyId)
    {
        CompanyId = companyId;
    }

    // The display name for this report. This is used when you select the report from the GeneratorReportService
    public override string DisplayName => "Company Products Information";

    // Create the report using the specified settings
    public override IEnumerable GenerateReport(GenericReportSettings<TestExportModel> settings)
    {
        // Get the data from our fake set (though in your case, this could be from a database)
        // Then filter that data by the company ID
        var data = TestExportModel.GetFakes().Where(entry => entry.CompanyId == CompanyId);

        // Return that report's data with any additional filter from the report settings
        return settings.Filter(data);
    }
}
```

### Exporting
```cs
// An example report that exports a specific company's products
var report = new TestCompanyProductsInfoReport(1);

// GenericReportSettings allows you to easily apply a custom filter, and specify which columns
// Initialising this with "true" exports all public properties of TestExportModel as columns
var settings = new GenericReportSettings<TestExportModel>(true);

// Create a new CSV file format exporter
var exporter = new CsvExporter();

// Initialise the report generator service
var generator = new ReportGeneratorService();

// Register our test report into the generator
generator.AddReport(report);

using (var stream = new MemoryStream()) // This is for sample purposes, you can export to any stream you want
{
    // Create and export the report using the specified report, filter settings and format exporter
    generator.ExportReport(stream, report.DisplayName, settings, exporter);
}
```
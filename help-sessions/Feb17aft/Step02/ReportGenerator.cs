namespace YetAnotherSOLIDExample
{
    public class ReportGenerator : IReportGenerator
    {
        public string ReportOutputType { get; set; }
        
        public void GenerateEmployeeReport(IEmployee em)
        {
            if (ReportOutputType.Equals("PDF"))
            {
                // ...
            } else if (ReportOutputType.Equals("DOCX"))
            {
                // ...
            }
            
        }
    }
}
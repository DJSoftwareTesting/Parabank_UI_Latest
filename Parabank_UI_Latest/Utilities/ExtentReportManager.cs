using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parabank_UI_Latest.Utilities
{
    public class ExtentReportManager
    {
        public static ExtentReports extent;
        public static ExtentTest test;
        public static string reportFolder;

        public static void Init()
        {
            string basePath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            reportFolder = Path.Combine(basePath, "TestReports");
            string reportPath = Path.Combine(reportFolder, "ExtentReport.html");
            var reporter = new ExtentSparkReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(reporter);
        }

        public static void Flush()
        {
            extent.Flush();
        }
    }
}

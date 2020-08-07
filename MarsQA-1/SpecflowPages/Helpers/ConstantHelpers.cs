using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsQA_1.Helpers
{
    public class ConstantHelpers
    {
        //Base Url
        public static string Url = "http://localhost:5000";

        //ScreenshotPath
        public static string ScreenshotPath = @"MarsQA-1\TestReports\Screenshots\";

        //ExtentReportsPath
        public static string ReportsPath = @"MarsQA-1\TestReports\Test_files\";

        //ReportXML Path
        public static string ReportXMLPath = @"MarsQA-1\TestReports\Test_files\";

        //File containg Login credentials 

        public static String LoginDataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\SpecflowTests\\Data\\Mars.xlsx");
        public static String CertificationsData = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\SpecflowTests\\Data\\CertificationData.xlsx");
        public static String LanguageData = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\SpecflowTests\\Data\\Data.xlsx");

    }
}


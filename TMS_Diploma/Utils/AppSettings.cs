using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Diploma.Utils
{
    public class AppSettings
    {
        public string BrowserType { get; set; }
        public double TimeOut { get; set; }
        public string BaseUrl { get; set; }
        public string BaseTRUrl { get; set; }
        public string UserNameSauceDemo { get; set; }
        public string PasswordSauceDemo { get; set; }
        public string TRLogin { get; set; }
        public string TRPassword { get; set; }
    }
}

using Newtonsoft.Json;
using System.Reflection;

namespace TMS_Diploma.Utils
{
    internal class Configurator
    {
        public static AppSettings ReadConfiguration()
        {
            var appSettigsPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "appsettings.json");
            var appSettingsText = File.ReadAllText(appSettigsPath);
            return JsonConvert.DeserializeObject<AppSettings>(appSettingsText) ?? throw new FileNotFoundException();
        }
    }
}

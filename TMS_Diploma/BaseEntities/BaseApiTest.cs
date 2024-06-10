using Allure.NUnit;
using Allure.NUnit.Attributes;
using RestSharp;
using TMS_Diploma.Services.API;
using TMS_Diploma.Utils;

namespace TMS_Diploma.BaseEntities
{
    [AllureNUnit]
    public class BaseApiTest
    {
        protected ApiServices ApiServices { get; private set; }
        protected RestClient Client { get; private set; }

        [SetUp]
        [AllureBefore("Setup Client")]
        public void SetupApi()
        {
            ApiServices = new ApiServices();

            Client = ApiServices.SetUpClientWithOptions(Configurator.ReadConfiguration().TRLogin,
                Configurator.ReadConfiguration().TRPassword);
        }

        [TearDown]
        [AllureAfter("Client Dispose")]
        public void TearDownApi()
        {
            Client.Dispose();
        }
    }
}

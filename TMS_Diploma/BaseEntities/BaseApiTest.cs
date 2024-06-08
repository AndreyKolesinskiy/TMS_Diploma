using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_Diploma.Services.API;
using TMS_Diploma.Utils;

namespace TMS_Diploma.BaseEntities
{
    public class BaseApiTest
    {
        protected ApiServices ApiServices { get; private set; }
        protected RestClient Client { get; private set; }
        private RestClientOptions _restOption;

        [SetUp]
        public void SetupApi()
        {
            ApiServices = new ApiServices();

            Client = ApiServices.SetUpClientWithOptions(Configurator.ReadConfiguration().TRLogin,
                Configurator.ReadConfiguration().TRPassword);
        }

        [TearDown]
        public void TearDownApi()
        {
            Client.Dispose();
        }
    }
}

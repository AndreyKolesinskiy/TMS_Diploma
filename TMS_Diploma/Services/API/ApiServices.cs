using RestSharp.Authenticators;
using RestSharp;
using TMS_Diploma.Utils;

namespace TMS_Diploma.Services.API
{
    public class ApiServices
    {
        private RestClient SetUpClient(RestClientOptions options)
        {
            return new RestClient(options);
        }

        public RestResponse CreateGetRequest(string endPoint, RestClient client)
        {
            return client.ExecuteGet(new RestRequest(endPoint));
        }

        public RestResponse CreatePostRequest(string endPoint, RestClient client, string body)
        {
            return client.ExecutePost(new RestRequest(endPoint).AddJsonBody(body));
        }

        public RestResponse CreatePostRequest(string endPoint, RestClient client, string headerValue, string headerName)
        {
            return client.ExecutePost(new RestRequest(endPoint).AddHeader(headerName, headerValue));
        }

        private RestClientOptions CreateOptions(string email, string password)
        {
            return new RestClientOptions(Configurator.ReadConfiguration().BaseTRUrl)
            {
                Authenticator = new HttpBasicAuthenticator(email, password)
            };
        }

        public RestClient SetUpClientWithOptions(string email, string password)
        {
            var options = new RestClientOptions(Configurator.ReadConfiguration().BaseTRUrl)
            {
                Authenticator = new HttpBasicAuthenticator(email, password)
            };
            return SetUpClient(options);
        }
    }
}

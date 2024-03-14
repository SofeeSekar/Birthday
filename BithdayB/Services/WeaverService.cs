using System;
namespace BithdayB.Services
{
    /// <summary>
    /// This is a service class for calling Weaver apis
    /// </summary>
	public class WeaverService:IWeaverService
	{
        /// <summary>
        /// Creating Variable _clinet for accessing the HTTP object
        /// </summary>
       private HttpClient _clinet;
        /// <summary>
        /// Weaver Service Constructor
        /// </summary>
        /// <param name="client"></param>
		public WeaverService(HttpClient client)
		{
             _clinet = client;
       
		}

      
        /// <summary>
        /// This Method is to call Weaver Login 
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public Task<LoginModel> PostLoginService(HttpContent content)
        {
            var response = _clinet.PostAsync("/multi/login_with_password", content).Result;
            var response1 = _clinet.PostAsync("/multi/login_with_password", content).Result.Content.ReadFromJsonAsync<LoginModel>();

            return response1;

        }
    }
}


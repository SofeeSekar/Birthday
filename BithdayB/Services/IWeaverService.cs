using System;
namespace BithdayB.Services
{
    /// <summary>
    /// Interface for Service
    /// </summary>
    public interface IWeaverService

    {
        /// <summary>
        /// Interface method
        /// </summary>
        /// <param name="LoginData"></param>
        /// <returns></returns>
        public Task<LoginModel> PostLoginService(HttpContent LoginData);

    }
}


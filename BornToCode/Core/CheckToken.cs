using System.Configuration;
using BornToCode.Core.Contracts;

namespace BornToCode.Core
{
    public class CheckToken : IAutorize
    {
        public bool TokenIsValid(string token)
        {
            return token == GetValidToken();
        }

        private string GetValidToken()
        {
            return ConfigurationManager.AppSettings["token"];
        }
    }
}
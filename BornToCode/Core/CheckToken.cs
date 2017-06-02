using System.Configuration;
using BornToCode.Core.Contracts;

namespace BornToCode.Core
{
    public class CheckToken : IAutorize
    {
        private string TokenPropName = "token";

        public bool TokenIsValid(string token) => token == GetValidToken();

        private string GetValidToken() => ConfigurationManager.AppSettings[TokenPropName];
    }
}
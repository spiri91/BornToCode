using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using BornToCodeModels;

namespace BornToCode.App_Start
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // New code:
            ODataModelBuilder builder = new ODataConventionModelBuilder().EnableLowerCamelCase();
            config.Filter().Expand().Select().OrderBy().MaxTop(null).Count();
            builder.EntitySet<Article>("articles");
            config.MapODataServiceRoute("ODataRoute", "odata", builder.GetEdmModel());
        }
    }
}
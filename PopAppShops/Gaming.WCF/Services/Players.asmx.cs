using System.Collections.Generic;
using System.Configuration;
using System.Web.Services;

namespace Gaming.WCF.Services
{
    /// <summary>
    /// Summary description for Players
    /// </summary>
    [WebService(Namespace = "https://my-game.azurewebsites.net")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Players : WebService
    {

        [WebMethod]
        public List<string> GetCategory()
        {
            var coreLogic = new Core.CategoryLogic();
            return coreLogic.Categories();
        }


        [WebMethod]
        public string Create(Categories payload)
        {
            return $"{payload.CreatedBy} create a new category named {payload.Name}";
        }

        [WebMethod]
        public string GetConfig()
        {
            return ConfigurationManager.AppSettings.Get("configName");
            
        }
    }

    public class Categories
    {
        public string Name { get; set; }
        public string CreatedBy { get; set; }
    }
}

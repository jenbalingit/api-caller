using OfficeOpenXml;
using OfficeOpenXml.Table;
using PopAppShops.Console.PlayersService;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace PopAppShops.Cons
{
    static class Program
    {
        static void Main(string[] args)
        {


            PlayersSoapClient client = new PlayersSoapClient();


            client.Create(new Categories { Name = "Pure", CreatedBy = "Jen" });

        }



    }

  

}

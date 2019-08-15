

using OfficeOpenXml.Table;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;

namespace PopAppShops.Cons
{
    static class Program
    {
        static void Main(string[] args)
        {


            var @class = new DataUtility();
            var employees = new List<Employee> {
                new Employee {  Id = DateTime.UtcNow.Ticks, DOB = new DateTime(1992,10,29),  Name = "Jen Balingit" },
                new Employee {  Id = DateTime.UtcNow.Ticks, DOB = new DateTime(1992,10,29),  Name = "Jens Balingit" },
                new Employee {  Id = DateTime.UtcNow.Ticks, DOB = new DateTime(1992,10,29),  Name = "Jens Balingit" }
            };

            var convert = employees.Select(s => new
            {
                UID = s.Id,
                AliasName = s.Name
            }).ToList();

            var @stream = @class.Generate(convert.Cast<object>().ToList(), "Employee");

            FileStream file = new FileStream($"c:\\popappsdata\\employee.xlsx", FileMode.Create, FileAccess.Write);
            @stream.WriteTo(file);
            file.Close();
            @stream.Close();
        }




    }

    public class Mail : MailMessage
    {
        public Mail() : base()
        {

        }
    }

    public class Employee
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        
    }

    public class DataUtility
    {

        public MemoryStream Generate(List<object> collections, string worksheetName)
        {
            MemoryStream stream = new MemoryStream();
            using (var package = new OfficeOpenXml.ExcelPackage(stream))
            {

                var mi = collections.FirstOrDefault().GetType()
                    .GetProperties()
                    .Select(pi => (MemberInfo)pi)
                    .ToArray();

                var worksheet = package.Workbook.Worksheets.Add(worksheetName);
                worksheet.Cells.LoadFromCollection(collections, true, TableStyles.Light18, BindingFlags.Public | BindingFlags.Instance, mi);
                worksheet.Cells.AutoFitColumns();

                return new MemoryStream(package.GetAsByteArray());
            }
        }
    }



}

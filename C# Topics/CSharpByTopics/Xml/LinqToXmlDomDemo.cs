using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace CSharpByTopics.Xml
{
    public class LinqToXmlDomDemo
    {
        public void Run()
        {
            //var xmlData =
            //    new XElement("MyRootElement",
            //        new XElement("MyElement",
            //            new XElement("MyValueElement", "Laban"),
            //            new XAttribute("myAttribute", "1234")));

            var xmlData = new XElement("Employees",
                new XElement("Employee",
                    new XElement("FirstName", "Lisa"),
                    new XAttribute("employeeId", "145"),
                    new XElement("LastName", "Svensson"),
                    new XElement("StreetAddress", "Häggtigen 9"),
                    new XAttribute("managerId", "130")),
                new XElement("Employee",
                    new XElement("FirstName", "Dan"),
                    new XAttribute("employeeId", "140"),
                    new XElement("LastName", "Jansson"),
                    new XElement("StreetAddress", "Häggtigen 9"),
                    new XAttribute("managerId", "130")),
                new XElement("Employee",
                    new XElement("FirstName", "Laban"),
                    new XAttribute("employeeId", "141"),
                    new XAttribute("managerId", "130"),
                    new XElement("LastName", "Arnesson"),
                    new XElement("StreetAddress", "Gatan 5")));

            string filePath = @"..\..\..\OutputData\MyXmlData.xml";

            if (File.Exists(filePath))
            {
                File.Delete(filePath);                 
            }
            xmlData.Save(filePath);
        }
    }
}

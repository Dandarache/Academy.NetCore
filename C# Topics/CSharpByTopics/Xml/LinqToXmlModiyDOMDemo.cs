using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace CSharpByTopics.Xml
{
    public class LinqToXmlModiyDOMDemo
    {
        public void Run()
        {
            var newEmployeeElement =
                new XElement("Employee",
                    new XElement("FirstName", "Labana"),
                    new XAttribute("employeeId", "145"),
                    new XElement("LastName", "Karlsson"),
                    new XElement("StreetAddress", "Storgatan 19"),
                    new XAttribute("managerId", "130"));

            string filePath = @"..\..\..\OutputData\MyXmlData2.xml";

            var xmlDataObject = XDocument.Load(filePath);
            xmlDataObject.Element("Employees").Add(newEmployeeElement);

            Console.WriteLine(xmlDataObject);

            xmlDataObject.Save(filePath);
        }
    }
}

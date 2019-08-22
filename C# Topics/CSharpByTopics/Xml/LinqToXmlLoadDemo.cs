using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace CSharpByTopics.Xml
{
    public class LinqToXmlLoadDemo
    {
        public void Run()
        {
            string firstName = "Labana";

            string xmlDataString = $"" +
                $"<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                $"<Employees xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">" +
                $"   <Employee managerId=\"140\" employeeId=\"150\">" +
                $"      <FirstName>Dan &lt; 45</FirstName>" +
                $"      <LastName>Jansson &amp;</LastName>" +
                $"      <Age>47</Age>" +
                $"      <Birthdate>1972-01-11T00:00:00</Birthdate>" +
                $"      <Gender>Male</Gender>" +
                $"   </Employee>" +
                $"   <Employee managerId=\"140\" employeeId=\"130\">" +
                $"      <FirstName>{firstName}</FirstName>" +
                $"      <LastName>Andersson</LastName>" +
                $"      <Age>25</Age>" +
                $"      <Birthdate>1994-02-01T00:00:00</Birthdate>" +
                $"      <Gender>Female</Gender>" +
                $"   </Employee>" +
                $"</Employees>";

            var xmlDataObject = XDocument.Parse(xmlDataString);

            Console.WriteLine(xmlDataObject);


            string filePath = @"..\..\..\OutputData\MyXmlData2.xml";

            xmlDataObject.Save(filePath);
        }
    }
}

using CSharpByTopics.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace CSharpByTopics.Xml
{
    public class SerializationDemo
    {
        public void Run()
        {
            XmlSerializer serializer =
                new XmlSerializer(
                    typeof(List<Employee>), 
                    new XmlRootAttribute("Employees"));

            StringBuilder sb = new StringBuilder();

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = ("\t");
            //settings.OmitXmlDeclaration = true;

            XmlWriter xmlWriter = XmlWriter.Create(sb, settings);

            serializer.Serialize(
                xmlWriter, 
                EmployeeRepository.GetEmployees());

            Console.WriteLine(sb);
        }
    }
}

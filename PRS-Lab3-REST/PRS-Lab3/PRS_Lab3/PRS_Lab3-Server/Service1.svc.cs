using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;

namespace PRS_Lab3_Server
{
    public class Service1 : IService1
    {
        private readonly string xmlFilePath = "D:/TU_Sem_7/PRS/PRS-2024/PRS-Lab3-REST/PRS-Lab3/data.xml";
        public string GetStudents()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);
            return xmlDoc.InnerXml;
        }

        public string AddStudent(string id, string name, int age, int grade)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);

            XmlNode root = xmlDoc.DocumentElement;
            XmlElement studentElement = xmlDoc.CreateElement("student");
            studentElement.SetAttribute("id", id);
            studentElement.SetAttribute("name", name);
            studentElement.SetAttribute("age", age.ToString());
            studentElement.SetAttribute("grade", grade.ToString());
            root.AppendChild(studentElement);

            xmlDoc.Save(xmlFilePath);
            return "Student added successfully";
        }

        public string UpdateStudent(string id, string name, int age, int grade)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);

            XmlNode studentNode = xmlDoc.SelectSingleNode($"/students/student[@id='{id}']");
            if (studentNode != null)
            {
                studentNode.Attributes["name"].Value = name;
                studentNode.Attributes["age"].Value = age.ToString();
                studentNode.Attributes["grade"].Value = grade.ToString();
                xmlDoc.Save(xmlFilePath);
                return "Student updated successfully";
            }
            return "Student not found";
        }

        public string DeleteStudent(string id)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);

            XmlNode studentNode = xmlDoc.SelectSingleNode($"/students/student[@id='{id}']");
            if (studentNode != null)
            {
                studentNode.ParentNode.RemoveChild(studentNode);
                xmlDoc.Save(xmlFilePath);
                return "Student deleted successfully";
            }
            return "Student not found";
        }
    }
}

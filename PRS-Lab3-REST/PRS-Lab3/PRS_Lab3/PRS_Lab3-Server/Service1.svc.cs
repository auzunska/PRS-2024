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
        public string AddIt(int num1, int num2)
        {
            return Convert.ToString(num1 + num2);
        }

        public string getResource()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);
            return xmlDoc.InnerXml;
        }

        public string addResource(string id, string value)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);

            XmlNode root = xmlDoc.DocumentElement;
            XmlElement newElement = xmlDoc.CreateElement("item");
            newElement.SetAttribute("id", id);
            newElement.InnerText = value;
            root.AppendChild(newElement);

            xmlDoc.Save(xmlFilePath);
            return "Resource added successfully";
        }

        public string updateResource(string id, string value, bool isdel = false)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);

            XmlNode node = xmlDoc.SelectSingleNode($"/root/item[@id='{id}']");
            if (node != null)
            {
                if (isdel)
                {
                    node.ParentNode.RemoveChild(node);
                    xmlDoc.Save(xmlFilePath);
                    return "Resource deleted successfully";
                }
                else
                {
                    node.InnerText = value;
                    xmlDoc.Save(xmlFilePath);
                    return "Resource updated successfully";
                }
            }
            return "Resource not found";
        }
    }
}

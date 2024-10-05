using System.Reflection.Emit;
using System.Xml;

namespace PRS_Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nChoose an action:");
                Console.WriteLine("1. Read XML data (currency rates)");
                Console.WriteLine("2. Write XML data (user details)");
                Console.WriteLine("3. Exit");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ReadXMLData();
                        break;
                    case "2":
                        WriteXMLData();
                        break;
                    case "3":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }
        static void ReadXMLData()
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("http://www.ecb.int/stats/eurofxref/eurofxref-daily.xml");

                foreach (XmlNode xmlNode in xmlDoc.DocumentElement.ChildNodes[2].ChildNodes[0].ChildNodes)
                {
                    string currency = xmlNode.Attributes["currency"].Value;
                    string rate = xmlNode.Attributes["rate"].Value;
                    Console.WriteLine($"{currency}: {rate}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading XML data: {ex.Message}");
            }
        }

        static void WriteXMLData()
        {
            try
            {
                Console.Write("Enter user name: ");
                string name = Console.ReadLine();

                Console.Write("Enter user age: ");
                string age = Console.ReadLine();

                XmlDocument xmlDoc = new XmlDocument();
                XmlNode rootNode = xmlDoc.CreateElement("users");
                xmlDoc.AppendChild(rootNode);

                XmlNode userNode = xmlDoc.CreateElement("user");
                XmlAttribute attribute = xmlDoc.CreateAttribute("age");
                attribute.Value = age;
                userNode.Attributes.Append(attribute);
                userNode.InnerText = name;
                rootNode.AppendChild(userNode);

                xmlDoc.Save(@"D:\TU_Sem_7\PRS\PRS-2024\PRS-Lab1\PRS-Lab1\TestXML.xml"); 
                Console.WriteLine("User data saved to XML file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing XML data: {ex.Message}");
            }
        }
    }
}

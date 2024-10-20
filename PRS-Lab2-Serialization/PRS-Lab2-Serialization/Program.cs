using System.Xml.Serialization;

namespace PRS_Lab2_Serialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of people to input: ");
            int personCount = int.Parse(Console.ReadLine());

            Person[] people = new Person[personCount];
            for (int i = 0; i < personCount; i++)
            {
                people[i] = GetPersonInput(i + 1);
            }

            string filePath = "D:/TU_Sem_7/PRS/PRS-2024/PRS-Lab2-Serialization/person-serialized.xml";

            SerializePeople(people, filePath);

            Person[] deserializedPeople = DeserializePeople(filePath);
            foreach (var person in deserializedPeople)
            {
                Console.WriteLine($"Name: {person.Name}, Age: {person.Age}, Company: {person.Company.Name}");
            }
        }

        static Person GetPersonInput(int personNumber)
        {
            Console.WriteLine($"\nEnter details for Person {personNumber}:");

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Enter Company Name: ");
            string companyName = Console.ReadLine();

            return new Person(name, age, new Company(companyName));
        }
        static void SerializePeople(Person[] people, string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Person[]));
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, people);
                Console.WriteLine($"People serialized to {filePath}");
            }
        }

        static Person[] DeserializePeople(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Person[]));
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                Person[] people = (Person[])serializer.Deserialize(fs);
                Console.WriteLine($"People deserialized from {filePath}");
                return people;
            }
        }
    }
}

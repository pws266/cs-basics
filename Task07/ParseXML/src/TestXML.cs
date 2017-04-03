using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace CSharpBasics
{
    [XmlRoot("addressBook", Namespace = "http://calculator")]
    public class AddressBook
    {
        [XmlElement("owner")]
        public Contact Owner;

        [XmlElement("contact", typeof(Contact))]
        //public Contact[] Contacts;
        public List<BaseContact> Contacts;

        [XmlAttribute("action-type")]
        public ActionType Action;

        [XmlElement("data")]
        public Int32 Data { get; set; }
    }

    [XmlIncludeAttribute(typeof(Contact))]
    public abstract class BaseContact
    {
    }

    public class Contact : BaseContact
    {
        public Contact()
        {
        }

        public Contact(string firstName, string lastName, string phoneNumber, string emailAddress)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
        }

        [XmlAttribute("firstName")]
        public string FirstName;

        [XmlAttribute("lastName")]
        public string LastName;

        [XmlElement("phone")]
        public string PhoneNumber;

        [XmlElement("email")]
        public string EmailAddress;

        public void Print()
        {
            Console.WriteLine("Name(FL): {0} {1}\nPhome number: {2}\nE-mail: {3}\n",
                              FirstName, LastName, PhoneNumber, EmailAddress);
        }
    }

    public enum ActionType
    {
        [XmlEnum("Bank-Debit")]
        DEBET,
        [XmlEnum("Elka-Credit")]
        CREDIT,
        [XmlEnum("Weekend-Work")]
        SEX,
        [XmlEnum("Dream-On")]
        DRUGS
    }

    class TestAddressBook
    {
/*
        public static void Main()
        {
            AddressBook ab = new AddressBook();
            ab.Owner = new Contact("Piter", "Wagner", "+7 (903) 650-3934", "pws266@yandex.ru");

            ab.Action = CSharpBasics.ActionType.DEBET;

            ab.Data = 11;

            //ab.Contacts = new Contact[3]
            ab.Contacts = new List<BaseContact>()
            {
                new Contact("Hansi", "Kursch", "+7 (952) 541-9005", "pws266@gmail.com"),
                new Contact("Lemmy", "Kilmister", "+7 (920) 415-9816", "motorhead@metal.uk"),
                new Contact("Doro", "Pesch", "+7 (920) 410-7296", "svetaka@yandex.ru")
            };

            var serializer = new XmlSerializer(typeof(AddressBook));

            var ns = new XmlSerializerNamespaces();
            ns.Add("calc", "http://calculator");

            using (var stream = new StreamWriter(new FileStream("../../../files/Test.xml", FileMode.Create), Encoding.UTF8))
            {
                serializer.Serialize(stream, ab, ns);
                stream.Flush();
            }

            // deserialization
            AddressBook readAB = new AddressBook();
            var reader = new XmlSerializer(typeof(AddressBook));

            using (var stream = new FileStream("../../../files/Test.xml", FileMode.Open))
            {
                readAB = (AddressBook)reader.Deserialize(stream);
            }

            Console.WriteLine("Owner field: ");
            readAB.Owner.Print();

            Console.WriteLine("Action field: " + readAB.Action);

            Console.WriteLine("Data field: {0}\n", readAB.Data);

            Console.WriteLine("List: ");

            foreach (Contact customer in readAB.Contacts)
            {
                customer.Print();
                Console.WriteLine();
            }
        }
 */ 
    }
}

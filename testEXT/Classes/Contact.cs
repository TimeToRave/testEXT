using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace testEXT.Classes
{
    public class Contact
    {
        private int id;
        private string client;
        private string salesman;

        public int Id
        {
            get { return id; }
            set
            {
                if (value >= 0)
                {
                    id = value;
                }
                else
                {
                    throw new InvalidDataException("Идентификатор не должен быть отрицательным");
                }
            }

        }

        public string Client
        {
            get { return client; }
            set
            {
                if (value.Length == 0)
                {
                    throw new InvalidDataException("Длина названия клиента-контактного лица равняется 0");
                }
                if (value.Length > 30)
                {
                    client = value.Substring(0, Math.Min(30, value.Length));
                }
                else
                {
                    client = value;
                }
            }
        }

        public string Salesman
        {
            get { return salesman; }
            set
            {
                if (value.Length == 0)
                {
                    throw new InvalidDataException("Длина названия ответственнного за продажу равняется 0");
                }
                if (value.Length > 30)
                {
                    salesman = value.Substring(0, Math.Min(30, value.Length));
                }
                else
                {
                    salesman = value;
                }
            }
        }

        public Contact()
        {
            Id = 0;
            Client = "Empty";
            Salesman = "Empty";
        }

        public Contact(int id, string client, string salesman)
        {
            Id = id;
            Client = client;
            Salesman = salesman;
        }

        public Contact(string client, string salesman) : this(0, client, salesman)
        {

        }

        public Contact(string contact)
        {
            string[] words = contact.Split(new string[] { "<#>" }, StringSplitOptions.RemoveEmptyEntries);
            if (Int32.TryParse(words[0], out int temp))
            {
                Id = temp;
                temp = 0;
            }
            else
            {
                Id = 0;
            }

            Client = words[1];
            Salesman = words[2];
        }

        public void Print()
        {
            Console.WriteLine(Id.ToString() + " | " + Client + " | " + Salesman);
        }

        public object[] ToObject()
        {
            return new object[] { Id, Client, Salesman };

        }


    }
}
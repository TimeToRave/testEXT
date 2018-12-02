using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace testEXT.Classes
{
    public class Sale
    {
        private int id;
        private string name;
        private int agentId;
        private int contactId;

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

        public string Name
        {
            get { return name; }
            set
            {
                if (value.Length == 0)
                {
                    throw new InvalidDataException("Длина названия города равняется 0");
                }
                if (value.Length > 30)
                {
                    name = value.Substring(0, Math.Min(30, value.Length));
                }
                else
                {
                    name = value;
                }
            }
        }

        public int AgentId
        {
            get { return agentId; }
            set
            {
                if (value >= 0)
                {
                    agentId = value;
                }
                else
                {
                    throw new InvalidDataException("Идентификатор не должен быть отрицательным");
                }
            }

        }

        public int ContactId
        {
            get { return contactId; }
            set
            {
                if (value >= 0)
                {
                    contactId = value;
                }
                else
                {
                    throw new InvalidDataException("Идентификатор не должен быть отрицательным");
                }
            }

        }

        public Sale()
        {
            id = 0;
            Name = "Empty";
            AgentId = 0;
            ContactId = 0;
        }

        public Sale(int id, string name, int agentId, int contactId)
        {
            Id = id;
            Name = name;
            AgentId = agentId;
            ContactId = contactId;
        }

        public Sale(string name, int agentId, int contactId) : this(0, name, agentId, contactId) { }

        public Sale(int id, string name, string agentName, string contactName)
        {
            Id = id;
            Name = name;
            AgentId = Controller.SearchAgentByName(agentName);
            ContactId = Controller.SearchContactByName(contactName);
        }

        public Sale(string sale)
        {
            string[] words = sale.Split(new string[] { "<#>" }, StringSplitOptions.RemoveEmptyEntries);

            if (Int32.TryParse(words[0], out int temp))
            {
                Id = temp;
                temp = 0;
            }
            else
            {
                Id = 0;
            }

            Name = words[1];

            if (Int32.TryParse(words[2], out temp))
            {
                AgentId = temp;
                temp = 0;
            }
            else
            {
                AgentId = 0;
            }

            if (Int32.TryParse(words[3], out temp))
            {
                ContactId = temp;
                temp = 0;
            }
            else
            {
                ContactId = 0;
            }

        }

        public void Print()
        {
            Console.WriteLine(Id.ToString() + " | " + Name + " | " + AgentId.ToString() + " | " + ContactId.ToString());
        }

        public object [] ToObject ()
        {
            return new object[] {Id, Name, AgentId, AgentId, ContactId, ContactId};
        }


    }
}
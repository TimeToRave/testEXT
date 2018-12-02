using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace testEXT.Classes
{
    public class Agent
    {
        private int id;
        private string client;
        private int cityId;

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
                    throw new InvalidDataException("Длина названия клиента равняется 0");
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

        public int CityId
        {
            get { return cityId; }
            set
            {
                if (value >= 0)
                {
                    cityId = value;
                }
                else
                {
                    throw new InvalidDataException("Идентификатор не должен быть отрицательным");
                }
            }

        }

        public Agent()
        {
            Id = 0;
            Client = "Empty";
            CityId = 0;
        }

        public Agent(int id, string client, int cityId)
        {
            Id = id;
            Client = client;
            CityId = cityId;
        }

        public Agent(string client, int cityId) : this(0, client, cityId)
        {
        }

        public Agent(string agent)
        {
            string[] words = agent.Split(new string[] { "<#>" }, StringSplitOptions.RemoveEmptyEntries);
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

            if (Int32.TryParse(words[2], out temp))
            {
                cityId = temp;
                temp = 0;
            }
            else
            {
                cityId = 0;
            }

        }

        public void Print()
        {
            Console.WriteLine(Id.ToString() + " | " + Client + " | " + CityId.ToString());
        }

        public object[] ToObject()
        {
            return new object[] { Id, Client, CityId };

        }

    }

}
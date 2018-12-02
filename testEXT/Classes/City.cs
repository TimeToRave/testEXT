using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace testEXT.Classes
{
    public class City
    {
        private int id;
        private string name;

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

        public City()
        {
            id = 0;
            Name = "Empty";
        }

        public City(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public City(string city)
        {
            string[] words = city.Split(new string[] { "<#>" }, StringSplitOptions.RemoveEmptyEntries);

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

        }

        public void Print()
        {
            Console.WriteLine(Id.ToString() + " | " + Name);
        }

        public object [] ToObject ()
        {
            return new object[] { Id, Name };

        }
    }

}
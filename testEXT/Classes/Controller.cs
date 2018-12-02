using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace testEXT.Classes
{
    public static class Controller
    {
        
        public static City[] GetAllCities()
        {
            String connectionString = @"Data Source=DESKTOP-M37KRRP\SQL2017;Initial Catalog=Sales;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();


            string query = "SELECT * FROM City";
            SqlCommand command;
            SqlDataReader dataReader;

            command = new SqlCommand(query, connection);
            dataReader = command.ExecuteReader();

            string result = "";

            while (dataReader.Read())
            {
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    result += dataReader.GetValue(i).ToString() + "<#>";
                }
                result += "<@>";
            }

            dataReader.Close();
            connection.Close();

            string[] rawCities = result.Split(new string[] { "<@>" }, StringSplitOptions.RemoveEmptyEntries);

            City[] citiesFromDB = new City[rawCities.Length];

            for (int i = 0; i < rawCities.Length; i++)
            {
                citiesFromDB[i] = new City(rawCities[i]);
            }

            return citiesFromDB;

        }

        public static Agent[] GetAllAgents()
        {
            String connectionString = @"Data Source=DESKTOP-M37KRRP\SQL2017;Initial Catalog=Sales;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string query = "SELECT * FROM Agent";
            SqlCommand command;
            SqlDataReader dataReader;

            command = new SqlCommand(query, connection);
            dataReader = command.ExecuteReader();

            string result = "";

            while (dataReader.Read())
            {
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    result += dataReader.GetValue(i).ToString() + "<#>";
                }
                result += "<@>";
            }

            dataReader.Close();
            connection.Close();

            string[] rawAgents = result.Split(new string[] { "<@>" }, StringSplitOptions.RemoveEmptyEntries);

            Agent[] agentsFromDB = new Agent[rawAgents.Length];

            for (int i = 0; i < rawAgents.Length; i++)
            {
                agentsFromDB[i] = new Agent(rawAgents[i]);
            }

            return agentsFromDB;

        }

        public static Contact[] GetAllContacts()
        {
            String connectionString = @"Data Source=DESKTOP-M37KRRP\SQL2017;Initial Catalog=Sales;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string query = "SELECT * FROM Contact";
            SqlCommand command;
            SqlDataReader dataReader;

            command = new SqlCommand(query, connection);
            dataReader = command.ExecuteReader();

            string result = "";

            while (dataReader.Read())
            {
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    result += dataReader.GetValue(i).ToString() + "<#>";
                }
                result += "<@>";
            }

            dataReader.Close();
            connection.Close();

            string[] rawContacts = result.Split(new string[] { "<@>" }, StringSplitOptions.RemoveEmptyEntries);

            Contact[] contactsFromDB = new Contact[rawContacts.Length];

            for (int i = 0; i < rawContacts.Length; i++)
            {
                contactsFromDB[i] = new Contact(rawContacts[i]);
            }

            return contactsFromDB;
        }

        public static Sale[] GetAllSales()
        {
            String connectionString = @"Data Source=DESKTOP-M37KRRP\SQL2017;Initial Catalog=Sales;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string query = "SELECT * FROM Sale";
            SqlCommand command;
            SqlDataReader dataReader;

            command = new SqlCommand(query, connection);
            dataReader = command.ExecuteReader();

            string result = "";

            while (dataReader.Read())
            {
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    result += dataReader.GetValue(i).ToString() + " <#>";
                }
                result += "<@>";
            }

            dataReader.Close();
            connection.Close();

            string[] rawSales = result.Split(new string[] { "<@>" }, StringSplitOptions.RemoveEmptyEntries);

            Sale[] salesFromDB = new Sale[rawSales.Length];

            for (int i = 0; i < rawSales.Length; i++)
            {
                salesFromDB[i] = new Sale(rawSales[i]);
            }

            return salesFromDB;
        }


        public static void CreateCity(City newCity)
        {
            String connectionString = @"Data Source=DESKTOP-M37KRRP\SQL2017;Initial Catalog=Sales;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command;
            string query = "INSERT INTO City VALUES (@cityName)";
            command = new SqlCommand(query, connection);
            command.Parameters.Add("@cityName", SqlDbType.NVarChar).Value = newCity.Name;

            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void CreateAgent(Agent newAgent)
        {
            String connectionString = @"Data Source=DESKTOP-M37KRRP\SQL2017;Initial Catalog=Sales;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command;
            string query = "INSERT INTO Agent VALUES (@agentName, @agentCityId)";
            command = new SqlCommand(query, connection);
            command.Parameters.Add("@agentName", SqlDbType.NVarChar).Value = newAgent.Client;
            command.Parameters.Add("@agentCityId", SqlDbType.Int).Value = newAgent.CityId;

            command.ExecuteNonQuery();
            connection.Close();

        }

        public static void CreateConact(Contact newContact)
        {
            String connectionString = @"Data Source=DESKTOP-M37KRRP\SQL2017;Initial Catalog=Sales;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command;
            string query = "INSERT INTO Contact VALUES (@clientName, @salesmanName)";
            command = new SqlCommand(query, connection);
            command.Parameters.Add("@clientName", SqlDbType.NVarChar).Value = newContact.Client;
            command.Parameters.Add("@salesmanName", SqlDbType.NVarChar).Value = newContact.Salesman;

            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void CreateSale(Sale newSale)
        {
            String connectionString = @"Data Source=DESKTOP-M37KRRP\SQL2017;Initial Catalog=Sales;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command;
            string query = "INSERT INTO Sale VALUES (@saleName, @saleAgentId, @saleContactId)";
            command = new SqlCommand(query, connection);

            command.Parameters.Add("@saleName", SqlDbType.NVarChar).Value = newSale.Name;

            if (newSale.AgentId == 0)
            {
                command.Parameters.Add("@saleAgentId", SqlDbType.Int).Value = System.Data.SqlTypes.SqlInt32.Null;
            }
            else
            {
                command.Parameters.Add("@saleAgentId", SqlDbType.Int).Value = newSale.AgentId;
            }

            if (newSale.ContactId == 0)
            {
                command.Parameters.Add("@saleContactId", SqlDbType.Int).Value = System.Data.SqlTypes.SqlInt32.Null;
            }
            else
            {
                command.Parameters.Add("@saleContactId", SqlDbType.Int).Value = newSale.ContactId;
            }

            command.ExecuteNonQuery();
            connection.Close();

        }

        public static void UpdateCity(City editedCity)
        {
            String connectionString = @"Data Source=DESKTOP-M37KRRP\SQL2017;Initial Catalog=Sales;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command;
            string query = "UPDATE City SET name=@cityName WHERE id=@cityId";
            command = new SqlCommand(query, connection);
            command.Parameters.Add("@cityName", SqlDbType.NVarChar).Value = editedCity.Name;
            command.Parameters.Add("@cityId", SqlDbType.Int).Value = editedCity.Id;

            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void UpdateAgent(Agent editedAgent)
        {
            String connectionString = @"Data Source=DESKTOP-M37KRRP\SQL2017;Initial Catalog=Sales;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command;
            string query = "UPDATE Agent SET client=@agentClient, city_id=@agentCityId WHERE id=@agentId";
            command = new SqlCommand(query, connection);
            command.Parameters.Add("@agentClient", SqlDbType.NVarChar).Value = editedAgent.Client;
            command.Parameters.Add("@agentCityId", SqlDbType.Int).Value = editedAgent.CityId;
            command.Parameters.Add("@agentId", SqlDbType.Int).Value = editedAgent.Id;

            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void UpdateContact(Contact editedContact)
        {
            String connectionString = @"Data Source=DESKTOP-M37KRRP\SQL2017;Initial Catalog=Sales;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command;
            string query = "UPDATE Contact SET client=@contactClient, sales_man=@contactSalesman WHERE id=@contactId";
            command = new SqlCommand(query, connection);
            command.Parameters.Add("@contactClient", SqlDbType.NVarChar).Value = editedContact.Client;
            command.Parameters.Add("@contactSalesman", SqlDbType.NVarChar).Value = editedContact.Salesman;
            command.Parameters.Add("@contactId", SqlDbType.Int).Value = editedContact.Id;

            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void UpdateSale(Sale editedSale)
        {
            String connectionString = @"Data Source=DESKTOP-M37KRRP\SQL2017;Initial Catalog=Sales;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command;
            string query = "UPDATE Sale SET name=@saleName, agent_id=@saleAgentId, contact_id=@saleContactId WHERE id=@saleId";
            command = new SqlCommand(query, connection);

            command.Parameters.Add("@saleName", SqlDbType.NVarChar).Value = editedSale.Name;

            if (editedSale.AgentId == 0)
            {
                command.Parameters.Add("@saleAgentId", SqlDbType.Int).Value = System.Data.SqlTypes.SqlInt32.Null;
            }
            else
            {
                command.Parameters.Add("@saleAgentId", SqlDbType.Int).Value = editedSale.AgentId;
            }

            if (editedSale.ContactId == 0)
            {
                command.Parameters.Add("@saleContactId", SqlDbType.Int).Value = System.Data.SqlTypes.SqlInt32.Null;
            }
            else
            {
                command.Parameters.Add("@saleContactId", SqlDbType.Int).Value = editedSale.ContactId;
            }
            command.Parameters.Add("@saleId", SqlDbType.Int).Value = editedSale.Id;

            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void DeleteCity(int id)
        {
            String connectionString = @"Data Source=DESKTOP-M37KRRP\SQL2017;Initial Catalog=Sales;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command;
            string query = "DELETE FROM City WHERE id=@cityId";
            command = new SqlCommand(query, connection);
            command.Parameters.Add("@cityId", SqlDbType.Int).Value = id;

            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void DeleteAgent(int id)
        {
            String connectionString = @"Data Source=DESKTOP-M37KRRP\SQL2017;Initial Catalog=Sales;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command;
            string query = "DELETE FROM Agent WHERE id=@agentId";
            command = new SqlCommand(query, connection);
            command.Parameters.Add("@agentId", SqlDbType.Int).Value = id;

            command.ExecuteNonQuery();
            connection.Close();

        }

        public static void DeleteContact(int id)
        {
            String connectionString = @"Data Source=DESKTOP-M37KRRP\SQL2017;Initial Catalog=Sales;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command;
            string query = "DELETE FROM Contact WHERE id=@contactId";
            command = new SqlCommand(query, connection);
            command.Parameters.Add("@contactId", SqlDbType.Int).Value = id;

            command.ExecuteNonQuery();
            connection.Close();

        }

        public static void DeleteSale(int id)
        {
            String connectionString = @"Data Source=DESKTOP-M37KRRP\SQL2017;Initial Catalog=Sales;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command;
            string query = "DELETE FROM Sale WHERE id=@saleId";
            command = new SqlCommand(query, connection);
            command.Parameters.Add("@saleId", SqlDbType.Int).Value = id;

            command.ExecuteNonQuery();
            connection.Close();
        }

        public static City SearchCityById(int id)
        {
            String connectionString = @"Data Source=DESKTOP-M37KRRP\SQL2017;Initial Catalog=Sales;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command;
            string query = "SELECT * FROM City WHERE id=@cityId";
            command = new SqlCommand(query, connection);
            command.Parameters.Add("@cityId", SqlDbType.Int).Value = id;

            SqlDataReader dataReader = command.ExecuteReader();

            string result = "";

            while (dataReader.Read())
            {
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    result += dataReader.GetValue(i).ToString() + "<#>";
                }
            }

            dataReader.Close();
            connection.Close();

            if (result.Length == 0)
            {
                return new City();
            }
            else
            {
                return new City(result);
            }

        }

        public static Agent SearchAgentById(int id)
        {
            String connectionString = @"Data Source=DESKTOP-M37KRRP\SQL2017;Initial Catalog=Sales;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command;
            string query = "SELECT * FROM Agent WHERE id=@agentId";
            command = new SqlCommand(query, connection);
            command.Parameters.Add("@agentId", SqlDbType.Int).Value = id;

            SqlDataReader dataReader = command.ExecuteReader();

            string result = "";


            while (dataReader.Read())
            {
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    result += dataReader.GetValue(i).ToString() + "<#>";
                }

            }

            dataReader.Close();
            connection.Close();


            if (result.Length == 0)
            {
                return new Agent();
            }
            else
            {
                return new Agent(result);
            }

        }

        public static Contact SearchContactById(int id)
        {
            String connectionString = @"Data Source=DESKTOP-M37KRRP\SQL2017;Initial Catalog=Sales;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command;
            string query = "SELECT * FROM Contact WHERE id=@contactId";
            command = new SqlCommand(query, connection);
            command.Parameters.Add("@contactId", SqlDbType.Int).Value = id;

            SqlDataReader dataReader = command.ExecuteReader();

            string result = "";


            while (dataReader.Read())
            {
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    result += dataReader.GetValue(i).ToString() + "<#>";
                }

            }

            dataReader.Close();
            connection.Close();


            if (result.Length == 0)
            {
                return new Contact();
            }
            else
            {
                return new Contact(result);
            }

        }


        public static Sale SearchSaleById(int id)
        {
            String connectionString = @"Data Source=DESKTOP-M37KRRP\SQL2017;Initial Catalog=Sales;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command;
            string query = "SELECT * FROM Sale WHERE id=@saleId";
            command = new SqlCommand(query, connection);
            command.Parameters.Add("@saleId", SqlDbType.Int).Value = id;

            SqlDataReader dataReader = command.ExecuteReader();

            string result = "";

            while (dataReader.Read())
            {
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    result += dataReader.GetValue(i).ToString() + "<#>";
                }
            }

            dataReader.Close();
            connection.Close();

            if (result.Length == 0)
            {
                return new Sale();
            }
            else
            {
                return new Sale(result);
            }

        }

        public static object [] GetAllData ()
        {

            String connectionString = @"Data Source=DESKTOP-M37KRRP\SQL2017;Initial Catalog=Sales;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command;
            string query = @"SELECT
                            Sale.id,
                            Sale.name,
                            (SELECT Agent.client FROM Agent where Agent.id = Sale.agent_id),
                            (SELECT City.name FROM City WHERE(SELECT Agent.city_id FROM Agent where Agent.id= Sale.agent_id) = City.id),
                            (SELECT Contact.client FROM Contact where Contact.id = Sale.contact_id),
                            (SELECT Contact.sales_man FROM Contact where Contact.id = Sale.contact_id)
                            FROM Sale";
            command = new SqlCommand(query, connection);
            SqlDataReader dataReader = command.ExecuteReader();

            string result = "";
            int columnCount = 0;
            while (dataReader.Read())
            {
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    result += dataReader.GetValue(i).ToString() + " <#>";
                }
                result += "<@>";
                
            }
            columnCount = dataReader.FieldCount;
            dataReader.Close();
            connection.Close();

            string[] rawSales = result.Split(new string[] { "<@>" }, StringSplitOptions.RemoveEmptyEntries);

            object []salesFromDB = new object[rawSales.Length];

            for (int i = 0; i < rawSales.Length; i++)
            {
                string[] words = rawSales[i].Split(new string[] { "<#>" }, StringSplitOptions.RemoveEmptyEntries);
                salesFromDB[i] = new object[words.Length];
                object[] temp = new object[words.Length];
                for (int j = 0; j < words.Length; j++)
                {

                    temp[j] = words[j];
                }
                salesFromDB[i] = temp;
            }

            return salesFromDB;

        }

        public static int SearchAgentByName (string name)
        {
            String connectionString = @"Data Source=DESKTOP-M37KRRP\SQL2017;Initial Catalog=Sales;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command;
            string query = "SELECT id FROM Agent WHERE client=@agentName";
            command = new SqlCommand(query, connection);
            command.Parameters.Add("@agentName", SqlDbType.NVarChar).Value = name;

            SqlDataReader dataReader = command.ExecuteReader();

            string result = "";

            while (dataReader.Read())
            {
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    result += dataReader.GetValue(i).ToString();
                }
            }

            dataReader.Close();
            connection.Close();

            if (result.Length == 0)
            {
                return 0;
            }
            else
            {
                return int.Parse(result);
            }
        }

        public static int SearchContactByName(string name)
        {
            String connectionString = @"Data Source=DESKTOP-M37KRRP\SQL2017;Initial Catalog=Sales;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command;
            string query = "SELECT id FROM Contact WHERE client=@contactName";
            command = new SqlCommand(query, connection);
            command.Parameters.Add("@contactName", SqlDbType.NVarChar).Value = name;

            SqlDataReader dataReader = command.ExecuteReader();

            string result = "";

            while (dataReader.Read())
            {
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    result += dataReader.GetValue(i).ToString();
                }
            }

            dataReader.Close();
            connection.Close();

            if (result.Length == 0)
            {
                return 0;
            }
            else
            {
                return int.Parse(result);
            }
        }


    }
}
using PantryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PantryInventoryData
{
    public class SqlDBInventoryData

    {
        string connectionString
        = "Data Source = DESKTOP-1RV72GH\\SQLEXPRESS; Initial Catalog = PantryInventory; Integrated Security = True;";

        SqlConnection sqlConnection;

        public SqlDBInventoryData()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public List<Shelves> GetShelves()
        {
            string selectStatement = "SELECT ItemName, ItemType, Quantity FROM Shelves";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            List<Shelves> shelves = new List<Shelves>();

            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                string ItemName = reader["ItemName"].ToString();
                string ItemType = reader["ItemType"].ToString();
                int Quantity = Convert.ToInt16(reader["Quantity"]);

                Shelves readShelves = new Shelves();
                readShelves.ItemName = ItemName;
                readShelves.ItemType = ItemType;
                readShelves.Quantity = (byte)Quantity;

                shelves.Add(readShelves);
            }

            sqlConnection.Close();

            return shelves;
        }

        public int AddItem(string ItemName, string ItemType, int Quantity)
        {
            int success;

            string insertStatement = "INSERT INTO Shelves VALUES (@ItemName, @ItemType, @Quantity)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@ItemName", ItemName);
            insertCommand.Parameters.AddWithValue("@ItemType", ItemType);
            insertCommand.Parameters.AddWithValue("@Quantity", Quantity);
            sqlConnection.Open();

            success = insertCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }

    }
}

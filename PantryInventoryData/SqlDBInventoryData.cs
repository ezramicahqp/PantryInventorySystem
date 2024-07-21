using PantryModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantryInventoryData
{
    public class SqlDBInventoryData

    {
        string connectionString
        //= "Data Source = DESKTOP-1RV72GH\\SQLEXPRESS; Initial Catalog = PantryInventory; Integrated Security = True;";
        = "Server=tcp:104.43.105.247,1433; Database= PantryInventory; User Id=sa; Password=micahQP2002!";

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

      

        public int CheckIfItemExist(string itemName)
        {
            int quantity = 0;

            string selectStatement = "SELECT Quantity FROM Shelves WHERE ItemName = @ItemName";

            using (SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection))
            {
                selectCommand.Parameters.AddWithValue("@ItemName", itemName);

                sqlConnection.Open();

                using (SqlDataReader reader = selectCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        quantity = Convert.ToInt32(reader["Quantity"]);
                    }
                }

                sqlConnection.Close();
            }

            return quantity;
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

        public int UpdateItem(string ItemName, int newQuantity)
        {
            int success;

            string updateStatement = $"UPDATE Shelves SET Quantity = @Quantity WHERE ItemName = @ItemName";
            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);
            sqlConnection.Open();

            updateCommand.Parameters.AddWithValue("@Quantity", newQuantity);
            updateCommand.Parameters.AddWithValue("@ItemName", ItemName);

            success = updateCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }

        public int DeleteItem(int Quantity)
        {
            int success;

            string deleteStatement = $"DELETE FROM Shelves WHERE Quantity = @Quantity";
            SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);
            sqlConnection.Open();

            deleteCommand.Parameters.AddWithValue("@Quantity", Quantity);

            success = deleteCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }

    }
}

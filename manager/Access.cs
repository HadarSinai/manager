using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace manager
{
    public class Access
    {
        public int InsertData(string connectionString)
        {
            string  ProductName,  ProductDescription, ProductImage, ToContinue;
            int CategoryId , ProductPrice;
            

            Console.WriteLine("insert CategoryId");
            CategoryId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("insert ProductName");
            ProductName = Console.ReadLine();
            Console.WriteLine("insert price");
            ProductPrice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("insert ProductDescription");
            ProductDescription = Console.ReadLine();
            Console.WriteLine("insert ProductImage");
            ProductImage = Console.ReadLine();
            
            string query = "insert into Products(  CategoryId,ProductName, ProductPrice, ProductDescription, ProductImage) values  ( @CategoryId, @ProductName, @ProductPrice, @ProductDescription, @ProductImage)";

            using (SqlConnection connections = new SqlConnection(connectionString))
            using (SqlCommand commands = new SqlCommand(query, connections))
            {
                
                commands.Parameters.Add("@CategoryId", SqlDbType.Int).Value = CategoryId;
                commands.Parameters.Add("@ProductName", SqlDbType.VarChar, 10).Value = ProductName;
                commands.Parameters.Add("@ProductPrice", SqlDbType.Int).Value = ProductPrice;
                commands.Parameters.Add("@ProductDescription", SqlDbType.VarChar, 50).Value = ProductDescription;
                commands.Parameters.Add("@ProductImage", SqlDbType.VarChar, 20).Value = ProductImage;
                connections.Open();
                
                
                
                int affected = commands.ExecuteNonQuery();
                
                connections.Close();
                Console.WriteLine(affected);
                Console.WriteLine("do you  want to continue? press y or n");
                ToContinue = Console.ReadLine();
                if (ToContinue.Equals("y")) 
                    InsertData(connectionString);
                return affected;
            }
        }

        public void ReadData(string connectionString)
        {
            string queryString = "select * from Products";
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                try
                {
                    command.Connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\n{0},\n{1},\n{2},\n{3},\n{4},\n{5}",
                            reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                Console.ReadLine();



            }
        }
    }
}

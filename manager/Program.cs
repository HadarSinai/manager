

using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;



namespace manager
{
    public class Program
    {
         
        static void Main()
        {
          Access data = new Access();
            string connectionString = "Data Source=SRV2\\PUPILS;Initial Catalog=InsertProduct;Integrated Security=True";
           
            data.InsertData(connectionString);
           data.ReadData(connectionString);
            
        }
    }
}
using System;
using System.Configuration;
using System.Data.Common;

namespace FaceRecognition
{
    public class DBHelper
    {
        public static void test()
        {
            string provider = ConfigurationManager.AppSettings["provider"];
            string connectionString = ConfigurationManager.AppSettings["connectionString"];

            DbProviderFactory factory = DbProviderFactories.GetFactory(provider);
            using (DbConnection connection = factory.CreateConnection())
            {
                if (connection == null)
                {
                    Console.WriteLine("Connection error");
                    Console.ReadLine();
                }
                connection.ConnectionString = connectionString;
                connection.Open();
                DbCommand command = factory.CreateCommand();

                if (command == null)
                {
                    Console.WriteLine("Command error");
                    Console.ReadLine();
                }

                command.Connection = connection;
                command.CommandText = @"SELECT * FROM[faceDetectionDB].[dbo].[User]";

                using (DbDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        Console.WriteLine($"{dataReader["id"]}");
                        Console.WriteLine($"{dataReader["name"]}");
                    }
                }

                Console.ReadLine();


            }

        }

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace PeopleBase
{
    internal class Arguments : Connection
    {
        string?[] args;
        List<string> listColumnsOfTable = new List<string>();
        List<string> listValuesOfColumns = new List<string>();
        List<string> listValuesOfTable = new List<string>();
        public Arguments(string?[] args)
        {
            this.args = args;
            if (File.Exists(saveDataBase()) == true)
            {
                var createConnect = new SqlCommand(createDataBase(), connect);
                connect.Open();
                Console.WriteLine("Подключение открыто");
                if (connect.State == ConnectionState.Open)
                {
                    Console.WriteLine("Свойства подключения:");
                    Console.WriteLine($"\tСтрока подключения: {connect.ConnectionString}");
                    Console.WriteLine($"\tБаза данных: {connect.Database}");
                    Console.WriteLine($"\tСервер: {connect.DataSource}");
                    Console.WriteLine($"\tВерсия сервера: {connect.ServerVersion}");
                    Console.WriteLine($"\tСостояние: {connect.State}");
                    Console.WriteLine($"\tWorkstationld: {connect.WorkstationId}");
                    Console.WriteLine("Подключение закрыто...");
                    Console.WriteLine("Программа завершила работу.");
                    connect.Close();
                    Console.Read();
                }
            }
            else
            {
                switch (args[0])
                {
                    case "1":
                        // Console.WriteLine(systemPath);
                        connect.Open();
                        var createTableConnect = new SqlCommand(createTable, connect);
                        var reader = createTableConnect.ExecuteReader();
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                Console.WriteLine(reader.GetValue(i));
                            }
                            Console.WriteLine();
                        }
                        if (connect.State == ConnectionState.Open)
                        {
                            connect.Close();
                        }
                        break;
                    case "2":
                        query += $"VALUES ('{args[1]}', '{args[2]}', '{args[3]}')";
                        var queryConnect = new SqlCommand(query, connect);
                        connect.Open();
                        _ = queryConnect.ExecuteReader();
                        if (connect.State == ConnectionState.Open)
                        {
                            connect.Close();
                        }
                        /*
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                Console.WriteLine(reader.GetValue(i));
                            }
                            Console.WriteLine();
                        }
                        
                        */
                        break;
                    case "3":
                        connect.Open();
                        var viewConnect = new SqlCommand(viewTable, connect);
                        reader = viewConnect.ExecuteReader();
                        reader.Read();
                        
                        // listColumnsOfDatabase.Add(reader.GetString(0));

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            listValuesOfTable.Add(reader.GetName(i));

                            listValuesOfTable.Add(reader.GetValue(i).ToString());

                            listColumnsOfTable.Add(reader.GetName(i));

                            Console.WriteLine(reader.GetName(i));

                            listValuesOfColumns.Add(reader.GetValue(i).ToString());

                            Console.WriteLine(reader.GetValue(i));
                        }
                        
                        // Console.WriteLine($"|{listValuesOfTable[0]}|{listValuesOfTable[1]}|{listValuesOfTable[2]}|");
                            
                        // Console.WriteLine(string.Format("|{0,5}|{1,5}|{2,5}|", column));
                        
                        if (connect.State == ConnectionState.Open)
                        {
                            connect.Close();
                        }
                        break;
                    case "4":

                        break;
                    case "5":

                        break;
                    case "6":

                        break;
                    default:
                        break;
                }
            }
        }
    }
}

using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using ConsoleTables;

namespace PeopleBase
{
    internal class Arguments : Connection
    {
        string?[] args;
        List<string> valuesOfColumns = new List<string>();
        List<string> valuesOfRows = new List<string>();
        List<string> output = new List<string>();
        ConsoleTable table = new ConsoleTable();
        Stopwatch watch = new Stopwatch();
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
                        break;
                    case "3":
                        connect.Open();
                        var viewConnect = new SqlCommand(viewTable, connect);
                        
                        reader = viewConnect.ExecuteReader();

                        while (reader.Read())
                        {                            
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                if (valuesOfColumns.Count < 3)
                                {
                                    valuesOfColumns.Add(reader.GetName(i).ToString());
                                }
                                valuesOfRows.Add(reader.GetValue(i).ToString());
                            }
                        }
                        table.AddColumn(valuesOfColumns);
                        for(int i = 0; i < valuesOfRows.Count;i++)
                        {
                            if ((i+1) % 3 == 0)
                            {
                                output.Add(valuesOfRows[i]);
                                table.AddRow(output[0], output[1], output[2]);
                                output.Clear();
                            }
                            else
                            {
                                output.Add(valuesOfRows[i]);
                            }
                        }                        
                        table.Write();
                        Console.WriteLine();

                        if (connect.State == ConnectionState.Open)
                        {
                            connect.Close();
                        }
                        
                        break;
                    case "4":
                        RandomGen randomGen = new RandomGen();
                        query += $"VALUES ('{randomGen.Output()[0]}', '{randomGen.Output()[1]}', '{randomGen.Output()[2]}')";
                        queryConnect = new SqlCommand(query, connect);
                        connect.Open();
                        _ = queryConnect.ExecuteReader();
                        if (connect.State == ConnectionState.Open)
                        {
                            connect.Close();
                        }
                        break;
                    case "5":
                        connect.Open();
                        watch.Start();
                        var checkConnect = new SqlCommand(checkTime, connect);

                        reader = checkConnect.ExecuteReader();

                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                if (valuesOfColumns.Count < 3)
                                {
                                    valuesOfColumns.Add(reader.GetName(i).ToString());
                                }
                                valuesOfRows.Add(reader.GetValue(i).ToString());
                            }
                        }
                        table.AddColumn(valuesOfColumns);
                        for (int i = 0; i < valuesOfRows.Count; i++)
                        {
                            if ((i + 1) % 3 == 0)
                            {
                                output.Add(valuesOfRows[i]);
                                table.AddRow(output[0], output[1], output[2]);
                                output.Clear();
                            }
                            else
                            {
                                output.Add(valuesOfRows[i]);
                            }
                        }
                        table.Write();
                        watch.Stop();
                        Console.WriteLine();
                        Console.WriteLine($"Время выполнения: {watch.ElapsedMilliseconds} мс");

                        if (connect.State == ConnectionState.Open)
                        {
                            connect.Close();
                        }

                        break;
                    case "6":
                        connect.Open();
                        break;
                    case "clear":
                        connect.Open();
                        var clearConnect = new SqlCommand(clearTable, connect);
                        _ = clearConnect.ExecuteReader();
                        if (connect.State == ConnectionState.Open)
                        {
                            connect.Close();
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}

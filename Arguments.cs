﻿using System.Diagnostics;
using System.Data.SqlClient;
using System.Data;
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
            if (File.Exists(saveDataBase()))
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
                        var viewConnect = new SqlCommand(viewFullAgeTable, connect);
                        
                        reader = viewConnect.ExecuteReader();

                        while (reader.Read())
                        {                            
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                if (valuesOfColumns.Count < 3)
                                {
                                    valuesOfColumns.Add(reader.GetName(i).ToString());
                                }
                                valuesOfRows.Add(reader.GetValue(i).ToString() ?? string.Empty);
                            }
                        }
                        table.AddColumn(valuesOfColumns);
                        table.AddColumn("Age".Split('\n'));
               
                        for(int i = 0; i < valuesOfRows.Count;i++)
                        {
                            if ((i+1) % 4 == 0)
                            {
                                output.Add(valuesOfRows[i]);
                                table.AddRow(output[0], output[1].Substring(0, 10), output[2], output[3]);
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
                        watch.Start();
                        BulkDataTable bulkDataTable = new BulkDataTable();
                        DataTable dt = new DataTable();
                        for (int i = 1000000; i > 0; i--)
                        {                            
                            dt = bulkDataTable.Million();
                        }

                        dt = dt.Rows
                                .Cast<DataRow>()
                                .Where(row => !row.ItemArray.All(f => f is DBNull))
                                .CopyToDataTable();

                        SqlBulkCopy objbulk = new SqlBulkCopy(connect);

                        objbulk.DestinationTableName = "PEOPLE";
                        
                        objbulk.ColumnMappings.Add("FULL_NAME", "FULL_NAME");
                        objbulk.ColumnMappings.Add("BIRTH_DATE", "BIRTH_DATE");
                        objbulk.ColumnMappings.Add("GENDER", "GENDER");
                        

                        connect.Open();

                        objbulk.WriteToServer(dt);

                        if (connect.State == ConnectionState.Open)
                        {
                            connect.Close();
                        }

                        watch.Stop();
                        Console.WriteLine();
                        Console.WriteLine($"Время выполнения: {watch.ElapsedMilliseconds} мс");
                        break;
                    case "4.1":
                        watch.Start();
                        bulkDataTable = new BulkDataTable();
                        dt = new DataTable();
                        for (int i = 2000; i > 0; i--)
                        {
                            dt = bulkDataTable.Hundred();
                            if (dt.Select("GENDER = 'M'").Length == 100)
                            {
                                break;
                            }
                        }

                        dt = dt.Rows
                                .Cast<DataRow>()
                                .Where(row => !row.ItemArray.All(f => f is DBNull))
                                .CopyToDataTable();

                        objbulk = new SqlBulkCopy(connect);

                        objbulk.DestinationTableName = "PEOPLE";

                        objbulk.ColumnMappings.Add("FULL_NAME", "FULL_NAME");
                        objbulk.ColumnMappings.Add("BIRTH_DATE", "BIRTH_DATE");
                        objbulk.ColumnMappings.Add("GENDER", "GENDER");


                        connect.Open();

                        objbulk.WriteToServer(dt);

                        if (connect.State == ConnectionState.Open)
                        {
                            connect.Close();
                        }

                        watch.Stop();
                        Console.WriteLine();
                        Console.WriteLine($"Время выполнения: {watch.ElapsedMilliseconds} мс");
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
                                valuesOfRows.Add(reader.GetValue(i).ToString() ?? string.Empty);
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
                    case "view":
                        connect.Open();
                        viewConnect = new SqlCommand(viewAllTable, connect);

                        reader = viewConnect.ExecuteReader();

                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                if (valuesOfColumns.Count < 3)
                                {
                                    valuesOfColumns.Add(reader.GetName(i).ToString());
                                }
                                valuesOfRows.Add(reader.GetValue(i).ToString() ?? string.Empty);
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
                        Console.WriteLine();

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

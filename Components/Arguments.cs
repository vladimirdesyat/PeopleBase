using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using ConsoleTables;

namespace PeopleBase.Components
{
    internal class Arguments : Connection
    {
        private string?[] args;
        private List<string> valuesOfColumns = new();
        private List<string> valuesOfRows = new();
        private List<string> output = new();
        private ConsoleTable table = new();
        private Stopwatch watch = new();
        public Arguments(string?[] args)
        {

            this.args = args;

                switch (args[0])
                {
                    case "1":
                        connect.Open();
                        try
                        {
                            _ = new SqlCommand(createTable, connect).ExecuteReader();
                        }
                        catch
                        {
                            Console.WriteLine("Таблица с таким именем уже находится в базе данных.");
                        }   

                        if (connect.State == ConnectionState.Open)
                        {
                            connect.Close();
                        }
                        break;
                    case "2":
                        query += $"VALUES ('{args[1]}', '{args[2]}', '{args[3]}')";
                        connect.Open();
                        try
                        {
                            _ = new SqlCommand(query, connect).ExecuteReader();
                        }
                        catch
                        {
                            Console.WriteLine("Неверный формат внесения данных.");
                        }

                        if (connect.State == ConnectionState.Open)
                        {
                            connect.Close();
                        }
                        break;
                    case "3":
                        connect.Open();
                        var reader = new SqlCommand(viewFullAgeTable, connect).ExecuteReader();
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
                        if (!valuesOfColumns.Any())
                        {
                            Console.WriteLine("В таблице отсутствуют данные для отображения.");
                        }
                        else
                        {
                            table.AddColumn(valuesOfColumns);
                            table.AddColumn("Age".Split('\n'));

                            for (int i = 0; i < valuesOfRows.Count; i++)
                            {
                                if ((i + 1) % 4 == 0)
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
                        }                        

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
                            dt = bulkDataTable.MillionRows();
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
                            dt = bulkDataTable.HundredRows();
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
                        try
                        {
                            reader = new SqlCommand(checkTime, connect).ExecuteReader();

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
                        }
                        catch 
                        {
                            Console.WriteLine("В таблице отсутствуют данные для отображения.");
                        }
                        Console.WriteLine();
                        Console.WriteLine($"Время выполнения: {watch.ElapsedMilliseconds} мс");

                        if (connect.State == ConnectionState.Open)
                        {
                            connect.Close();
                        }
                        break;
                    case "6":
                        connect.Open();
                        if (connect.State == ConnectionState.Open)
                        {
                            connect.Close();
                        }
                    break;
                    case "clear":
                        connect.Open();
                        _ = new SqlCommand(clearTable, connect).ExecuteReader();
                        
                        if (connect.State == ConnectionState.Open)
                        {
                            connect.Close();
                        }
                        break;
                    case "view":
                        connect.Open();
                        try
                        {
                            reader = new SqlCommand(viewAllTable, connect).ExecuteReader();

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
                        }
                        catch
                        {
                            Console.WriteLine("В таблице отсутствуют данные для отображения.");
                        }

                        if (connect.State == ConnectionState.Open)
                        {
                            connect.Close();
                        }
                        break;
                    case "drop":
                        connect.Open();
                        try
                        {
                            _ = new SqlCommand(drop, connect).ExecuteNonQuery();
                        }
                        catch
                        {
                            Console.WriteLine("Таблица не существует.");
                        }                        
                        connect.Close();
                        break;
                    default:
                        break;
                }
            }
        }
}



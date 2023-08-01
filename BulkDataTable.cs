﻿using System.Data;

namespace PeopleBase
{
    internal class BulkDataTable
    {
        public DataTable tbl = new DataTable();
        public BulkDataTable()
        {
            tbl.TableName = "PEOPLE";
            tbl.Columns.Add(new DataColumn("FULL_NAME", typeof(string)));
            tbl.Columns.Add(new DataColumn("BIRTH_DATE", typeof(string)));
            tbl.Columns.Add(new DataColumn("GENDER", typeof(string)));
        }
        public DataTable Million()
        {
            RandomGen randomGen = new RandomGen();

            DataRow row = tbl.NewRow();
            
            row["FULL_NAME"] = randomGen.Output()[0];
            row["BIRTH_DATE"] = randomGen.Output()[1];
            row["GENDER"] = randomGen.Output()[2];

            tbl.Rows.Add(row);

            return tbl;
        }

        public DataTable Hundred()
        {
            RandomGen randomGen = new RandomGen();

            DataRow row = tbl.NewRow();
                        
            if (!randomGen.Output()[2].Contains('F') && randomGen.Output()[0].Contains('F'))
            {
                row["FULL_NAME"] = randomGen.Output()[0];
                row["BIRTH_DATE"] = randomGen.Output()[1];
                row["GENDER"] = randomGen.Output()[2];               
            }

            tbl.Rows.Add(row);

            return tbl;
        }
    }
}

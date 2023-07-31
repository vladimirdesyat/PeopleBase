using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleBase
{
    internal class BulkDataTable
    {
        public DataTable tbl = new DataTable();
        public BulkDataTable()
        {
            
        }

        public void Start()
        {
            tbl.Columns.Add(new DataColumn("FULL_NAME", typeof(string)));
            tbl.Columns.Add(new DataColumn("BIRTH_DATE", typeof(string)));
            tbl.Columns.Add(new DataColumn("GENDER", typeof(string)));

            RandomGen randomGen = new RandomGen();

            for (int i = 0; i < 10000; i++)
            {
                DataRow row = tbl.NewRow();
                row["FULL_NAME"] = randomGen.Output()[0];
                row["BIRTH_DATE"] = randomGen.Output()[1];
                row["GENDER"] = randomGen.Output()[2];

                tbl.Rows.Add(row);
            }
        }
    }
}

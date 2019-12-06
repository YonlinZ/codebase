using DapperEx;
using Modul.Entity.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var conn = System.Configuration.ConfigurationManager.ConnectionStrings["MySql"].ConnectionString;
            var c = ConnectionFactory.GetConnection(DataBaseType.MYSQL, conn);
            c.Open();
            Console.WriteLine(c.State);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            var conn = System.Configuration.ConfigurationManager.ConnectionStrings["MSSQL"].ConnectionString;
            var c = ConnectionFactory.GetConnection(DataBaseType.MSSQL, conn);
            c.Open();
            Console.WriteLine(c.State);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var conn = System.Configuration.ConfigurationManager.ConnectionStrings["MySql"].ConnectionString;
            var sql = "select * from monitoring_rx_3301_201911";
            //var table = DapperExReader.GetTable(DataBaseType.MYSQL, conn, sql);
            //var table = DapperExReader.GetTable("MySql", sql);
            //var instance = DapperExReader.GetInstance<monitoring_rx>("MySql", sql);
            var instance = DapperExReader.GetInstance("MySql", sql);
            dgv.DataSource = instance;
            Console.WriteLine(instance.Count());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var conn = System.Configuration.ConfigurationManager.ConnectionStrings["MSSQL"].ConnectionString;
            var sql = "select * from monitoring_rx_3301_201911";
            //var table = DapperExReader.GetTable(DataBaseType.MSSQL, conn, sql);
            var table = DapperExReader.GetTable("MSSQL", sql);
            Console.WriteLine(table.Rows.Count);
        }
    }
}
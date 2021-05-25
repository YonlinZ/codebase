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
            var c = ConnectionFactory.GetConnection();
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
            //var instance = DapperExReader.GetInstances<monitoring_rx>("MySql", sql);
            //var instance = DapperExReader.GetInstance("MySql", sql);
            //var instance = DapperExReader.GetInstance<monitoring_rx>(DataBaseType.MYSQL, conn, "0d3925fb-ae82-4c96-8f57-c131239a9564", "monitoring_rx_3301_201912");
            var scalar = DapperUtil.GetScalar<int>(DataBaseType.MYSQL, conn, "select count(*) from monitoring_rx_3301_201911");
            //dgv.DataSource = instance;
            Console.WriteLine(scalar);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var conn = System.Configuration.ConfigurationManager.ConnectionStrings["MSSQL"].ConnectionString;
            var sql = "select * from monitoring_rx_3301_201911";
            //var table = DapperExReader.GetTable(DataBaseType.MSSQL, conn, sql);
            //var table = DapperExReader.GetTable("MSSQL", sql);
            var instance = DapperUtil.GetScalar<string>(DataBaseType.MSSQL, conn, "select top 1 HIN_FACILITY_IDENT,* from monitoring_rx_3301_201911");
            Console.WriteLine(instance);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var trans = new DapperExTrans("MySql");
            try
            {
                trans.BeginTransaction();
                var rows1 = trans.Execute("INSERT INTO t1(name, entered, entered_by) VALUES('name1',now(), 'admin');;");
                var rows2 = trans.Execute("INSERT INTO t2(id, role, entered, entered_by) VALUES(100,'role3',now(), 'admin');");
                trans.CommitTransaction();
            }
            catch (Exception ex)
            {
                trans.RollbackTransaction();
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var conn = @"Data Source = C:\Users\AXB\Desktop\202009.db;Version = 3;";
            var sql = "select * from SysData limit 100";
            var table = DapperUtil.GetTable(DataBaseType.SQLITE, conn, sql);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Dapper;

namespace DapperEx
{
    public class DapperExReader
    {
        /// <summary>
        /// 根据查询字符串获取DataTable
        /// </summary>
        /// <param name="type">数据库类型</param>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="querySql">查询字符串</param>
        /// <returns></returns>
        public static DataTable GetTable(DataBaseType type, string connectionString, string querySql)
        {
            using (var connection = ConnectionFactory.GetConnection(type, connectionString))
            {
                var reader = connection.ExecuteReader(querySql);
                var table = new DataTable();
                table.Load(reader);
                return table;
            }
        }
        /// <summary>
        /// 根据查询字符串获取DataTable
        /// </summary>
        /// <param name="dataBaseName">数据库名</param>
        /// <param name="querySql">查询字符串</param>
        /// <returns></returns>
        public static DataTable GetTable(string dataBaseName, string querySql)
        {
            using (var connection = ConnectionFactory.GetConnection(dataBaseName))
            {
                var reader = connection.ExecuteReader(querySql);
                var table = new DataTable();
                table.Load(reader);
                return table;
            }
        }

        public static IEnumerable<T> GetInstance<T>(DataBaseType type, string connectionString, string querySql)
            where T : new()
        {
            using (var connection = ConnectionFactory.GetConnection(type, connectionString))
            {
                var instance = connection.Query<T>(querySql);
                return instance;
            }
        }

        public static IEnumerable<T> GetInstance<T>(string dataBaseName, string querySql)
            where T : new()
        {
            using (var connection = ConnectionFactory.GetConnection(dataBaseName))
            {
                var instance = connection.Query<T>(querySql);
                return instance;
            }
        }
    }
}

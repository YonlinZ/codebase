using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace DapperEx
{
    public class ConnectionFactory
    {
        public static string DefaulDB { get; set; } = "DefaulDB";
        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <param name="type">数据库类型</param>
        /// <param name="connectionString">连接字符串</param>
        /// <returns></returns>
        public static IDbConnection GetConnection(DataBaseType type, string connectionString)
        {
            try
            {
                switch (type)
                {
                    case DataBaseType.MSSQL:
                        return new SqlConnection(connectionString);
                    case DataBaseType.MYSQL:
                        return new MySqlConnection(connectionString);
                    case DataBaseType.ORACLE:
                        throw new NotImplementedException(type.ToString());
                    case DataBaseType.SQLITE:
                        return new SQLiteConnection(connectionString);
                    default:
                        throw new NotImplementedException(type.ToString());
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <param name="dataBaseName">数据库名,配置文件中的 connectionStrings 节点下的 name 值</param>
        /// <returns></returns>
        public static IDbConnection GetConnection(string dataBaseName = null)
        {
            try
            {
                DataBaseType type = DataBaseType.OTHER;
                var providerName = string.Empty;
                var connectionString = string.Empty;
                if (string.IsNullOrWhiteSpace(dataBaseName))
                {
                    providerName = System.Configuration.ConfigurationManager.ConnectionStrings[DefaulDB]?.ProviderName;
                    connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[DefaulDB]?.ConnectionString;
                }
                else
                {
                    providerName = System.Configuration.ConfigurationManager.ConnectionStrings[dataBaseName]?.ProviderName;
                    connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[dataBaseName]?.ConnectionString;
                }
                if (string.IsNullOrWhiteSpace(providerName))
                {
                    throw new Exception($"连接字符串中 ProviderName 无效");
                }

                switch (providerName.ToUpper())
                {
                    case "SYSTEM.DATA.SQLCLIENT":
                        type = DataBaseType.MSSQL;
                        break;
                    case "MYSQL.DATA.MYSQLCLIENT":
                        type = DataBaseType.MYSQL;
                        break;
                    case "SYSTEM.DATA.ORACLECLIENT":
                        type = DataBaseType.ORACLE;
                        break;
                    case "SYSTEM.DATA.SQLITE":
                        type = DataBaseType.SQLITE;
                        break;
                    default:
                        break;
                }
                return GetConnection(type, connectionString);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
    }
}

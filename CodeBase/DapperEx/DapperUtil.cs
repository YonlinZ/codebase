using Dapper;
using System;
using System.Collections.Generic;
using System.Data;

namespace DapperEx
{
    public static class DapperUtil
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
        /// <param name="DbName">数据库名</param>
        /// <param name="querySql">查询字符串</param>
        /// <returns></returns>
        public static DataTable GetTable(string querySql, string DbName = null)
        {
            using (var connection = ConnectionFactory.GetConnection(DbName))
            {
                var reader = connection.ExecuteReader(querySql);
                var table = new DataTable();
                table.Load(reader);
                return table;
            }
        }
        /// <summary>
        /// 获取可枚举实体类列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <param name="connectionString"></param>
        /// <param name="querySql"></param>
        /// <param name="param"></param>
        /// <param name="buffered"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public static IEnumerable<T> GetInstances<T>(DataBaseType type, string connectionString, string querySql, object param = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
            where T : class, new()
        {
            using (var connection = ConnectionFactory.GetConnection(type, connectionString))
            {
                var instance = connection.Query<T>(querySql, param, buffered: buffered, commandTimeout: commandTimeout, commandType: commandType);
                return instance;
            }
        }
        /// <summary>
        /// 获取可枚举实体类列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="DbName"></param>
        /// <param name="querySql"></param>
        /// <param name="param"></param>
        /// <param name="buffered"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public static IEnumerable<T> GetInstances<T>(string querySql, object param = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null, string DbName = null)
            where T : class, new()
        {
            using (var connection = ConnectionFactory.GetConnection(DbName))
            {
                var instance = connection.Query<T>(querySql, param, buffered: buffered, commandTimeout: commandTimeout, commandType: commandType);
                return instance;
            }
        }
        /// <summary>
        /// 获取可枚举匿名类型列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <param name="connectionString"></param>
        /// <param name="querySql"></param>
        /// <param name="param"></param>
        /// <param name="buffered"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public static IEnumerable<dynamic> GetDynamicInstances(DataBaseType type, string connectionString, string querySql, object param = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            using (var connection = ConnectionFactory.GetConnection(type, connectionString))
            {
                var instance = connection.Query(querySql, param, buffered: buffered, commandTimeout: commandTimeout, commandType: commandType);
                return instance;
            }
        }
        /// <summary>
        /// 获取可枚举匿名类型列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="DbName"></param>
        /// <param name="querySql"></param>
        /// <param name="param"></param>
        /// <param name="buffered"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public static IEnumerable<dynamic> GetDynamicInstances(string querySql, object param = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null, string DbName = null)
        {
            using (var connection = ConnectionFactory.GetConnection(DbName))
            {
                var instance = connection.Query(querySql, param, buffered: buffered, commandTimeout: commandTimeout, commandType: commandType);
                return instance;
            }
        }
        /// <summary>
        /// 根据主键获取实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="primaryKey">主键值</param>
        /// <param name="tableName">表名,可省</param>
        /// <returns></returns>
        public static T GetInstance<T>(DataBaseType dbType, string connectionString, string primaryKey, string tableName = null)
            where T : class, new()
        {
            Type type = typeof(T);
            var propInfos = type.GetProperties();
            foreach (var item in propInfos)
            {
                if (item.IsDefined(typeof(CustomAttribute.CustomAttributePrimaryKeyAttribute), true))
                {
                    using (var connection = ConnectionFactory.GetConnection(dbType, connectionString))
                    {
                        var querySql = $"SELECT * FROM {tableName ?? type.Name} WHERE {item.Name} = @primaryKey";
                        var instance = connection.QuerySingleOrDefault<T>(querySql, new { primaryKey });
                        return instance;
                    }
                }
            }
            return null;
        }
        /// <summary>
        /// 根据主键获取实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="primaryKey">主键值</param>
        /// <param name="tableName">表名,可省</param>
        /// <returns></returns>
        public static T GetInstance<T>(string primaryKey, string tableName = null, string DbName = null)
            where T : class, new()
        {
            Type type = typeof(T);
            var propInfos = type.GetProperties();
            foreach (var item in propInfos)
            {
                if (item.IsDefined(typeof(CustomAttribute.CustomAttributePrimaryKeyAttribute), true))
                {
                    using (var connection = ConnectionFactory.GetConnection(DbName))
                    {
                        var querySql = $"SELECT * FROM {tableName ?? type.Name} WHERE {item.Name} = @primaryKey";
                        var instance = connection.QuerySingleOrDefault<T>(querySql, new { primaryKey });
                        return instance;
                    }
                }
            }
            return null;
        }
        /// <summary>
        /// 获取标量值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetScalar<T>(DataBaseType type, string connectionString, string querySql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            using (var connection = ConnectionFactory.GetConnection(type, connectionString))
            {
                var scalar = connection.ExecuteScalar<T>(querySql, param, commandTimeout: commandTimeout, commandType: commandType);
                return scalar;
            }
        }
        /// <summary>
        /// 获取标量值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetScalar<T>(string querySql, object param = null, int? commandTimeout = null, CommandType? commandType = null, string DbName = null)
        {
            using (var connection = ConnectionFactory.GetConnection(DbName))
            {
                var scalar = connection.ExecuteScalar<T>(querySql, param, commandTimeout: commandTimeout, commandType: commandType);
                return scalar;
            }
        }
        /// <summary>
        /// 执行非查询:增删改存储过程
        /// </summary>
        /// <param name="type"></param>
        /// <param name="connectionString"></param>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public static int Execute(DataBaseType type, string connectionString, string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            using (var connection = ConnectionFactory.GetConnection(type, connectionString))
            {
                return connection.Execute(sql, param, commandTimeout: commandTimeout, commandType: commandType);
            }
        }
        /// <summary>
        /// 执行非查询:增删改存储过程
        /// </summary>
        /// <param name="DbName"></param>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public static int Execute(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null, string DbName = null)
        {
            using (var connection = ConnectionFactory.GetConnection(DbName))
            {
                return connection.Execute(sql, param, commandTimeout: commandTimeout, commandType: commandType);
            }
        }
    }
}

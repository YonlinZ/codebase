using Dapper;
using System;
using System.Data;

namespace DapperEx
{
    public class DapperExTrans
    {
        private IDbConnection conn;
        private IDbTransaction trans;

        public DapperExTrans(string dataBaseName)
        {
            conn = ConnectionFactory.GetConnection(dataBaseName);
        }
        public DapperExTrans(IDbConnection conn)
        {
            this.conn = conn;
        }
        /// <summary>
        /// 根据数据库名开启事务
        /// </summary>
        /// <param name="dataBaseName"></param>
        public void BeginTransaction()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            trans = conn.BeginTransaction();
        }
        /// <summary>
        /// 提交事务
        /// </summary>
        public void CommitTransaction()
        {
            trans.Commit();
            conn.Close();
            conn.Dispose();
        }
        /// <summary>
        /// 回滚事务
        /// </summary>
        public void RollbackTransaction()
        {
            trans?.Rollback();
            if (conn?.State != ConnectionState.Closed)
            {
                conn?.Close();
            }
            conn?.Dispose();
        }

        /// <summary>
        /// 执行具有事务的增删改存储过程
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public int Execute(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            try
            {
                return conn.Execute(sql, param, trans, commandTimeout, commandType);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
    }
}

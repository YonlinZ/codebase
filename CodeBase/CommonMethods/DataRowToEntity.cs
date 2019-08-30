using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Reflection;

namespace CommonMethods
{
    class ConvertToEntity
    {
        /// <summary>
        /// DataRow 转实体类
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="row"> DataRow </param>
        /// <returns></returns>
        public static T DataRowToEntity<T>(DataRow row) where T : class, new()
        {
            var type = typeof(T);
            T instance = Activator.CreateInstance(type) as T;
            foreach (var property in type.GetProperties())
            {
                if (row.Table.Columns.Contains(property.Name) && property.CanWrite)
                {
                    property.SetValue(instance, row[property.Name] == DBNull.Value ? null : row[property.Name], null);
                }
            }
            return instance;
        }
    }
}

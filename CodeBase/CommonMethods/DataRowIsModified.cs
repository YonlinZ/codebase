using System.Data;
using System.Linq;

namespace CommonMethods
{
    public class IsModified
    {
        public static bool DataRowIsModified(DataRow dataRow, string[] ignoreColumns)
        {
            if (dataRow.RowState == DataRowState.Unchanged)
            {
                return false;
            }

            for (int index = 0; index < dataRow.Table.Columns.Count; index++)
            {
                if(ignoreColumns.Contains(dataRow.Table.Columns[index].Caption))
                {
                    continue;
                }
                if(dataRow[index, DataRowVersion.Current].ToString()!= dataRow[index, DataRowVersion.Original].ToString())
                {
                    return true;
                }
            }
            return false;
        }
    }
}

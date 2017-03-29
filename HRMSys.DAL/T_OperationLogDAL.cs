using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRMSys.Model;
using System.Data;
using System.Data.SqlClient;

namespace HRMSys.DAL
{
    public class T_OperationLogDAL
    {
        private T_OperationLog ToModel(DataRow row)
        {
            T_OperationLog model = new T_OperationLog();
            model.Id = (System.Guid)SqlHelper.FromDbValue(row["Id"]);
            model.OperatorId = (System.Guid)SqlHelper.FromDbValue(row["OperatorId"]);
            model.MakeDate = (System.DateTime)SqlHelper.FromDbValue(row["MakeDate"]);
            model.ActionDesc = (string)SqlHelper.FromDbValue(row["ActionDesc"]);
            return model;
        }

        public void Insert(Guid operatorId,string actionDesc)
        {
            SqlHelper.ExecuteNonQuery(@"insert into T_OperationLog(
            Id,OperatorId,MakeDate,ActionDesc)
            values(newid(),@OperatorId,getdate(),@ActionDesc)", new SqlParameter("@OperatorId", operatorId)
                 , new SqlParameter("@ActionDesc", actionDesc));
        }

        public T_OperationLog[] Search(string sql, SqlParameter[] parameters)
        {
            DataTable table = SqlHelper.ExecuteDataTable(sql, parameters);
            T_OperationLog[] logs = new T_OperationLog[table.Rows.Count];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                logs[i] = ToModel(table.Rows[i]);
            }
            return logs;
        }
    }
}

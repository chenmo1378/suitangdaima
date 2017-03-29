using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRMSys.Model;
using System.Data.SqlClient;
using System.Data;

namespace HRMSys.DAL
{
    //asp.net webform。asp.net mvc
    //微软不再培养傻瓜!
    public class IdNameDAL
    {
        public IdName[] GetByCategory(string category)
        {
            DataTable table = SqlHelper.ExecuteDataTable("select Id,Name from T_IdName where Category=@Category",
                new SqlParameter("@Category", category));
            IdName[] items = new IdName[table.Rows.Count];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                IdName idname = new IdName();
                idname.Id = (Guid)row["Id"];
                idname.Name = (string)row["Name"];
                items[i] = idname;
            }
            return items;
        }

        //备课
        //把员工管理的重复的东西提前准备好
        //把部门管理的CRUD准备好。
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace HRMSys.DAL
{
    public class SettingDAL
    {
        public void SetValue(string name, string value)
        {
            int i = SqlHelper.ExecuteNonQuery("Update T_Setting set Value=@Value where Name=@Name",
                new SqlParameter("@Value",value),
                new SqlParameter("@Name", name));
            if (i != 1)//只可能出现在开发、测试阶段
            {
                throw new Exception("影响行数不是1，而是"+i);
            }
        }

        public void SetValue(string name, bool value)
        {
            SetValue(name, value.ToString());
        }

        public void SetValue(string name, int value)
        {
            SetValue(name, value.ToString());
        }

        public string GetValue(string name)
        {
            DataTable table = SqlHelper.ExecuteDataTable("select Value from T_Setting where Name=@Name",
                    new SqlParameter("@Name", name));
            if (table.Rows.Count <= 0)
            {
                throw new Exception(name + "不存在！");
            }
            else if (table.Rows.Count > 1)
            {
                throw new Exception("出现"
                    + table.Rows.Count + "条Name=" + name + "的Settings数据");
            }
            else
            {
                DataRow row = table.Rows[0];
                return (string)row["Value"];
            }
        }

        //todo:重载！
        public bool GetBoolValue(string name)
        {
            return Convert.ToBoolean(GetValue(name));
        }

        public int GetIntValue(string name)
        {
            return Convert.ToInt32(GetValue(name));
        }
    }
}

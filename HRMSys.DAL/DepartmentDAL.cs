using HRMSys.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSys.DAL
{
    public class DepartmentDAL
    {
        public IEnumerable<Department> ListAll()
        {
            List<Department> list = new List<Department>();
            DataTable dt = SqlHelper.ExecuteDataTable("select * from T_Department where IsStopped=0");
            foreach (DataRow row in dt.Rows)
            {
                Department dept = ToModel(row);
                list.Add(dept);
            }
            return list;
        }

        private Department ToModel(DataRow row)
        {
            Department dept = new Department();
            dept.Id = (Guid)SqlHelper.FromDbValue(row["Id"]);
            dept.Name = (string)SqlHelper.FromDbValue(row["Name"]);
            return dept;
        }

        public Department GetById(Guid id)
        {
            DataTable dt = SqlHelper.ExecuteDataTable("select * from T_Department where Id=@Id",
                new SqlParameter("@Id", id));
            if (dt.Rows.Count <= 0)
            {
                return null;
            }
            else
            {
                return ToModel(dt.Rows[0]);
            }
        }

        public void Update(Guid id,string name)
        {
            SqlHelper.ExecuteNonQuery(@"Update T_Department Set Name=@Name where Id=@Id",
                new SqlParameter("@Name",name),new SqlParameter("@Id",id));
        }

        public void Insert(string name)
        {
            SqlHelper.ExecuteNonQuery(@"Insert Into T_Department(Id,Name,IsStopped) values(newid(),@Name,0)",
                new SqlParameter("@Name", name));
        }

        public void DeleteById(Guid id)
        {
            SqlHelper.ExecuteNonQuery(@"Update T_Department Set IsStopped=1 where Id=@Id",
                 new SqlParameter("@Id", id));
        }
    }
}

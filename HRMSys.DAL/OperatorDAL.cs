using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRMSys.Model;
using System.Data.SqlClient;
using System.Data;

namespace HRMSys.DAL
{
    public class OperatorDAL
    {
        public void DeleteById(Guid id)
        {
            //软删除
            SqlHelper.ExecuteNonQuery("Update T_Operator Set IsDeleted=1 where Id=@Id",
                new SqlParameter("@Id",id));
        }

        public Operator[] ListAll()
        {
            DataTable dt = SqlHelper.ExecuteDataTable("select * from T_Operator where IsDeleted=0");
            Operator[] operators = new  Operator[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                operators[i] = ToOperator(dt.Rows[i]);
            }
            return operators;
        }

        public void Insert(Operator op)
        {
            //bit类型，在sql语句中要写0、1
            //在.net中要用bool表示
            SqlHelper.ExecuteNonQuery(@"insert into T_Operator(
                Id,UserName,Password,IsDeleted,RealName,IsLocked) values(newid(),@UserName,@Password,0,@RealName,0)",
                    new SqlParameter("@UserName", op.UserName),
                    new SqlParameter("@Password", op.Password),
                    new SqlParameter("@RealName", op.RealName));
        }

        private Operator ToOperator(DataRow row)
        {
            Operator op = new Operator();
            op.Id = (Guid)row["Id"];
            op.UserName = (string)row["UserName"];
            op.Password = (string)row["Password"];
            op.IsDeleted = (bool)row["IsDeleted"];
            op.RealName = (string)row["RealName"];
            op.IsLocked = (bool)row["IsLocked"];
            return op;
        }

        /// <summary>
        /// 不更新密码
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="realName"></param>
        public void Update(Guid id,string userName, string realName)
        {
            SqlHelper.ExecuteNonQuery("update T_Operator set UserName=@UserName,RealName=@RealName where Id=@Id",
                new SqlParameter("@UserName",userName),
                new SqlParameter("@RealName", realName),
                new SqlParameter("@Id",id));
        }

        /// <summary>
        /// 更新密码
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="realName"></param>
        /// <param name="pwd"></param>
        public void Update(Guid id,string userName, string realName, string pwd)
        {
            SqlHelper.ExecuteNonQuery("update T_Operator set UserName=@UserName,RealName=@RealName,Password=@Password where Id=@Id",
               new SqlParameter("@UserName", userName),
               new SqlParameter("@RealName", realName),
               new SqlParameter("@Password",pwd),
               new SqlParameter("@Id", id));
        }

        public Operator GetById(Guid id)
        {
            DataTable table = SqlHelper.ExecuteDataTable("select * from T_Operator where Id=@Id and IsDeleted=0",
                new SqlParameter("@Id", id));
            if (table.Rows.Count <= 0)
            {
                return null;
            }
            else if (table.Rows.Count > 1)
            {
                throw new Exception("存在Id重复用户！");
            }
            else
            {
                return ToOperator(table.Rows[0]);
            }
        }

        public Operator GetByUserName(string userName)
        {
            DataTable table = SqlHelper.ExecuteDataTable("select * from T_Operator where UserName=@UserName and IsDeleted=0",
                new SqlParameter("@UserName",userName));
            if (table.Rows.Count <= 0)
            {
                return null;
            }
            else if (table.Rows.Count > 1)
            {
                throw new Exception("存在重名用户！");
            }
            else
            {
                return ToOperator(table.Rows[0]);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using HRMSys.Model;
using System.Data;

namespace HRMSys.DAL
{
    public class SalarySheetDAL
    {
        /// <summary>
        /// 判断是否已经生成指定年月、部门的工资单
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="deptId"></param>
        /// <returns></returns>
        public bool IsExists(int year, int month, Guid deptId)
        {
            object obj = SqlHelper.ExecuteScalar(@"select count(*) from T_SalarySheet
            where Year=@Year and Month=@Month and DepartmentId=@DepartmentId",
                     new SqlParameter("@Year", year),
                      new SqlParameter("@Month", month),
                       new SqlParameter("@DepartmentId", deptId));
            return Convert.ToInt32(obj) > 0;
        }

        /// <summary>
        /// 清理已经生成的工资单
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="deptId"></param>
        public void Clear(int year, int month, Guid deptId)
        {
            object obj = SqlHelper.ExecuteScalar(@"select Id from T_SalarySheet
            where Year=@Year and Month=@Month and DepartmentId=@DepartmentId",
                     new SqlParameter("@Year", year),
                      new SqlParameter("@Month", month),
                       new SqlParameter("@DepartmentId", deptId));
            Guid sheetId = (Guid)obj;
            //一般先删明细表再删主表

            //todo：使用事务保证原子性
            SqlHelper.ExecuteNonQuery("delete from T_SalarySheetItem where SheetId=@SheetId",
                new SqlParameter("@SheetId", sheetId));
            SqlHelper.ExecuteNonQuery("delete from T_SalarySheet where Id=@Id",
                new SqlParameter("@Id", sheetId));
        }

        public void Build(int year, int month, Guid deptId)
        {
            //生成表头T_SalarySheet

            //查询部门的所有员工
            //foreach(员工 in 员工们)
            //{针对每个员工都生成一条T_SalarySheetItem}

            //生成的时候是先生成主表，再生成明细表。因为明细表需要主表的Id

            Guid sheetId = Guid.NewGuid();
            SqlHelper.ExecuteNonQuery(@"Insert into T_SalarySheet(Id,Year,Month,DepartmentId)
                    Values(@Id,@Year,@Month,@DepartmentId)",
               new SqlParameter("@Id", sheetId), new SqlParameter("@Year", year),
               new SqlParameter("@Month", month), new SqlParameter("@DepartmentId", deptId));

            Employee[] employees = new EmployeeDAL().ListByDepment(deptId);
            foreach (Employee employee in employees)
            {
                SqlHelper.ExecuteNonQuery(@"Insert into T_SalarySheetItem
                    (Id,SheetId,EmployeeId,Bonus,BaseSalary,Fine,Other)
                values(newid(),@SheetId,@EmployeeId,0,0,0,0)",
                          new SqlParameter("@SheetId",sheetId),
                                new SqlParameter("@EmployeeId", employee.Id));
            }
        }

        public SalarySheetItem[] GetSalarySheetItems(int year, int month, Guid deptId)
        {
            DataTable tableMain  = SqlHelper.ExecuteDataTable(@"select * from T_SalarySheet
            where Year=@Year and Month=@Month and DepartmentId=@DepartmentId",
                    new SqlParameter("@Year", year),
                     new SqlParameter("@Month", month),
                      new SqlParameter("@DepartmentId", deptId));
            //先查询指定年月、部门的工资数据主表Id。再查询子表信息
            //todo:可以使用“子查询”技术来简化
            if (tableMain.Rows.Count == 1)
            {
                Guid sheetId = (Guid)tableMain.Rows[0]["Id"];

                DataTable table = SqlHelper.ExecuteDataTable(@"select * from T_SalarySheetItem where
                    SheetId=@SheetId",
                                     new SqlParameter("@SheetId",sheetId));
                SalarySheetItem[] items = new SalarySheetItem[table.Rows.Count];
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    DataRow row = table.Rows[i];
                    SalarySheetItem item = new SalarySheetItem();
                    item.Id = (Guid)row["Id"];
                    item.BaseSalary = (decimal)row["BaseSalary"];
                    item.Bonus = (decimal)row["Bonus"];
                    item.Fine = (decimal)row["Fine"];
                    item.Other = (decimal)row["Other"];
                    item.EmployeeId = (Guid)row["EmployeeId"];
                    item.SheetId = (Guid)row["SheetId"];

                    items[i] = item;
                }
                return items;
            }
            else if (tableMain.Rows.Count <= 0)
            {
                return new SalarySheetItem[0];
            }
            else
            {
                throw new Exception();
            }            
        }

        public void Update(SalarySheetItem item)
        {
            SqlHelper.ExecuteNonQuery(@"Update T_SalarySheetItem
                Set BaseSalary=@BaseSalary,Bonus=@Bonus,
                Fine=@Fine,Other=@Other where Id=@Id",
                    new SqlParameter("@BaseSalary",item.BaseSalary),
                    new SqlParameter("@Bonus", item.Bonus),
                    new SqlParameter("@Fine", item.Fine),
                    new SqlParameter("@Other", item.Other),
                    new SqlParameter("@Id", item.Id));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using HRMSys.Model;

namespace HRMSys.DAL
{
    public class EmployeeDAL
    {
        public Employee ToModel(DataRow row)
        {
            Employee employee = new Employee();
            employee.Address = (string)row["Address"];
            employee.BaseSalary = (int)row["BaseSalary"];
            employee.BirthDay = (DateTime)row["BirthDay"];
            employee.ContractEndDay = (DateTime)row["ContractEndDay"];
            employee.ContractStartDay = (DateTime)row["ContractStartDay"];
            employee.DepartmentId = (Guid)row["DepartmentId"];
            employee.EducationId = (Guid)row["EducationId"];
            employee.Email = (string)row["Email"];
            employee.EmergencyContact = (string)SqlHelper.FromDbValue(row["EmergencyContact"]);
            employee.GenderId = (Guid)row["GenderId"];
            employee.Id = (Guid)row["Id"];
            employee.IdNum = (string)row["IdNum"];
            employee.InDate = (DateTime)row["InDate"];
            employee.Major = (string)row["Major"];
            employee.MarriageId = (Guid)row["MarriageId"];
            employee.Name = (string)row["Name"];
            employee.Nationality = (string)row["Nationality"];
            employee.NativeAddr = (string)row["NativeAddr"];
            employee.Number = (string)row["Number"];
            employee.PartyStatusId = (Guid)row["PartyStatusId"];
            employee.Position = (string)row["Position"];
            employee.Remarks = (string)SqlHelper.FromDbValue(row["Remarks"]);
            employee.Resume = (string)SqlHelper.FromDbValue(row["Resume"]);
            employee.School = (string)SqlHelper.FromDbValue(row["School"]);
            employee.TelNum = (string)row["TelNum"];
            //todo:如果员工非常多，那么Photo会增加内存占用
            employee.Photo = (byte[])SqlHelper.FromDbValue(row["Photo"]);
            return employee;
        }

        public Employee[] ListAll()
        {
            DataTable table = SqlHelper.ExecuteDataTable("select * from T_Employee");
            Employee[] items = new Employee[table.Rows.Count];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Employee employee = ToModel(table.Rows[i]);
                items[i] = employee;
            }
            return items;
        }

        public Employee GetById(Guid id)
        {
            DataTable table = SqlHelper.ExecuteDataTable("select * from T_Employee where Id=@Id",
                new SqlParameter("@Id",id));
            if (table.Rows.Count <= 0)
            {
                return null;
            }
            else if (table.Rows.Count == 1)
            {
                return ToModel(table.Rows[0]);
            }
            else
            {
                throw new Exception();
            }
        }

        public void Insert(Employee employee)
        {
            SqlHelper.ExecuteNonQuery(@"INSERT INTO [T_Employee]
           ([Id],[Number],[Name],[BirthDay],[InDate],[MarriageId],[PartyStatusId],[Nationality]
           ,[NativeAddr],[EducationId],[Major],[School],[Address],[BaseSalary],[Email]
           ,[IdNum],[TelNum],[EmergencyContact],[DepartmentId],[Position],[ContractStartDay]
           ,[ContractEndDay],[Resume],[Remarks],[IsStopped],[GenderId],Photo)
            VALUES(newid(),@Number,@Name,@BirthDay,@InDate,@MarriageId,@PartyStatusId,@Nationality
           ,@NativeAddr,@EducationId,@Major,@School,@Address,@BaseSalary,@Email
           ,@IdNum,@TelNum,@EmergencyContact,@DepartmentId,@Position,@ContractStartDay
           ,@ContractEndDay,@Resume,@Remarks,0,@GenderId,@Photo)", new SqlParameter("@Number", employee.Number)
                                                         , new SqlParameter("@Name", employee.Name)
                                                         , new SqlParameter("@BirthDay", employee.BirthDay)
                                                         , new SqlParameter("@InDate", employee.InDate)
                                                         , new SqlParameter("@MarriageId", employee.MarriageId)
                                                         , new SqlParameter("@PartyStatusId", employee.PartyStatusId)
                                                         , new SqlParameter("@Nationality", employee.Nationality)
                                                         , new SqlParameter("@NativeAddr", employee.NativeAddr)
                                                         , new SqlParameter("@EducationId", employee.EducationId)
                                                         , new SqlParameter("@Major", SqlHelper.ToDbValue(employee.Major))
                                                         , new SqlParameter("@School", SqlHelper.ToDbValue(employee.School))
                                                         , new SqlParameter("@Address", employee.Address)
                                                         , new SqlParameter("@BaseSalary", employee.BaseSalary)
                                                         , new SqlParameter("@Email", SqlHelper.ToDbValue(employee.Email))
                                                         , new SqlParameter("@IdNum", employee.IdNum)
                                                         , new SqlParameter("@TelNum", employee.TelNum)
                                                         , new SqlParameter("@EmergencyContact", SqlHelper.ToDbValue(employee.EmergencyContact))
                                                         , new SqlParameter("@DepartmentId", employee.DepartmentId)
                                                         , new SqlParameter("@Position", employee.Position)
                                                         , new SqlParameter("@ContractStartDay", employee.ContractStartDay)
                                                         , new SqlParameter("@ContractEndDay", employee.ContractEndDay)
                                                         , new SqlParameter("@Resume", SqlHelper.ToDbValue(employee.Resume))
                                                         , new SqlParameter("@Remarks", SqlHelper.ToDbValue(employee.Remarks))
                                                         , new SqlParameter("@GenderId", employee.GenderId)
                                                         , new SqlParameter("@Photo", SqlHelper.ToDbValue(employee.Photo)));

        }

        public void Update(Employee employee)
        {
            SqlHelper.ExecuteNonQuery(@"Update T_Employee set 
            [Number]=@Number,[Name]=@Name,[BirthDay]=@BirthDay,[InDate]=@InDate,
            [MarriageId]=@MarriageId,[PartyStatusId]=@PartyStatusId,[Nationality]=@Nationality,
            [NativeAddr]=@NativeAddr,[EducationId]=@EducationId,[Major]=@Major,[School]=@School,
            [Address]=@Address,[BaseSalary]=@BaseSalary,[Email]=@Email,
            [IdNum]=@IdNum,[TelNum]=@TelNum,[EmergencyContact]=@EmergencyContact,
            [DepartmentId]=@DepartmentId,[Position]=@Position,[ContractStartDay]=@ContractStartDay,
            [ContractEndDay]=@ContractEndDay,[Resume]=@Resume,[Remarks]=@Remarks,[GenderId]=@GenderId
            ,Photo=@Photo
            Where Id=@Id", new SqlParameter("@Number", employee.Number)
                                                         , new SqlParameter("@Name", employee.Name)
                                                         , new SqlParameter("@BirthDay", employee.BirthDay)
                                                         , new SqlParameter("@InDate", employee.InDate)
                                                         , new SqlParameter("@MarriageId", employee.MarriageId)
                                                         , new SqlParameter("@PartyStatusId", employee.PartyStatusId)
                                                         , new SqlParameter("@Nationality", employee.Nationality)
                                                         , new SqlParameter("@NativeAddr", employee.NativeAddr)
                                                         , new SqlParameter("@EducationId", employee.EducationId)
                                                         , new SqlParameter("@Major", SqlHelper.ToDbValue(employee.Major))
                                                         , new SqlParameter("@School", SqlHelper.ToDbValue(employee.School))
                                                         , new SqlParameter("@Address", employee.Address)
                                                         , new SqlParameter("@BaseSalary", employee.BaseSalary)
                                                         , new SqlParameter("@Email", SqlHelper.ToDbValue(employee.Email))
                                                         , new SqlParameter("@IdNum", employee.IdNum)
                                                         , new SqlParameter("@TelNum", employee.TelNum)
                                                         , new SqlParameter("@EmergencyContact", SqlHelper.ToDbValue(employee.EmergencyContact))
                                                         , new SqlParameter("@DepartmentId", employee.DepartmentId)
                                                         , new SqlParameter("@Position", employee.Position)
                                                         , new SqlParameter("@ContractStartDay", employee.ContractStartDay)
                                                         , new SqlParameter("@ContractEndDay", employee.ContractEndDay)
                                                         , new SqlParameter("@Resume", SqlHelper.ToDbValue(employee.Resume))
                                                         , new SqlParameter("@Remarks", SqlHelper.ToDbValue(employee.Remarks))
                                                         , new SqlParameter("@GenderId", employee.GenderId)
                                                         , new SqlParameter("@Photo", SqlHelper.ToDbValue(employee.Photo))
                                                         , new SqlParameter("@Id", employee.Id));
        }

        public Employee[] Search(string sql, List<SqlParameter> parameters)
        {
           DataTable table = 
               SqlHelper.ExecuteDataTable(sql, parameters.ToArray());
           return ToEmployees(table);
        }

        private Employee[] ToEmployees(DataTable table)
        {
            Employee[] items = new Employee[table.Rows.Count];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                items[i] = ToModel(table.Rows[i]);
            }
            return items;
        }

        //搜索三天之内过生日的员工
        public Employee[] Search3DaysBirthDay()
        {
            string sql = @"select * from T_Employee
where DATEDIFF(day,GetDate(),Convert(varchar(5),DatePart(yyyy,GetDate()))+
		'-'+Convert(varchar(5),DATEPART(mm,BirthDay))
		+'-'+Convert(varchar(5),DATEPART(dd,BirthDay))) between 0 and 3";
            DataTable table = SqlHelper.ExecuteDataTable(sql);
            return ToEmployees(table);
        }

        /// <summary>
        /// 查询部门下所有的员工
        /// </summary>
        /// <param name="deptId"></param>
        /// <returns></returns>
        public Employee[] ListByDepment(Guid deptId)
        {
            DataTable table =
                SqlHelper.ExecuteDataTable(@"select * from T_Employee
                where DepartmentId=@DepartmentId",
                      new SqlParameter("@DepartmentId", deptId));
            return ToEmployees(table);
        }
    }
}

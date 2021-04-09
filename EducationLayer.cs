using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Example
{
    class EducationLayer : IEducationLayer<Student, int>
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-JUG08PP;initial Catalog=Dapper_Example;Integrated Security=True;");
        public bool Delete(Student item)
        {
            try
            {
                sqlOpen();
                sqlCon.Query<Student>(@"DELETE FROM [dbo].[Student] WHERE Id=@Id",item);
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception("Delete Student exception" + ex.Message.ToString());
            }
            finally
            {
                sqlClose();
            }
        }

        

        public List<Student>GetAll()
        {
            try
            {
                sqlOpen();

                List<Student> list = sqlCon.Query<Student>("SELECT * FROM [dbo].[Student]").ToList();

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("GetAll exception" + ex.Message.ToString()); 
            }
            finally
            {
                sqlClose();
            }
        }

        public bool Save(Student item)
        {
            try
            {
                sqlOpen();

                sqlCon.Query<Student>(@"INSERT INTO [dbo].[Student] ([Name],[Surname],[Address]) VALUES (@Name,@Surname,@Address)", item);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Save exception" + ex.Message.ToString());
            }
            finally
            {
                sqlClose();
            }
        }

        public bool Update(Student item)
        {
            try
            {
                sqlOpen();

                sqlCon.Query<Student>(@"UPDATE [dbo].[Student] SET [Name]=@Name ,
                    [Surname]=@Surname,
                    [Address]=@Address",item);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Update exception" + ex.Message.ToString());
            }
            finally
            {
                sqlClose();
            }
        }

        #region ConnectionOpenClose
        public void sqlOpen()
        {
            if (sqlCon.State == System.Data.ConnectionState.Closed)
            {
                sqlCon.Open();
            }
        }
        public void sqlClose()
        {
            if (sqlCon.State == System.Data.ConnectionState.Open)
            {
                sqlCon.Close();
            }
        } 
        #endregion
    }
}

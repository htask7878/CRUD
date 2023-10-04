using System.Data;
using System.Data.SqlClient;

namespace CRUD.Models
{
    public class crud_model
    {
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Database=CRUD;User Id=sa;pwd=cdmi123");

        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public int insert_data(string name,string email,string password)
        {
            SqlCommand cmd = new SqlCommand("insert into [dbo].[user](name,email,password)values('" + name + "','" + email + "','" + password + "')", con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }

        public DataSet get_data()
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[user]",con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;  
        }

        public int delete_data(int id)
        {
            SqlCommand cmd = new SqlCommand("delete from [dbo].[user] where id='" + id + "'", con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }

        public DataSet select_update_data(int id)
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[user] where id='"+id+"'",con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public int update_data(string name,string email,string password,int id)
        {
            SqlCommand cmd = new SqlCommand("update [dbo].[user] set name='" + name + "',email='" + email + "',password='" + password + "' where id='" + id + "'", con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }
    }
}

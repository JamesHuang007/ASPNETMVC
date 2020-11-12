using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class GuestbooksDBService
    {
        private readonly static string cnstr = ConfigurationManager.ConnectionStrings["ASP.NET MVC"].ConnectionString;
        private readonly SqlConnection conn = new SqlConnection(cnstr);
    }
    public List<Guestbooks> GetDataList()
    {
        List<Guestbooks> DataList = new List<Guestbooks>();
        string sql = @" SELECT * FROM Guestbooks; ";
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Guestbooks Data = new Guestbooks();
                Data.Id = Convert.ToInt32(dr["Id"]);
                Data.Name = dr["Name"].ToString();
                Data.Content = dr["Content"].ToString();
                Data.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
                    if (!dr["RelpyTime"].Equals(DBNull.Value))
                    {
                        Data.Reply = dr["Reply"].ToString();
                        Data.ReplyTime = Convert.ToDateTime(dr["ReplyTime"]);
                    }
            DataList.Add(Data);
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message.ToString());
        }
        finally
        {
            conn.Close();
        }
    return DataList;
    }


}

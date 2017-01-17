using Ignition.Repo.Dto;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Ignition.Repo.Dao
{
    public class UserDao
    {
        //private String connString2 = ConfigurationManager.AppSettings.Get

        public UserDao() { }

        public UserDto isUser(string username, string password) 
        {
            var connString = ConfigurationManager.ConnectionStrings[0].ConnectionString;

            UserDto matchingUser = new UserDto();
            using (SqlConnection myConnection = new SqlConnection(connString))
            {
                string oString = "Select * from Userss where Username=@un and Password=@pw";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                oCmd.Parameters.AddWithValue("@un", username);
                oCmd.Parameters.AddWithValue("@pw", password);
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        int idd;
                        int.TryParse(oReader["Id"].ToString(), out idd);
                        matchingUser.Id = idd;
                        matchingUser.Username = oReader["Username"].ToString();
                        matchingUser.Password = oReader["Password"].ToString();
                        int.TryParse(oReader["Role"].ToString(), out idd);
                        matchingUser.Role = idd;
                    }

                    myConnection.Close();
                }
            }

            return matchingUser;
        }
    }
}

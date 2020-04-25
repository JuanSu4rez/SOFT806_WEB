using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Configuration;
using System.Data;

/**
 * Author: Sebastian Suarez
 * Date: 18/04/2020
 * Class responsible of interact with the database methods
 **/
namespace Assignment1_WEB {
    public class DBController {

        static string connectionString = ConfigurationManager.ConnectionStrings["connectionDB"].ConnectionString;
        public static User validateLogIn(string eMail, string password) {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString)) {
                sqlConnection.Open();
                string securedPassword = Security.getHash(eMail, password);
                string myQuery = "SELECT varUserName FROM tbleUsers WHERE eMail = '" + eMail + "' AND password = '" + securedPassword + "'";
                SqlCommand sqlCommand = new SqlCommand(myQuery, sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read()) {
                    User logedUser;                   
                    string userName = sqlDataReader.GetString(0);
                    logedUser = new User(userName);
                    return logedUser;
                }
                return null;
            }
        }
        public static bool registerNewUser(string name, string eMail, string password) {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString)) {
                sqlConnection.Open();
                string myQuery = " SELECT COUNT(*) FROM tbleUsers WHERE eMail = '" + eMail + "'";
                SqlCommand sqlCommand = new SqlCommand(myQuery, sqlConnection);
                int rowCounter = Convert.ToInt32(sqlCommand.ExecuteScalar());
                if (rowCounter > 0)
                    return false;
                else {
                    string securedPassword = Security.getHash(eMail, password);
                    myQuery = "INSERT INTO tbleUsers (varUserName, eMail, password) VALUES ('" + name + "','" + eMail + "','" + securedPassword + "')";
                    sqlCommand = new SqlCommand(myQuery, sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    return true;
                }
            }
        }

        public static Boolean isEmailRegistered(string eMail) {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString)) {
                Boolean result;
                sqlConnection.Open();
                string myQuery = " SELECT COUNT(*) FROM users WHERE eMail = '" + eMail + "'";
                SqlCommand sqlCommand = new SqlCommand(myQuery, sqlConnection);
                int rowCounter = Convert.ToInt32(sqlCommand.ExecuteScalar());
                result = rowCounter > 0 ? true : false;
                return result;
            }
        }
    }
}
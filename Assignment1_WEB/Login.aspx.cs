using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/**
 * Author: Sebastian Suarez
 * Date: 18/04/2020
 * Login page of the website
 **/
namespace Assignment1_WEB {
    public partial class Login : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            
        }

        protected void btnLoginClick(object sender, EventArgs e) {
            User user;
            try {
                user = DBController.validateLogIn(txtEmail.Text, txtPassword.Text);
            }
            catch (Exception) {
                lblErrorMessage.Visible = true;
                lblErrorMessage.Text = "An eror has occured!";
                throw;
            }           

            //if users exists, should be redirected to main page, 
            if (user != null) {
                HttpCookie httpCookie = new HttpCookie("logedUser");
                httpCookie.Values["firstName"] = user.userName;
                //httpCookie.Values["idUser"] = user.ID.ToString();
                httpCookie.Expires = DateTime.Now.AddDays(3);
                Response.Cookies.Add(httpCookie); 
                Response.Redirect("Default.aspx");

            } else {
                lblErrorMessage.Visible = true;
                lblErrorMessage.Text = "user not found!";
            }

        }
    }
}
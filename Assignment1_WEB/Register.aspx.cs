using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/**
 * Author: Sebastian Suarez
 * Date: 18/04/2020
 * Register page of the website
 **/
namespace Assignment1_WEB {
    public partial class Register : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void btnRegisterClick(object sender, EventArgs e) {

            string userName = txtFirstName.Text;
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            bool insertionResult = false;
            try {
                insertionResult = DBController.registerNewUser(
                    userName,
                    email,
                    password);
            }
            catch (Exception) {
                lblErrorMessage.Visible = true;
                lblErrorMessage.Text = "An error has ocurred";
                throw;
            }            

            if (insertionResult) {
                HttpCookie httpCookie = new HttpCookie("logedUser");
                httpCookie.Values["firstName"] = userName;
                httpCookie.Expires = DateTime.Now.AddDays(3);
                Response.Cookies.Add(httpCookie);
                lblErrorMessage.Visible = false;

                //MasterPage master = this.Master as MasterPage;
                //master.publicLogOut();

                Response.Redirect("Login.aspx");
            } else {
                lblErrorMessage.Visible = true;
                lblErrorMessage.Text = "The provided email is already registered";
            }
            
        }
    }
}
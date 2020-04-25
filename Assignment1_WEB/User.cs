using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/**
 * Author: Sebastian Suarez
 * Date: 18/04/2020
 * Class used to storage data related to the loged user  
 **/
namespace Assignment1_WEB {
    public class User {

        public User(string nameParam) {
            userName = nameParam;
        }

        public string userName { get; set; }
    }
}
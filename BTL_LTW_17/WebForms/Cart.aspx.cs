using BTL_LTW_17.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_LTW_17.WebForms
{
    public partial class Cart : System.Web.UI.Page
    {
        protected Models.User _currentUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            _currentUser = Session[Constants.KEY_USER] as Models.User;
        }

        protected void SignIn(object sender, EventArgs e)
        {
            string currentUrl = Request.Url.ToString();
            Session[Constants.KEY_BACK_URL] = currentUrl;
            Response.Redirect("~/Htmls/Login.html");
        }
    }
}
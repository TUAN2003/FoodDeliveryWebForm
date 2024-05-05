using BTL_LTW_17.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_LTW_17.WebForms
{
    public partial class DeleteRest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int idRest = int.Parse(Request.Params.Get(0));
            List<Models.Restaurant> restaurants= Application[Utils.Constants.KEY_RESTAURANTS] as List<Models.Restaurant>;
            User currentUser = Session[Utils.Constants.KEY_USER] as User;
            if(currentUser.Role == 0)
            {
                int index = restaurants.FindIndex(rest => idRest == rest.Id);
                restaurants.RemoveAt(index);
                Application[Utils.Constants.KEY_RESTAURANTS] = restaurants;
                Response.Redirect("Home.aspx");
            }
            else
            {
                Response.Write("không xóa được");
            }
        }
    }
}
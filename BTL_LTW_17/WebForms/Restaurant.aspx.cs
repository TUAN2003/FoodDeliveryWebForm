using BTL_LTW_17.Models;
using BTL_LTW_17.Utils;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace BTL_LTW_17.WebForms
{
    public partial class Restaurant : System.Web.UI.Page
    {
        protected Models.Restaurant _restaurant;
        protected List<Models.Food> foods;
        protected int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Convert.ToInt32(Request.QueryString["Id"].ToString());
            List<Models.Restaurant> restaurants = Application[Utils.Constants.KEY_RESTAURANTS] as List<Models.Restaurant>;
            _restaurant = restaurants.Find(rest => rest.Id == id);
            imgAvatar.Src = _restaurant.Image;
            nameRest.InnerText = _restaurant.Name;
            addressRest.InnerText = _restaurant.Address;
            foods = _restaurant.Menu;

            // Gọi phương thức DataBind để hiển thị danh sách thức ăn
        }

        protected void AddFood_OnCart(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            Response.Redirect($"Pay.aspx?name={b.CommandArgument}");
        }
    }
}
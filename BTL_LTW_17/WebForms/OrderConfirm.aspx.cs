
using BTL_LTW_17.Models;
using BTL_LTW_17.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_LTW_17.WebForms
{
    public partial class OrderConfirm : System.Web.UI.Page
    {
        protected Models.Restaurant restaurant;
        protected Models.User user;
        protected List<FoodOrder> foodOrders;
        protected void Page_Load(object sender, EventArgs e)
        {
            user = Session[Constants.KEY_USER] as Models.User;
            List<Models.Restaurant> restaurants = Application[Constants.KEY_RESTAURANTS] as List<Models.Restaurant>;
            int idRest = int.Parse(Request.Form["id"].ToString());
            restaurant = restaurants.Find(rest =>  rest.Id == idRest);
            if(restaurant != null)
            {
                if (Request.Form.GetValues("check") != null)
                {
                    foodOrders = new List<FoodOrder>();
                    foreach (var item in Request.Form.GetValues("check"))
                    {
                        string[] s = item.Split(';');
                        foodOrders.Add(new FoodOrder(restaurant.Menu.Find(f => f.Id == int.Parse(s[0])), int.Parse(Request.Form.GetValues("quantity")[int.Parse(s[1])])));
                    }
                }
                Session[Constants.KEY_BILL] = new Bill(restaurant.Id, foodOrders, user.NumberPhone, null, TotalPrice(), null, null);
            }
        }

        protected void SignIn(object sender, EventArgs e)
        {
            string currentUrl = Request.Url.ToString();
            Session[Constants.KEY_BACK_URL] = currentUrl;
            Response.Redirect("~/Htmls/Login.html");
        }

        protected void Confirm(object sender, EventArgs e)
        {
            
        }

        protected int TotalPrice()
        {
            int sum = 0;
            foreach (var item in foodOrders)
            {
                sum += (item.Quantity * item.Item.Price);
            }
            return sum;
        }

        private string GetMethod(string method)
        {
            if (method.Equals("zalopay"))
            {
                return "ZaloPay";
            }else if (method.Equals("bank"))
            {
                return "Tài khoản ngân hàng";
            }
            else
            {
                return "Tiền mặt";
            }
        }
    }
}
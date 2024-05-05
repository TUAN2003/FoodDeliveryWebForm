using BTL_LTW_17.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_LTW_17.WebForms
{
    public partial class Site : System.Web.UI.MasterPage
    {
        private Models.User _currentUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            var dropDown = $@"<div class=""dropdown"">
                        <div class=""dropdown-menu"">
                            <a href=""#"">
                                <div class=""dropdown-item order-history"">
                                    <i class=""fa-solid fa-clock-rotate-left""></i>
                                    <span>Lịch sử đặt hàng</span>
                                </div>
                            </a>
                            <a href=""#"">
                                <div class=""dropdown-item update-acc"">
                                    <i class=""fa-solid fa-user""></i>
                                    <span>Cập nhật tài khoản</span>
                                </div>
                            </a>
                            <a href=""./Logout.aspx"">
                                <div class=""dropdown-item logout"">
                                    <i class=""fa-solid fa-power-off""></i>
                                    <span>Đăng xuất</span>
                                </div>
                            </a>
                        </div>
                    </div>";
            _currentUser = (Models.User)Session[Constants.KEY_USER];
            if (_currentUser != null)
            {
                StringBuilder html = new StringBuilder($"<img  id=\"img-avatar\" src=\"../Images/default_avatar.jpg\" alt=\"avatar\"/>");
                if (_currentUser.Avatar != null)
                {
                    html.Clear();
                    html.Append($"<img  id=\"img-avatar\" src=\"data:image/png;base64,{_currentUser.Avatar}\" alt=\"avatar\"/>");
                }
                html.Append($"<h4 id=\"nameUser\">{_currentUser.Name}</h4><i class=\"fa-solid fa-sort-down\"></i>");
                userAccount.InnerHtml = html.Append(dropDown).ToString();
                userAccount.Attributes.CssStyle["background-color"] = "white";
                userAccount.Attributes.CssStyle["height"] = "inherit";
                userAccount.Attributes.CssStyle["width"] = "180px";
            }
        }

        protected void SignIn(object sender, EventArgs e)
        {
            string currentUrl = Request.Url.ToString();
            Session[Constants.KEY_BACK_URL] = currentUrl;
            Response.Redirect("~/Htmls/Login.html");
        }
    }
}
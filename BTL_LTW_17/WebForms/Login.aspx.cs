using BTL_LTW_17.Models;
using BTL_LTW_17.Utils;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;

namespace BTL_LTW_17.WebForms
{
    public partial class Login : Page, ICheckValid<User>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string phone = Request.Form[Constants.KEY_PHONE]?.ToString();
            string pwd = Request.Form[Constants.KEY_PASSWORD]?.ToString();

            string s = CheckValid(new User(phone, pwd));
            // số điện thoại và mật khẩu hợp lệ
            if (s == Constants.NOTI_DATA_VALID)
            {
                HashSet<User> users = (HashSet<User>)Application[Constants.KEY_USERS];
                User user = new User(phone);
                users.TryGetValue(user, out user);
                // không tồn tại user
                if (user == null)
                {
                    Response.Redirect($"../Htmls/Login.html?warn={Constants.NOTI_NBPHONE_UNREGISTERED}");
                    return;
                }
                // mật khẩu chính xác
                if (user.EqualsPassword(pwd))
                {
                    User userNoPwd = user.Clone();
                    userNoPwd.Password = null;
                    Session[Constants.KEY_USER] = userNoPwd;
                    string url= "./Home.aspx";
                    if(Session[Constants.KEY_BACK_URL] != null)
                    {
                        url = Session[Constants.KEY_BACK_URL].ToString();
                        Session.Remove(Constants.KEY_BACK_URL);
                    }
                    Response.Redirect(url);
                }
                else //mật khẩu không chính xác
                {
                    Response.Redirect($"../Htmls/Login.html?warn={Constants.NOTI_PASSWORD_INCORRECT}");
                }
            }
            else // không hợp lệ
            {
                Response.Redirect($"../Htmls/Login.html?warn={s}");
            }
        }

        // kiểm tra số điện thoại và mật khẩu có đúng với định dạng không
        public string CheckValid(User input)
        {
            if (!Regex.IsMatch(input.NumberPhone, Constants.REGEX_PARTTERN_PHONE))
            {
                return Constants.NOTI_NBPHONE_ERROR;
            }
            if (!Regex.IsMatch(input.Password, Constants.REGEX_PARTTERN_PASSWORD))
            {
                return Constants.NOTI_PASSWORD_ERROR;
            }
            return Constants.NOTI_DATA_VALID;
        }
    }
}
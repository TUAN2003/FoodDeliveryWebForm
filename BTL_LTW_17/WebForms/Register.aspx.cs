using BTL_LTW_17.Models;
using BTL_LTW_17.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_LTW_17.WebForms
{
    public partial class Register : System.Web.UI.Page, ICheckValid<User>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string phone = Request.Form[Constants.KEY_PHONE]?.ToString();
                string pwd = Request.Form[Constants.KEY_PASSWORD]?.ToString();
                string uname = Request.Form[Constants.KEY_USER_NAME]?.ToString();
                string sex = Request.Form[Constants.KEY_SEX]?.ToString();
                string avatar = EncodeImage();
                string address = Request.Form[Constants.KEY_ADDRESS]?.ToString();
                SignUp(new Models.User(phone, pwd, avatar, uname, sex == "Nam" ? true : false,address,1));
            }
        }
        // User : phone,pwd,avatar,uname,sex
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
            if (!Regex.IsMatch(input.Name, Constants.REGEX_USER_NAME))
            {
                return Constants.NOTI_USER_NAME_ERROR;
            }
            return Constants.NOTI_DATA_VALID;
        }

        void SignUp(User user)
        {
            string s = CheckValid(user);
            if (s == Constants.NOTI_DATA_VALID)
            {
                var users = (HashSet<User>)Application[Constants.KEY_USERS];
                if (users == null)
                {
                    users = new HashSet<User>();
                    Application[Constants.KEY_USERS] = users;
                }
                if (!users.Contains(user))
                {
                    users.Add(user);
                    Response.Redirect($"Register.aspx?success={Constants.NOTI_REGISTER_SUCCESS}");
                }
                else
                {
                    AlertFail(Constants.NOTI_NBPHONE_EXIST);
                }
            }
            else
            {
                AlertFail(s);
            }
        }

        string EncodeImage()
        {
            var postedFile = fileUpload.PostedFile;
            if (postedFile != null && postedFile.ContentLength > 0)
            {
                // Tạo một đối tượng hình ảnh từ dữ liệu tệp ảnh
                using (System.Drawing.Image image = System.Drawing.Image.FromStream(postedFile.InputStream))
                {
                    // Chuyển đổi hình ảnh thành mảng byte
                    using (MemoryStream ms = new MemoryStream())
                    {
                        image.Save(ms, image.RawFormat);
                        byte[] imageBytes = ms.ToArray();
                        // Mã hóa mảng byte thành chuỗi base64
                        string base64String = Convert.ToBase64String(imageBytes);
                        return base64String;
                    }
                }
            }
            return null;
        }

        void AlertFail(string msg)
        {
            alertFail.InnerHtml = $"<img src=\"../Images/warning.png\" alt=\"Warning\" /> {msg}";
            alertFail.Attributes.CssStyle["Display"] = "flex";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_LTW_17.Utils
{
    public static class Constants
    {
        public const string KEY_USERS = "users";
        public const string KEY_FOODS = "foods";
        public const string KEY_BILLS = "bills";
        public const string KEY_BILL = "bill";
        public const string KEY_RESTAURANTS = "restaurants";
        public const string KEY_ID_RESTAURANT = "idRestaurant";
        public const string KEY_USER = "user";
        public const string KEY_PHONE = "phone";
        public const string KEY_PASSWORD = "password";
        public const string KEY_AVATAR = "avatar";
        public const string KEY_USER_NAME = "username";
        public const string KEY_SEX = "sex";
        public const string KEY_ADDRESS = "address";
        public const string KEY_BACK_URL = "backurl";
        public const string KEY_FILE_UPLOAD = "fileUpload";

        public const string NOTI_NBPHONE_ERROR = "Số điện thoại không hợp lệ";
        public const string NOTI_NBPHONE_UNREGISTERED = "Số điện thoại chưa được đăng kí";
        public const string NOTI_PASSWORD_INCORRECT = "Mật khẩu không chính xác";
        public const string NOTI_USER_NAME_ERROR = "Tên người dùng phải chức ít nhất 5 kí tự và nhiều nhất 16 kí tự bắt đầu bằng chữ cái hoặc số";
        public const string NOTI_PASSWORD_ERROR = "Mật khẩu không hợp lệ";
        public const string NOTI_NBPHONE_EXIST = "Số điện thoại đã đăng được ký";
        public const string NOTI_DATA_VALID = "Data Valid";
        public const string NOTI_REGISTER_SUCCESS = "Đăng ký tài khoản thành công";

        // định dạng số điện thoại việt nam
        public const string REGEX_PARTTERN_PHONE = @"(03|05|07|08|09|01[2|6|8|9])+([0-9]{8})\b";
        //định dạng mật mẩu phải ít nhất 8 kí tự gồm số , chữ cái và kí tự đặc biệt
        public const string REGEX_PARTTERN_PASSWORD = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$";
        //Tên sẽ bắt đầu bởi bất kỳ chữ cái viết thường (a-z),(A-Z), số (0-9),
        //dấu gạch dưới hoặc dấu gạch nối. Tiếp theo, {5,16} đảm bảo có ít nhất 5 trong số các ký tự đó, nhưng không quá 16.
        public const string REGEX_USER_NAME = @"^[a-zA-Z0-9_-]{5,16}$";
    }
}
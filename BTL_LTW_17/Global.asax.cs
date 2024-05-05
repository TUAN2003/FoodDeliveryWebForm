using BTL_LTW_17.Models;
using BTL_LTW_17.Utils;
using System;
using System.Collections.Generic;

namespace BTL_LTW_17
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            HashSet<User> users = new HashSet<User>();
            Application[Constants.KEY_USERS] = users;
            users.Add(new User("0383875782", "19072003Tuan@", "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", "Vũ Anh Tuấn ABCCC", true, "68 ngõ 18 định công thượng hoàng mai hà nội",0));
            users.Add(new User("0383875783", "19072003Tuan@", "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", "Vũ Anh Tuấn ABCCC", true, "68 ngõ 18 định công thượng hoàng mai hà nội", 1));
            List<Restaurant> restaurants = new List<Restaurant>();
            for (int i = 0; i < 2; i++)
            {
                restaurants.Add(new Restaurant(i * 5, "Phở thịt chuột Anh Tuấn", "96 định công thanh xuân", "../Images/yen.jpg", "50", new List<string> { "Phở", "Bún", "Cháo", "Bánh Mì" }, new List<Food>{
                new Food(0,"Phở Chuột tái lăn ","chuột được xào nên và nhiều hành lá",90000,"../Images/default_avatar.jpg","Phở"),
                new Food(1,"Phở chuột xào sả ớt ","chuột được xào nên và nhiều hành lá",90000,"../Images/default_avatar.jpg","Phở"),
                new Food(2,"Bánh mì ba tê ","chuột được xào nên và nhiều hành lá",90000,"../Images/default_avatar.jpg","Bánh Mì"),
                new Food(3,"Cháo sườn với quẩy ","chuột được xào nên và nhiều hành lá",120000,"../Images/default_avatar.jpg","Cháo")},4.5f,10,1.7f));

                restaurants.Add(new Restaurant(i * 5 + 1, "Tí Bún tí rau", "96 định công thanh xuân", "../Images/camap.jpg", "50", new List<string> { "Phở", "Bún", "Cháo", "Bánh Mì" }, new List<Food>{
                new Food(0,"Bánh giò ","chuột được xào nên và nhiều hành lá",90000,"../Images/yen.jpg","Phở"),
                new Food(1,"Cháo lòng ","chuột được xào nên và nhiều hành lá",50000,"../Images/yen.jpg","Phở"),
                new Food(2,"Giả cầy ","chuột được xào nên và nhiều hành lá",90000,"../Images/yen.jpg","Bánh Mì"),
                new Food(3,"Thịt chó ","chuột được xào nên và nhiều hành lá",120000,"../Images/yen.jpg","Cháo"),new Food(4,"Miến lươn ","chuột được xào nên và nhiều hành lá",120000,"../Images/yen.jpg","Cháo")}));
                restaurants.Add(new Restaurant(i * 5 + 2, "Nhà hàng hải sản Ghẹ 50kg", "96 định công thanh xuân", "../Images/thuongluong.jpg", "50"));
                restaurants.Add(new Restaurant(i * 5 + 3, "Bún cá định công", "96 định công thanh xuân", "../Images/default_avatar.jpg", "50"));
                restaurants.Add(new Restaurant(i * 5 + 4, "Bia hơi hải xồm", "96 định công thanh xuân", "../Images/history.jpg", "50"));
            }
            Application[Constants.KEY_RESTAURANTS] = restaurants;
            Application[Constants.KEY_FOODS] = new List<Food>() {
                new Food(0,"Phở Chuột tái lăn ","chuột được xào nên và nhiều hành lá",90000,"../Images/default_avatar.jpg","Phở"),
                new Food(1,"Phở chuột xào sả ớt ","chuột được xào nên và nhiều hành lá",90000,"../Images/default_avatar.jpg","Phở"),
                new Food(2,"Bánh mì ba tê ","chuột được xào nên và nhiều hành lá",90000,"../Images/default_avatar.jpg","Bánh Mì"),
                new Food(3,"Cháo sườn với quẩy ","chuột được xào nên và nhiều hành lá",120000,"../Images/default_avatar.jpg","Cháo")
            };
            Application["count"] = 0;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Application.Lock();
            int count = int.Parse(Application["count"].ToString());
            count++;
            Application["count"] = count;
            Application.UnLock();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            Application.Lock();
            int count = int.Parse(Application["count"].ToString());
            count--;
            Application["count"] = count;
            Application.UnLock();
        }

        protected void Application_End(object sender, EventArgs e)
        {
            
        }
    }
}
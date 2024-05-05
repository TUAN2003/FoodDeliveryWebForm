using BTL_LTW_17.Models;
using BTL_LTW_17.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_LTW_17.WebForms
{
    public partial class Last : System.Web.UI.Page
    {
        protected bool isSuccess;
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Bill> bills = Application[Constants.KEY_BILLS] as List<Bill>;
            if (bills == null)
            {
                bills = new List<Bill>();
                Application[Constants.KEY_BILLS] = bills;
            }
            Bill bill = Session[Constants.KEY_BILL] as Bill;
            if (bill != null)
            {
                bill.AddressCustomer = Request.Form["address"]?.ToString();
                bill.Note = Request.Form["note"]?.ToString();
                bill.Method = Request.Form["method"]?.ToString();
                bills.Add(bill);
                isSuccess = true;
            }
            else
                isSuccess = false;
        }

    }
}
using BTL_LTW_17.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_LTW_17.WebForms
{
    public partial class ShowBills : System.Web.UI.Page
    {
        protected List<Bill> bills;
        protected void Page_Load(object sender, EventArgs e)
        {
            bills = Application[Utils.Constants.KEY_BILLS] as List<Bill>;
            if(bills != null)
            {
                foreach (var item in bills)
                {
                    TableCell[] cells =
                    {
                        new TableCell(){Text=item.IdRestaurant.ToString()},
                        new TableCell(){Text=item.PhoneCustomer},
                        new TableCell(){Text=ListFoodToString(item.FoodOrders)},
                        new TableCell(){Text=item.AddressCustomer},
                        new TableCell(){Text=item.TotalPrice.ToString()},
                        new TableCell(){Text=item.Note},
                    };
                    TableRow row = new TableRow();
                    row.Cells.AddRange(cells);
                    myTable.Rows.Add(row);
                }
            }
        }

        private string ListFoodToString(List<FoodOrder> list)
        {
            StringBuilder sb = new StringBuilder("");
            foreach (var item in list)
            {
                sb.Append(item.Item.Name + "-");
            }
            return sb.ToString();
        }
    }
}
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
    public partial class Home : System.Web.UI.Page
    {
        protected List<Models.Restaurant> _restaurants;
        private const int _SIZE = 10;
        private int _countItem;
        private int _nPage;
        protected int _indexPage;
        protected int _nextPage;
        protected int _prevPage;
        protected void Page_Load(object sender, EventArgs e)
        {
            _restaurants = (List<Models.Restaurant>)Application[Utils.Constants.KEY_RESTAURANTS];
            _countItem = _restaurants.Count;
            _nPage = _countItem / _SIZE;
            _nPage = (_countItem % _SIZE) != 0 ? _nPage + 1 : _nPage;
            _indexPage = Convert.ToInt32(Request.QueryString["Index"]);
            LoadItemRange(0,_restaurants.Count-1);

            //StringBuilder html = new StringBuilder("");
            //var activeClass = "pagination-active";
            //for (int i = 1; i <= _nPage; i++)
            //{
            //    if (_indexPage == i - 1)
            //        html.Append($@"<li><a class=""pag-item " + activeClass + $@""" href=""./Home.aspx?Page=0&Index={i - 1}"">{i}</a></li>");
            //    else
            //        html.Append($@"<li><a class=""pag-item"" href=""./Home.aspx?Page=0&Index={i - 1}"">{i}</a></li>");
            //}
            ////pagination.InnerHtml = html.ToString();

            //_nextPage = _prevPage = _indexPage;
            //if (0 < _indexPage)
            //{
            //    _prevPage--;
            //}
            //if (_indexPage < _nPage - 1)
            //{
            //    _nextPage++;
            //}
        }

        void LoadItemRange(int beg, int end)
        {
            StringBuilder html = new StringBuilder($@"<h2 class=""title-block"">Lựa chọn gần bạn</h2>");
            for (int i = beg; i <= end; i++)
            {
                html.Append($@"<div class=""product-block"">
                    <a href=""./Restaurant.aspx?Id={_restaurants[i].Id}&&Name={_restaurants[i].Name}"" target=""_blank"" class=""link-product"">
                        <div class=""product-item"">
                            <span class=""status-online""></span>
                            <img src=""{_restaurants[i].Image}"" alt=""Alternate Text"" />
                            <div class=""info-item"">
                                <div class=""info-basic-item"">
                                    <h4 class=""name-item"">{_restaurants[i].Name}
                                    </h4>
                                    <p class=""address-item"">
                                        {_restaurants[i].Address}
                                    </p>
                                    <div class=""info-basic-item2"">
                              <div class=""info-rate"">
                                <i class=""fa-solid fa-star"" style=""color: rgb(251, 205, 0);""></i>
                                <span>{_restaurants[i].Rate}</span>
                            </div>
                            <div class=""info-time"">
                                <i class=""fa-regular fa-clock"" style=""color: rgba(0, 0, 0, 0.485);""></i>
                                <span>{_restaurants[i].Time}phút</span>
                            </div>
                            <div class=""info-distance"">
                                <i class=""fa-solid fa-location-dot"" style=""color: rgba(0, 0, 0, 0.485);""></i>
                                <span>{_restaurants[i].Distance}km</span>
                            </div>
                                    </div>
                                </div>
                            </div>
                            <p class=""promotion-item"">
                                <i class=""fa-solid fa-tag""></i>Giảm {_restaurants[i].Promotion}%
                            </p>
                        </div>
                    </a>
                </div>");
            }
            listRestaurant.InnerHtml = html.ToString();
        }

        void LoadItemByIndexPage(int indexPage)
        {
            var beg = indexPage * _SIZE;
            var end = (indexPage == (_nPage - 1)) ? _countItem - 1 : beg + _SIZE - 1;
            LoadItemRange(beg, end);
        }

        protected void _NextPage(object sender, EventArgs e)
        {
            if (_indexPage < _nPage - 1)
            {
                _indexPage++;
                LoadItemByIndexPage(_indexPage);
            }
        }
        protected void _PrevPage(object sender, EventArgs e)
        {
            if (_indexPage > 0)
            {
                _indexPage--;
                LoadItemByIndexPage(_indexPage);
            }
        }
    }
}
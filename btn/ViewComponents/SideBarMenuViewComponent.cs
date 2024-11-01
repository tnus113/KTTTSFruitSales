using Microsoft.AspNetCore.Mvc;
using btn.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesAndPurchaseManagement.ViewComponents
{
    public class SidebarMenuViewComponent : ViewComponent
    {
        private List<MenuItem> MenuItems = new List<MenuItem>();

        public SidebarMenuViewComponent()
        {
            MenuItems = new List<MenuItem>()
    {
        new MenuItem() { Id = 1, Name = "Tổng quan", Link = "/", Icon = "fas fa-tachometer-alt" },
        new MenuItem() { Id = 2, Name = "Hóa đơn bán", Link = "/SellBill/Index", Icon = "fas fa-user" },
        new MenuItem() { Id = 3, Name = "Hóa đơn nhập", Link = "/ImportBill/Index", Icon = "fa fa-briefcase" },
        new MenuItem() { Id = 4, Name = "Hàng hóa", Link = "/Product/Index", Icon = "fa fa-box" },
        new MenuItem() { Id = 5, Name = "Nhân viên", Link = "/Employee/Index", Icon = "fas fa-list" },
        new MenuItem() { Id = 6, Name = "Khách hàng", Link = "/Customer/Index", Icon = "fas fa-users" },
        new MenuItem() { Id = 7, Name = "Nhà cung cấp", Link = "/Provider/Index", Icon = "fas fa-truck" },
        new MenuItem() { Id = 21, Name = "Đăng xuất", Link = "/Home/Logout", Icon = "fa fa-sign-out-alt" },
    };
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("SidebarMenu", MenuItems);
        }
    }
}

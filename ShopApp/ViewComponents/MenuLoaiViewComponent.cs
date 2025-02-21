using Microsoft.AspNetCore.Mvc;
using ShopApp.Data;
using ShopApp.ViewModels;

namespace ShopApp.ViewComponents
{
    public class MenuLoaiViewComponent : ViewComponent
    {
        private readonly Hshop2023Context db;

        public MenuLoaiViewComponent(Hshop2023Context context) => db = context;

        public IViewComponentResult Invoke()
        {
            var items = db.Loais.Select(lo => new MenuLoaiVM { 
                MaLoai = lo.MaLoai,
                TenLoai = lo.TenLoai,
                SoLuong = lo.HangHoas.Count
            }).OrderBy(p => p.TenLoai);
            return View(items); // Default cshtml
            //return View("MenuLoai2", items); // Custom cshtml
        }
    }
}

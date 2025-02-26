using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using ShopApp.Data;
using ShopApp.Helpers;
using ShopApp.ViewModels;

namespace ShopApp.Controllers
{
    public class KhachHangController : Controller
    {
        private readonly Hshop2023Context db;
        private readonly IMapper _mapper;

        public KhachHangController(Hshop2023Context context, IMapper mapper)
        {
            db = context;
            _mapper= mapper;
        }
        [HttpGet]
        public IActionResult Dangky()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Dangky(RegisterVM model, IFormFile Hinh)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var khachHang = _mapper.Map<KhachHang>(model);
                    khachHang.RandomKey = MyUtil.GenerateRandonKey();
                    khachHang.MatKhau = model.MatKhau.ToMD5Hash(khachHang.RandomKey);
                    khachHang.HieuLuc = true;//sẽ xử lý khi dùng mail để active
                    khachHang.VaiTro = 0;

                    if (Hinh != null)
                    {
                        khachHang.Hinh = MyUtil.UploadHinh(Hinh, "KhachHang");
                    }

                    db.Add(khachHang);
                    db.SaveChanges();
                    return RedirectToAction("Index", "HangHoa");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
                return View();   
        }
    }
}

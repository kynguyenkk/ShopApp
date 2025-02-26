using AutoMapper;
using ShopApp.Data;
using ShopApp.ViewModels;

namespace ShopApp.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Cách tạo mapper khi có tên không giống nhau
            //CreateMap<RegisterVM, KhachHang>()
            //    .ForMember(kh => kh.HoTen, option => option.MapFrom(RegisterVM => RegisterVM.HoTen))
            //    .ReverseMap();
            CreateMap<RegisterVM, KhachHang>();
        }
    }
}

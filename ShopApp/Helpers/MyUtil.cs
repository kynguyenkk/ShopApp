using System.Text;

namespace ShopApp.Helpers
{
    public class MyUtil
    {
        public static string UploadHinh(IFormFile Hinh, string folder)
        {
            try
            {
                var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Hinh", folder, Hinh.FileName);
                using (var myfile = new FileStream(fullPath, FileMode.CreateNew))
                {
                    Hinh.CopyTo(myfile);
                }
                return Hinh.FileName;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
        public static string GenerateRandonKey(int length = 5)
        {
            var patten = @"qazwsxedcrfvtgbyhnujmiklopQAZWSXEDCRFVTGBYHNUJMIKLOP!";
            var sb = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                sb.Append(patten[new Random().Next(0, patten.Length)]);
            }
            return sb.ToString();
        }
    }
}

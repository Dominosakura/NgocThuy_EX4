using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NgocThuy_Lab3_4.Models;


namespace NgocThuy_Lab3_4.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FormRegister()
        {
            ViewBag.listType = new List<TypeBusiness>()
            {
                new TypeBusiness() { ID = "0", Name = "---Chọn Loại Hình Doanh Nghiệp---" },
                new TypeBusiness() { ID = "1", Name = "Doanh Nghiệp Nhà Nước" },
                new TypeBusiness() { ID = "2", Name = "Doanh Nghiệp Tư Nhân" },
                new TypeBusiness() { ID = "3", Name = "Doanh Nghiệp Cổ Phần" },
                new TypeBusiness() { ID = "4", Name = "Doanh Nghiệp Hợp Tác" },
                new TypeBusiness() { ID = "5", Name = "Đơn Vị Sự Nghiệp Công Lập" },
                new TypeBusiness() { ID = "6", Name = "Doanh Nghiệp Liên Doanh" }
            };
            return View();

        }


        public ActionResult RegisterDetails()
        {
          
            TempData["TenDonVi"] = Request["txtTenDonVi"];
            TempData["LoaiHinhDoanhNghiep"] = Request["txtLoaiHinhDoanhNghiep"];
            TempData["SoLuongNV"] = Request["SoLuongNV"];
            TempData["DiaChi"] = Request["txtDiaChi"];
            TempData["NguoiLienHe"] = Request["txtNguoiLienHe"]; 
            TempData["SoDienThoai"] = Request["txtSoDienThoai"]; 
            TempData["SoFax"] = Request["txtSoFax"]; 
            TempData["Email"] = Request["txtEmail"]; 
            TempData["DiaChiWebsite"] = Request["txtDiaChiWebsite"];
            TempData["TenDangNhap"] = Request["txtTenDangNhap"]; 
            TempData["MatKhau"] = Request["txtMatKhau"]; 
            TempData["XacNhanMatKhau"] = Request["txtXacNhanMatKhau"];

            TempData["NhanThuDienTu"] = Request["txtNhanThuDienTu"] == "Nhận" ? "Nhận" : "Không nhận";



            return View();
        }

    }
}
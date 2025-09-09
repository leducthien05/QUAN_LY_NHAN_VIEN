using QUAN_LY_NHAN_VIEN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUAN_LY_NHAN_VIEN.Controller
{
    public class DoiMKcontroller
    {
        private DoiMK model;

        public DoiMKcontroller()
        {
            model = new DoiMK();
        }

        //Lấy thông tin so sánh
        public string GetPassWordDB(string tenTK, string maNV)
        {
            return model.GetPassword(tenTK, maNV);
        }

        //UPDATE mật khẩu
        public bool UpdateMKNew(string tenTk, string MK, string maNV)
        {
            return model.UpdateMK(tenTk, MK, maNV);
        }
    }
}

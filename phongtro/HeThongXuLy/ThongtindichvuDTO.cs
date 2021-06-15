using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace phongtro.HeThongXuLy
{
    class ThongtindichvuDTO
    {
        
        private string sMaDV;

        public string SMaDV
        {
            get { return sMaDV; }
            set { sMaDV = value; }
        }
        private string sTenDV;

        public string STenDV
        {
            get { return sTenDV; }
            set { sTenDV = value; }
        }
        private double sDonGia;

        public double SDonGia
        {
            get { return sDonGia; }
            set { sDonGia = value; }
        }

       
        private string sDonViTinh;

        public string SDonViTinh
        {
            get { return sDonViTinh; }
            set { sDonViTinh = value; }
        }
    }
}

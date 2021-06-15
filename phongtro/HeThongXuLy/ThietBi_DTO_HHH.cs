using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace phongtro.HeThongXuLy
{
    class ThietBi_DTO_HHH
    {
        private string sMaTB;

        public string SMaTB
        {
            get { return sMaTB; }
            set { sMaTB = value; }
        }
        private string sMaPT;

        public string SMaPT
        {
            get { return sMaPT; }
            set { sMaPT = value; }
        }

        private string sTenTB;

        public string STenTB
        {
            get { return sTenTB; }
            set { sTenTB = value; }
        }
      
        private string sNhanHieu;

        public string SNhanHieu
        {
            get { return sNhanHieu; }
            set { sNhanHieu = value; }
        }

        private int sSoLuong;

        public int SSoLuong
        {
            get { return sSoLuong; }
            set { sSoLuong = value; }
        }

        private Boolean sTinhTrang;

        public Boolean STinhTrang
        {
            get { return sTinhTrang; }
            set { sTinhTrang = value; }
        }
        
        private string sNgaymua;

        public string SNgaymua
        {
            get { return sNgaymua; }
            set { sNgaymua = value; }
        }
        private string sGia;

        public string SGia
        {
            get { return sGia; }
            set { sGia = value; }
        }
    }
}

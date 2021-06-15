
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace phongtro.HeThongXuLy
{
    class KHACHTRO_DTO
    {
        private string _chunha;

        public string ChuNha
        {
            get { return _chunha; }
            set { _chunha = value; }
        }
        private string _makt;
        private string _mapt;

        public string MaPT
        {
            get { return _mapt; }
            set { _mapt = value; }
        }
        public string MaKT
        {
            get { return _makt; }
            set { _makt = value; }
        }
        private string _hoten;

        public string HoTen
        {
            get { return _hoten; }
            set { _hoten = value; }
        }
        private string _cmdn;
        public string CMND
        {
            get { return _cmdn; }
            set { _cmdn = value; }
        }
        private string _gioitinh;

        public string GioiTinh
        {
            get { return _gioitinh; }
            set { _gioitinh = value; }
        }
        private string _nghenghiep;

        public string NgheNghiep
        {
            get { return _nghenghiep; }
            set { _nghenghiep = value; }
        }
        private string _diachi;

        public string DiaChi
        {
            get { return _diachi; }
            set { _diachi = value; }
        }
        private string _sdt;
        public string SDT
        {
            get { return _sdt; }
            set { _sdt = value; }
        }
        private string _image;

        public string image
        {
            get { return _image; }
            set { _image = value; }
        }
        private Boolean _trangthai;

        public Boolean Trangthai
        {
            get { return _trangthai; }
            set { _trangthai = value; }
        }
    }
}

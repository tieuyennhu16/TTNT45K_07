using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace phongtro.HeThongXuLy
{
    class PHIEUTHUE_DTO
    {
        private int _maphieuthue;

        public int MaPhieuThue
        {
            get { return _maphieuthue; }
            set { _maphieuthue = value; }
        }

        private string _mapt;

        public string MaPT
        {
            get { return _mapt; }
            set { _mapt = value; }
        }
        private string _nakt;

        public string MaKT
        {
            get { return _nakt; }
            set { _nakt = value; }
        }
        private string  _ngaythue;

        public string  NgayThue
        {
            get { return _ngaythue; }
            set { _ngaythue = value; }
        }
        private int _sltoida;

        public int SLToiDa
        {
            get { return _sltoida; }
            set { _sltoida = value; }
        }
        private string _tang;

        public string Tang
        {
            get { return _tang; }
            set { _tang = value; }
        }
        private string _day;

        public string Day
        {
            get { return _day; }
            set { _day = value; }
        }
        private double _tiendatcoc;

        public double TienDatCoc
        {
            get { return _tiendatcoc; }
            set { _tiendatcoc = value; }
        }
        private Boolean _trangthai;

        public Boolean TrangThai
        {
            get { return _trangthai; }
            set { _trangthai = value; }
        }
    }
}

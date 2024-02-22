namespace API_Basic.Entities
{
    public class Lop
    {
        public int LopId { get; set; }
        public string TenLop { get; set; }
        public int SiSo { get; set; }
        public IEnumerable<HocSinh> hocSinhs { get; set; }
    }
}

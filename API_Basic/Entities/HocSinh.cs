namespace API_Basic.Entities
{
    public class HocSinh
    {
        public int HocSinhId { get; set; }
        public int LopId { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string QueQuan { get; set; }
        public Lop Lop { get; set; }
    }
}

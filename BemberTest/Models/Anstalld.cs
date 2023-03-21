namespace BemberTest.Models
{
    public class Anstalld
    {
        public int AnstalldId { get; set; }
        public string AnstalldNamn { get; set; }
        public string? Foretag { get; set;}
    }

    public class AnstalldDto 
    {
        public string AnstalldNamn { get; set; }
        public string Foretag { get; set; }
    }
}

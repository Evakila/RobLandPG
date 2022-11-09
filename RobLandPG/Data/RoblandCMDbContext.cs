using Microsoft.EntityFrameworkCore;

namespace RobLandPG.Data
{
    public class RoblandCMDbContext:DbContext
    {
        public DbSet<tblusers> tblusers { get; set; }
        public DbSet<tblclientdocuments> tblclientdocuments { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.UseNpgsql("Host=Servers;Database=RoblandCM;Username=postgress;Password=Evakila2018");
        public RoblandCMDbContext()
        {
        }

        public RoblandCMDbContext(DbContextOptions<RoblandCMDbContext> options)
            : base(options)
        {
        }
    }
    public class tblusers
    {
        public int id { get; set; }
        public string username { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
    }
    public class tblclientdocuments
    {
        public int id { get; set; }
        public int clientid { get; set; }
        public string docname { get; set; }
        public string description { get; set; }
        public string contenttype { get; set; }
        public byte[] document { get; set; }
        public string username { get; set; }

    }
}

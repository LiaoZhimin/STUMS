namespace STUMS_DAL
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using STUMS_Models;

    public class MyDBContext : DbContext
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“MyDBContext”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“STUMS_DAL.MyDBContext”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“MyDBContext”
        //连接字符串。
        public MyDBContext()
            : base("name=MyDBContext")
        {
        }

        //为您要在模型中包含的每种实体类型都添加 DbSet。有关配置和使用 Code First  模型
        //的详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=390109。

        public virtual DbSet<School> Schools { get; set; }
        public virtual DbSet<IDCards> IDCards { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<StuPunishments> StuPunishments { get; set; }
        public virtual DbSet<StuRewards> StuRewards { get; set; }
        public virtual DbSet<StuFamilies> StuFamilies { get; set; }
        public virtual DbSet<Teachers> Teachers { get; set; }
        public virtual DbSet<Workers> Workers { get; set; }
        public virtual DbSet<Major> Majors { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Dormitory> Dormitorys { get; set; }
        public virtual DbSet<StudentMessage> StudentMessages { get; set; }
    }
}
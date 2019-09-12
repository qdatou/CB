namespace CBSP.DAL
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class CBDBModel : DbContext
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“CBDBModel”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“CBSP.DAL.CBDBModel”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“CBDBModel”
        //连接字符串。
        public CBDBModel()
            : base("name=CBDBModel")
        {
        }

        public virtual DbSet<Sys_Role> Sys_Role { get; set; }
        public virtual DbSet<Sys_Right> Sys_Right { get; set; }
        public virtual DbSet<Sys_RoleRight> Sys_RoleRight { get; set; }
        public virtual DbSet<Sys_Depart> Sys_Depart { get; set; }
        public virtual DbSet<Sys_Custom> Sys_Custom { get; set; }
        public virtual DbSet<Sys_CustomRight> Sys_CustomRight { get; set; }
        public virtual DbSet<Dict_Duty> Dict_Duty { get; set; }
        public virtual DbSet<Sys_User> Sys_User { get; set; }
        public virtual DbSet<Sys_UserDuty> Sys_UserDuty { get; set; }
        public virtual DbSet<Sys_UserRole> Sys_UserRole { get; set; }
        

    }

}
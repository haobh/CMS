namespace ModelEntity.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBContextCMS : DbContext
    {
        public DBContextCMS()
            : base("name=DBContextCMS")
        {
        }

        public virtual DbSet<About> Abouts { get; set; }
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Footer> Footers { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MenuType> MenuTypes { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Slide> Slides { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserActivityLog> UserActivityLogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<About>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<About>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<About>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<About>()
                .Property(e => e.MetaDescriptions)
                .IsFixedLength();
        }
    }
}

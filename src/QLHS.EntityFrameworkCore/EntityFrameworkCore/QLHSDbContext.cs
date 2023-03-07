using Microsoft.EntityFrameworkCore;
using QLHS.Rooms;
using QLHS.Students;
using QLHS.Teachers;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using QLHS.Subjects;

namespace QLHS.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class QLHSDbContext :
    AbpDbContext<QLHSDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public DbSet<Teachers.Teacher> Teachers { get; set; }
    public DbSet<Student> Books { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public QLHSDbContext(DbContextOptions<QLHSDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */
            builder.Entity<Teachers.Teacher>(b =>
            {
                b.ToTable(QLHSConsts.DbTablePrefix + "Teachers" + QLHSConsts.DbSchema);
                b.ConfigureByConvention();

                b.Property(x => x.Name)
                    .HasMaxLength(TeacherConsts.MaxNameLength)
                    .IsRequired();

                b.Property(x => x.ShortBio)
                    .HasMaxLength(TeacherConsts.MaxShortBioLength)
                    .IsRequired();
            });

            builder.Entity<Student>(b =>
            {
                b.ToTable(QLHSConsts.DbTablePrefix + "Students" + QLHSConsts.DbSchema);
                b.ConfigureByConvention();

                b.Property(x => x.Name)
                    .HasMaxLength(StudentConsts.MaxNameLength)
                    .IsRequired();

                //one-to-many relationship with Teacher table
                b.HasOne<Teachers.Teacher>().WithMany().HasForeignKey(x => x.TeacherId).IsRequired();

                //many-to-many relationship with Category table => BookRooms
                b.HasMany(x => x.Rooms).WithOne().HasForeignKey(x => x.StudentId).IsRequired();
            });

            builder.Entity<Room>(b =>
            {
                b.ToTable(QLHSConsts.DbTablePrefix + "Rooms" + QLHSConsts.DbSchema);
                b.ConfigureByConvention();

                b.Property(x => x.Name)
                    .HasMaxLength(RoomConsts.MaxNameLength)
                    .IsRequired();
            });

            builder.Entity<StudentRoom>(b =>
            {
                b.ToTable(QLHSConsts.DbTablePrefix + "StudentRooms" + QLHSConsts.DbSchema);
                b.ConfigureByConvention();

                //define composite key
                b.HasKey(x => new { x.StudentId, x.RoomId });

                //many-to-many configuration
                b.HasOne<Student>().WithMany(x => x.Rooms).HasForeignKey(x => x.StudentId).IsRequired();
                b.HasOne<Room>().WithMany().HasForeignKey(x => x.RoomId).IsRequired();
                
                b.HasIndex(x => new { x.StudentId, x.RoomId });
            });


        builder.Entity<Subject>(b =>
        {
            b.ToTable(QLHSConsts.DbTablePrefix + "Subjects", QLHSConsts.DbSchema);
            b.ConfigureByConvention(); 
            

            /* Configure more properties here */
        });
    }
}

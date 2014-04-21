using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace CV.DAL
{
    using CV.Common;
    using CV.Model;

    /// <summary>
    /// ApplicationDbContext class.
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
            //this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().ToTable(Constants.TablePrefix + "Roles");
            modelBuilder.Entity<IdentityUserClaim>().ToTable(Constants.TablePrefix + "UserClaims");
            modelBuilder.Entity<IdentityUserLogin>().ToTable(Constants.TablePrefix + "UserLogins");
            modelBuilder.Entity<IdentityUserRole>().ToTable(Constants.TablePrefix + "UserRoles");
            modelBuilder.Entity<IdentityUser>().ToTable(Constants.TablePrefix + "Users");
            modelBuilder.Entity<ApplicationUser>().ToTable(Constants.TablePrefix + "Users");

            //modelBuilder.Entity<CvContactDetail>()
            //    .Map<Address>(a => a.Requires("Discriminator").HasValue("Address"))
            //    .Map<Email>(e => e.Requires("Discriminator").HasValue("Email"))
            //    .Map<Phone>(p => p.Requires("Discriminator").HasValue("Phone"))
            //    .Map<WebSite>(w => w.Requires("Discriminator").HasValue("Website"));

            // modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        
        public DbSet<Person> People { get; set; }
        
        public DbSet<ContactDetail> ContactDetails { get; set; }

        public DbSet<Resume> Resumes { get; set; }
        
        public DbSet<Education> Education { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<Attachment> Attachments { get; set; }

        public DbSet<Certification> Certifications { get; set; }

        public DbSet<Experience> Experiences { get; set; }

        public DbSet<SkillMatrix> SkillMatrix { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public System.Data.Entity.DbSet<CV.Model.Address> Addresses { get; set; }
    }
}

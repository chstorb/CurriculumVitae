namespace CV.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CvContactDetail",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        Usage = c.String(nullable: false),
                        Street = c.String(),
                        City = c.String(),
                        StateProvince = c.String(),
                        ZipPostalCode = c.String(),
                        CountryRegion = c.String(),
                        EMailAddress = c.String(),
                        Number = c.String(),
                        WebAddress = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CvPerson", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.CvPerson",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false),
                        BirthName = c.String(),
                        FirstName = c.String(),
                        MartialStatus = c.String(),
                        NumberOfChildren = c.Int(),
                        BirthDate = c.DateTime(),
                        PlaceOfBirth = c.String(),
                        Nationality = c.String(),
                        MotherId = c.Int(),
                        FatherId = c.Int(),
                        Notes = c.String(),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CvAttachment",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        AttachmentType = c.String(),
                        AttachmentDate = c.DateTime(),
                        FileType = c.String(),
                        FilePath = c.String(),
                        Summary = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CvPerson", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.CvCertification",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        Title = c.String(),
                        InstitutionName = c.String(),
                        DateOfReceipt = c.DateTime(),
                        City = c.String(),
                        StateProvince = c.String(),
                        CountryRegion = c.String(),
                        Summary = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CvPerson", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.CvEducation",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        SchoolInstitution = c.String(nullable: false),
                        Degree = c.String(),
                        DateFrom = c.DateTime(),
                        DateTo = c.DateTime(),
                        Concentrations = c.String(),
                        City = c.String(),
                        StateProvince = c.String(),
                        CountryRegion = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CvPerson", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.CvLanguage",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        LanguageName = c.String(nullable: false),
                        Level = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CvPerson", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.CvResume",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        Visible = c.Boolean(nullable: false),
                        WorkAuthorisationFor = c.String(),
                        CurrentCareerLevel = c.String(),
                        CurrentEducationLevel = c.String(),
                        SalaryFrom = c.Decimal(storeType: "money"),
                        SalaryTo = c.Decimal(storeType: "money"),
                        PreferredCountry = c.String(),
                        PreferredLocation = c.String(),
                        DesiredJobType = c.String(),
                        DesiredJobStatus = c.String(),
                        TravelDaysPerMonth = c.Int(),
                        AvailabilityDate = c.DateTime(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CvPerson", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.CvExperience",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ResumeId = c.Int(nullable: false),
                        Employer = c.String(),
                        JobTitle = c.String(),
                        Industry = c.String(),
                        City = c.String(),
                        StateProvince = c.String(),
                        CountryRegion = c.String(),
                        Description = c.String(),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        Responsibilities = c.String(),
                        Visible = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CvResume", t => t.ResumeId, cascadeDelete: true)
                .Index(t => t.ResumeId);
            
            CreateTable(
                "dbo.CvSkillMatrix",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ExperienceId = c.Int(nullable: false),
                        SkillId = c.Int(nullable: false),
                        Level = c.String(),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CvExperience", t => t.ExperienceId, cascadeDelete: true)
                .ForeignKey("dbo.CvSkill", t => t.SkillId, cascadeDelete: true)
                .Index(t => t.ExperienceId)
                .Index(t => t.SkillId);
            
            CreateTable(
                "dbo.CvSkill",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(),
                        WebAddress = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CvRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.CvUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.CvRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.CvUsers", t => t.IdentityUser_Id)
                .Index(t => t.RoleId)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.CvUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CvUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CvUsers", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.CvUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.CvUsers", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CvUserRoles", "IdentityUser_Id", "dbo.CvUsers");
            DropForeignKey("dbo.CvUserLogins", "IdentityUser_Id", "dbo.CvUsers");
            DropForeignKey("dbo.CvUserClaims", "IdentityUser_Id", "dbo.CvUsers");
            DropForeignKey("dbo.CvUserRoles", "RoleId", "dbo.CvRoles");
            DropForeignKey("dbo.CvResume", "PersonId", "dbo.CvPerson");
            DropForeignKey("dbo.CvSkillMatrix", "SkillId", "dbo.CvSkill");
            DropForeignKey("dbo.CvSkillMatrix", "ExperienceId", "dbo.CvExperience");
            DropForeignKey("dbo.CvExperience", "ResumeId", "dbo.CvResume");
            DropForeignKey("dbo.CvLanguage", "PersonId", "dbo.CvPerson");
            DropForeignKey("dbo.CvEducation", "PersonId", "dbo.CvPerson");
            DropForeignKey("dbo.CvContactDetail", "PersonId", "dbo.CvPerson");
            DropForeignKey("dbo.CvCertification", "PersonId", "dbo.CvPerson");
            DropForeignKey("dbo.CvAttachment", "PersonId", "dbo.CvPerson");
            DropIndex("dbo.CvUserLogins", new[] { "IdentityUser_Id" });
            DropIndex("dbo.CvUserClaims", new[] { "IdentityUser_Id" });
            DropIndex("dbo.CvUserRoles", new[] { "IdentityUser_Id" });
            DropIndex("dbo.CvUserRoles", new[] { "RoleId" });
            DropIndex("dbo.CvRoles", "RoleNameIndex");
            DropIndex("dbo.CvSkillMatrix", new[] { "SkillId" });
            DropIndex("dbo.CvSkillMatrix", new[] { "ExperienceId" });
            DropIndex("dbo.CvExperience", new[] { "ResumeId" });
            DropIndex("dbo.CvResume", new[] { "PersonId" });
            DropIndex("dbo.CvLanguage", new[] { "PersonId" });
            DropIndex("dbo.CvEducation", new[] { "PersonId" });
            DropIndex("dbo.CvCertification", new[] { "PersonId" });
            DropIndex("dbo.CvAttachment", new[] { "PersonId" });
            DropIndex("dbo.CvContactDetail", new[] { "PersonId" });
            DropTable("dbo.CvUserLogins");
            DropTable("dbo.CvUserClaims");
            DropTable("dbo.CvUsers");
            DropTable("dbo.CvUserRoles");
            DropTable("dbo.CvRoles");
            DropTable("dbo.CvSkill");
            DropTable("dbo.CvSkillMatrix");
            DropTable("dbo.CvExperience");
            DropTable("dbo.CvResume");
            DropTable("dbo.CvLanguage");
            DropTable("dbo.CvEducation");
            DropTable("dbo.CvCertification");
            DropTable("dbo.CvAttachment");
            DropTable("dbo.CvPerson");
            DropTable("dbo.CvContactDetail");
        }
    }
}

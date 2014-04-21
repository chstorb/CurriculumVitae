namespace CV.DAL.Migrations
{
    using CV.Model;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CV.DAL.ApplicationDbContext>
    {
        public Configuration()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));
            
            AutomaticMigrationsEnabled = false;
        }

        //protected override void Seed(CV.DAL.ApplicationDbContext context)
        //{
        //    //  This method will be called after migrating to the latest version.

        //    //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
        //    //  to avoid creating duplicate seed data. E.g.

        //    context.People.AddOrUpdate(
        //      p => p.FullName,
        //      new Person { FullName = "Andrew Peters" },
        //      new Person { FullName = "Brice Lambson" },
        //      new Person { FullName = "Rowan Miller" }
        //    );            
        //}

        protected override void Seed(CV.DAL.ApplicationDbContext context)
        {
            AddUserAndRole(context);

            context.Skills.AddOrUpdate(s => s.Title, 
               new Skill { Title = "ADO", Description = null, WebAddress = null, }, 
               new Skill { Title = "Apache Ant", Description = null, WebAddress = null, }, 
               new Skill { Title = "Apache Tomcat", Description = null, WebAddress = null, }, 
               new Skill { Title = "Apache Webserver", Description = null, WebAddress = null, }, 
               new Skill { Title = "Araxis Merge", Description = null, WebAddress = null, }, 
               new Skill { Title = "ASP.NET MVC", Description = null, WebAddress = null, }, 
               new Skill { Title = "C", Description = null, WebAddress = null, }, 
               new Skill { Title = "C#", Description = null, WebAddress = null, }, 
               new Skill { Title = "C++", Description = null, WebAddress = null, }, 
               new Skill { Title = "COM", Description = null, WebAddress = null, }, 
               new Skill { Title = "COM Interop", Description = null, WebAddress = null, }, 
               new Skill { Title = "DAO", Description = null, WebAddress = null, }, 
               new Skill { Title = "DBVisualizer", Description = null, WebAddress = null, }, 
               new Skill { Title = "Eclipse", Description = null, WebAddress = null, }, 
               new Skill { Title = "Entity Framework", Description = null, WebAddress = null, }, 
               new Skill { Title = "Java", Description = null, WebAddress = null, }, 
               new Skill { Title = "JDeveloper", Description = null, WebAddress = null, }, 
               new Skill { Title = "JDBC", Description = null, WebAddress = null, }, 
               new Skill { Title = "JDOM", Description = null, WebAddress = null, }, 
               new Skill { Title = "JSP", Description = null, WebAddress = null, }, 
               new Skill { Title = "JUnit", Description = null, WebAddress = null, }, 
               new Skill { Title = "log4cplus", Description = null, WebAddress = null, }, 
               new Skill { Title = "Log4j", Description = null, WebAddress = null, }, 
               new Skill { Title = "MFC", Description = null, WebAddress = null, }, 
               new Skill { Title = "Microsoft Access", Description = null, WebAddress = null, }, 
               new Skill { Title = "Microsoft Office", Description = null, WebAddress = null, }, 
               new Skill { Title = "Microsoft SQL Server", Description = null, WebAddress = null, }, 
               new Skill { Title = "Microsoft Visio", Description = null, WebAddress = null, }, 
               new Skill { Title = "Microsoft Visual Source Safe", Description = null, WebAddress = null, }, 
               new Skill { Title = "Microsoft VisualStudio.NET", Description = null, WebAddress = null, }, 
               new Skill { Title = "Oracle", Description = null, WebAddress = null, }, 
               new Skill { Title = "Oracle Reports", Description = null, WebAddress = null, }, 
               new Skill { Title = "PL/SQL", Description = null, WebAddress = null, }, 
               new Skill { Title = "STL", Description = null, WebAddress = null, }, 
               new Skill { Title = "SVN", Description = null, WebAddress = null, }, 
               new Skill { Title = "T4 Codegenerator", Description = null, WebAddress = null, }, 
               new Skill { Title = "Team Explorer", Description = null, WebAddress = null, }, 
               new Skill { Title = "TortoiseSVN", Description = null, WebAddress = null, }, 
               new Skill { Title = "Transact-SQL", Description = null, WebAddress = null, }, 
               new Skill { Title = "VB.NET (Visual Basic .NET)", Description = null, WebAddress = null, }, 
               new Skill { Title = "VBA (Visual Basic for Applications)", Description = null, WebAddress = null, }, 
               new Skill { Title = "VBScript (Visual Basic Script)", Description = null, WebAddress = null, }, 
               new Skill { Title = "Visual Studio 2013", Description = null, WebAddress = null, }, 
               new Skill { Title = "Windows 7", Description = null, WebAddress = null, }, 
               new Skill { Title = "Windows Forms", Description = null, WebAddress = null, }, 
               new Skill { Title = "Windows Virtual PC", Description = null, WebAddress = null, }, 
               new Skill { Title = "Windows Workflow Foundation", Description = null, WebAddress = null, }, 
               new Skill { Title = "Xerces-c", Description = null, WebAddress = null, }, 
               new Skill { Title = "XML", Description = null, WebAddress = null, }, 
               new Skill { Title = "XSD", Description = null, WebAddress = null, }, 
               new Skill { Title = "XSLT", Description = null, WebAddress = null, } 
            );
            context.SaveChanges();
            
            Person person = null;

            person = new Person { LastName = "Free", BirthName = null, FirstName = "Lance", MartialStatus = "married", NumberOfChildren =  0 , BirthDate = DateTime.Parse("1969-04-21"), PlaceOfBirth = "Munich, Bavaria, Germany", Nationality = "german", Notes = null, Category = null };
            context.People.Add(person);
            context.SaveChanges();
            
            Address address = null;

            address = new Address { ZipPostalCode = "80939", City = "Munich", StateProvince = "Bavaria", Usage = "Business", Street = "Goethestr. 123", PersonId = person.ID };
            context.ContactDetails.Add(address);
            context.SaveChanges();

            Email email = null;

            email = new Email { EMailAddress = "lancef@example.com", Usage = "Home", PersonId = person.ID };
            context.ContactDetails.Add(email);
            context.SaveChanges();

            email = new Email { EMailAddress = "lance.free@example.com", Usage = "Business", PersonId = person.ID };
            context.ContactDetails.Add(email);
            context.SaveChanges();

            Phone phone = null;

            phone = new Phone { Number = "0123.456789", Usage = "Mobile", PersonId = person.ID };
            context.ContactDetails.Add(phone);
            context.SaveChanges();
            
            Resume resume = null;

            resume = new Resume { Title = "Web Developer", Visible = true, WorkAuthorisationFor = "I am authorised to work in this country for any employer", CurrentCareerLevel = "Experienced", CurrentEducationLevel = "Master's Degree", SalaryFrom = 80000 , SalaryTo = 100000 , PreferredCountry = "Germany", PreferredLocation = "Berlin", DesiredJobType = "Temporary/Contract/Project", DesiredJobStatus = "Full-time/Part-time/Per Day", TravelDaysPerMonth = 5, AvailabilityDate = DateTime.Parse("2014-07-01"), Notes = null, PersonId = person.ID };
            context.Resumes.Add(resume);
            context.SaveChanges();
            
            List<Education> education = new List<Education>
            {
               new Education { SchoolInstitution = "Middleham University", Degree = "MBA for Distance Learning", DateFrom = DateTime.Parse("1990-11-01"), DateTo = DateTime.Parse("1996-01-31"), Concentrations = null, City = "Madison", StateProvince = null, CountryRegion = null, Description = null, PersonId = resume.ID }, 
               new Education { SchoolInstitution = "Shri Ganga Higher Secondary School", Degree = null, DateFrom = DateTime.Parse("1978-07-01"), DateTo = DateTime.Parse("1979-06-30"), Concentrations = "Psychology, Community Psychology", City = "New York", StateProvince = null, CountryRegion = null, Description = null, PersonId = resume.ID }, 
            }; 
            education.ForEach(e => context.Education.Add(e));
            
            List<Language> languages = new List<Language>
            {
               new Language { LanguageName = "English", Level = "Fluent", PersonId = person.ID }, 
               new Language { LanguageName = "Arabic", Level = "Fluent", PersonId = person.ID }, 
               new Language { LanguageName = "Spanish", Level = "Advanced", PersonId = person.ID }, 
            }; 
            languages.ForEach(e => context.Languages.Add(e));
            
            List<Attachment> attachments = new List<Attachment>
            {
               new Attachment { Title = "Enterprise Developer", AttachmentType = "Certificate of Learning", AttachmentDate = DateTime.Parse("2013-06-13"), FileType = "JPEG", FilePath = "Certificate02.JPG", Summary = null, PersonId = resume.ID }, 
               new Attachment { Title = "Windows Azure IaaS", AttachmentType = "Certificate of Learning", AttachmentDate = DateTime.Parse("2013-08-22"), FileType = "JPEG", FilePath = "Certificate01.JPG", Summary = null, PersonId = resume.ID }, 
            }; 
            attachments.ForEach(e => context.Attachments.Add(e));
            
            List<Certification> certifications = new List<Certification>
            {
               new Certification { Title = "Designing Applications for Windows Azure", InstitutionName = "Virtual Academy", DateOfReceipt = DateTime.Parse("2012-02-05"), City = "Online", StateProvince = null, CountryRegion = null, Summary = null, PersonId = resume.ID }, 
               new Certification { Title = "Building Modern Web Apps", InstitutionName = "Virtual Academy", DateOfReceipt = DateTime.Parse("2012-05-11"), City = "Online", StateProvince = null, CountryRegion = null, Summary = null, PersonId = resume.ID }, 
            }; 
            certifications.ForEach(e => context.Certifications.Add(e));
            
            Experience experience = null;
            List<SkillMatrix> skillmatrix = null;

            experience = new Experience { Employer = "Micron Computers Ltd.", JobTitle = "Web Developer", Industry = null, City = "New York", StateProvince = null, CountryRegion = null, Description = null, StartDate = DateTime.Parse("2014-01-01"), EndDate = DateTime.Parse("2014-04-30"), Responsibilities = null, Visible = true, ResumeId = resume.ID };
            context.Experiences.Add(experience);
            context.SaveChanges();

            experience = new Experience { Employer = "Amiantit Groups of Companies", JobTitle = "Software Developer", Industry = null, City = null, StateProvince = null, CountryRegion = "Saudi Arabia", Description = "Software Developer", StartDate = DateTime.Parse("2013-01-01"), EndDate = DateTime.Parse("2013-08-31"), Responsibilities = null, Visible = true, ResumeId = resume.ID };
            context.Experiences.Add(experience);
            context.SaveChanges();

            skillmatrix = new List<SkillMatrix>
            {
               new SkillMatrix { Level = null, StartDate = DateTime.Parse("2013-01-01"), EndDate = DateTime.Parse("2013-08-31"), SkillId = context.Skills.Single(c => c.Title == "COM" ).ID, ExperienceId = experience.ID }, 
               new SkillMatrix { Level = null, StartDate = DateTime.Parse("2013-01-01"), EndDate = DateTime.Parse("2013-08-31"), SkillId = context.Skills.Single(c => c.Title == "ADO" ).ID, ExperienceId = experience.ID }, 
               new SkillMatrix { Level = null, StartDate = DateTime.Parse("2013-01-01"), EndDate = DateTime.Parse("2013-08-31"), SkillId = context.Skills.Single(c => c.Title == "Apache Ant" ).ID, ExperienceId = experience.ID }, 
               new SkillMatrix { Level = null, StartDate = DateTime.Parse("2013-01-01"), EndDate = DateTime.Parse("2013-08-31"), SkillId = context.Skills.Single(c => c.Title == "Microsoft Office" ).ID, ExperienceId = experience.ID }, 
               new SkillMatrix { Level = null, StartDate = DateTime.Parse("2013-01-01"), EndDate = DateTime.Parse("2013-08-31"), SkillId = context.Skills.Single(c => c.Title == "MFC" ).ID, ExperienceId = experience.ID }, 
               new SkillMatrix { Level = null, StartDate = DateTime.Parse("2013-01-01"), EndDate = DateTime.Parse("2013-08-31"), SkillId = context.Skills.Single(c => c.Title == "XSLT" ).ID, ExperienceId = experience.ID }, 
               new SkillMatrix { Level = null, StartDate = DateTime.Parse("2013-01-01"), EndDate = DateTime.Parse("2013-08-31"), SkillId = context.Skills.Single(c => c.Title == "Oracle" ).ID, ExperienceId = experience.ID }, 
               new SkillMatrix { Level = null, StartDate = DateTime.Parse("2013-01-01"), EndDate = DateTime.Parse("2013-08-31"), SkillId = context.Skills.Single(c => c.Title == "Microsoft SQL Server" ).ID, ExperienceId = experience.ID }, 
               new SkillMatrix { Level = null, StartDate = DateTime.Parse("2013-01-01"), EndDate = DateTime.Parse("2013-08-31"), SkillId = context.Skills.Single(c => c.Title == "Transact-SQL" ).ID, ExperienceId = experience.ID }, 
               new SkillMatrix { Level = null, StartDate = DateTime.Parse("2013-01-01"), EndDate = DateTime.Parse("2013-08-31"), SkillId = context.Skills.Single(c => c.Title == "VBA (Visual Basic for Applications)" ).ID, ExperienceId = experience.ID }, 
               new SkillMatrix { Level = null, StartDate = DateTime.Parse("2013-01-01"), EndDate = DateTime.Parse("2013-08-31"), SkillId = context.Skills.Single(c => c.Title == "VBScript (Visual Basic Script)" ).ID, ExperienceId = experience.ID }, 
               new SkillMatrix { Level = null, StartDate = DateTime.Parse("2013-01-01"), EndDate = DateTime.Parse("2013-08-31"), SkillId = context.Skills.Single(c => c.Title == "C++" ).ID, ExperienceId = experience.ID }, 
               new SkillMatrix { Level = null, StartDate = DateTime.Parse("2013-01-01"), EndDate = DateTime.Parse("2013-08-31"), SkillId = context.Skills.Single(c => c.Title == "XML" ).ID, ExperienceId = experience.ID }
            };
            skillmatrix.ForEach(e => context.SkillMatrix.Add(e));

            experience = new Experience { Employer = "Amiantit Groups of Companies", JobTitle = "QC Supervisor", Industry = null, City = "Dammam", StateProvince = null, CountryRegion = "Saudi Arabia", Description = "Manage and monitor the quality of all finished products (Wool Line, Rigid Pipe and Ceiling Board Line) to maintain the company’s high standard and meet the market requirements.", StartDate = DateTime.Parse("1999-02-01"), EndDate = DateTime.Parse("1997-12-31"), Responsibilities = "Responsible in maintaining/Developing the product quality, Batch Formulation, chemical plant formulation for resin material, quality & Process audit. ", Visible = true, ResumeId = resume.ID };
            context.Experiences.Add(experience);
            context.SaveChanges();
        }

        bool AddUserAndRole(ApplicationDbContext context)
        {
            var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            
            IdentityResult ir = rm.Create(new IdentityRole("canEdit"));
            var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var user = new ApplicationUser()
            {
                UserName = "user1",
            };
            ir = um.Create(user, "Passw0rd1");
            if (ir.Succeeded == false)
                return ir.Succeeded;

            ir = um.AddToRole(user.Id, "canEdit");
           
            return ir.Succeeded;
        }
    }
}

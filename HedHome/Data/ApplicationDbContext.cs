using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HedHome.Models;
using HedHome.Models.HedDataModel;

namespace HedHome.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Campus> Campuses { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<SubjectType> SubjectTypes { get; set; }
        public DbSet<DurationType> DurationTypes { get; set; }
        public DbSet<StudyType> StudyTypes { get; set; }
        public DbSet<DeliveryType> DeliveryTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Prerequisite>()
                .HasKey(k => new {k.ParentId, k.ChildId});

            builder.Entity<Prerequisite>()
                .HasOne(p => p.ParentCourse)
                .WithMany(p => p.PrerequisitesFor)
                .HasForeignKey(p => p.ParentId);

            builder.Entity<Prerequisite>()
                .HasOne(p => p.ChildCourse)
                .WithMany(p => p.PrerequisitesOf)
                .HasForeignKey(p => p.ChildId);

            builder.Entity<CourseSkill>()
                .HasKey(k => new {k.CourseId, k.SkillId});

            builder.Entity<CourseSkill>()
                .HasOne(cs => cs.Course)
                .WithMany(c => c.CourseSkills)
                .HasForeignKey(cs => cs.CourseId);

            builder.Entity<CourseSkill>()
                .HasOne(cs => cs.Skill)
                .WithMany(s => s.CourseSkills)
                .HasForeignKey(cs => cs.SkillId);

            builder.Entity<InstitutionFaculty>()
                .HasKey(k => new {k.InstitutionId, k.FacultyId});

            builder.Entity<InstitutionFaculty>()
                .HasOne(lf => lf.Institution)
                .WithMany(l => l.InstitutionFaculties)
                .HasForeignKey(lf => lf.InstitutionId);

            builder.Entity<InstitutionFaculty>()
                .HasOne(lf => lf.Faculty)
                .WithMany(f => f.InstitutionFaculties)
                .HasForeignKey(lf => lf.FacultyId);
        }

        public DbSet<HedHome.Models.HedDataModel.CourseSkill> CourseSkill { get; set; }
    }
}

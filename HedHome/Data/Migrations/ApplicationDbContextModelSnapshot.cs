﻿// <auto-generated />
using HedHome.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace HedHome.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HedHome.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("HedHome.Models.HedDataModel.Campus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Campuses");
                });

            modelBuilder.Entity("HedHome.Models.HedDataModel.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("HedHome.Models.HedDataModel.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CampusId");

                    b.Property<int?>("CityId");

                    b.Property<bool>("CompetencyBased");

                    b.Property<string>("CourseNumber");

                    b.Property<int?>("DeliveryTypeId");

                    b.Property<string>("Description");

                    b.Property<int>("Duration");

                    b.Property<int?>("DurationTypeId");

                    b.Property<int>("DurationValue");

                    b.Property<int?>("FacultyId");

                    b.Property<int?>("InstitutionId");

                    b.Property<bool>("PracticumRequired");

                    b.Property<decimal>("StudentPrice");

                    b.Property<int?>("StudyTypeId");

                    b.Property<int?>("SubjectTypeId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("CampusId");

                    b.HasIndex("CityId");

                    b.HasIndex("DeliveryTypeId");

                    b.HasIndex("DurationTypeId");

                    b.HasIndex("FacultyId");

                    b.HasIndex("InstitutionId");

                    b.HasIndex("StudyTypeId");

                    b.HasIndex("SubjectTypeId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("HedHome.Models.HedDataModel.CourseSkill", b =>
                {
                    b.Property<int>("CourseId");

                    b.Property<int>("SkillId");

                    b.HasKey("CourseId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("CourseSkill");
                });

            modelBuilder.Entity("HedHome.Models.HedDataModel.DeliveryType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("DeliveryTypes");
                });

            modelBuilder.Entity("HedHome.Models.HedDataModel.DurationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("DurationTypes");
                });

            modelBuilder.Entity("HedHome.Models.HedDataModel.Faculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("HedHome.Models.HedDataModel.Institution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Institutions");
                });

            modelBuilder.Entity("HedHome.Models.HedDataModel.InstitutionFaculty", b =>
                {
                    b.Property<int>("InstitutionId");

                    b.Property<int>("FacultyId");

                    b.HasKey("InstitutionId", "FacultyId");

                    b.HasIndex("FacultyId");

                    b.ToTable("InstitutionFaculty");
                });

            modelBuilder.Entity("HedHome.Models.HedDataModel.Prerequisite", b =>
                {
                    b.Property<int>("ParentId");

                    b.Property<int>("ChildId");

                    b.HasKey("ParentId", "ChildId");

                    b.HasIndex("ChildId");

                    b.ToTable("Prerequisite");
                });

            modelBuilder.Entity("HedHome.Models.HedDataModel.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("HedHome.Models.HedDataModel.StudyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("StudyTypes");
                });

            modelBuilder.Entity("HedHome.Models.HedDataModel.SubjectType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("SubjectTypes");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("HedHome.Models.HedDataModel.Course", b =>
                {
                    b.HasOne("HedHome.Models.HedDataModel.Campus", "Campus")
                        .WithMany()
                        .HasForeignKey("CampusId");

                    b.HasOne("HedHome.Models.HedDataModel.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("HedHome.Models.HedDataModel.DeliveryType", "DeliveryType")
                        .WithMany()
                        .HasForeignKey("DeliveryTypeId");

                    b.HasOne("HedHome.Models.HedDataModel.DurationType", "DurationType")
                        .WithMany()
                        .HasForeignKey("DurationTypeId");

                    b.HasOne("HedHome.Models.HedDataModel.Faculty", "Faculty")
                        .WithMany()
                        .HasForeignKey("FacultyId");

                    b.HasOne("HedHome.Models.HedDataModel.Institution", "Institution")
                        .WithMany()
                        .HasForeignKey("InstitutionId");

                    b.HasOne("HedHome.Models.HedDataModel.StudyType", "StudyType")
                        .WithMany()
                        .HasForeignKey("StudyTypeId");

                    b.HasOne("HedHome.Models.HedDataModel.SubjectType", "SubjectType")
                        .WithMany()
                        .HasForeignKey("SubjectTypeId");
                });

            modelBuilder.Entity("HedHome.Models.HedDataModel.CourseSkill", b =>
                {
                    b.HasOne("HedHome.Models.HedDataModel.Course", "Course")
                        .WithMany("CourseSkills")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HedHome.Models.HedDataModel.Skill", "Skill")
                        .WithMany("CourseSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HedHome.Models.HedDataModel.InstitutionFaculty", b =>
                {
                    b.HasOne("HedHome.Models.HedDataModel.Faculty", "Faculty")
                        .WithMany("InstitutionFaculties")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HedHome.Models.HedDataModel.Institution", "Institution")
                        .WithMany("InstitutionFaculties")
                        .HasForeignKey("InstitutionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HedHome.Models.HedDataModel.Prerequisite", b =>
                {
                    b.HasOne("HedHome.Models.HedDataModel.Course", "ChildCourse")
                        .WithMany("PrerequisitesOf")
                        .HasForeignKey("ChildId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HedHome.Models.HedDataModel.Course", "ParentCourse")
                        .WithMany("PrerequisitesFor")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("HedHome.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("HedHome.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HedHome.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("HedHome.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

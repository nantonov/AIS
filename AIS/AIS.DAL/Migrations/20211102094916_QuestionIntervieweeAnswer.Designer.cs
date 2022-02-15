﻿// <auto-generated />
using System;
using AIS.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AIS.DAL.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20211102094916_QuestionIntervieweeAnswer")]
    partial class QuestionIntervieweeAnswer
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AIS.DAL.Entities.CompanyEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("AIS.DAL.Entities.EmployeeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("AIS.DAL.Entities.IntervieweeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AppliesFor")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("AppliesFor");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Interviewees");
                });

            modelBuilder.Entity("AIS.DAL.Entities.QuestionAreaEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("QuestionAreas");
                });

            modelBuilder.Entity("AIS.DAL.Entities.QuestionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("QuestionSetId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionSetId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("AIS.DAL.Entities.QuestionIntervieweeAnswerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Mark")
                        .HasColumnType("int");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrueAnswerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("TrueAnswerId");

                    b.ToTable("QuestionIntervieweeAnswers");
                });

            modelBuilder.Entity("AIS.DAL.Entities.QuestionSetEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionAreaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionAreaId");

                    b.ToTable("QuestionSets");
                });

            modelBuilder.Entity("AIS.DAL.Entities.SessionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FinishedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("IntervieweeId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionAreaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("IntervieweeId");

                    b.HasIndex("QuestionAreaId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("AIS.DAL.Entities.TrueAnswerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId")
                        .IsUnique();

                    b.ToTable("TrueAnswers");
                });

            modelBuilder.Entity("AIS.DAL.Entities.EmployeeEntity", b =>
                {
                    b.HasOne("AIS.DAL.Entities.CompanyEntity", "Company")
                        .WithMany("Employees")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("AIS.DAL.Entities.IntervieweeEntity", b =>
                {
                    b.HasOne("AIS.DAL.Entities.CompanyEntity", "Company")
                        .WithMany("Interviewees")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("AIS.DAL.Entities.QuestionEntity", b =>
                {
                    b.HasOne("AIS.DAL.Entities.QuestionSetEntity", "QuestionSet")
                        .WithMany("Questions")
                        .HasForeignKey("QuestionSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QuestionSet");
                });

            modelBuilder.Entity("AIS.DAL.Entities.QuestionIntervieweeAnswerEntity", b =>
                {
                    b.HasOne("AIS.DAL.Entities.QuestionEntity", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AIS.DAL.Entities.TrueAnswerEntity", "TrueAnswer")
                        .WithMany()
                        .HasForeignKey("TrueAnswerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");

                    b.Navigation("TrueAnswer");
                });

            modelBuilder.Entity("AIS.DAL.Entities.QuestionSetEntity", b =>
                {
                    b.HasOne("AIS.DAL.Entities.QuestionAreaEntity", "QuestionArea")
                        .WithMany("QuestionSets")
                        .HasForeignKey("QuestionAreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QuestionArea");
                });

            modelBuilder.Entity("AIS.DAL.Entities.SessionEntity", b =>
                {
                    b.HasOne("AIS.DAL.Entities.CompanyEntity", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AIS.DAL.Entities.EmployeeEntity", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AIS.DAL.Entities.IntervieweeEntity", "Interviewee")
                        .WithMany()
                        .HasForeignKey("IntervieweeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AIS.DAL.Entities.QuestionAreaEntity", "QuestionArea")
                        .WithMany()
                        .HasForeignKey("QuestionAreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Employee");

                    b.Navigation("Interviewee");

                    b.Navigation("QuestionArea");
                });

            modelBuilder.Entity("AIS.DAL.Entities.TrueAnswerEntity", b =>
                {
                    b.HasOne("AIS.DAL.Entities.QuestionEntity", "Question")
                        .WithOne("TrueAnswer")
                        .HasForeignKey("AIS.DAL.Entities.TrueAnswerEntity", "QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("AIS.DAL.Entities.CompanyEntity", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Interviewees");
                });

            modelBuilder.Entity("AIS.DAL.Entities.QuestionAreaEntity", b =>
                {
                    b.Navigation("QuestionSets");
                });

            modelBuilder.Entity("AIS.DAL.Entities.QuestionEntity", b =>
                {
                    b.Navigation("TrueAnswer");
                });

            modelBuilder.Entity("AIS.DAL.Entities.QuestionSetEntity", b =>
                {
                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
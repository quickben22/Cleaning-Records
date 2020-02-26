﻿// <auto-generated />
using System;
using CleaningRecords.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CleaningRecords.Migrations
{
    [DbContext(typeof(PodaciContext))]
    [Migration("20200225124457_init12")]
    partial class init12
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1");

            modelBuilder.Entity("CleaningRecords.DAL.Models.Cleaner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<int>("CleanerStatus")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Color")
                        .HasColumnType("TEXT");

                    b.Property<string>("Contract")
                        .HasColumnType("TEXT");

                    b.Property<string>("DriversLicence")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Friday")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Friday2")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FridayEnd")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FridayEnd2")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FridayStart")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FridayStart2")
                        .HasColumnType("TEXT");

                    b.Property<string>("Ironing")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Monday")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Monday2")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("MondayEnd")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("MondayEnd2")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("MondayStart")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("MondayStart2")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<bool>("NotAvailable")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("NotAvailable2")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("NotAvailableEnd")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("NotAvailableEnd2")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("NotAvailableStart")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("NotAvailableStart2")
                        .HasColumnType("TEXT");

                    b.Property<string>("PPS")
                        .HasColumnType("TEXT");

                    b.Property<string>("Pets")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Saturday")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Saturday2")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("SaturdayEnd")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("SaturdayEnd2")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("SaturdayStart")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("SaturdayStart2")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Sunday")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Sunday2")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("SundayEnd")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("SundayEnd2")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("SundayStart")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("SundayStart2")
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telephone")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Thursday")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Thursday2")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ThursdayEnd")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ThursdayEnd2")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ThursdayStart")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ThursdayStart2")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Tuesday")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Tuesday2")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("TuesdayEnd")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TuesdayEnd2")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TuesdayStart")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TuesdayStart2")
                        .HasColumnType("TEXT");

                    b.Property<string>("Visa")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Wednesday")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Wednesday2")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("WednesdayEnd")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("WednesdayEnd2")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("WednesdayStart")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("WednesdayStart2")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cleaners");
                });

            modelBuilder.Entity("CleaningRecords.DAL.Models.CleanerTeam", b =>
                {
                    b.Property<int>("CleanerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeamId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CleanerId", "TeamId");

                    b.HasIndex("TeamId");

                    b.ToTable("CleanerTeam");
                });

            modelBuilder.Entity("CleaningRecords.DAL.Models.CleaningJob", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<int?>("CleanerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("Day")
                        .HasColumnType("INTEGER");

                    b.Property<int>("JobStatus")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Location")
                        .HasColumnType("TEXT");

                    b.Property<int?>("LocationId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("NoOfHours")
                        .HasColumnType("REAL");

                    b.Property<int?>("RepeatJobId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ServiceId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TeamId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("TimeEnd")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TimeStart")
                        .HasColumnType("TEXT");

                    b.Property<int>("Week")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CleanerId");

                    b.HasIndex("ClientId");

                    b.HasIndex("RepeatJobId");

                    b.HasIndex("ServiceId");

                    b.HasIndex("TeamId");

                    b.ToTable("CleaningJobs");
                });

            modelBuilder.Entity("CleaningRecords.DAL.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("Address2")
                        .HasColumnType("TEXT");

                    b.Property<string>("Address3")
                        .HasColumnType("TEXT");

                    b.Property<string>("Address4")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClientNumber")
                        .HasColumnType("TEXT");

                    b.Property<int>("ClientStatus")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Instructions")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telephone")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("CleaningRecords.DAL.Models.RepeatJob", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AllDays")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RepeatFrequency")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("RepeatJobs");
                });

            modelBuilder.Entity("CleaningRecords.DAL.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Color")
                        .HasColumnType("TEXT");

                    b.Property<double>("Cost")
                        .HasColumnType("REAL");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<double>("Rate")
                        .HasColumnType("REAL");

                    b.Property<int>("ServiceStatus")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("CleaningRecords.DAL.Models.ServiceJob", b =>
                {
                    b.Property<int>("ServiceId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CleaningJobId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ServiceId", "CleaningJobId");

                    b.HasIndex("CleaningJobId");

                    b.ToTable("ServiceJob");
                });

            modelBuilder.Entity("CleaningRecords.DAL.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Color")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("TeamStatus")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("CleaningRecords.DAL.Models.CleanerTeam", b =>
                {
                    b.HasOne("CleaningRecords.DAL.Models.Cleaner", "Cleaner")
                        .WithMany("CleanerTeams")
                        .HasForeignKey("CleanerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CleaningRecords.DAL.Models.Team", "Team")
                        .WithMany("CleanerTeams")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CleaningRecords.DAL.Models.CleaningJob", b =>
                {
                    b.HasOne("CleaningRecords.DAL.Models.Cleaner", "Cleaner")
                        .WithMany("CleaningJobs")
                        .HasForeignKey("CleanerId");

                    b.HasOne("CleaningRecords.DAL.Models.Client", "Client")
                        .WithMany("CleaningJobs")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CleaningRecords.DAL.Models.RepeatJob", "RepeatJob")
                        .WithMany("CleaningJobs")
                        .HasForeignKey("RepeatJobId");

                    b.HasOne("CleaningRecords.DAL.Models.Service", "Service")
                        .WithMany("CleaningJobs")
                        .HasForeignKey("ServiceId");

                    b.HasOne("CleaningRecords.DAL.Models.Team", "Team")
                        .WithMany("CleaningJobs")
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("CleaningRecords.DAL.Models.ServiceJob", b =>
                {
                    b.HasOne("CleaningRecords.DAL.Models.CleaningJob", "CleaningJob")
                        .WithMany("ServiceJobs")
                        .HasForeignKey("CleaningJobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CleaningRecords.DAL.Models.Service", "Service")
                        .WithMany("ServiceJobs")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

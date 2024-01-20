﻿// <auto-generated />
using System;
using ECOPlantation.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ECOPlantation.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240120103820_fertilizer")]
    partial class fertilizer
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ECOPlantation.Models.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ApplicationUsers");
                });

            modelBuilder.Entity("ECOPlantation.Models.DonationPayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("DonatedBy")
                        .HasColumnType("int");

                    b.Property<int?>("DonatedUserId")
                        .HasColumnType("int");

                    b.Property<int>("RequestedDonation")
                        .HasColumnType("int");

                    b.Property<double>("TotalDonation")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("DonatedUserId");

                    b.HasIndex("RequestedDonation");

                    b.ToTable("DonationPayments");
                });

            modelBuilder.Entity("ECOPlantation.Models.DonationRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Donated")
                        .HasColumnType("bit");

                    b.Property<string>("RequestPhotoURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RequestedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RequestedBy");

                    b.ToTable("DonationRequests");
                });

            modelBuilder.Entity("ECOPlantation.Models.Fertilizers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FertilizerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("MsgDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PlantName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("userID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("userID");

                    b.ToTable("Fertilizers");
                });

            modelBuilder.Entity("ECOPlantation.Models.Invite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Organiser")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Organiser");

                    b.ToTable("Invites");
                });

            modelBuilder.Entity("ECOPlantation.Models.News", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("NewsContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NewsPhotoURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NewsTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostedBy");

                    b.ToTable("News");
                });

            modelBuilder.Entity("ECOPlantation.Models.PlantCount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("NoOfPlants")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("PlantCounts");
                });

            modelBuilder.Entity("ECOPlantation.Models.Visitor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("InviteID")
                        .HasColumnType("int");

                    b.Property<int>("VistorID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InviteID");

                    b.HasIndex("VistorID");

                    b.ToTable("Visitors");
                });

            modelBuilder.Entity("ECOPlantation.Models.DonationPayment", b =>
                {
                    b.HasOne("ECOPlantation.Models.ApplicationUser", "DonatedUser")
                        .WithMany()
                        .HasForeignKey("DonatedUserId");

                    b.HasOne("ECOPlantation.Models.DonationRequest", "DonationId")
                        .WithMany()
                        .HasForeignKey("RequestedDonation")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DonatedUser");

                    b.Navigation("DonationId");
                });

            modelBuilder.Entity("ECOPlantation.Models.DonationRequest", b =>
                {
                    b.HasOne("ECOPlantation.Models.ApplicationUser", "RequestedUser")
                        .WithMany()
                        .HasForeignKey("RequestedBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RequestedUser");
                });

            modelBuilder.Entity("ECOPlantation.Models.Fertilizers", b =>
                {
                    b.HasOne("ECOPlantation.Models.ApplicationUser", "UserFertilizer")
                        .WithMany()
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserFertilizer");
                });

            modelBuilder.Entity("ECOPlantation.Models.Invite", b =>
                {
                    b.HasOne("ECOPlantation.Models.ApplicationUser", "OrganiserFK")
                        .WithMany()
                        .HasForeignKey("Organiser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrganiserFK");
                });

            modelBuilder.Entity("ECOPlantation.Models.News", b =>
                {
                    b.HasOne("ECOPlantation.Models.ApplicationUser", "Poster")
                        .WithMany()
                        .HasForeignKey("PostedBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Poster");
                });

            modelBuilder.Entity("ECOPlantation.Models.Visitor", b =>
                {
                    b.HasOne("ECOPlantation.Models.Invite", "InvitedBy")
                        .WithMany()
                        .HasForeignKey("InviteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECOPlantation.Models.ApplicationUser", "VisitorFK")
                        .WithMany()
                        .HasForeignKey("VistorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InvitedBy");

                    b.Navigation("VisitorFK");
                });
#pragma warning restore 612, 618
        }
    }
}

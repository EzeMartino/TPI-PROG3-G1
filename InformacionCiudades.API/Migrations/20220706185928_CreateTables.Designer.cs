﻿// <auto-generated />
using Contents.API.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Contents.API.Migrations
{
    [DbContext(typeof(ContentContext))]
    [Migration("20220706185928_CreateTables")]
    partial class CreateTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.6");

            modelBuilder.Entity("Contents.API.Entities.Content", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Comment")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<int>("Duration")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Rating")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Contents");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "Category 1",
                            Comment = "Comment 1",
                            Duration = 12,
                            Rating = 5,
                            Title = "Title 1",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Category = "Category 2",
                            Comment = "Comment 2",
                            Duration = 12,
                            Rating = 6,
                            Title = "Title 2",
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            Category = "Category 3",
                            Comment = "Comment 3",
                            Duration = 12,
                            Rating = 7,
                            Title = "Title 3",
                            UserId = 3
                        });
                });

            modelBuilder.Entity("Contents.API.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "email1@email.com",
                            Password = "password1",
                            Username = "User 1"
                        },
                        new
                        {
                            Id = 2,
                            Email = "email2@email.com",
                            Password = "password2",
                            Username = "User 2"
                        },
                        new
                        {
                            Id = 3,
                            Email = "email3@email.com",
                            Password = "password3",
                            Username = "User 3"
                        });
                });

            modelBuilder.Entity("Contents.API.Entities.Content", b =>
                {
                    b.HasOne("Contents.API.Entities.User", "User")
                        .WithMany("Contents")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Contents.API.Entities.User", b =>
                {
                    b.Navigation("Contents");
                });
#pragma warning restore 612, 618
        }
    }
}
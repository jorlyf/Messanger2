﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using back.Contexts;

#nullable disable

namespace back.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220711103518_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.6");

            modelBuilder.Entity("back.Models.ChatAttachment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ChatMessageId")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("Type")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ChatMessageId");

                    b.ToTable("ChatAttachment");
                });

            modelBuilder.Entity("back.Models.ChatDialog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("ChatDialogs");
                });

            modelBuilder.Entity("back.Models.ChatMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ChatDialogId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SenderId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ChatDialogId");

                    b.HasIndex("SenderId");

                    b.ToTable("ChatMessage");
                });

            modelBuilder.Entity("back.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AvatarUrl")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ChatDialogId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ChatDialogId");

                    b.HasIndex("Login")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("back.Models.ChatAttachment", b =>
                {
                    b.HasOne("back.Models.ChatMessage", null)
                        .WithMany("Attachments")
                        .HasForeignKey("ChatMessageId");
                });

            modelBuilder.Entity("back.Models.ChatMessage", b =>
                {
                    b.HasOne("back.Models.ChatDialog", null)
                        .WithMany("Messages")
                        .HasForeignKey("ChatDialogId");

                    b.HasOne("back.Models.User", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("back.Models.User", b =>
                {
                    b.HasOne("back.Models.ChatDialog", null)
                        .WithMany("Users")
                        .HasForeignKey("ChatDialogId");
                });

            modelBuilder.Entity("back.Models.ChatDialog", b =>
                {
                    b.Navigation("Messages");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("back.Models.ChatMessage", b =>
                {
                    b.Navigation("Attachments");
                });
#pragma warning restore 612, 618
        }
    }
}
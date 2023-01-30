﻿// <auto-generated />
using System;
using ConsoleMessengerServer.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConsoleMessengerServer.Migrations
{
    [DbContext(typeof(MessengerDbContext))]
    partial class MessengerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ConsoleMessengerServer.Entities.Dialog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Dialogs");
                });

            modelBuilder.Entity("ConsoleMessengerServer.Entities.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("DialogId")
                        .HasColumnType("int");

                    b.Property<bool>("IsRead")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserSenderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DialogId");

                    b.HasIndex("UserSenderId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("ConsoleMessengerServer.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.HasKey("Id");

                    b.HasAlternateKey("PhoneNumber");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DialogUser", b =>
                {
                    b.Property<int>("DialogsId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("DialogsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("DialogUser");
                });

            modelBuilder.Entity("ConsoleMessengerServer.Entities.Message", b =>
                {
                    b.HasOne("ConsoleMessengerServer.Entities.Dialog", "Dialog")
                        .WithMany("Messages")
                        .HasForeignKey("DialogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConsoleMessengerServer.Entities.User", "UserSender")
                        .WithMany("SentMessages")
                        .HasForeignKey("UserSenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dialog");

                    b.Navigation("UserSender");
                });

            modelBuilder.Entity("DialogUser", b =>
                {
                    b.HasOne("ConsoleMessengerServer.Entities.Dialog", null)
                        .WithMany()
                        .HasForeignKey("DialogsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConsoleMessengerServer.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ConsoleMessengerServer.Entities.Dialog", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("ConsoleMessengerServer.Entities.User", b =>
                {
                    b.Navigation("SentMessages");
                });
#pragma warning restore 612, 618
        }
    }
}

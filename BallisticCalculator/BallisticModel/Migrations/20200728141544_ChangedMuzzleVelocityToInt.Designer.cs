﻿// <auto-generated />
using BallisticModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BallisticModel.Migrations
{
    [DbContext(typeof(BallisticContext))]
    [Migration("20200728141544_ChangedMuzzleVelocityToInt")]
    partial class ChangedMuzzleVelocityToInt
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BallisticModel.Ammunition", b =>
                {
                    b.Property<int>("AmmunitionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AmmunitionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Coefficient")
                        .HasColumnType("real");

                    b.Property<float>("Diameter")
                        .HasColumnType("real");

                    b.Property<float>("Grain")
                        .HasColumnType("real");

                    b.HasKey("AmmunitionID");

                    b.ToTable("Ammunition");
                });

            modelBuilder.Entity("BallisticModel.Firearm", b =>
                {
                    b.Property<int>("FirearmID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AmmunitionID")
                        .HasColumnType("int");

                    b.Property<string>("FirearmName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FirearmTypeID")
                        .HasColumnType("int");

                    b.Property<int>("MuzzleVelocity")
                        .HasColumnType("int");

                    b.HasKey("FirearmID");

                    b.HasIndex("AmmunitionID");

                    b.HasIndex("FirearmTypeID");

                    b.ToTable("Firearms");
                });

            modelBuilder.Entity("BallisticModel.FirearmType", b =>
                {
                    b.Property<int>("FirearmTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FirearmTypeID");

                    b.ToTable("FirearmTypes");
                });

            modelBuilder.Entity("BallisticModel.Firearm", b =>
                {
                    b.HasOne("BallisticModel.Ammunition", "Ammunition")
                        .WithMany("Firearm")
                        .HasForeignKey("AmmunitionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BallisticModel.FirearmType", "FirearmType")
                        .WithMany("Firearm")
                        .HasForeignKey("FirearmTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

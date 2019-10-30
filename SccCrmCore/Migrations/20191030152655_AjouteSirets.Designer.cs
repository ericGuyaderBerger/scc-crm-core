﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SccCrmCore.Models.Entities;

namespace SccCrmCore.Migrations
{
    [DbContext(typeof(CrmDbContext))]
    [Migration("20191030152655_AjouteSirets")]
    partial class AjouteSirets
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SccCrmCore.Models.Entities.Siren", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Actif");

                    b.Property<DateTime>("DateMaj");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(9);

                    b.HasKey("Id");

                    b.ToTable("Sirens");
                });

            modelBuilder.Entity("SccCrmCore.Models.Entities.Siret", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresse")
                        .IsRequired();

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(14);

                    b.Property<int>("SirenId");

                    b.HasKey("Id");

                    b.HasIndex("SirenId");

                    b.ToTable("Sirets");
                });

            modelBuilder.Entity("SccCrmCore.Models.Entities.Siret", b =>
                {
                    b.HasOne("SccCrmCore.Models.Entities.Siren", "Siren")
                        .WithMany()
                        .HasForeignKey("SirenId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

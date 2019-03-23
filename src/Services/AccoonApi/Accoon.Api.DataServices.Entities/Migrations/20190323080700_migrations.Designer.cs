﻿// <auto-generated />
using System;
using Accoon.Api.DataServices.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Accoon.Api.DataServices.Entities.Migrations
{
    [DbContext(typeof(AccoonDbContext))]
    [Migration("20190323080700_migrations")]
    partial class migrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Accoon.Api.DataServices.Entities.CustomEntities.AddressEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<long?>("CustomerId");

                    b.Property<int?>("Number");

                    b.Property<string>("Street")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Accoon.Api.DataServices.Entities.CustomEntities.CustomerEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age");

                    b.Property<int>("MyProperty");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Accoon.Api.DataServices.Entities.CustomEntities.AddressEntity", b =>
                {
                    b.HasOne("Accoon.Api.DataServices.Entities.CustomEntities.CustomerEntity", "Customer")
                        .WithMany("Addresses")
                        .HasForeignKey("CustomerId");
                });
#pragma warning restore 612, 618
        }
    }
}
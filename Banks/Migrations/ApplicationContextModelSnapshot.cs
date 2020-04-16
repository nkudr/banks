﻿// <auto-generated />
using Banks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Banks.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113");

            modelBuilder.Entity("Banks.Models.Bank", b =>
                {
                    b.Property<string>("IFSC")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ADDRESS");

                    b.Property<string>("BANK");

                    b.Property<string>("BANKCODE");

                    b.Property<string>("CITY");

                    b.HasKey("IFSC");

                    b.ToTable("Banks");
                });
#pragma warning restore 612, 618
        }
    }
}

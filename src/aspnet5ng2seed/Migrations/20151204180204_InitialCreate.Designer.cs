using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using aspnet5ng2seed.Models;

namespace aspnet5ng2seed.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20151204180204_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("aspnet5ng2seed.Models.Shipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Destination");

                    b.Property<string>("Origin");

                    b.Property<DateTime>("ShippedDate");

                    b.HasKey("Id");
                });
        }
    }
}

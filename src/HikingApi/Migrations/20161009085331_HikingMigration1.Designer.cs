using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using HikingApi.Model;

namespace HikingApi.Migrations
{
    [DbContext(typeof(HikingContext))]
    [Migration("20161009085331_HikingMigration1")]
    partial class HikingMigration1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HikingApi.Model.MapPoint", b =>
                {
                    b.Property<string>("MapPointId");

                    b.Property<double>("Elevation");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<double>("Order");

                    b.Property<string>("TrailId");

                    b.HasKey("MapPointId");

                    b.HasIndex("TrailId");

                    b.ToTable("MapPoints");
                });

            modelBuilder.Entity("HikingApi.Model.Trail", b =>
                {
                    b.Property<string>("TrailId");

                    b.Property<string>("Description");

                    b.Property<decimal>("Difficulty");

                    b.Property<decimal>("Length");

                    b.Property<string>("Name");

                    b.Property<decimal>("Rating");

                    b.HasKey("TrailId");

                    b.ToTable("Trails");
                });

            modelBuilder.Entity("HikingApi.Model.MapPoint", b =>
                {
                    b.HasOne("HikingApi.Model.Trail")
                        .WithMany("MapPoints")
                        .HasForeignKey("TrailId");
                });
        }
    }
}

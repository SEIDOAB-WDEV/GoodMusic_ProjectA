﻿// <auto-generated />
using System;
using DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DbContext.Migrations.SqlServerDbContext
{
    [DbContext(typeof(MainDbContext.SqlServerDbContext))]
    partial class SqlServerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ArtistDbMMusicGroupDbM", b =>
                {
                    b.Property<Guid>("ArtistsDbMArtistId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MusicGroupsDbMMusicGroupId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ArtistsDbMArtistId", "MusicGroupsDbMMusicGroupId");

                    b.HasIndex("MusicGroupsDbMMusicGroupId");

                    b.ToTable("ArtistDbMMusicGroupDbM", "supusr");
                });

            modelBuilder.Entity("DbModels.AlbumDbM", b =>
                {
                    b.Property<Guid>("AlbumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("CopiesSold")
                        .HasColumnType("bigint");

                    b.Property<Guid>("MusicGroupDbMMusicGroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("int");

                    b.Property<bool>("Seeded")
                        .HasColumnType("bit");

                    b.HasKey("AlbumId");

                    b.HasIndex("MusicGroupDbMMusicGroupId");

                    b.ToTable("Albums", "supusr");
                });

            modelBuilder.Entity("DbModels.ArtistDbM", b =>
                {
                    b.Property<Guid>("ArtistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("BirthDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("Seeded")
                        .HasColumnType("bit");

                    b.HasKey("ArtistId");

                    b.ToTable("Artists", "supusr");
                });

            modelBuilder.Entity("DbModels.MusicGroupDbM", b =>
                {
                    b.Property<Guid>("MusicGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("EstablishedYear")
                        .HasColumnType("int");

                    b.Property<int>("Genre")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("Seeded")
                        .HasColumnType("bit");

                    b.Property<string>("strGenre")
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("MusicGroupId");

                    b.ToTable("MusicGroups", "supusr");
                });

            modelBuilder.Entity("Models.DTO.GstUsrInfoDbDto", b =>
                {
                    b.Property<int>("NrSeededAlbums")
                        .HasColumnType("int");

                    b.Property<int>("NrSeededArtists")
                        .HasColumnType("int");

                    b.Property<int>("NrSeededMusicGroups")
                        .HasColumnType("int");

                    b.Property<int>("NrUnseededAlbums")
                        .HasColumnType("int");

                    b.Property<int>("NrUnseededMusicGroups")
                        .HasColumnType("int");

                    b.Property<int>("nrUnseededArtists")
                        .HasColumnType("int");

                    b.ToTable((string)null);

                    b.ToView("vwInfoDb", "gstusr");
                });

            modelBuilder.Entity("ArtistDbMMusicGroupDbM", b =>
                {
                    b.HasOne("DbModels.ArtistDbM", null)
                        .WithMany()
                        .HasForeignKey("ArtistsDbMArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DbModels.MusicGroupDbM", null)
                        .WithMany()
                        .HasForeignKey("MusicGroupsDbMMusicGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DbModels.AlbumDbM", b =>
                {
                    b.HasOne("DbModels.MusicGroupDbM", "MusicGroupDbM")
                        .WithMany("AlbumsDbM")
                        .HasForeignKey("MusicGroupDbMMusicGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MusicGroupDbM");
                });

            modelBuilder.Entity("DbModels.MusicGroupDbM", b =>
                {
                    b.Navigation("AlbumsDbM");
                });
#pragma warning restore 612, 618
        }
    }
}

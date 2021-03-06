// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VaccineDetecter_Backend.Data;

#nullable disable

namespace VaccineDetecter_Backend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220313150250_RemovePersonalData")]
    partial class RemovePersonalData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("VaccineDetecter_Backend.Models.MedicalTest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("PersonId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("RedBloodCell")
                        .HasColumnType("int");

                    b.Property<string>("TestDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WhiteBloodCell")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("VaccineDetecter_Backend.Models.Person", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Email");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("VaccineDetecter_Backend.Models.MedicalTest", b =>
                {
                    b.HasOne("VaccineDetecter_Backend.Models.Person", "person")
                        .WithMany("Tests")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("person");
                });

            modelBuilder.Entity("VaccineDetecter_Backend.Models.Person", b =>
                {
                    b.Navigation("Tests");
                });
#pragma warning restore 612, 618
        }
    }
}

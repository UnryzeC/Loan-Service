﻿// <auto-generated />
using LoanService.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

#nullable disable

namespace LoanService.Infrastructure.Migrations
{
    [DbContext( typeof( AppDbContext ) ) ]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel( ModelBuilder modelBuilder )
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation( "ProductVersion", "7.0.15" );

            modelBuilder.Entity( "LoanService.Core.Loan.LoanRequest", b =>
                {
                    b.Property<Guid>( "Id" ).ValueGeneratedOnAdd( ).HasColumnType( "TEXT" );

                    b.Property<Guid>( "CreatedById" ).HasColumnType( "TEXT" );

                    b.Property<DateTime>( "CreatedDateTime" ).ValueGeneratedOnAdd( ).HasColumnType( "TEXT" ).HasDefaultValueSql( "CURRENT_TIMESTAMP" );

                    b.Property<int>( "Currency" ).HasColumnType( "INTEGER" );

                    b.Property<bool>( "Deleted" ).HasColumnType( "INTEGER" );

                    b.Property<bool>( "IsActive" ).HasColumnType( "INTEGER" );

                    b.Property<Guid?>( "LoanOfficerId" ).HasColumnType( "TEXT" );

                    b.Property<int>( "LoanPeriod" ).HasColumnType( "INTEGER" );

                    b.Property<decimal>( "RequestedAmount" ).HasColumnType( "TEXT" );

                    b.Property<int>( "Status" ).HasColumnType( "INTEGER" );

                    b.Property<int>( "Type" ).HasColumnType( "INTEGER" );

                    b.Property<Guid>( "UserId" ).HasColumnType( "TEXT" );

                    b.HasKey( "Id" );

                    b.HasIndex( "LoanOfficerId" );

                    b.HasIndex( "UserId" );

                    b.ToTable( "loan_requests", (string)null );
                }
            );

            modelBuilder.Entity( "LoanService.Core.User.UserEntity", b =>
                {
                    b.Property<Guid>( "Id" ).ValueGeneratedOnAdd( ).HasColumnType( "TEXT" );

                    b.Property<Guid>( "CreatedById" ).HasColumnType( "TEXT" );

                    b.Property<DateTime>( "CreatedDateTime" ).ValueGeneratedOnAdd( ).HasColumnType( "TEXT" ).HasDefaultValueSql( "CURRENT_TIMESTAMP" );

                    b.Property<DateTime>( "DateOfBirth" ).HasColumnType( "TEXT" );

                    b.Property<bool>( "Deleted" ).HasColumnType( "INTEGER" );

                    b.Property<string>( "Email" ).IsRequired( ).HasMaxLength( 100 ).HasColumnType( "TEXT" );

                    b.Property<string>( "Firstname" ).IsRequired( ).HasMaxLength( 50 ).HasColumnType( "TEXT" );

                    b.Property<string>( "IdNumber").IsRequired( ).HasMaxLength( 11 ).HasColumnType( "TEXT" ).IsFixedLength( );

                    b.Property<bool>( "IsActive" ).HasColumnType( "INTEGER" );

                    b.Property<string>( "Lastname" ).IsRequired( ).HasMaxLength( 50 ).HasColumnType( "TEXT" );

                    b.Property<string>( "Password" ).IsRequired( ).HasMaxLength( 70 ).HasColumnType( "TEXT" );

                    b.Property<string>("Salt").IsRequired( ).HasMaxLength( 30 ).HasColumnType( "TEXT" );

                    b.HasKey( "Id" );

                    b.ToTable( "users", (string)null );

                    b.HasData(
                        new
                        {
                            Id = new Guid("4c7db504-dc3d-4ecd-baae-a78e4e1baad4"),
                            CreatedById = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreatedDateTime = new DateTime( 1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified ),
                            DateOfBirth = new DateTime( 1995, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified ),
                            Deleted = false,
                            Email = "SandroTakaishvili@example.com",
                            Firstname = "Sandro",
                            IdNumber = "62202018205",
                            IsActive = true,
                            Lastname = "Takaishvili",
                            Password = "388F706930EF4CF0F7F4D59EE9819AA5B89FBEF8D4BB4EB7AB4D28B08CF034CC",
                            Salt = "fGWDCWTrmwnYbXJbPWHwDQ=="
                        }
                   );
                }
            );

            modelBuilder.Entity( "LoanService.Core.Loan.LoanRequest", b =>
                {
                    b.HasOne( "LoanService.Core.User.UserEntity", "LoanOfficer" ).WithMany( ).HasForeignKey( "LoanOfficerId" );

                    b.HasOne( "LoanService.Core.User.UserEntity", "User" ).WithMany( "LoanRequests" ).HasForeignKey( "UserId" ).OnDelete(DeleteBehavior.NoAction ).IsRequired( );

                    b.Navigation( "LoanOfficer" );

                    b.Navigation( "User" );
                }
            );

            modelBuilder.Entity( "LoanService.Core.User.UserEntity", b =>
                {
                    b.Navigation( "LoanRequests" );
                }
            );
#pragma warning restore 612, 618
        }
    }
}

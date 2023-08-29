using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ObserverPattern.SqlConn;

namespace ObserverPattern.Models;

public partial class InfinityDbContext : DbContext
{
    public InfinityDbContext()
    {
    }

    public InfinityDbContext(DbContextOptions<InfinityDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CustomerMast> CustomerMasts { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(new Connection().GetConnectionString());

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerMast>(entity =>
        {
            entity.HasKey(e => e.TranId);

            entity.ToTable("CUSTOMER_MAST");

            entity.HasIndex(e => e.CustomerCode, "INDEX1")
                .IsUnique()
                .HasFillFactor(90);

            entity.HasIndex(e => e.OldCustomerCode, "INDEX2").HasFillFactor(90);

            entity.HasIndex(e => e.TempCustomerCode, "INDEX3")
                .IsUnique()
                .HasFillFactor(90);

            entity.Property(e => e.TranId).HasColumnName("TRAN_ID");
            entity.Property(e => e.AmlScreeningCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AML_SCREENING_CODE");
            entity.Property(e => e.Approved)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("APPROVED");
            entity.Property(e => e.BirthDate)
                .HasColumnType("date")
                .HasColumnName("BIRTH_DATE");
            entity.Property(e => e.CasteCatCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CASTE_CAT_CODE");
            entity.Property(e => e.CasteCode).HasColumnName("CASTE_CODE");
            entity.Property(e => e.CibPreviousDataProviderBranchId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CIB_PREVIOUS_DATA_PROVIDER_BRANCH_ID");
            entity.Property(e => e.CibPreviousDataProviderIdentificationNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CIB_PREVIOUS_DATA_PROVIDER_IDENTIFICATION_NUMBER");
            entity.Property(e => e.ConsCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CONS_CODE");
            entity.Property(e => e.CorporateCustomerCategoryId).HasColumnName("CORPORATE_CUSTOMER_CATEGORY_ID");
            entity.Property(e => e.CountryCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("COUNTRY_CODE");
            entity.Property(e => e.CustTypeCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CUST_TYPE_CODE");
            entity.Property(e => e.CustTypeCustCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CUST_TYPE_CUST_CODE");
            entity.Property(e => e.CustomerCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CUSTOMER_CODE");
            entity.Property(e => e.CustomerInternalClassCodeId).HasColumnName("CUSTOMER_INTERNAL_CLASS_CODE_ID");
            entity.Property(e => e.CustomerLegalScope).HasColumnName("CUSTOMER_LEGAL_SCOPE");
            entity.Property(e => e.EducationCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EDUCATION_CODE");
            entity.Property(e => e.EmailId)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("EMAIL_ID");
            entity.Property(e => e.EstimatedMonthlyTranCount).HasColumnName("ESTIMATED_MONTHLY_TRAN_COUNT");
            entity.Property(e => e.EstimatedMonthlyTurnover)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ESTIMATED_MONTHLY_TURNOVER");
            entity.Property(e => e.EstimatedYearlyTranCount).HasColumnName("ESTIMATED_YEARLY_TRAN_COUNT");
            entity.Property(e => e.EstimatedYearlyTurnover)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ESTIMATED_YEARLY_TURNOVER");
            entity.Property(e => e.FaxNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FAX_NO");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FIRST_NAME");
            entity.Property(e => e.FirstNameLocal)
                .HasMaxLength(256)
                .HasColumnName("FIRST_NAME_LOCAL");
            entity.Property(e => e.FullName)
                .HasMaxLength(202)
                .IsUnicode(false)
                .HasComputedColumnSql("(concat([FIRST_NAME],' ',isnull(nullif([MIDDLE_NAME]+' ',' '),''),[LAST_NAME]))", false)
                .HasColumnName("FULL_NAME");
            entity.Property(e => e.FullNameLocal)
                .HasMaxLength(459)
                .HasComputedColumnSql("(concat(isnull(nullif([FIRST_NAME_LOCAL]+' ',' '),''),isnull(nullif([MIDDLE_NAME_LOCAL]+' ',' '),''),isnull(nullif([LAST_NAME_LOCAL]+' ',' '),'')))", false)
                .HasColumnName("FULL_NAME_LOCAL");
            entity.Property(e => e.GenderCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GENDER_CODE");
            entity.Property(e => e.GrtDate)
                .HasColumnType("date")
                .HasColumnName("GRT_DATE");
            entity.Property(e => e.GrtEmpId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GRT_EMP_ID");
            entity.Property(e => e.InstCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("INST_CODE");
            entity.Property(e => e.IntdCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("INTD_CODE");
            entity.Property(e => e.IntdTypeCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("INTD_TYPE_CODE");
            entity.Property(e => e.IsMigrated).HasColumnName("IS_MIGRATED");
            entity.Property(e => e.IsNrnHolder).HasColumnName("IS_NRN_HOLDER");
            entity.Property(e => e.IsPep).HasColumnName("IS_PEP");
            entity.Property(e => e.IsPrHolder).HasColumnName("IS_PR_HOLDER");
            entity.Property(e => e.IsShareholder).HasColumnName("IS_SHAREHOLDER");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LAST_NAME");
            entity.Property(e => e.LastNameLocal)
                .HasMaxLength(100)
                .HasColumnName("LAST_NAME_LOCAL");
            entity.Property(e => e.MaritalStatusCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MARITAL_STATUS_CODE");
            entity.Property(e => e.MfModuleCode).HasColumnName("MF_MODULE_CODE");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MIDDLE_NAME");
            entity.Property(e => e.MiddleNameLocal)
                .HasMaxLength(100)
                .HasColumnName("MIDDLE_NAME_LOCAL");
            entity.Property(e => e.Migrating).HasColumnName("MIGRATING");
            entity.Property(e => e.MobileNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MOBILE_NO");
            entity.Property(e => e.MobileNoForAlert)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MOBILE_NO_FOR_ALERT");
            entity.Property(e => e.ObligorCode).HasColumnName("OBLIGOR_CODE");
            entity.Property(e => e.OccupationCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("OCCUPATION_CODE");
            entity.Property(e => e.OldCustomerCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("OLD_CUSTOMER_CODE");
            entity.Property(e => e.PgtDate)
                .HasColumnType("date")
                .HasColumnName("PGT_DATE");
            entity.Property(e => e.PgtEmpId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PGT_EMP_ID");
            entity.Property(e => e.PoBoxNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PO_BOX_NO");
            entity.Property(e => e.Post)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("POST");
            entity.Property(e => e.RegistrationDate)
                .HasColumnType("date")
                .HasColumnName("REGISTRATION_DATE");
            entity.Property(e => e.ReligionCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RELIGION_CODE");
            entity.Property(e => e.ResidentCountryCode)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("RESIDENT_COUNTRY_CODE");
            entity.Property(e => e.ShareAcNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SHARE_AC_NO");
            entity.Property(e => e.ShareNo).HasColumnName("SHARE_NO");
            entity.Property(e => e.Status).HasColumnName("STATUS");
            entity.Property(e => e.StatusChangeDate)
                .HasColumnType("date")
                .HasColumnName("STATUS_CHANGE_DATE");
            entity.Property(e => e.StatusChangeUserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("STATUS_CHANGE_USER_ID");
            entity.Property(e => e.TelephoneNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TELEPHONE_NO");
            entity.Property(e => e.TempCustomerCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TEMP_CUSTOMER_CODE");
            entity.Property(e => e.TranDate)
                .HasColumnType("date")
                .HasColumnName("TRAN_DATE");
            entity.Property(e => e.TranUserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TRAN_USER_ID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using System.Collections.Generic;

namespace ObserverPattern.Models;

public partial class CustomerMast
{
    public int TranId { get; set; }

    public string CustomerCode { get; set; } = null!;

    public int? ObligorCode { get; set; }

    public string? CountryCode { get; set; }

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public string FullName { get; set; } = null!;

    public string? FirstNameLocal { get; set; }

    public string? MiddleNameLocal { get; set; }

    public string? LastNameLocal { get; set; }

    public string FullNameLocal { get; set; } = null!;

    public string? ConsCode { get; set; }

    public string? GenderCode { get; set; }

    public string? MaritalStatusCode { get; set; }

    public string? ReligionCode { get; set; }

    public DateTime? BirthDate { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public string? PoBoxNo { get; set; }

    public string? TelephoneNo { get; set; }

    public string? MobileNo { get; set; }

    public string? EmailId { get; set; }

    public string? FaxNo { get; set; }

    public string? EducationCode { get; set; }

    public string? OccupationCode { get; set; }

    public string? Post { get; set; }

    public string? IntdTypeCode { get; set; }

    public string? IntdCode { get; set; }

    public string? CustTypeCode { get; set; }

    public int? CasteCode { get; set; }

    public int? CorporateCustomerCategoryId { get; set; }

    public string? InstCode { get; set; }

    public string? CasteCatCode { get; set; }

    public string? CustTypeCustCode { get; set; }

    public bool IsShareholder { get; set; }

    public int? MfModuleCode { get; set; }

    public string? ShareAcNo { get; set; }

    public string? MobileNoForAlert { get; set; }

    public bool? IsMigrated { get; set; }

    public string? AmlScreeningCode { get; set; }

    public int EstimatedMonthlyTranCount { get; set; }

    public decimal EstimatedMonthlyTurnover { get; set; }

    public int EstimatedYearlyTranCount { get; set; }

    public decimal EstimatedYearlyTurnover { get; set; }

    public string? OldCustomerCode { get; set; }

    public string? TempCustomerCode { get; set; }

    public DateTime TranDate { get; set; }

    public string TranUserId { get; set; } = null!;

    public string Approved { get; set; } = null!;

    public int Status { get; set; }

    public DateTime StatusChangeDate { get; set; }

    public string StatusChangeUserId { get; set; } = null!;

    public string? CibPreviousDataProviderBranchId { get; set; }

    public string? CibPreviousDataProviderIdentificationNumber { get; set; }

    public int CustomerLegalScope { get; set; }

    public bool IsPep { get; set; }

    public bool? Migrating { get; set; }

    public int? ShareNo { get; set; }

    public DateTime? GrtDate { get; set; }

    public string? GrtEmpId { get; set; }

    public DateTime? PgtDate { get; set; }

    public string? PgtEmpId { get; set; }

    public string ResidentCountryCode { get; set; } = null!;

    public bool IsNrnHolder { get; set; }

    public bool IsPrHolder { get; set; }

    public int? CustomerInternalClassCodeId { get; set; }
}

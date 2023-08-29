using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using ObserverPattern.Models;
using ObserverPattern.Repository;
using System.Collections.Generic;
using System;
using System.Drawing.Text;
using System.Xml.Linq;

namespace ObserverPattern.Functions
{
    public class DueDateBackgroundService:BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            MainRepo _mainRepo = new MainRepo(new InfinityDbContext());
            var loansDueSoon = _mainRepo.RegisterUser();
            List<Subject> subjects = new List<Subject>();
            foreach (var loan in loansDueSoon)
            {
                var subject = new Subject(new CustomerMast()
                {
                    TranId = loan.TranId,
                    CustomerCode = loan.CustomerCode,
                    ObligorCode = loan.ObligorCode,
                    CountryCode = loan.CountryCode,
                    FirstName = loan.FirstName,
                    MiddleName = loan.MiddleName,
                    LastName = loan.LastName,
                    FullName = loan.FullName,
                    FirstNameLocal = loan.FirstNameLocal,
                    MiddleNameLocal = loan.MiddleNameLocal,
                    LastNameLocal = loan.LastNameLocal,
                    FullNameLocal = loan.FullNameLocal,
                    ConsCode = loan.ConsCode,
                    GenderCode = loan.GenderCode,
                    MaritalStatusCode = loan.MaritalStatusCode,
                    ReligionCode = loan.ReligionCode,
                    BirthDate = loan.BirthDate,
                    RegistrationDate = loan.RegistrationDate,
                    PoBoxNo = loan.PoBoxNo,
                    TelephoneNo = loan.TelephoneNo,
                    MobileNo = loan.MobileNo,
                    EmailId = loan.EmailId,
                    FaxNo = loan.FaxNo,
                    EducationCode = loan.EducationCode,
                    OccupationCode = loan.OccupationCode,
                    Post = loan.Post,
                    IntdTypeCode = loan.IntdTypeCode,
                    IntdCode = loan.IntdCode,
                    CustTypeCode = loan.CustTypeCode,
                    CasteCode = loan.CasteCode,
                    CorporateCustomerCategoryId = loan.CorporateCustomerCategoryId,
                    InstCode = loan.InstCode,
                    CasteCatCode = loan.CasteCatCode,
                    CustTypeCustCode = loan.CustTypeCustCode,
                    IsShareholder = loan.IsShareholder,
                    MfModuleCode = loan.MfModuleCode,
                    ShareAcNo = loan.ShareAcNo,
                    MobileNoForAlert = loan.MobileNoForAlert,
                    IsMigrated = loan.IsMigrated,
                    AmlScreeningCode = loan.AmlScreeningCode,
                    EstimatedMonthlyTranCount = loan.EstimatedMonthlyTranCount,
                    EstimatedMonthlyTurnover = loan.EstimatedMonthlyTurnover,
                    EstimatedYearlyTranCount = loan.EstimatedYearlyTranCount,
                    EstimatedYearlyTurnover = loan.EstimatedYearlyTurnover,
                    OldCustomerCode = loan.OldCustomerCode,
                    TempCustomerCode = loan.TempCustomerCode,
                    TranDate = loan.TranDate,
                    TranUserId = loan.TranUserId,
                    Approved = loan.Approved,
                    Status = loan.Status,
                    StatusChangeDate = loan.StatusChangeDate,
                    StatusChangeUserId = loan.StatusChangeUserId,
                    CibPreviousDataProviderBranchId = loan.CibPreviousDataProviderBranchId,
                    CibPreviousDataProviderIdentificationNumber = loan.CibPreviousDataProviderIdentificationNumber,
                    CustomerLegalScope = loan.CustomerLegalScope,
                    IsPep = loan.IsPep,
                    Migrating = loan.Migrating,
                    ShareNo = loan.ShareNo,
                    GrtDate = loan.GrtDate,
                    GrtEmpId = loan.GrtEmpId,
                    PgtDate = loan.PgtDate,
                    PgtEmpId = loan.PgtEmpId,
                    ResidentCountryCode = loan.ResidentCountryCode,
                    IsNrnHolder = loan.IsNrnHolder,
                    IsPrHolder = loan.IsPrHolder,
                    CustomerInternalClassCodeId = loan.CustomerInternalClassCodeId
                });
                var observer = new Observer();
                subject.Subscribe(observer);
                subjects.Add(subject);
            }
            while (!stoppingToken.IsCancellationRequested)
            {
                foreach (var subject in subjects)
                {
                    subject.SearchForChange();
                }
                await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken); // Delay for 10 sec before checking again
            }

        }
    }
}

using Microsoft.AspNetCore.Http.HttpResults;
using NN.POS.System.API.Core.Entities.BusinessPartners;
using NN.POS.System.Model.Dtos.BusinessPartners;
using static NN.POS.System.Model.Enums.BusinessPartnerEnum;

namespace NN.POS.System.API.Infra.Tables.BusinessPartners;

public static class BusinessPartnerExtensions
{
    public static BusinessPartnerDto ToDto(this BusinessPartnerEntity t) =>
        new()
        {
            Id = t.Id,
            FirstName = t.FirstName,
            LastName = t.LastName,
            PhoneNumber = t.PhoneNumber,
            ContactType = t.ContactType,
            BusinessType = t.BusinessType,
            CreatedAt = t.CreatedAt,
            UpdatedAt = t.UpdatedAt,
            Email = t.Email,
            Address = t.Address
        };

    public static BusinessPartnerEntity ToEntity(this BusinessPartnerTable t) =>
        new()
        {
            Id = t.Id,
            FirstName = t.FirstName,
            LastName = t.LastName,
            PhoneNumber = t.PhoneNumber,
            ContactType = t.ContactType,
            BusinessType = t.BusinessType,
            CreatedAt = t.CreatedAt,
            UpdatedAt = t.UpdatedAt,
            Email = t.Email,
            Address = t.Address
        };

    public static BusinessPartnerEntity ToEntity(this BusinessPartnerDto t) =>
        new()
        {
            Id = t.Id,
            FirstName = t.FirstName,
            LastName = t.LastName,
            PhoneNumber = t.PhoneNumber,
            ContactType = t.ContactType,
            BusinessType = t.BusinessType,
            CreatedAt = t.CreatedAt,
            UpdatedAt = t.UpdatedAt,
            Email = t.Email,
            Address = t.Address,
        };

    public static BusinessPartnerTable ToTable(this BusinessPartnerEntity t) =>
        new()
        {
            Id = t.Id,
            FirstName = t.FirstName,
            LastName = t.LastName,
            PhoneNumber = t.PhoneNumber,
            ContactType = t.ContactType,
            BusinessType = t.BusinessType,
            UpdatedAt = t.UpdatedAt,
            Email = t.Email,
            Address = t.Address,
            CreatedAt = t.CreatedAt,
        };
}
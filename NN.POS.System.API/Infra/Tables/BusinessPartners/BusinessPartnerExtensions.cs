using NN.POS.System.API.Core.Entities.BusinessPartners;
using NN.POS.System.Model.Dtos.BusinessPartners;

namespace NN.POS.System.API.Infra.Tables.BusinessPartners;

public static class BusinessPartnerExtensions
{
    public static BusinessPartnerDto ToDto(this BusinessPartnerEntity t) =>
        new(
            id: t.Id,
            firstName: t.FirstName,
            lastName: t.LastName,
            phoneNumber: t.PhoneNumber,
            contactType: t.ContactType,
            businessType: t.BusinessType,
            createdAt: t.CreatedAt,
            updatedAt: t.UpdatedAt
        )
        {
            Email = t.Email,
            Address = t.Address,
        };

    public static BusinessPartnerEntity ToEntity(this BusinessPartnerTable t) =>
        new(
            id: t.Id,
            firstName: t.FirstName,
            lastName: t.LastName,
            phoneNumber: t.PhoneNumber,
            contactType: t.ContactType,
            businessType: t.BusinessType,
            createdAt: t.CreatedAt,
            updatedAt: t.UpdatedAt
        )
        {
            Email = t.Email,
            Address = t.Address,
        };

    public static BusinessPartnerEntity ToEntity(this BusinessPartnerDto t) =>
        new(
            id: t.Id,
            firstName: t.FirstName,
            lastName: t.LastName,
            phoneNumber: t.PhoneNumber,
            contactType: t.ContactType,
            businessType: t.BusinessType,
            createdAt: t.CreatedAt,
            updatedAt: t.UpdatedAt
        )
        {
            Email = t.Email,
            Address = t.Address,
        };

    public static BusinessPartnerTable ToTable(this BusinessPartnerEntity t) =>
        new(
            id: t.Id,
            firstName: t.FirstName,
            lastName: t.LastName,
            phoneNumber: t.PhoneNumber,
            contactType: t.ContactType,
            businessType: t.BusinessType,
            updatedAt: t.UpdatedAt
        )
        {
            Email = t.Email,
            Address = t.Address,
            CreatedAt = t.CreatedAt,
        };
}
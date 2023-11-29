using NN.POS.API.Core.Entities.BusinessPartners;
using NN.POS.Model.Dtos.BusinessPartners;

namespace NN.POS.API.Infra.Tables.BusinessPartners;

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
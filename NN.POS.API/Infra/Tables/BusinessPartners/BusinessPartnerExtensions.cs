using NN.POS.API.Core.Entities.BusinessPartners;
using NN.POS.API.Core.Entities.BusinessPartners.CustomerGroups;
using NN.POS.Model.Dtos.BusinessPartners;
using NN.POS.Model.Dtos.BusinessPartners.CustomerGroups;

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

    #region Customer Group

    public static CustomerGroupEntity ToEntity(this CustomerGroupTable c) => new()
    {
        CreatedAt = c.CreatedAt,
        Id = c.Id,
        Name = c.Name,
        UpdatedAt = c.UpdatedAt,
        Value = c.Value
    };

    public static CustomerGroupEntity ToEntity(this CustomerGroupDto c) => new()
    {
        CreatedAt = c.CreatedAt,
        Id = c.Id,
        Name = c.Name,
        UpdatedAt = c.UpdatedAt,
        Value = c.Value
    };

    public static CustomerGroupTable ToTable(this CustomerGroupEntity c) => new()
    {
        CreatedAt = c.CreatedAt,
        Id = c.Id,
        Name = c.Name,
        UpdatedAt = c.UpdatedAt,
        Value = c.Value
    };

    public static CustomerGroupDto ToDto(this CustomerGroupEntity c) => new()
    {
        CreatedAt = c.CreatedAt,
        Id = c.Id,
        Name = c.Name,
        UpdatedAt = c.UpdatedAt,
        Value = c.Value
    };
    #endregion
}
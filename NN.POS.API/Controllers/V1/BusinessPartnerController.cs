using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NN.POS.API.App.Commands.BusinessPartners;
using NN.POS.API.App.Queries.BusinessPartners;
using NN.POS.API.App.Queries.BusinessPartners.CustomerGroups;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.BusinessPartners;
using NN.POS.Model.Dtos.BusinessPartners.CustomerGroups;

namespace NN.POS.API.Controllers.V1;

public class BusinessPartnerController(IMediator mediator) : BaseApiController
{
    /// <summary>
    /// Get BP base condition:
    /// dto.ContactType => [None = 0, Supplier = 1, Customer = 2, SupplierCustomer = 3]
    /// dto.BusinessType => [0: None, 1: Individual, 2: Business]
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [Authorize(Roles = "Admin, read-business-partner")]
    [HttpGet]
    public async Task<ActionResult<PagedResult<BusinessPartnerDto>>> Get([FromQuery] GetBusinessPartnerDto dto)
    {
        var q = new GetBusinessPartnerQuery()
        {
            Results = dto.Results,
            ContactType = dto.ContactType,
            BusinessType = dto.BusinessType,
            Page = dto.Page,
        };
        var data = await mediator.Send(q);
        return Ok(data);
    }
    
    [Authorize(Roles = "Admin, read-business-partner")]
    [HttpGet("{id}")]
    public async Task<ActionResult<BusinessPartnerDto>> GetById(int id)
    {
        var q = new GetBusinessPartnerByIdQuery(id);
        var data = await mediator.Send(q);
        return Ok(data);
    }

    [Authorize(Roles = "Admin, read-business-partner")]
    [HttpGet("count")]
    public async Task<ActionResult<BusinessPartnerDto>> GetCount()
    {
        var q = new GetBusinessPartnerCountQuery();
        var data = await mediator.Send(q);
        return Ok(data);
    }

    [Authorize(Roles = "Admin, write-business-partner")]
    [HttpPost]
    public async Task<ActionResult<BusinessPartnerDto>> CreateAsync([FromBody] CreateBusinessPartnerDto dto)
    {
        var cmd = new CreateBusinessPartnerCommand(firstName: dto.FirstName, lastName: dto.LastName,
            phoneNumber: dto.PhoneNumber, contactType: dto.ContactType, businessType: dto.BusinessType)
        {
            Email = dto.Email,
            Address = dto.Address,
        };
        var data = await mediator.Send(cmd);
        return Ok(data);
    }

    [Authorize(Roles = "Admin, write-business-partner")]
    [HttpPut]
    public async Task<ActionResult<BusinessPartnerDto>> UpdateAsync([FromBody] UpdateBusinessPartnerDto dto)
    {
        var cmd = new UpdateBusinessPartnerCommand()
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            PhoneNumber = dto.PhoneNumber,
            ContactType = dto.ContactType,
            Address = dto.Address,
            BusinessType = dto.BusinessType,
            Email = dto.Email,
            Id = dto.Id,
        };
        var data = await mediator.Send(cmd);
        return Ok(data);
    }

    [Authorize(Roles = "Admin, write-business-partner")]
    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteAsync(int id)
    {
        var cmd = new DeleteBusinessPartnerCommand(id);
        var data = await mediator.Send(cmd);
        return Ok(data);
    }


    #region Customer Group

    [HttpGet("customer-groups")]
    public async Task<ActionResult<PagedResult<CustomerGroupDto>>> GetAllCustomerGroups([FromQuery] GetCustomerGroupDto q)
    {
        var query = new GetCustomerGroupsQuery
        {
            Page = q.Page,
            Results = q.Results,
            Search = q.Search
        };
        var data = await mediator.Send(query);
        return Ok(data);
    }

    [HttpPost("customer-group")]
    public async Task<ActionResult> CreateCustomerGroup([FromBody] CreateCustomerGroupDto dto)
    {
        await mediator.Send(new CreateCustomerGroupCommand
        {
            Dto = dto
        });
        return Ok();
    }

    [HttpPut("customer-group/{id}")]
    public async Task<ActionResult> UpdateCustomerGroup(int id, [FromBody] UpdateCustomerGroupDto dto)
    {
        await mediator.Send(new UpdateCustomerGroupCommand
        {
            Id = id,
            Dto = dto
        });
        return Ok();
    }

    [HttpDelete("customer-group/{id}")]
    public async Task<ActionResult> DeleteCustomerGroup(int id)
    {
        await mediator.Send(new DeleteCustomerGroupCommand
        {
            Id = id
        });
        return Ok();
    }
    #endregion
}
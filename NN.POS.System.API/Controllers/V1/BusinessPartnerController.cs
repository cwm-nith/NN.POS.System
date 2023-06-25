using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NN.POS.System.API.App.Commands.BusinessPartners;
using NN.POS.System.API.App.Queries.BusinessPartners;
using NN.POS.System.API.Commons.Pagination;
using NN.POS.System.API.Core.Dtos.BusinessPartners;

namespace NN.POS.System.API.Controllers.V1;

public class BusinessPartnerController : BaseApiController
{

    private readonly IMediator _mediator;

    public BusinessPartnerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize(Roles = "Admin, read-business-partner")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<PagedResult<BusinessPartnerDto>>> Get([FromQuery] GetBusinessPartnerDto dto)
    {
        var q = new GetBusinessPartnerQuery()
        {
            Results = dto.Results,
            ContactType = dto.ContactType,
            BusinessType = dto.BusinessType,
            Page = dto.Page,
        };
        var data = await _mediator.Send(q);
        return Ok(data);
    }

    [Authorize(Roles = "Admin, write-business-partner")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<BusinessPartnerDto>> CreateAsync([FromBody] CreateBusinessPartnerDto dto)
    {
        var cmd = new CreateBusinessPartnerCommand(firstName: dto.FirstName, lastName: dto.LastName,
            phoneNumber: dto.PhoneNumber, contactType: dto.ContactType, businessType: dto.BusinessType)
        {
            Email = dto.Email,
            Address = dto.Address,
        };
        var data = await _mediator.Send(cmd);
        return Ok(data);
    }

    [Authorize(Roles = "Admin, write-business-partner")]
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
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
        var data = await _mediator.Send(cmd);
        return Ok(data);
    }
}
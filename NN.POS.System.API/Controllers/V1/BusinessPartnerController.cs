using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NN.POS.System.API.App.Commands.BusinessPartners;
using NN.POS.System.API.Core.Dtos.BusinessPartners;

namespace NN.POS.System.API.Controllers.V1;

public class BusinessPartnerController : BaseApiController
{

    private readonly IMediator _mediator;

    public BusinessPartnerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public ActionResult Get()
    {
        return Ok("Hello");
    }

    [Authorize(Roles = "Admin, read-business-partner")]
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
}
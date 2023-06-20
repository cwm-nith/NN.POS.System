﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NN.POS.System.Application.Commands.Users;
using NN.POS.System.Core.Exceptions.Users;

namespace NN.POS.System.API.Controllers.V1;

public class UserControllerController : BaseApiController
{
    private readonly IMediator _mediator;

    public UserControllerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Get test data example with no auth
    /// </summary>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpGet]
    public ActionResult Get()
    {
        throw new UserNotFoundException(Guid.NewGuid());
        return Ok(new
        {
            Name = "Hello",
            Id = 2
        });
    }
    [AllowAnonymous]
    [HttpPost]
    public async Task<ActionResult> CreateUser()
    {
        var data = await _mediator.Send(new CreateUserCommand("Hello", 20));
        return Ok(data);
    }
}
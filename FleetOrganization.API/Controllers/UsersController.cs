using FleetOrganiztion.COMMUNICATION.Requests;
using Microsoft.AspNetCore.Mvc;

namespace FleetOrganization.API.Controllers;

[Route("[controller]")]
[ApiController]

public class UsersController : ControllerBase
{
    //endpoint
    [HttpPost]

    public IActionResult Create(RequestUserJson requestUser)
    {
        return Created();
    }

}


using FleetOrganization.USECASES.Users.Register;
using FleetOrganiztion.COMMUNICATION.Requests;
using FleetOrganiztion.COMMUNICATION.Responses;
using Microsoft.AspNetCore.Mvc;

namespace FleetOrganization.API.Controllers;

[Route("[controller]")]
[ApiController]

public class UsersController : ControllerBase
{
    //endpoint
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredUserJsoncs), StatusCodes.Status201Created)]
    public IActionResult Create(RequestUserJson requestUser)
    {
        //Variavel para armazenar a resposta e simplificar usando VAR
        var useCase = new RegisterUserUseCase();

        //Aqui vamos chamar o metodo execute do use case
        var response = useCase.Execute(requestUser);

        return Created(string.Empty,response);
    }

}


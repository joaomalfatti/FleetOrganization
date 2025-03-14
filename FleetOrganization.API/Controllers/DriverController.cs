using FleetOrganization.EXCEPTION;
using FleetOrganization.USECASES.Users.Register;
using FleetOrganiztion.COMMUNICATION.Requests;
using FleetOrganiztion.COMMUNICATION.Responses;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FleetOrganization.API.Controllers;

[Route("[controller]")]
[ApiController]

public class DriverController : ControllerBase
{
    //endpoint
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredDriverJsoncs), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]

    public IActionResult Register(RequestDriverJson requestUser)
    {
        //Executando algo
        try
        {
            //Variavel para armazenar a resposta e simplificar usando VAR
            var useCase = new RegisterDriverUseCase();

            //Aqui vamos chamar o metodo execute do use case
            var response = useCase.Execute(requestUser);

            return Created(string.Empty, response);

        }
        //Caso ocorra um erro
        catch (FleetOrgazationExeception exception)
        {
            {
                return BadRequest(new ResponseErrorMessagesJson
                {
                    Errors = exception.GetErrorMessages()
                });
            }
        }
        //Erro desconhecido que não foi tratado.
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorMessagesJson
            {
                Errors = ["Erro Desconhecido"]
            });
        }

    }

}


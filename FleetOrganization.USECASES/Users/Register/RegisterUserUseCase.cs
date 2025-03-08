using FleetOrganiztion.COMMUNICATION.Requests;
using FleetOrganiztion.COMMUNICATION.Responses;

namespace FleetOrganization.USECASES.Users.Register;

public class RegisterUserUseCase
{
    //Dentro do register user use case, vamos ter a logica de negocio para registrar um usuario.
    //Vai retornar um ResponseRegisteredUserJson

    public ResponseRegisteredUserJsoncs Execute(RequestUserJson requestUser) //Aqui vamos passar o parametro que vai ser o requestUser
    {
        //validação


        return new ResponseRegisteredUserJsoncs
        {

        };
    }
}


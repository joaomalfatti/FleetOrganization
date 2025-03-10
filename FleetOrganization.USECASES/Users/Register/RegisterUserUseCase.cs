using FleetOrganization.DOMAIN.Entities;
using FleetOrganization.EXCEPTION;
using FleetOrganization.INFRAESTRUCTURE.Context;
using FleetOrganiztion.COMMUNICATION.Requests;
using FleetOrganiztion.COMMUNICATION.Responses;

namespace FleetOrganization.USECASES.Users.Register;

public class RegisterUserUseCase
{
    //Dentro do register user use case, vamos ter a logica de negocio para registrar um usuario.
    //Vai retornar um ResponseRegisteredUserJson

    public ResponseRegisteredUserJsoncs Execute(RequestUserJson requestUser) //Aqui vamos passar o parametro que vai ser o requestUser
    {
        //chamando a função validate
        Validate(requestUser);

        //criando uma ententidade
        var entity = new EntitiesUser
        {
            Name = requestUser.Name,
            Email = requestUser.Email,
            Password = requestUser.Password,
            TypeUser = requestUser.TypeUser
        };

        var dbContext = new FleetOrganizationDbContext();

        dbContext.tb_users.Add(entity);

        dbContext.SaveChanges();

        return new ResponseRegisteredUserJsoncs
        {
            Name = entity.Name,
        };
    }

    //somente essa classe vai ver
    private void Validate(RequestUserJson requestUser) //Aqui vamos passar o parametro que vai ser o requestUser
    {
        //Fazendo a instância da minha validação
        var validor = new RegisterUserValidator();

        //agora vai trazer o resultado da validação
        var result = validor.Validate(requestUser);

        //Se o resultado não for valido
        if (result.IsValid == false)
        {
            //Neste caso aqui, vai pegar todas as mensagens de erros que retornar caso não é válido.
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

            //Aqui vai devolver a API uma exceção de erro.
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}


using FleetOrganization.DOMAIN.Entities;
using FleetOrganization.EXCEPTION;
using FleetOrganization.INFRAESTRUCTURE.DataAccess;
using FleetOrganization.INFRAESTRUCTURE.Security.Cryptography;
using FleetOrganiztion.COMMUNICATION.Requests;
using FleetOrganiztion.COMMUNICATION.Responses;

namespace FleetOrganization.USECASES.Users.Register;

public class RegisterUserUseCase
{


    public ResponseRegisteredUserJsoncs Execute(RequestUserJson requestUser) //Aqui vamos passar o parametro que vai ser o requestUser
    {
        
        Validate(requestUser);

        var cryptography = new BCryptAlgorithm();
        
        var entity = new EntitiesUser
        {
            Name = requestUser.Name,
            Email = requestUser.Email,
            Password = cryptography.HashPassword(requestUser.Password),
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

    
    private void Validate(RequestUserJson requestUser) //Aqui vamos passar o parametro que vai ser o requestUser
    {
        
        var validator = new RegisterUserValidator();

        
        var result = validator.Validate(requestUser);

        
        if (result.IsValid == false)
        {
            //Neste caso aqui, vai pegar todas as mensagens de erros que retornar caso não é válido.
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

            //Aqui vai devolver a API uma exceção de erro.
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}


using FleetOrganization.DOMAIN.Entities;
using FleetOrganization.EXCEPTION;
using FleetOrganization.INFRAESTRUCTURE.DataAccess;
using FleetOrganization.INFRAESTRUCTURE.Security.Cryptography;
using FleetOrganiztion.COMMUNICATION.Requests;
using FleetOrganiztion.COMMUNICATION.Responses;
using FluentValidation.Results;

namespace FleetOrganization.USECASES.Users.Register;

public class RegisterDriverUseCase
{


    public ResponseRegisteredDriverJsoncs Execute(RequestDriverJson requestDriver) //Aqui vamos passar o parametro que vai ser o requestUser
    {
        var dbContext = new FleetOrganizationDbContext();

        Validate(requestDriver, dbContext);

        var cryptography = new BCryptAlgorithm();
        
        var entity = new EntitiesDriver
        {
            Name = requestDriver.Name,
            CNH = requestDriver.CNH,
            Category = requestDriver.Category,
            Telephone = requestDriver.Telephone,
            Disponibility = requestDriver.Disponibility,
            Email = requestDriver.Email,
            Password = cryptography.HashPassword(requestDriver.Password),
            
        };

        

        dbContext.tb_users.Add(entity);

        dbContext.SaveChanges();

        return new ResponseRegisteredDriverJsoncs
        {
            Name = entity.Name,
            AccessToken = "token"
        };
    }

    
    private void Validate(RequestDriverJson requestUser, FleetOrganizationDbContext dbContext) //Aqui vamos passar o parametro que vai ser o requestUser
    {
        
        var validator = new RegisterDriverValidator();

        
        var result = validator.Validate(requestUser);

        var existUserWithName = dbContext.tb_users.Any(user => user.Name.Equals(requestUser.Name));
        if(existUserWithName)
            result.Errors.Add(new ValidationFailure("Name", "Nome já cadastrado."));

        var existUserWithEmail = dbContext.tb_users.Any(user => user.Email.Equals(requestUser.Email));
        if (existUserWithEmail)
            result.Errors.Add(new ValidationFailure("Email", "Email já cadastrado."));


        if (result.IsValid == false)
        {
            //Neste caso aqui, vai pegar todas as mensagens de erros que retornar caso não é válido.
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

            //Aqui vai devolver a API uma exceção de erro.
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}


using FleetOrganiztion.COMMUNICATION.Requests;
using FluentValidation;

namespace FleetOrganization.USECASES.Users.Register;

public class RegisterUserValidator : AbstractValidator<RequestUserJson>
{
    //Estou criando um validator para minha classe RequestUser.
    //CTOR
    public RegisterUserValidator()
    {
        RuleFor(requestUser => requestUser.Name).NotEmpty().WithMessage("Nome é obrigatório.");
        RuleFor(requestUser => requestUser.Email).EmailAddress().WithMessage("Email é obrigatório.");
        RuleFor(requestUser => requestUser.Password).NotEmpty().WithMessage("Senha é obrigatória.");
        When(requestUser => string.IsNullOrEmpty(requestUser.Password) == false, () => 
        { 
            RuleFor(requestUser => requestUser.Password.Length).GreaterThanOrEqualTo(6).WithMessage("Senha deve ter no mínimo 8 caracteres.");
        });
        RuleFor(requestUser => requestUser.TypeUser).NotEmpty().WithMessage("Tipo de usuário é obrigatório.");
       
    }

}


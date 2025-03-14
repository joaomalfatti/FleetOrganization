using FleetOrganiztion.COMMUNICATION.Requests;
using FluentValidation;

namespace FleetOrganization.USECASES.Users.Register;

public class RegisterDriverValidator : AbstractValidator<RequestDriverJson>
{
    //Estou criando um validator para minha classe RequestUser.
    //CTOR
    public RegisterDriverValidator()
    {
        RuleFor(requestDriver => requestDriver.Name)
            .NotEmpty()
            .WithMessage("Nome é obrigatório.");

        RuleFor(requestDriver => requestDriver.CNH)
            .NotEmpty()
            .WithMessage("CNH é obrigatório.");

        RuleFor(requestDriver => requestDriver.Category)
            .NotEmpty()
            .WithMessage("Categoria é obrigatório.");

        RuleFor(requestDriver => requestDriver.Telephone)
            .NotEmpty()
            .WithMessage("Telefone é obrigatório.");

        RuleFor(requestDriver => requestDriver.CNH)
            .NotEmpty()
            .WithMessage("CNH é obrigatório.");

        RuleFor(requestDriver => requestDriver.Disponibility)
            .NotEmpty()
            .WithMessage("Disponilidade é obrigatória");

        RuleFor(requestDriver => requestDriver.Email)
            .NotEmpty()
            .WithMessage("Email é obrigatório")
            .EmailAddress()
            .WithMessage("Email inválido.");

        RuleFor(requestDriver => requestDriver.Password)
            .NotEmpty()
            .WithMessage("Senha é obrigatória")
            .MinimumLength(8)
            .WithMessage("Senha deve ter no mínimo 8 caracteres.");

        //Relacionamento com a Viagem
        RuleFor(requestDriver => requestDriver.Trips)
            .NotEmpty()
            .WithMessage("CNH é obrigatório.");


    }

}


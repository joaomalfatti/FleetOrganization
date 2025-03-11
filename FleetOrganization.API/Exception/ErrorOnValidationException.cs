using System.Net;

namespace FleetOrganization.EXCEPTION;
public class ErrorOnValidationException : FleetOrgazationExeception
{
    //Somente ctor pode ler
    private readonly List<string> _errorMessages;

    //ctor
    public ErrorOnValidationException(List<string> errorMessages)
    {
        _errorMessages = errorMessages;
    }

    public override List<string> GetErrorMessages()
    {
        return _errorMessages;
    }

    //Erro de validação
    public override HttpStatusCode GetStatusCode() => HttpStatusCode.BadRequest;
    
}

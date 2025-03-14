using System.Net;

namespace FleetOrganization.API.Exception;

public abstract class FleetOrgazationExeception : SystemException
{
    //Quero fazer um controle de exceção.
    public abstract List<string> GetErrorMessages();
    public abstract HttpStatusCode GetStatusCode();
}


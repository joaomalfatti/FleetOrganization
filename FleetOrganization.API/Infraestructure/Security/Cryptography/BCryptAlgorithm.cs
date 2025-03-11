﻿namespace FleetOrganization.INFRAESTRUCTURE.Security.Cryptography;



public class BCryptAlgorithm
{
    public string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }
}



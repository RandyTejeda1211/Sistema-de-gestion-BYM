using System;
using BCrypt.Net;

class Program
{
    static void Main(string[] args)
    {
        string password = "Randy1212@";
        string hashed = BCrypt.Net.BCrypt.HashPassword(password);

        Console.WriteLine("Hash generado: " + hashed);

        bool isValid = BCrypt.Net.BCrypt.Verify(password, hashed);
        Console.WriteLine("¿Contraseña válida? " + isValid);
    }
}

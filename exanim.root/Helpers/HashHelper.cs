using System.Security.Cryptography;
using exanim.core.Helpers;

namespace exanim.root.Helpers;

public sealed class HashHelper : IHashHelper
{
    private const int _saltSize = 16;
    private const int _keySize = 32;
    private const int _iterations = 350_000;
    private static readonly HashAlgorithmName _algorithm = HashAlgorithmName.SHA512;

    public bool Compute(string pwd, string check)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(pwd);
        ArgumentException.ThrowIfNullOrWhiteSpace(check);

        string[] parts = check.Split(':');
        if (parts.Length != 4)
            throw new FormatException("Hash almacenado esta en formato incorrecto");
        var algorithm = new HashAlgorithmName(parts[0]);
        int iteras = int.Parse(parts[1]);
        byte[] salt = Convert.FromBase64String(parts[2]);
        byte[] stored = Convert.FromBase64String(parts[3]);

        byte[] derived = Rfc2898DeriveBytes.Pbkdf2(pwd, salt, iteras, algorithm, stored.Length);

        return CryptographicOperations.FixedTimeEquals(derived, stored);
    }

    public string Create(string pwd)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(pwd);
        byte[] salt = RandomNumberGenerator.GetBytes(_saltSize);
        byte[] key = Rfc2898DeriveBytes.Pbkdf2(pwd, salt, _iterations, _algorithm, _keySize);
        return $"{_algorithm}:{_iterations}:{Convert.ToBase64String(salt)}:{Convert.ToBase64String(key)}";
    }
}
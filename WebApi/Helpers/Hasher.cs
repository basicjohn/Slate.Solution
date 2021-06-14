using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

using WebApi.Entities;

// https://docs.microsoft.com/en-us/aspnet/core/security/data-protection/consumer-apis/password-hashing?view=aspnetcore-5.0
namespace WebApi.Helpers
{
  public class Hasher
  {
    public static (byte[], string) Make(string secret)
    {
      // generate a 128-bit salt using a secure PRNG
      byte[] salt = new byte[128 / 8];
      using (var rng = RandomNumberGenerator.Create())
      {
        rng.GetBytes(salt);
      }
      // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
      string hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
          password: secret,
          salt: salt,
          prf: KeyDerivationPrf.HMACSHA1,
          iterationCount: 10000,
          numBytesRequested: 256 / 8));
      return (
        salt,
        hash
      );
    }
    public static bool Verify(string secret, User user)
    {
      string hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
          password: secret,
          salt: user.Salt,
          prf: KeyDerivationPrf.HMACSHA1,
          iterationCount: 10000,
          numBytesRequested: 256 / 8));
      return hash == user.Hash;
    }
  }
}
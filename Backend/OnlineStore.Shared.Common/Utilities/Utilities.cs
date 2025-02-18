using System.Security.Cryptography;
using System.Text;

namespace OnlineStore.Shared.Common.Utilities;
public static class Utilities
{
    public static string EncryptSHA256(string inputString)
    {
        var sha256 = SHA256.Create();
        byte[] bytes = Encoding.UTF8.GetBytes(inputString);
        byte[] hash = sha256.ComputeHash(bytes);
        return GetStringFromHash(hash);
    }

    public static string EncryptSHA512(string inputString)
    {
        SHA512 sha512 = SHA512.Create();
        byte[] bytes = Encoding.UTF8.GetBytes(inputString);
        byte[] hash = sha512.ComputeHash(bytes);
        return GetStringFromHash(hash);
    }

    private static string GetStringFromHash(byte[] hash)
    {
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < hash.Length; i++)
        {
            result.Append(hash[i].ToString("X2"));
        }
        return result.ToString();
    }
}
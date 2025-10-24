using System.Security.Cryptography;
using System.Text;
using ms_estate_center.Domain.Entities;
using ms_estate_center.Adapter.Out.Mongodb.Users;
using ms_estate_center.Infrastructure.Settings;
using Microsoft.Extensions.Options;

namespace ms_estate_center.Application.UseCases.Users
{
    public class ValidateUserUseCase
    {
        private readonly UsersRepository _repository;
        private readonly AESSettings _settings;

        public ValidateUserUseCase(UsersRepository repository, IOptions<AESSettings> options)
        {
            _repository = repository;
            _settings = options.Value ?? throw new ArgumentNullException(nameof(options));
        }

        public async Task<User> ValidateUser(string email, string password)
        {
            User? userFoundByEmail = await _repository.GetByEmail(email);

            string decipheredValue = DecryptString(userFoundByEmail.Password);

            if (decipheredValue != password)
                throw new ArgumentException("The user data entered is incorrect");

            return userFoundByEmail;
        }

       public string DecryptString(string cipherTextBase64)
       {
            byte[] keyBytes = Encoding.UTF8.GetBytes(_settings.Key);
            byte[] ivBytes = Encoding.UTF8.GetBytes(_settings.IV);

            byte[] cipherBytes = Convert.FromBase64String(cipherTextBase64);

            using var aes = Aes.Create();
            aes.Key = keyBytes;
            aes.IV = ivBytes;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            using var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            using var ms = new MemoryStream(cipherBytes);
            using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
            using var reader = new StreamReader(cs, Encoding.UTF8);
            
            return reader.ReadToEnd();
       }

    }
}

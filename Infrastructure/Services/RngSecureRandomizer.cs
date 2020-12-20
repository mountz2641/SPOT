using Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Infrastructure.Services
{
    public class RngSecureRandomizer : ISecureRandomizer
    {
        public async Task<byte[]> GetSizeAsync(int size)
        {
            using (var rng = RNGCryptoServiceProvider.Create())
            {
                var arr = new byte[size];
                rng.GetNonZeroBytes(arr);
                return await Task.FromResult(arr);
            }
        }
    }
}

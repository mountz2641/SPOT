using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Services;
using SimpleBase;

namespace Infrastructure.Services
{
    public class VehicleCodeGenerator : IVehicleCodeGenerator
    {
        private readonly ISecureRandomizer _secureRandomizer;

        public VehicleCodeGenerator(ISecureRandomizer secureRandomizer)
        {
            _secureRandomizer = secureRandomizer;
        }
        public async Task<string> GenerateAsync()
        {
            var arr = await _secureRandomizer.GetSizeAsync(32);
            var result = Convert.ToBase64String(arr).Replace("/","_").Replace("+","-");
            return result;
        }
    }
}

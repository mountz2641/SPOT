using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface ISecureRandomizer
    {
        public Task<byte[]> GetSizeAsync(int size);
    }
}

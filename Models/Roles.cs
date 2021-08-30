using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutsalSemuaSenang.Models
{
    public class Roles
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static implicit operator Roles(int v)
        {
            throw new NotImplementedException();
        }
    }
}

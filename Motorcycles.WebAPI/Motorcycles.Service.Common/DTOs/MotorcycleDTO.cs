using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motorcycles.Service.Common.DTOs
{
    public class MotorcycleDTO
    {
        public int Id { get; set; }
        public string? Model { get; set; }
        public string? Brand { get; set; }
        public string? Color { get; set; }
        public int Year { get; set; }
        public int UserId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class RegiaoViewModel
    {
        public string nome;

        public int total;

        public List<SensorViewModel> sensores = new List<SensorViewModel>();
    }
}

using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WebApplication.Models
{
    public class RelatorioSensorViewModel
    {
        public string pais;

        public int total;

        public List<RegiaoViewModel> regioes = new List<RegiaoViewModel>();
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class EventViewModel
    {
        public int Id { get; set; }

        public string timestamp { get; set; } // Unix Timestamp ex: 1539112021301

        public string tag { get; set; } // ex: brasil.sudeste.sensor01

        public string valor { get; set; }

        public string pais { get; set; }

        public string regiao { get; set; }

        public string sensor { get; set; }

        public int valido { get; set; }
    }
}

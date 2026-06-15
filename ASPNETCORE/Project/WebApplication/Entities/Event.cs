
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebApplication.Entities
{
    public class Event
    {
        public int Id { get; set; }

        public string timestamp { get; set; } // Unix Timestamp ex: 1539112021301

        public string tag { get; set; } // ex: brasil.sudeste.sensor01

        public string valor { get; set; }

        public string pais { get; set; }

        public string regiao { get; set; }

        public string sensor { get; set; }

        public int valido { get; set; }

        public void validar()
        {
            this.valido = 1;

            if (String.IsNullOrEmpty(pais) ||
                String.IsNullOrEmpty(regiao) ||
                String.IsNullOrEmpty(sensor) ||
                String.IsNullOrEmpty(valor) ||
                String.IsNullOrEmpty(tag) ||
                String.IsNullOrEmpty(timestamp))
            {
                this.valido = 0;
                return;
            }

            if (pais != "brasil")
            {
                this.valido = 0;
                return;
            }

            if (regiao != "norte" &&
                regiao != "nordeste" &&
                regiao != "sul" &&
                regiao != "sudeste" &&
                regiao != "centrooeste")
            {
                this.valido = 0;
                return;
            }
        }

        public void setarPaisRegiaoSensor()
        {
            string pattern = "\\.";
            string[] substrings = Regex.Split(tag, pattern);

            if (substrings == null || substrings.Length != 3)
            {
                return;
            }

            pais = substrings[0];
            regiao = substrings[1];
            sensor = substrings[2];

            validar();
        }
    }
}

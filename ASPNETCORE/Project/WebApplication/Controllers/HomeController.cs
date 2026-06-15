using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.EF;
using WebApplication.Models;
using System.Text.Json;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using AutoMapper;
using WebApplication.Entities;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public HomeController(AppDbContext db,
            IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public IActionResult Index()
        {           
            return View();
        }

        public IActionResult Graph()
        {
            List<Event> eventos = _db.eventos.Where(e => e.valido == 1).ToArray<Event>().ToList();

            RelatorioSensorViewModel relatorio = new RelatorioSensorViewModel();

            eventos.ForEach(e => buildReport(e, relatorio));

            return View(relatorio);
        }

        public IActionResult Report()
        {
            List<Event> eventos =  _db.eventos.ToArray<Event>().ToList();

            RelatorioSensorViewModel relatorio = new RelatorioSensorViewModel();

            eventos.ForEach(e => buildReport(e, relatorio));

            return View(relatorio);
        }

        private void buildReport(Event evento, RelatorioSensorViewModel relatorio)
        {
            string paisNome = evento.pais;
            string regiaoNome = evento.regiao;
            string sensorNome = evento.sensor;
            int indexRegiao = -1;
            int indexSensor = -1;
            RegiaoViewModel regiao = new RegiaoViewModel();
            SensorViewModel sensor = new SensorViewModel();

            // Se encontrar regiao no relatorio, busca-la. Caso contrário, atualizar o nome da regiao criada anteriormente
            if (relatorio.regioes != null && relatorio.regioes.FindIndex(r => r.nome == regiaoNome) != -1)
            {
                indexRegiao = relatorio.regioes.FindIndex(r => r.nome == regiaoNome);
                regiao = relatorio.regioes[indexRegiao];
            } else {
                regiao.nome = regiaoNome;
            }

            // Se encontrar sensor na regiao, busca-lo. Caso contrário, atualizar o nome do sensor criado anteriormente
            if (regiao.sensores != null && regiao.sensores.FindIndex(s => s.nome == sensorNome) != -1)
            {
                indexSensor = regiao.sensores.FindIndex(s => s.nome == sensorNome);
                sensor = regiao.sensores[indexSensor];
            } else
            {
                sensor.nome = sensorNome;
            }

            relatorio.pais = paisNome;

            relatorio.total += 1;
            sensor.total += 1;
            regiao.total += 1;

            if (indexSensor == -1)
            {
                regiao.sensores.Add(sensor);
            }

            if (indexRegiao == -1)
            {
                relatorio.regioes.Add(regiao);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EventViewModel eventoVM)
        {
            Event evento = _mapper.Map<Event>(eventoVM);
            evento.setarPaisRegiaoSensor();

            _db.eventos.Add(evento);
            await _db.SaveChangesAsync();

            return new JsonResult(evento);
        }

        public IActionResult GetData()
        {
            Event[] eventos = _db.eventos.OrderByDescending(e => e.Id).ToArray<Event>();

            EventViewModel[] eventosVM = _mapper.Map<EventViewModel[]>(eventos);

            return new JsonResult(eventosVM);
        }

        public IActionResult hasData()
        {
            string hasData = _db.eventos.Where(e => e.valido == 1).FirstOrDefault() != null ? "hasData" : "noData";

            return new JsonResult(hasData);
        }

        public IActionResult GetLastResults(string regiao, string sensor)
        {
            Event[] eventos;
            string[] dados;

            if (String.IsNullOrEmpty(regiao) || String.IsNullOrEmpty(sensor)) {
                return new JsonResult("SELECT OPTIONS");
            }
            else
            {
                eventos = _db.eventos.Where(e => e.valido == 1 && e.regiao == regiao && e.sensor == sensor).OrderByDescending(e => e.Id).Take(10).ToArray<Event>();
                dados = eventos.OrderBy(e => e.Id).Select(e => e.valor).ToArray();
            }

            int[] dadosInt;

            try
            {
                dadosInt = Array.ConvertAll(dados, s => int.Parse(s));
            } catch {

                return new JsonResult("INVALID DATA");
            } 

            return new JsonResult(dadosInt);

        }

        public async Task<IActionResult> DeleteAllData()
        {
            Event[] eventos = _db.eventos.ToArray<Event>();

            
            _db.eventos.RemoveRange(eventos);
            

            await _db.SaveChangesAsync();

            return new JsonResult("Eventos Deletados");
        }
    }
}

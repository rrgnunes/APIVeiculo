using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Backend.Models;
namespace Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private VeiculoContext _veiculoContext;
        public VeiculoController(VeiculoContext veiculoContext)
        {
            _veiculoContext = veiculoContext;
        }

        [HttpGet("")]
        public ActionResult<List<Veiculo>> Getstrings()
        {
            return _veiculoContext.Veiculos.ToList();
        }

        [HttpGet("pagina/{pagina}")]
        public ActionResult<List<Veiculo>> Getstrings(int? pagina)
        {
            const int paginaQtd = 1;
            List<Veiculo> lstVeiculo = _veiculoContext.Veiculos.Skip((pagina ?? 0) * paginaQtd)
                                          .Take(paginaQtd)
                                          .ToList();
            return lstVeiculo;
        }

        [HttpGet("{id}")]
        public ActionResult<Veiculo> GetstringById(int id)
        {
            return _veiculoContext.Veiculos.FirstOrDefault(veiculo => veiculo.Id == id);
        }

        [HttpPost("")]
        public Veiculo Poststring(Veiculo veiculo)
        {
            _veiculoContext.Veiculos.Add(veiculo);
            _veiculoContext.SaveChanges();
            return veiculo;
        }

        [HttpPut("{id}")]
        public ActionResult<Veiculo> Putstring(int id, Veiculo veiculo)
        {
            var oldUser = _veiculoContext.Veiculos.FirstOrDefault(veiculo => veiculo.Id == id);
            if (oldUser != null)
            {
                oldUser.Placa = veiculo.Placa;
                oldUser.Cor = veiculo.Cor;
                oldUser.Modelo = veiculo.Modelo;
                oldUser.AnoFab = veiculo.AnoFab;
                oldUser.Fabricante = veiculo.Fabricante;
                _veiculoContext.SaveChanges();
            }
            return oldUser;
        }

        [HttpDelete("{id}")]
        public ActionResult<int> DeletestringById(int id)
        {
            _veiculoContext.Veiculos.Remove(_veiculoContext.Veiculos.FirstOrDefault(veiculo => veiculo.Id == id));
            _veiculoContext.SaveChanges();
            return id;
        }
    }
}

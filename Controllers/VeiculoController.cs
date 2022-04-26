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

        [HttpGet("placa/{placa}")]
        public ActionResult<List<Veiculo>> Getplaca(string placa)
        {
            List<Veiculo> lstVeiculo = _veiculoContext.Veiculos.Where(p => p.Placa == placa).ToList();
            return lstVeiculo;
        }

        [HttpGet("placa/{placa}/pagina/{pagina}")]
        public ActionResult<List<Veiculo>> Getplacas(int? pagina, string placa)
        {
            const int paginaQtd = 1;
            List<Veiculo> lstVeiculo = _veiculoContext.Veiculos.Where(p => p.Placa == placa).Skip((pagina ?? 0) * paginaQtd)
                                          .Take(paginaQtd)
                                          .ToList();
            return lstVeiculo;
        }

        [HttpGet("modelo/{modelo}")]
        public ActionResult<List<Veiculo>> Getmodelo(string modelo)
        {
            List<Veiculo> lstVeiculo = _veiculoContext.Veiculos.Where(p => p.Modelo == modelo).ToList();
            return lstVeiculo;
        }

        [HttpGet("modelo/{modelo}/pagina/{pagina}")]
        public ActionResult<List<Veiculo>> Getmodelos(int? pagina, string modelo)
        {
            const int paginaQtd = 1;
            List<Veiculo> lstVeiculo = _veiculoContext.Veiculos.Where(p => p.Modelo == modelo).Skip((pagina ?? 0) * paginaQtd)
                                          .Take(paginaQtd)
                                          .ToList();
            return lstVeiculo;
        }

        [HttpGet("qtdmodelo/{modelo}")]
        public ActionResult<Quantidade> GetQtdModelo(string modelo)
        {
            Quantidade oQtd = new Quantidade();
            oQtd.qtdRetorno = _veiculoContext.Veiculos.Where(p => p.Modelo == modelo).ToList().Count;
            return oQtd;
        }

        [HttpGet("qtdcor/{cor}")]
        public ActionResult<Quantidade> GetQtdCr(string cor)
        {
            Quantidade oQtd = new Quantidade();
            oQtd.qtdRetorno = _veiculoContext.Veiculos.Where(p => p.Cor == cor).ToList().Count;
            return oQtd;
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

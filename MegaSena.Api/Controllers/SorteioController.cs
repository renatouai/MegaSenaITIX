
using Erp.Api.Model;
using MegaSena.Domain;
using MegaSena.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace Erp.Api.Controllers
{
    [RoutePrefix("sorteio")]
    public class SorteioController : ApiController
    {
        private readonly ISorteioService _sorteioService;
        private readonly IJogoService _jogoService;
        public SorteioController(ISorteioService sorteioService, IJogoService jogoService)
        {
            this._sorteioService = sorteioService;
            this._jogoService = jogoService;
        }

        [HttpGet]
        [Route("listar")]
        public HttpResponseMessage ListarSorteios()
        {
            try
            {
                var res = _sorteioService.ListarSorteios();
                if (res == null)
                    throw new Exception("Não foi possível recuperar dados dos sorteios.");

                var _sorteios = new List<SorteioModel>();
                foreach (var item in _sorteioService.ListarSorteios())
                {
                    var _sorteio = new SorteioModel();

                    _sorteio.IdSorteio = item.IdSorteio;
                    _sorteio.Nome = item.Nome;
                    _sorteio.DataCriacao = item.DataCriacao;
                    _sorteio.NumeroGanhadores = item.NumeroGanhadores;
                    _sorteio.Situacao = item.Situacao;
                    _sorteio.NumeroJogos = item.Jogos.Count;
                    _sorteio.DezenasSorteadas = item.DezenasSorteadas;

                    var _jogos = new List<JogoModel>();
                    foreach (var j in item.Jogos)
                    {
                        _jogos.Add(new JogoModel()
                        {
                            IdJogo = j.IdJogo,
                            NomeSorteio = item.Nome,
                            Dezenas = j.Dezenas,
                            Data = j.Data,
                            Situacao = j.Situacao,
                            TipoPremio = j.TipoPremio
                        });
                    }
                    _sorteio.Ganhadores = _jogos.Where(x => x.Situacao == "Ganhou").ToList(); // já esta em mémoria
                    _sorteio.Jogos = _jogos;
                    _sorteios.Add(_sorteio);
                }
                return Request.CreateResponse(HttpStatusCode.OK, _sorteios);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("obter")]
        public HttpResponseMessage ObterSorteio(int id)
        {
            try
            {
                var res = _sorteioService.ObterSorteio(id);
                if (res == null)
                    throw new Exception("Não foi possível recuperar dados do sorteio");

                var _sorteio = new SorteioModel();
                _sorteio.Nome = res.Nome;
                _sorteio.IdSorteio = res.IdSorteio;

                return Request.CreateResponse(HttpStatusCode.OK, _sorteio);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("gerarJogos")]
        public HttpResponseMessage GerarJogos(int id)
        {
            try
            {
                var listaJogador = new List<Jogador>();
                listaJogador.Add(new Jogador("Reanto Ayres de Oliveira", "05982100676"));

                var sorteio = _sorteioService.ObterSorteio(id);

                for (int i = 0; i <= 50; i++)
                {
                    _jogoService.SalvarJogo(new Jogo(sorteio, sorteio.MegaSena(), "Aposta", listaJogador));
                }
                return Request.CreateResponse(HttpStatusCode.OK);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("realizarSorteio")]
        public HttpResponseMessage RealizarSorteio(int id)
        {
            try
            {
                // aqui poderia abrir um leque de opções megasena,lotomania
                _sorteioService.RealizarSorteioMegaSena(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
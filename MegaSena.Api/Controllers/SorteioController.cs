
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
        public SorteioController(ISorteioService sorteioService)
        {
            this._sorteioService = sorteioService;
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
    }
}
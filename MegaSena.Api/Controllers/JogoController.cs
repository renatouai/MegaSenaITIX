
using Erp.Api.Model;
using MegaSena.Domain;
using MegaSena.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Erp.Api.Controllers
{
    [RoutePrefix("jogo")]
    public class JogoController : ApiController
    {
        private readonly IJogoService _jogoService;
        private readonly ISorteioService _sorteioService;
        public JogoController(IJogoService jogoService, ISorteioService sorteioService)
        {
            this._jogoService = jogoService;
            this._sorteioService = sorteioService;
        }

        [HttpGet]
        [Route("listar")]
        public HttpResponseMessage ListarJogos()
        {
            try
            {
                var res = _jogoService.ListarJogos();
                var _jogos = new List<JogoModel>();

                foreach (var item in res)
                {
                    _jogos.Add(new JogoModel()
                    {
                        IdJogo = item.IdJogo,
                        NomeSorteio = item.Sorteio.Nome,
                        Dezenas = item.Dezenas,
                        Situacao = item.Situacao
                    });
                }   
                return Request.CreateResponse(HttpStatusCode.OK, _jogos);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("excluir")]
        public HttpResponseMessage Excluir(int id)
        {
            try
            {
                var jogador = _jogoService.ObterJogo(id);
                if (jogador == null)
                    throw new Exception("Jogo não encontrado");

                var res = _jogoService.Excluir(jogador);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("salvar")]
        public HttpResponseMessage Salvar(JogoModel model)
        {
            try
            {
                var listaJogador = new List<Jogador>();

                if (model.Jogadores.Count == 0)
                    throw new Exception("Adicione no mínimo um jogador");

                foreach(var item in model.Jogadores)
                    listaJogador.Add(new Jogador(item.Nome, item.CPF));

                List<int> res = model.Dezenas.Split(',').Select(Int32.Parse).ToList();

                _jogoService.SalvarJogo(new Jogo(_sorteioService.ObterSorteio(model.IdSorteio),res, "Aposta", listaJogador));
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("obter")]
        public HttpResponseMessage ObterJogo(int id)
        {
            try
            {
                var jogo = _jogoService.ObterJogo(id);
                if (jogo == null)
                    throw new Exception("Jogo não encontrado ");

                var model = new JogoModel();

                model.IdJogo = jogo.IdJogo;
                model.Data = jogo.Data;
                model.Situacao = jogo.Situacao;
                model.NomeSorteio = jogo.Sorteio.Nome;
                model.IdJogo = jogo.IdJogo;
                model.Dezenas = jogo.Dezenas;

                return Request.CreateResponse(HttpStatusCode.OK, model);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
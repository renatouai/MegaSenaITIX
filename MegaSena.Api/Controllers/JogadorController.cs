
using Erp.Api.Model;
using MegaSena.Domain;
using MegaSena.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Erp.Api.Controllers
{
    [RoutePrefix("jogador")]
    public class JogadorController : ApiController
    {
        private readonly IJogadorService _jogadorService;
        public JogadorController(IJogadorService jogadorService)
        {
            this._jogadorService = jogadorService;
        }

        [HttpGet]
        [Route("listar")]
        public HttpResponseMessage ListarJogadores()
        {
            try
            {
                var res = _jogadorService.ListarJogadores();
                var _jogadores = new List<JogadorModel>();

                foreach (var item in res)
                {
                    _jogadores.Add(new JogadorModel()
                    {
                        CPF = item.CPF,
                        IdJogador = item.IdJogador,
                        Nome = item.Nome
                    });
                }
                return Request.CreateResponse(HttpStatusCode.OK, _jogadores);
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

                var jogador = _jogadorService.ObterJogadorPorId(id);
                if (jogador == null)
                    throw new Exception("Jogador não encontrado");

                var res = _jogadorService.Excluir(jogador);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("salvar")]
        public HttpResponseMessage SalvarJogador(JogadorModel model)
        {
            try
            {
                 _jogadorService.SalvarJogador(new Jogador(model.Nome,model.CPF));
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
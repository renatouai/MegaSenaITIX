
using MegaSena.Domain.Interface;
using System.Net.Http;
using System.Web.Http;

namespace Erp.Api.Controllers
{
    [RoutePrefix("jogo")]
    public class JogoController : ApiController
    {
        private readonly ISorteioService _sorteioService;
        public JogoController(ISorteioService sorteioService)
        {
            this._sorteioService = sorteioService;
        }

        /*        [HttpGet]
        [Route("listarJogos")]
        public HttpResponseMessage ListarJogos()
        {
         
        } */
    }
}
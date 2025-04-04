using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.EntityFrameworkDiver;
using Microsoft.AspNetCore.Mvc;

namespace FootballAPI.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        //private readonly FootballContext footballContext;        
        private readonly IFootballService<Match> _FootballService;
        public MatchController(IFootballService<Match> footballService)
        {
            _FootballService = footballService;
        }

        //TODO: se agrega en el verbo http el nombre del metodo
        //Se omite el uso del decorador Route
        //cuando el metodo recibe parametros se le asigna el FromQuery,FromBody
        //En el post se agrega this.Ok
        //en el launchSettings se agreaga la variable "launchUrl" para que cuando inicialice el servicio cargue el swagger
        [HttpGet("getall")]
        public ActionResult<IEnumerable<Match>> Get()
        {
            return this.Ok(_FootballService.FindAll());
            //return this.Ok(footballContext.Matches);
        }

        [HttpGet("GetById")]
        public ActionResult GetById([FromQuery] int id)
        {
            var response = _FootballService.Find(id);
            //var response = footballContext.Matches.Find(id);
            if (response == default)
                this.NotFound();
            return this.Ok();
        }

        [HttpPost("post")]
        public ActionResult Post([FromBody] Match match)
        {
            var response = _FootballService.Add(match);
            //var response = footballContext.Matches.Add(match).Entity;
            return this.CreatedAtAction("GetById", response.Id, response);
        }

        [HttpPut("put")]
        public ActionResult Update([FromQuery] int id, [FromBody]Match match)
        {
            if (_FootballService.Find(id) == default)
                return this.NotFound();

            var response = _FootballService.Update(match , id);
            //if (footballContext.Matches.Find(id) == default)
            //    return this.NotFound();

            //footballContext.Matches.Update(match);
            return this.Ok();
        }
    }
}

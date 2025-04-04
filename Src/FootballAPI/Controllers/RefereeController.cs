using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.EntityFrameworkDiver;
using Microsoft.AspNetCore.Mvc;

namespace FootballAPI.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class RefereeController : ControllerBase
    {
        //readonly FootballContext footballContext;
        private readonly IFootballService<Referee> _FootballService;
        public RefereeController(IFootballService<Referee> footballService)
        {
            _FootballService = footballService;
        }

        //TODO: se agrega en el verbo http el nombre del metodo
        //Se omite el uso del decorador Route
        //cuando el metodo recibe parametros se le asigna el FromQuery,FromBody
        //En el post se agrega this.Ok
        //en el launchSettings se agreaga la variable "launchUrl" para que cuando inicialice el servicio cargue el swagger

        [HttpGet("getall")]
        public ActionResult<IEnumerable<Referee>> Get()
        {
            return this.Ok(_FootballService.FindAll());
            //return this.Ok(footballContext.Referees);
        }

        [HttpGet("GetById")]
        public ActionResult GetById([FromQuery]int id)
        {
            var response = _FootballService.Find(id);
            //var response = footballContext.Referees.Find(id);
            if (response == default)
                this.NotFound();
            return this.Ok();
        }

        [HttpPost("post")]
        public ActionResult Post([FromBody]Referee referee)
        {
            var response = _FootballService.Add(referee);
            //var response = footballContext.Referees.Add(referee).Entity;
            return this.CreatedAtAction("GetById", response.Id, response);
        }

        [HttpPut("update")]
        public ActionResult Update([FromQuery] int id,[FromBody] Referee referee)
        {
            if (_FootballService.Find(id) == default)
                return this.NotFound();

            var response = _FootballService.Update(referee, id);
            //if (footballContext.Referees.Find(id) == default)
            //    return this.NotFound();

            //footballContext.Referees.Update(referee);        
            return this.Ok();
        }
    }
}

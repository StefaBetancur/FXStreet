using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FootballAPI.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        //readonly FootballContext footballContext;
        private readonly IFootballService<Player> _FootballService;
        public PlayerController(IFootballService<Player> footballService)
        {
            _FootballService = footballService;
        }
        //TODO: se agrega en el verbo http el nombre del metodo
        //Se omite el uso del decorador Route
        //cuando el metodo recibe parametros se le asigna el FromQuery,FromBody
        //En el post se agrega this.Ok
        //en el launchSettings se agreaga la variable "launchUrl" para que cuando inicialice el servicio cargue el swagger
        [HttpGet("getall")]
        public ActionResult<IEnumerable<Player>> Get()
        {
            return this.Ok(_FootballService.FindAll());
            // return this.Ok(footballContext.Players);
        }

        [HttpGet("GetById")]
      
        public ActionResult GetById([FromQuery]int id)
        {
            var response = _FootballService.Find(id);
            //var response = footballContext.Players.Find(id);
            if (response == default)
                this.NotFound();
            return this.Ok(response);
        }

        [HttpPost("post")]
        public ActionResult Post([FromBody] Player player)
        {
            var response = _FootballService.Add(player);
            //var response = footballContext.Players.Add(player).Entity;
            return this.Ok(this.CreatedAtAction("GetById", response.Id, response));
        }

        [HttpPut("update")]
        public ActionResult Update([FromQuery] int id, [FromBody]Player player)
        {
            if (_FootballService.Find(id) == default)
                return this.NotFound();

            var response= _FootballService.Update(player, id);
            //if (footballContext.Players.Find(id) == default)
            //    return this.NotFound();

            //footballContext.Players.Update(player);        
            return this.Ok();
        }
    }
}

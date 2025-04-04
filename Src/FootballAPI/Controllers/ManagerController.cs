using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.EntityFrameworkDiver;
using Microsoft.AspNetCore.Mvc;

namespace FootballAPI.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IFootballService<Manager> _FootballService;
        public ManagerController(IFootballService<Manager> footballService)
        {
            _FootballService = footballService;
        }

        //TODO: se agrega en el verbo http el nombre del metodo
        //Se omite el uso del decorador Route
        //cuando el metodo recibe parametros se le asigna el FromQuery,FromBody
        //En el post se agrega this.Ok
        //en el launchSettings se agreaga la variable "launchUrl" para que cuando inicialice el servicio cargue el swagger

        [HttpGet("getall")]
        public ActionResult<IEnumerable<Manager>> Get()
        {
            return this.Ok(_FootballService.FindAll());

            //return this.Ok(footballContext.Managers);
        }

        [HttpGet("GetById")]
        public ActionResult GetById([FromQuery]int id)
        {
            var response = _FootballService.Find(id);
            //var response = footballContext.Managers.Find(id);
            if (response == default)
                this.NotFound();
            return this.Ok(response);
        }

        [HttpPost("post")]
        public ActionResult Post(Manager manager)
        {
            var response = _FootballService.Add(manager);
            // var response = footballContext.Managers.Add(manager).Entity;
            return this.CreatedAtAction("GetById", response.Id, response);
        }

        [HttpPut("put")]
        public ActionResult Update([FromQuery]int id, [FromBody]Manager manager)
        {
            if (_FootballService.Find(id) == default)
                return this.NotFound();

           var response = _FootballService.Update(manager, id);
            //if (footballContext.Managers.Find(id) == default)
            //    return this.NotFound();

            //footballContext.Managers.Update(manager);           
            return this.Ok();
        }
    }
}

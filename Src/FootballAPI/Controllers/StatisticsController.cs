using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FootballAPI.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        readonly IFootballStatisticsService footballContext;
        public StatisticsController(IFootballStatisticsService footballContext)
        {
            this.footballContext = footballContext;
        }

        //TODO: se agrega en el verbo http el nombre del metodo
        //Se omite el uso del decorador Route
        //cuando el metodo recibe parametros se le asigna el FromQuery,FromBody
        //En el post se agrega this.Ok
        //en el launchSettings se agreaga la variable "launchUrl" para que cuando inicialice el servicio cargue el swagger
        [HttpGet("yellowcards")]
        public ActionResult GetYellowCards()
        {
            return this.Ok(footballContext.GetYellowCards());
        }

        [HttpGet("redcards")]
        public ActionResult GetRedCards()
        {
            return this.Ok(footballContext.GetRedCards());
        }

        [HttpGet("minutesplayed")]
        public ActionResult GetMinutesPlayed()
        {
            return this.Ok(footballContext.GetMinutesPlayed());
        }
    }
}

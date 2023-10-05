using Mi_Agenda_de_Contactos.Data.Implementations;
using Mi_Agenda_de_Contactos.Migrations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mi_Agenda_de_Contactos.Controllers
{
    [Route("api/[controller]")] //secciona "controles" y devuelve por ejemplo api/user
    [ApiController] //decoradores especificos de controladores
    public class UserController : ControllerBase
    {
        private AgendaContext _agendaContext; //inyeccion
        public UserController(AgendaContext agendaContext)
        {
            _agendaContext = agendaContext;
        }

        [HttpGet]
        public IActionResult GetUsuarios()
        {
            return Ok(); //Status code: 200
        }
        [HttpDelete]
        public IActionResult EliminarUsuario() 
        {
            return NoContent(); //Status code: 204
        }
        [HttpGet("{apellido}")] //solo deberiamos poner numeros, por seguridad
        public IActionResult GetUsuariosApellido(string apellido) 
        {
            return Ok(_agendaContext.Users.Where(x => x.LastName == apellido).ToList());// response 
        }
        [HttpPut]
        public IActionResult UpdateUser(User userToUpdateDto) 
        {
            return Ok();
        }
    }
}

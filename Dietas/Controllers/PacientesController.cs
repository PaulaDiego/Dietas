using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Dietas.Models;
using System.Web.Http.Cors;
using Dietas.Service;

namespace Dietas.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PacientesController : ApiController
    {
        private IPacientesService PacientesService;
        public PacientesController(IPacientesService _PacientesService)
        {
            this.PacientesService = _PacientesService;
        }

        // GET: api/Pacientes
        public IQueryable<Paciente> GetPacientes()
        {
            return this.PacientesService.ReadPacientes();
        }

        // GET: api/Pacientes/5
        [ResponseType(typeof(Paciente))]
        public IHttpActionResult GetPaciente(long id)
        {
            Paciente Paciente = this.PacientesService.GetPaciente(id);
            if (Paciente == null)
            {
                return NotFound();
            }

            return Ok(Paciente);
        }

        // PUT: api/Pacientes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPaciente(long id, Paciente Paciente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Paciente.Id)
            {
                return BadRequest();
            }


            try
            {
                this.PacientesService.PutPaciente(Paciente);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (this.PacientesService.GetPaciente(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Pacientes
        [ResponseType(typeof(Paciente))]
        public IHttpActionResult PostPaciente(Paciente Paciente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Paciente = this.PacientesService.Create(Paciente);

            return CreatedAtRoute("DefaultApi", new { id = Paciente.Id }, Paciente);
        }

        // DELETE: api/Pacientes/5
        [ResponseType(typeof(Paciente))]
        public IHttpActionResult DeletePaciente(long id)
        {
            try
            {
                return Ok(this.PacientesService.Delete(id));
            }
            catch (NoEncontradoException e)
            {
                return NotFound();
            }



        }
    }
}
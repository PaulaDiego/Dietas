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
    public class DietasController : ApiController
    {
        private IDietasService DietasService;
        public DietasController(IDietasService _DietasService)
        {
            this.DietasService = _DietasService;
        }

        // GET: api/Dietas
        public IQueryable<Dieta> GetDietas()
        {
            return this.DietasService.ReadDietas();
        }

        // GET: api/Dietas/5
        [ResponseType(typeof(Dieta))]
        public IHttpActionResult GetDieta(long id)
        {
            Dieta Dieta = this.DietasService.GetDieta(id);
            if (Dieta == null)
            {
                return NotFound();
            }

            return Ok(Dieta);
        }

        // PUT: api/Dietas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDieta(long id, Dieta Dieta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Dieta.Id)
            {
                return BadRequest();
            }


            try
            {
                this.DietasService.PutDieta(Dieta);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (this.DietasService.GetDieta(id) == null)
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

        // POST: api/Dietas
        [ResponseType(typeof(Dieta))]
        public IHttpActionResult PostDieta(Dieta Dieta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Dieta = this.DietasService.Create(Dieta);

            return CreatedAtRoute("DefaultApi", new { id = Dieta.Id }, Dieta);
        }

        // DELETE: api/Dietas/5
        [ResponseType(typeof(Dieta))]
        public IHttpActionResult DeleteDieta(long id)
        {
            try
            {
                return Ok(this.DietasService.Delete(id));
            }
            catch (NoEncontradoException e)
            {
                return NotFound();
            }



        }
    }
}
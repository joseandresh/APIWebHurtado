namespace APIWebHurtado.Controllers
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using System.Web.Http.Description;
    using APIWebHurtado.Models;

    public class HurtadoesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Hurtadoes
        [Authorize]
        public IQueryable<Hurtado> GetHurtadoes()
        {
            return db.Hurtadoes;
        }

        // GET: api/Hurtadoes/5
        [Authorize]
        [ResponseType(typeof(Hurtado))]
        public IHttpActionResult GetHurtado(int id)
        {
            Hurtado hurtado = db.Hurtadoes.Find(id);
            if (hurtado == null)
            {
                return NotFound();
            }

            return Ok(hurtado);
        }

        // PUT: api/Hurtadoes/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHurtado(int id, Hurtado hurtado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hurtado.HurtadoID)
            {
                return BadRequest();
            }

            db.Entry(hurtado).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HurtadoExists(id))
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

        // POST: api/Hurtadoes
        [Authorize]
        [ResponseType(typeof(Hurtado))]
        public IHttpActionResult PostHurtado(Hurtado hurtado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Hurtadoes.Add(hurtado);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = hurtado.HurtadoID }, hurtado);
        }

        // DELETE: api/Hurtadoes/5
        [Authorize]
        [ResponseType(typeof(Hurtado))]
        public IHttpActionResult DeleteHurtado(int id)
        {
            Hurtado hurtado = db.Hurtadoes.Find(id);
            if (hurtado == null)
            {
                return NotFound();
            }

            db.Hurtadoes.Remove(hurtado);
            db.SaveChanges();

            return Ok(hurtado);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HurtadoExists(int id)
        {
            return db.Hurtadoes.Count(e => e.HurtadoID == id) > 0;
        }
    }
}
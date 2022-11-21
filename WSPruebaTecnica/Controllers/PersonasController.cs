using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSPruebaTecnica.Models;
using WSPruebaTecnica.Request;
using WSPruebaTecnica.Responses;

namespace WSPruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Response oRespuesta = new Response();
            oRespuesta.Exito = 0;

            try
            {

                using (PruebaTecnicaContext db = new PruebaTecnicaContext())
                {
                    var lst = db.Personas.ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Datos = lst;

                }

            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }


        [HttpPost]

        public IActionResult Add(PersonasRequest oRequest)
        {
            Response oRespuesta = new Response();
            oRespuesta.Exito = 0;

            try
            {

                using (PruebaTecnicaContext db = new PruebaTecnicaContext())
                {
                    Persona oClient = new Persona();
                    oClient.Nombres = oRequest.Nombres;
                    db.Personas.Add(oClient);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;

                }

            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);

        }

        [HttpPut]

        public IActionResult Edit(PersonasRequest oRequest)
        {
            Response oRespuesta = new Response();
            oRespuesta.Exito = 0;

            try
            {

                using (PruebaTecnicaContext db = new PruebaTecnicaContext())
                {
                    Persona oClient = db.Personas.Find(oRequest.Id);
                    oClient.Nombres = oRequest.Nombres;
                    db.Entry(oClient).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    var lst = db.Personas.ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Datos = lst;

                }

            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);

        }

        [HttpDelete("{Id}")]

        public IActionResult Delete(int Id)
        {
            Response oRespuesta = new Response();
            oRespuesta.Exito = 0;

            try
            {

                using (PruebaTecnicaContext db = new PruebaTecnicaContext())
                {
                    Persona oClient = db.Personas.Find(Id);
                    db.Remove(oClient);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;


                }

            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);

        }
    }
}

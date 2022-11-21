using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSPruebaTecnica.Models;
using WSPruebaTecnica.Request;
using WSPruebaTecnica.Responses;

namespace WSPruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
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
                    var lst = db.Usuarios.ToList();
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

        public IActionResult Add(UsuarioRequest oRequest)
        {
            Response oRespuesta = new Response();
            oRespuesta.Exito = 0;

            try
            {

                using (PruebaTecnicaContext db = new PruebaTecnicaContext())
                {
                    Usuario oClient = new Usuario();
                    oClient.Usuario1 = oRequest.Nombre;
                    db.Usuarios.Add(oClient);
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

        public IActionResult Edit(UsuarioRequest oRequest)
        {
            Response oRespuesta = new Response();
            oRespuesta.Exito = 0;

            try
            {

                using (PruebaTecnicaContext db = new PruebaTecnicaContext())
                {
                    Usuario oClient = db.Usuarios.Find(oRequest.Id);
                    oClient.Usuario1 = oRequest.Nombre;
                    db.Entry(oClient).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    var lst = db.Usuarios.ToList();
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
                    Usuario oClient = db.Usuarios.Find(Id);
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

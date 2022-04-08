using EncuestasAPI.Models;
using EncuestasAPI.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace EncuestasAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EncuestaController : ControllerBase
    {
       
        public EncuestaController(IEncuestaRepository encuestaRepository)
        {
            _encuesta = encuestaRepository;
        }

        IEncuestaRepository _encuesta;

        [Produces("text/html")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var content = _encuesta.fillEncuesta(id);
            return new ContentResult
            {
                Content = content,
                ContentType = "text/html",
                StatusCode = (int)HttpStatusCode.OK
            };
        }

        [Authorize]
        [HttpGet]
        [Route("getOne")]
        public IActionResult GetResults(int id)
        {
            var data = _encuesta.getResultsEncuesta(id);
            return Ok(data);

        }


        [Authorize]
        [HttpPost]
        public IActionResult Post(EncuestaTable encuesta)
        {
            var resp=_encuesta.insertEncuesta(encuesta);
            var result = new OkObjectResult(new { message = "201 Created", link = resp});
            return result;
        }

        [HttpPost]
        [Route("llenar")]
        public IActionResult llenar([FromBody] dynamic requestData)
        {
            try
            {
                string strjson= requestData.ToString();
                strjson = strjson.Replace("{","");
                strjson = strjson.Replace("}", "");
                var props = strjson.Split(",");
                int id=-1;
                foreach (var item in props)
                {
                    var name_value = item.Split(":");
                    var nombre = name_value[0].Replace("\"", "");
                    nombre=nombre.Trim();
                    if (nombre == "encuesta_id")
                    {
                        id = Convert.ToInt32(name_value[1]);
                    }
                }

                _encuesta.insertFilled(id, requestData.ToString());

                return Ok();
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
           
        }

        [Authorize]
        [HttpPut]
        public IActionResult Put(EncuestaTable encuesta)
        {
            _encuesta.updateEncuesta(encuesta);
            return Ok();
        }

        [Authorize]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _encuesta.deleteEncuesta(id);
            return Ok();
        }


    }
}

using EncuestasAPI.Models;
using EncuestasAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace EncuestasAPI.Repository.Implementation
{
    public class EncuestaRepository : RepositoryBase<EncuestaTable>, IEncuestaRepository
    {
        public EncuestaRepository(EncuestasDbContext context) : base(context)
        {

        }

        public string fillEncuesta(int id)
        {
            try
            {
                IQueryable<EncuestaTable> list;

                

                string res = "<form>";

                list = _context.EncuestaTables
                    .Include(e => e.Campos).ThenInclude(c => c.IdTipoCampoNavigation)
                    .Where(e => e.IdEncuesta == id);

                EncuestaTable encuesta = list.FirstOrDefault();

                foreach (var campo in encuesta.Campos)
                {
                    string requerido = "";
                    if (campo.EsRequerido) {
                        requerido = "required";
                    }
                    res += "<label>" + campo.TituloCampo + ":</label> <br> <input type =\"" + campo.IdTipoCampoNavigation.TipoHtml + "\" id = \"" + campo.NombreCampo + "\" name = \"" + campo.NombreCampo + "\""+requerido+"><br>";
                }

                res += "<input type = \"submit\" value = \"Submit\"></form>" +
                    "<script>function handleSubmit(event) {event.preventDefault();const data = new FormData(event.target);" +
                    "const value = Object.fromEntries(data.entries());" +
                    "value.encuesta_id="+encuesta.IdEncuesta+
                    ";console.log(value);" +
                    "var xhr = new XMLHttpRequest();" +
                    "xhr.open(\"POST\", " + "\"https://localhost:5001/api/Encuesta/llenar\");" +
                    "xhr.setRequestHeader(\"Accept\", \"application / json\");"+
                    "xhr.setRequestHeader('Content-Type', 'application/json');" +
                    "xhr.send(JSON.stringify(value));"+
                    "}" +
                    "const form = document.querySelector('form');" +
                    "form.addEventListener('submit', handleSubmit);</script>";
                    

                return res;
            }
            catch (Exception)
            {

                return "Error en el servidor";
            }
           
        }

        public IEnumerable<RespuestasEncuestum> getResultsEncuesta(int id)
        {

            IQueryable<RespuestasEncuestum> list;

            list = _context.RespuestasEncuesta.Where(r=>r.IdEncuesta==id);

            return list.ToList();
        }

        public EncuestaTable getOneEncuesta(int id)
        {

            IQueryable<EncuestaTable> list;

            list = _context.EncuestaTables.Where(e => e.IdEncuesta == id);

            return list.FirstOrDefault();
        }

        public string insertEncuesta(EncuestaTable encuesta)
        {

            try
            {
                _context.EncuestaTables.Add(encuesta);
            _context.SaveChanges();

                return "https://localhost:5001/api/Encuesta?id="+encuesta.IdEncuesta;
            } catch (Exception e) {
                return "";
            } 

           

        }

        public bool insertFilled(int id, string jsonstring)
        {
            try
            {
                RespuestasEncuestum respuestas=new RespuestasEncuestum { IdEncuesta=id,Respuestas=jsonstring};
                _context.Add(respuestas);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public bool updateEncuesta(EncuestaTable encuesta)
        {
            try
            {
                EncuestaTable encuestaold = _context.EncuestaTables
                    .Where(e => e.IdEncuesta == encuesta.IdEncuesta).FirstOrDefault();

                encuestaold.DescripcionEncuesta = encuesta.DescripcionEncuesta;
                encuestaold.NombreEncuesta = encuesta.NombreEncuesta;

                foreach (Campo campo in encuesta.Campos)
                {
                    campo.IdEncuesta = encuesta.IdEncuesta;
                    _context.Update(campo);
                }

                _context.SaveChanges();
                _context.Update(encuestaold);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool deleteEncuesta(int id)
        {
            try

            {
                EncuestaTable encuesta = _context.EncuestaTables.Where(e => e.IdEncuesta == id).FirstOrDefault();
                _context.Remove(encuesta);
                _context.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

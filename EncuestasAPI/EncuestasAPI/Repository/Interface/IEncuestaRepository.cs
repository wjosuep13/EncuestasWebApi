
using EncuestasAPI.Models;

using System.Collections.Generic;


namespace EncuestasAPI.Repository.Interface
{
    public interface IEncuestaRepository : IRepositoryBase<EncuestaTable>
    {
        string fillEncuesta(int id);

        IEnumerable<RespuestasEncuestum> getResultsEncuesta(int id);

        EncuestaTable getOneEncuesta(int id);
        string insertEncuesta(EncuestaTable encuesta);

        bool insertFilled(int id,string jsonstring);

        bool updateEncuesta(EncuestaTable encuesta);
        bool deleteEncuesta(int id);
    }
}

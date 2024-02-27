using Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationEstudiantes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {

        private static List<Estudiante> list = new List<Estudiante>()
        {

            new() { Id = 1, Documento = "1108", Nombres = "Jose Rios", Programa = "Ingeniería de Sistemas", Semestre = 1 },
            new() { Id = 2, Documento = "1207", Nombres = "Maria Garcia", Programa = "Administración de Empresas", Semestre = 2 },
            new() { Id = 3, Documento = "1306", Nombres = "Carlos Lopez", Programa = "Derecho", Semestre = 3 },
            new() { Id = 4, Documento = "1405", Nombres = "Laura Martinez", Programa = "Medicina", Semestre = 4 },
            new() { Id = 5, Documento = "1504", Nombres = "Juan Rodriguez", Programa = "Ingeniería Civil", Semestre = 5 },
            new() { Id = 6, Documento = "1603", Nombres = "Ana Ramirez", Programa = "Psicología", Semestre = 6 },
            new() { Id = 7, Documento = "1702", Nombres = "Luisa Torres", Programa = "Contaduría Pública", Semestre = 7 },
            new() { Id = 8, Documento = "1801", Nombres = "Pedro Sanchez", Programa = "Ingeniería Industrial", Semestre = 8 },
            new() { Id = 9, Documento = "1909", Nombres = "Sofia Perez", Programa = "Arquitectura", Semestre = 9 },
            new() { Id = 10, Documento = "2008", Nombres = "Elena Castro", Programa = "Biología", Semestre = 10 },
            new() { Id = 11, Documento = "2107", Nombres = "Diego Gutierrez", Programa = "Ingeniería de Sistemas", Semestre = 2 },
            new() { Id = 12, Documento = "2206", Nombres = "Laura Jimenez", Programa = "Administración de Empresas", Semestre = 3 },
            new() { Id = 13, Documento = "2305", Nombres = "Andres Silva", Programa = "Derecho", Semestre = 4 },
            new() { Id = 14, Documento = "2404", Nombres = "Camila Montoya", Programa = "Medicina", Semestre = 5 },
            new() { Id = 15, Documento = "2503", Nombres = "Santiago Ruiz", Programa = "Ingeniería Civil", Semestre = 6 },
            new() { Id = 16, Documento = "2602", Nombres = "Valentina Rojas", Programa = "Psicología", Semestre = 7 },
            new() { Id = 17, Documento = "2701", Nombres = "Daniel Gomez", Programa = "Contaduría Pública", Semestre = 8 },
            new() { Id = 18, Documento = "2809", Nombres = "Ana Maria Perez", Programa = "Ingeniería Industrial", Semestre = 9 },
            new() { Id = 19, Documento = "2908", Nombres = "Carlos Torres", Programa = "Arquitectura", Semestre = 10 },
            new() { Id = 20, Documento = "3007", Nombres = "Juliana Ramirez", Programa = "Biología", Semestre = 1 },


    };

        public static List<Estudiante> List { get => list; set => list = value; }

        [HttpGet]
        public ActionResult<List<Estudiante>> Get()
        {

            return List;
        }

        [HttpGet("{id}")]
        public ActionResult<Estudiante> Get(int id)
        {

            Estudiante estudianteEncontrado = List.Find(x => x.Id == id);

            if (estudianteEncontrado is not null)
            {

                return Ok(estudianteEncontrado);

            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<Estudiante> Post([FromBody] Estudiante estudiante)
        {

            List.Add(estudiante);
            return Ok(estudiante);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Estudiante estudiante)
        {
            Estudiante estudianteEncontrado = List.Find(x => x.Id == id);

            if (estudianteEncontrado is not null) {

                estudianteEncontrado.Documento = estudiante.Documento;
                estudianteEncontrado.Nombres = estudiante.Nombres;
                estudianteEncontrado.Semestre = estudiante.Semestre;
                estudianteEncontrado.Activo = estudiante.Activo;
                estudianteEncontrado.Programa = estudiante.Programa;

                return Ok($"Estudiante {id} actualizado correctamente");
            }



            return NotFound("No se encontró el elemento a actualizar");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            Estudiante estudianteEncontrado = List.Find(x => x.Id == id);

            if (estudianteEncontrado is not null)
            {
                List.Remove(estudianteEncontrado);
                return Ok($"Estudiante {id} borrado");

            }

            return NotFound("No se encontró el elemento a borrar");

        }
    }
}

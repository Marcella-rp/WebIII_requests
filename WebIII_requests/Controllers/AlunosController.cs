using Microsoft.AspNetCore.Mvc;
using WebIII_requests.Services;

namespace WebIII_requests.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunosController : ControllerBase
    {

        [HttpGet]
        public List<Alunos> GetAluno()
        {
            return ListaDeAlunos.listaDeAlunos;
        }

        [HttpPost]
        public Alunos AdicionarAluno (Alunos NovoAluno)
        {
            ListaDeAlunos.listaDeAlunos.Add(NovoAluno);
            return NovoAluno;
        }

        [HttpPut]
        public List<Alunos> AlterarAluno(string cpf,string turma)
        {
            var listateste = ListaDeAlunos.listaDeAlunos.Where(c => c.Cpf == cpf).ToList();
            if (listateste.Exists(c => c.Cpf == cpf))
            {
                foreach (var aluno in ListaDeAlunos.listaDeAlunos)
                {
                    aluno.Turma = turma;
                }
            }
            return ListaDeAlunos.listaDeAlunos;
        }

        [HttpDelete]
        public List<Alunos> RemoverAluno(string cpf)
        {
            ListaDeAlunos.listaDeAlunos.RemoveAll(c => c.Cpf == cpf);
            return ListaDeAlunos.listaDeAlunos;
        }
    }
}

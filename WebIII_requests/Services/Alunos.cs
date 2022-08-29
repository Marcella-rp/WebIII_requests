namespace WebIII_requests.Services
{
    public class Alunos
    {
        public string Cpf { get; set; }
        public string NomeAluno { get; set; }
        public string NomeResponsavel { get; set; }
        public string Turma {get; set; }
        public DateTime DataNascimento { get; set; }


        public Alunos( string cpf, string nomeAluno, string nomeResponsavel, string turma, DateTime dataNascimento)
        {
            Cpf = cpf;
            NomeAluno = nomeAluno;
            NomeResponsavel = nomeResponsavel;
            Turma = turma;
            DataNascimento = dataNascimento;
        }
    }
}

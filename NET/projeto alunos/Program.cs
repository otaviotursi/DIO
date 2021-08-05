using System;

namespace projeto_alunos
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];

            string opcaoUsuario = ObterOpcaoUsuario();

            var indiceAluno = 0;
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        // TODO: adicionar aluno
                        Aluno aluno = new Aluno();

                        Console.WriteLine("Informe o nome do aluno: ");
                        aluno.Nome = Console.ReadLine();
                        
                        Console.WriteLine("Informe a nota do aluno:");
                        
                        if (decimal.TryParse(Console.ReadLine(), out decimal nota)){
                            aluno.Nota = nota;
                        } else {
                            throw new ArgumentException("Valor da nota deve ser decimal");
                        }

                        alunos[indiceAluno] = aluno;
                        indiceAluno += 1;

                        
                        break;

                    case "2":
                        foreach (var estudante in alunos){
                            if (!string.IsNullOrEmpty(estudante.Nome)){
                                Console.WriteLine($"ALUNO: {estudante.Nome} - NOTA: {estudante.Nota}");
                            }
                        }
                        break;

                    case "3":
                        decimal notaTotal = 0;
                        var nrAlunos = 0;

                        for (int i=0; i < alunos.Length; i++){
                            if (!string.IsNullOrEmpty(alunos[i].Nome)){
                                notaTotal += alunos[i].Nota;
                                nrAlunos +=1;
                            }
                        }

                        var mediaGeral = notaTotal/nrAlunos;
                        ConceitoEnum conceitoGeral;

                        if (mediaGeral < 3) {
                            conceitoGeral = ConceitoEnum.E;
                        } else if (mediaGeral < 5){
                            conceitoGeral = ConceitoEnum.D;
                        } else if (mediaGeral < 7){
                            conceitoGeral = ConceitoEnum.C;
                        } else if (mediaGeral < 9){
                            conceitoGeral = ConceitoEnum.B;
                        } else {
                            conceitoGeral = ConceitoEnum.A;
                        }
                        Console.WriteLine($"MÉDIA GERAL: {mediaGeral} - CONCEITO: {conceitoGeral}");
                
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();

                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Inserir novo alunos");
            Console.WriteLine("2 - Listar alunos");
            Console.WriteLine("3 - Calcular média geral");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();

            return opcaoUsuario;
        }
    }
}

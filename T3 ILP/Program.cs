using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace T3_ILP
{
    class Program
    {
        static void Main(string[] args)
        {
            //Exerc1();
            //Exerc2();
            //Exerc3();
            //Exerc4();
            //Exerc5();
            //Exerc6();
            //Exerc7();
            Exerc8();
        }

        static void Exerc1()
        {
            double S = 0;
            Enumerable.Range(0, 50).ToList().ForEach(n => S += (double)(2 * n + 1) / (double)(n + 1));
            Console.WriteLine("Resultado da soma: " + S);
            Console.ReadKey();
            Console.Clear();
        }

        private static void Exerc2()
        {
            var listInt = new List<int>();
            var num = 1;
            Console.WriteLine("Entre com números inteiros positivos: ");
            while(num > 0)
                listInt.Add(num = Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine("Média dos números informados: " + listInt.Where(x=> x > 0).Average());
            Console.ReadKey();
            Console.Clear();
        }

        static void Exerc3()
        {
            var listInt = new List<int>();
            Console.WriteLine("Informe 10 números inteiros: ");
            for (int i = 0; i < 10; i++)
                listInt.Add(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine("Total de números ímpares: " + listInt.Where(x => x % 2 != 0).Count());
            Console.WriteLine("Total de números pares: " + listInt.Where(x => x % 2 == 0).Count());
            Console.WriteLine("Soma dos números pares: " + listInt.Where(x => x % 2 == 0).Sum());
            Console.WriteLine("Média dos números ímpares: " + listInt.Where(x => x % 2 != 0).Average());
            Console.ReadKey();
            Console.Clear();
        }

        static void Exerc4()
        {
            var listFunc = new List<Func>();
            Console.WriteLine("Informe os dados de 10 funcionarios: ");
            for (int i = 1; i <= 10; i++)
            {
                var func = new Func();
                Console.WriteLine("Funcionário " + i + ", código: ");
                func.Cod = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Carga horária: ");
                func.QtdHoras = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Número de dependentes: ");
                func.QtdDependentes = Convert.ToInt32(Console.ReadLine());
                listFunc.Add(func);
            }
            listFunc.ForEach(f => f.SalarioBruto = ((f.QtdHoras * 12) + 40 * f.QtdDependentes));
            foreach(Func func in listFunc)
                Console.WriteLine("Funcionário " + func.Cod + ". Desconto INSS: " + 0.085 * func.SalarioBruto + ", desconto IR:" + 0.05 * func.SalarioBruto + ", salário líquido: " + (1 - 0.135) * func.SalarioBruto);
            Console.ReadKey();
            Console.Clear();
        }

        public partial class Func
        {
            public int Cod { get; set; }
            public int QtdHoras { get; set; }
            public int QtdDependentes { get; set; }
            public double SalarioBruto { get; set; }
        }

        static void Exerc5()
        {
            var listLeitor = new List<Leitor>();
            Console.WriteLine("Informe dados de leitores: ");
            while (true)
            {
                var leitor = new Leitor();
                Console.WriteLine("Sexo: ");
                leitor.Sexo = Console.ReadLine();
                Console.WriteLine("Idade: ");
                leitor.Idade = Convert.ToInt32(Console.ReadLine());
                if (leitor.Idade < 0)
                    break;
                Console.WriteLine("Quantidade de livros lidos: ");
                leitor.QtdLivros = Convert.ToInt32(Console.ReadLine());
                listLeitor.Add(leitor);
            }
            Console.Clear();
            Console.WriteLine("Total de livros lidos por menores de 10 anos: " + listLeitor.Where(l => l.Idade < 10).Sum(f => f.QtdLivros));
            Console.WriteLine("Quantidade de mulheres que leram 5 livros ou mais: " + listLeitor.Where(l => l.Sexo == "F" && l.QtdLivros >= 5).Count());
            Console.WriteLine("Média de idade dos homens que leram menos que 5 livros: " + listLeitor.Where(l => l.Sexo == "M" && l.QtdLivros < 5).Average(f => f.Idade));
            Console.WriteLine("Percentual de pessoas que não leram livros: " + (double)listLeitor.Where(l => l.QtdLivros == 0).Count() / (double)listLeitor.Count());
            Console.ReadKey();
            Console.Clear();
        }

        public partial class Leitor
        {
            public string Sexo { get; set; }
            public int Idade { get; set; }
            public int QtdLivros { get; set; }
        }

        static void Exerc6()
        {
            var listPessoas = new List<Pessoa>();
            /* Realiza a consulta no banco de dados */
            Console.WriteLine("Total de respostas 10: " + listPessoas.Where(p => p.Nota == 10).Count());
            Console.WriteLine("Média de idade: " + listPessoas.Average(p => p.Idade));
            Console.WriteLine("Porcentagem dos que responderam 5 ou menos para a opinião da peça: " + (double)listPessoas.Where(p => p.Nota <= 5).Count() / (double)listPessoas.Count());
            Console.WriteLine("Identificador da pessoa mais velha: " + listPessoas.OrderBy(p=>p.Idade).Last().Identificador);
            Console.ReadKey();
            Console.Clear();
        }

        public partial class Pessoa
        {
            public int Idade { get; set; }
            public string Identificador { get; set; }
            public int Nota { get; set; }
        }

        static void Exerc7()
        {
            var listAlunos = new List<Aluno>();
            Console.WriteLine("Informe dados dos alunos: ");
            while (true)
            {
                var aluno = new Aluno();
                Console.WriteLine("Série: ");
                aluno.Serie = Convert.ToInt32(Console.ReadLine());
                if (aluno.Serie == 0)
                    break;
                Console.WriteLine("Quantidade de livros que lê: ");
                aluno.QtdLivros = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Gosta de redação? ");
                aluno.Gosta_de_Redacao = Convert.ToInt32(Console.ReadLine());
                listAlunos.Add(aluno);
            }
            Console.Clear();
            Console.WriteLine("Quantidade de alunos na terceira série: " + listAlunos.Where(a => a.Serie == 3).Count());
            Console.WriteLine("Maior quantidade de livros lidos por um aluno que está na quarta série: " + listAlunos.Where(a => a.Serie == 4).Max(a => a.QtdLivros));
            Console.WriteLine("Porcentagem de alunos que não gostam de fazer redação e que estão na terceira série: " + (double)listAlunos.Where(a => a.Serie == 3 && a.Gosta_de_Redacao == 0).Count() / (double)listAlunos.Count());
            Console.ReadKey();
            Console.Clear();
        }

        public partial class Aluno
        {
            public int Serie { get; set; }
            public int QtdLivros { get; set; }
            public int Gosta_de_Redacao { get; set; }
        }

        static void Exerc8()
        {
            var listProdutos = new List<Produto>();
            Console.WriteLine("Informe dados dos produtos: ");
            while (true)
            {
                var produto = new Produto();
                Console.WriteLine("Id: ");
                produto.Id = Convert.ToInt32(Console.ReadLine());
                if (produto.Id == 0)
                    break;
                Console.WriteLine("Valor: ");
                produto.Valor = Convert.ToInt64(Console.ReadLine());
                Console.WriteLine("Percentual de aumento: ");
                produto.Percentual = Convert.ToDouble(Console.ReadLine());
                listProdutos.Add(produto);
            }
            Console.Clear();
            listProdutos.ForEach(p => p.Valor = p.Valor * (1 + p.Percentual));
            Console.WriteLine("Novos valores: ");
            foreach (Produto p in listProdutos)
                Console.WriteLine(p.Valor);
            Console.WriteLine("Quantidade de produtos mais caros que R$100(após aumento) e que tiveram aumento superior a 5%: " + listProdutos.Where(p => p.Valor > 100 && p.Percentual > 0.05).Count());
            Console.WriteLine("Média de valor dos produtos que não sofreram aumento: " + listProdutos.Where(p => p.Percentual == 0).Average(p => p.Valor));
            Console.WriteLine("Produto mais caro após aumento: " + listProdutos.Max(p=> p.Valor));
            Console.ReadKey();
            Console.Clear();
        }

        public partial class Produto
        {
            public int Id { get; set; }
            public double Valor { get; set; }
            public double Percentual { get; set; }
        }

    }
}

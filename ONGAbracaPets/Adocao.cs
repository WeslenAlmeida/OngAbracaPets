using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ONGAbracaPets
{
    internal class Adocao
    {
        private string CpfAdotante { get; set; }
        private string NumChipAnimal { get; set; }
        public Adocao()
        {
            ControlDB db = new ControlDB();
            bool verifica;
            string cpf;
            int numChip;

            Console.WriteLine(">>> CADASTRO DE ADOÇÃO <<<");
            Console.WriteLine("Digite '0' cara cancelar o Cadastro <<<\n");

            //Verifica se o CPF do Adotante já está Cadastrado
            do
            {
                Console.Write("Digite o CPF do Adotante: ");
                cpf = db.TratamentoDado(Console.ReadLine());
                if (cpf == "0")
                    return;

                verifica = db.VerifCpfExistente(cpf, "CPF", "Adotante");
                if (!verifica)
                {
                    Console.WriteLine("CPF não cadastrado / Inválido!!!");
                    Thread.Sleep(2000);
                }
            }while(!verifica);

            CpfAdotante = cpf;

            //Verifica se o Animal está Cadastrado e se já foi Adotado
            do
            {
                Console.Write("Digite o Número do Chip do Animal: ");
                while (!int.TryParse(Console.ReadLine(), out numChip))
                {
                    Console.WriteLine("Chip Inválido!!\n");
                    Console.Write("Digite o Número do Chip do Animal: ");
                }
                    if (numChip == 0)
                    return;

                verifica = db.VerifChipExistente(numChip, "FK_Animal_NumChip", "Adocao");
                if (verifica)
                {
                    Console.WriteLine("Este animal já foi adotado!!!");
                    Thread.Sleep(2000);
                    return;
                }

                verifica = db.VerifChipExistente(numChip, "NumChip", "Animal");
                if (!verifica)
                {
                    Console.WriteLine("Animal não cadastrado!!!");
                    Thread.Sleep(2000);
                }

                
            } while (!verifica);
            NumChipAnimal = numChip.ToString();

            //Mostra os dados do Adotante e do Animal
            db.ReadAdotante(CpfAdotante);
            db.ReadAnimal(int.Parse(NumChipAnimal));

            Console.WriteLine("Confirma a Adoção?[S/N]:  ");
            string confirma;
            do
            {
                confirma = Console.ReadLine().ToUpper();
                if (confirma == "N")
                    return;
                if(confirma != "S" && confirma != "N")
                {
                    Console.WriteLine("Dado Inválido!!!!");
                    Thread.Sleep(2000);
                }

            } while (confirma != "S" && confirma != "N");

            //Query de Inserção
            string query = "INSERT INTO Adocao (FK_Animal_NumChip, FK_Adotante_CPF)" +
                $"VALUES ({int.Parse(NumChipAnimal)}, '{CpfAdotante}')";

            //Metodo para Inserir os Dados no Banco
            db.SqlExecute(query, "Adocao", "DbOng");
        }
    }
}

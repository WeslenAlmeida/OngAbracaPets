using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ONGAbracaPets
{
    internal class Animal
    {
        private string Familia { get; set; }
        private string Raca { get; set; }
        private string Sexo { get; set; }
        private string Nome { get; set; }

        public Animal()
        {
            

        }
        public void CadastraAnimal()
        {
            ControlDB db = new ControlDB();
            Console.WriteLine(">>> CADASTRO DE ANIMAL <<<");
            Console.WriteLine("Digite '0' cara cancelar o Cadastro <<<\n");

            //Cadastra a Família do Animal
            do
            {
                Console.Write("Digite a Familia do Animal: ");
                Familia = db.TratamentoDado(Console.ReadLine());
                if (Familia == "0")
                    return;
                if (Familia.Length == 0)
                    Console.WriteLine("Campo Obrigatório!!");
            } while (Familia.Length == 0);

            //Cadastra a Raça do Animal
            do
            {
                Console.Write("Digite a Raça do Animal: ");
                Raca = db.TratamentoDado(Console.ReadLine());
                if (Raca == "0")
                    return;
                if (Raca.Length == 0)
                    Console.WriteLine("Campo Obrigatório!!");
            } while (Raca.Length == 0);

            //Cadastra o Sexo do Animal
            do
            {
                Console.Write("Digite o sexo do Animal [M] Masculino / [F] Feminino: ");
                Sexo = db.TratamentoDado(Console.ReadLine()).ToUpper();
                if (Sexo == "0")
                    return;
                if (Sexo != "M" && Sexo != "N" && Sexo != "F")
                {
                    Console.WriteLine("Digite um opção válida!!!");
                    Thread.Sleep(2000);
                }
            } while (Sexo != "M" && Sexo != "N" && Sexo != "F");

            //Cadastra o Nome do Animal
            Console.Write("Digite o Nome do Animal (Opicional): ");
            if (Nome == "0")
                return;
            Nome = db.TratamentoDado(Console.ReadLine());

            //Query para Inserir os Dados no Banco
            string query = "INSERT INTO Animal (Familia, Raca, Sexo, Nome)" +
                $"VALUES ('{Familia}', '{Raca}', '{Sexo}', '{Nome}')";

            //Método Para Inserir os Dados no Banco
            db.SqlExecute(query, "Animal", "DbOng");
        }

        public void AlteraAnimal()
        {
            ControlDB db = new ControlDB();
            int numeroChip;
            bool verifica;
            Console.WriteLine(">>> CADASTRO DE ANIMAL <<<");
            Console.WriteLine("Digite '0' cara cancelar a Alteração <<<\n");

            //Verifica se o Número do Chip do Animal está Cadastrado para Alterar
            do
            {
                
                Console.Write("Insira o Número do Chip do Animal que deseja alterar: ");
                while (!int.TryParse(Console.ReadLine(), out numeroChip));
                verifica = db.VerifChipExistente(numeroChip, "NumChip", "Animal");
                if (numeroChip == 0)
                    return;
                if (!verifica)
                {
                    Console.WriteLine("Animal não cadastrado!!!");
                    Thread.Sleep(2000);
                }

            }while (!verifica);

            //Altera a Família do Animal
            do
            {
                Console.Write("Digite a Familia do Animal: ");
                Familia = db.TratamentoDado(Console.ReadLine());
                if (Familia == "0")
                    return;
                if (Familia.Length == 0)
                    Console.WriteLine("Campo Obrigatório!!");
            } while (Familia.Length == 0);

            //Altera a Raça do Animal
            do
            {
                Console.Write("Digite a Raça do Animal: ");
                Raca = db.TratamentoDado(Console.ReadLine());
                if (Raca == "0")
                    return;
                if (Raca.Length == 0)
                    Console.WriteLine("Campo Obrigatório!!");
            } while (Raca.Length == 0);

            //Altera o Sexo do Animal
            do
            {
                Console.Write("Digite o sexo do Animal [M] Masculino / [F] Feminino: ");
                Sexo = db.TratamentoDado(Console.ReadLine()).ToUpper();
                if (Sexo == "0")
                    return;
                if (Sexo != "M" && Sexo != "N" && Sexo != "F")
                {
                    Console.WriteLine("Digite um opção válida!!!");
                    Thread.Sleep(2000);
                }
            } while (Sexo != "M" && Sexo != "N" && Sexo != "F");

            //Altera o Nome do Animal
            Console.Write("Digite o Nome do Animal (Opicional): ");
            if (Nome == "0")
                return;
            Nome = db.TratamentoDado(Console.ReadLine());

            //Query para Atualizar os Dados no Banco
            string query = $"UPDATE Animal SET Familia = '{Familia}', Raca = '{Raca}', Sexo = '{Sexo}', Nome = '{Nome}'" +
                $"WHERE NumChip = {numeroChip}";

            //Método Para Inserir os Dados no Banco
            db.SqlExecute(query, "Animal", "DbOng");
        }
    }
}

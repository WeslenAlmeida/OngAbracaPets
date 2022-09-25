using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ONGAbracaPets
{
    internal class Adotante 
    {
        private string Cpf { get; set; }
        private string Nome { get; set; }
        private string Sexo { get; set; }
        private string DataNasc { get; set; }
        private string telefone { get; set; }
        private string Logradouro { get; set; }
        private string Numero { get; set; }
        private string Complemento { get; set; }
        private string Bairro { get; set; }
        private string Cidade { get; set; }
        private string Estado { get; set; }
        private string Cep { get; set; }

        public Adotante()
        {
           

        }

        //Método para Cadastrar o Adotante
        public void CadastraAdotante()
        {
            ControlDB db = new ControlDB();
            Console.WriteLine(">>> CADASTRO DE ADOTANTE <<<");
            Console.WriteLine("Digite '0' cara cancelar o Cadastro <<<\n");

            //Valida e Salva o CPF do Adotante e, Caso já Esteja Cadastrado, Não Permite Salvar no Banco
            do
            {
                Console.Write("Digite seu CPF: ");
                Cpf = db.TratamentoDado(Console.ReadLine());
                if (Cpf == "0")
                    return;
                if (!ValidaCPF(Cpf))
                {
                    Console.WriteLine("Digite um CPF Válido!");
                    Thread.Sleep(2000);
                }

                bool verifica = db.VerifCpfExistente(Cpf, "CPF", "Adotante");
                if (verifica)
                {
                    Console.WriteLine("CPF Já cadastrado!!!");
                    Thread.Sleep(2000);
                    Cpf = "";
                }


            } while (!ValidaCPF(Cpf));

            //Cadastra o Nome
            do
            {
                Console.Write("Digite seu Nome (Max 50 caracteres): ");
                Nome = db.TratamentoDado(Console.ReadLine());
                if (Nome == "0")
                    return;
                if (Nome.Length == 0)
                {
                    Console.WriteLine("Campo Obrigatório!!!!");
                    Thread.Sleep(2000);
                }
                if (Nome.Length > 50)
                {
                    Console.WriteLine("Infome um nome menor que 50 caracteres!!!!");
                    Thread.Sleep(2000);
                }
            } while (Nome.Length > 50 || Nome.Length == 0);

            //Cadastra a data de Nascimento
            string data;
            do
            {
                Console.Write("Digite sua data de nascimento (Mês/Dia/Ano): ");
                data = db.TratamentoDado(Console.ReadLine());
                if (data == "0")
                    return;
                if(data == "")
                    Console.WriteLine("Campo Obrigatório!!!");
                DateTime dataNasc;
                while (!DateTime.TryParse(data, out dataNasc))
                {
                    Console.WriteLine("Formato de data incorreto!");
                    break;
                }
                DataNasc = db.TratamentoDado(dataNasc.ToString("dd/MM/yyyy"));
            } while (data == "");
           

            //Cadastra o Sexo
            do
            {
                Console.Write("Digite seu sexo [M] Masculino / [F] Feminino / [N] Prefere não informar: ");
                Sexo = db.TratamentoDado(Console.ReadLine()).ToUpper();
                if (Sexo == "0")
                    return;
                if (Sexo != "M" && Sexo != "N" && Sexo != "F")
                {
                    Console.WriteLine("Digite um opção válida!!!");
                    Thread.Sleep(2000);
                }
            } while (Sexo != "M" && Sexo != "N" && Sexo != "F");

            //Cadastra o Logradouro
            do
            {
                Console.Write("Digite seu logradouro: ");
                Logradouro = db.TratamentoDado(Console.ReadLine());
                if (Logradouro.Length == 0)
                    Console.WriteLine("Campo Obrigatório!");
                if (Logradouro == "0")
                    return;
            } while (Logradouro.Length == 0);

            //Cadastra o Número da Residência
            do
            {
                Console.Write("Digite seu número: ");
                Numero = db.TratamentoDado(Console.ReadLine());
                if (Numero.Length == 0)
                    Console.WriteLine("Campo Obrigatório!");
                if (Numero == "0")
                    return;
            } while (Numero.Length == 0);

            //Cadastra o Complemento
            do
            {
                Console.Write("Digite o complemento([N] Caso não Possua): ");
                Complemento = db.TratamentoDado(Console.ReadLine());
                if (Complemento.Length == 0)
                    Console.WriteLine("Campo Obrigatório!");
                if (Complemento == "0")
                    return;
            } while (Complemento.Length == 0);

            //Cadastra o Bairro
            do
            {
                Console.Write("Digite seu bairro: ");
                Bairro = db.TratamentoDado(Console.ReadLine());
                if (Bairro.Length == 0)
                    Console.WriteLine("Campo Obrigatório!");
                if (Bairro == "0")
                    return;
            } while (Bairro.Length == 0);

            //Cadastra a Cidade
            do
            {
                Console.Write("Digite sua cidade: ");
                Cidade = db.TratamentoDado(Console.ReadLine());
                if (Cidade.Length == 0)
                    Console.WriteLine("Campo Obrigatório!");
                if (Cidade == "0")
                    return;
            } while (Cidade.Length == 0);

            //Cadastra o Estado
            do
            {
                Console.Write("Digite seu estado: ");
                Estado = db.TratamentoDado(Console.ReadLine());
                if (Estado.Length == 0)
                    Console.WriteLine("Campo Obrigatório!");
                if (Estado == "0")
                    return;
            } while (Estado.Length == 0);

            //Cadastra o Cep
            do
            {
                Console.Write("Digite seu CEP: ");
                Cep = db.TratamentoDado(Console.ReadLine());
                if (Cep.Length == 0)
                    Console.WriteLine("Campo Obrigatório!");
                if (Cep == "0")
                    return;
            } while (Cep.Length == 0);

            //Query de Inserção
            string query = "INSERT INTO Adotante (CPF, Nome, Sexo, DataNasc, Telefone, Logradouro, Numero, Complemento, Bairro, Cidade, Estado, Cep)" +
                $"VALUES ('{Cpf}', '{Nome}', '{Sexo}', '{DataNasc}', '{telefone}', '{Logradouro}', '{Numero}', '{Complemento}', '{Bairro}', '{Cidade}', '{Estado}', '{Cep}')";

            //Metodo para Inserir os Dados no Banco
            db.SqlExecute(query, "Adotante", "DbOng");
        }

        //Método para Alterar os Dados do Adotante
        public void AlteraAdotante()
        {
            ControlDB db = new ControlDB();
            Console.WriteLine(">>> ALTERAR CADASTRO DE ADOTANTE <<<");
            Console.WriteLine("Digite '0' cara cancelar a Alteração <<<\n");

            //Verifica no Banco de Dados se o CPF está Cadastrado
            do
            {
                Console.Write("Digite o CPF do adotante que deseja alterar os dados: ");
                Cpf = db.TratamentoDado(Console.ReadLine());
                if (Cpf == "0")
                    return;
                if (!ValidaCPF(Cpf))
                {
                    Console.WriteLine("Digite um CPF Válido!");
                    Thread.Sleep(2000);
                }

                bool verifica = db.VerifCpfExistente(Cpf, "CPF", "Adotante");
                if (!verifica)
                {
                    Console.WriteLine("CPF não cadastrado!!!");
                    Thread.Sleep(2000);
                    Cpf = "";
                }


            } while (!ValidaCPF(Cpf));

            //Altera o Nome
            do
            {
                Console.Write("Digite seu Nome (Max 50 caracteres): ");
                Nome = db.TratamentoDado(Console.ReadLine());
                if (Nome == "0")
                    return;
                if (Nome.Length == 0)
                {
                    Console.WriteLine("Campo Obrigatório!!!!");
                    Thread.Sleep(2000);
                }
                if (Nome.Length > 50)
                {
                    Console.WriteLine("Infome um nome menor que 50 caracteres!!!!");
                    Thread.Sleep(2000);
                }
            } while (Nome.Length > 50 || Nome.Length == 0);

            //Altera o Sexo
            do
            {
                Console.Write("Digite seu sexo [M] Masculino / [F] Feminino / [N] Prefere não informar: ");
                Sexo = db.TratamentoDado(Console.ReadLine()).ToUpper();
                if (Sexo == "0")
                    return;
                if (Sexo != "M" && Sexo != "N" && Sexo != "F")
                {
                    Console.WriteLine("Digite um opção válida!!!");
                    Thread.Sleep(2000);
                }
            } while (Sexo != "M" && Sexo != "N" && Sexo != "F");

            //Altera o Logradouro
            do
            {
                Console.Write("Digite seu logradouro: ");
                Logradouro = db.TratamentoDado(Console.ReadLine());
                if (Logradouro.Length == 0)
                    Console.WriteLine("Campo Obrigatório!");
                if (Logradouro == "0")
                    return;
            } while (Logradouro.Length == 0);

            //Altera o Número da Residência
            do
            {
                Console.Write("Digite seu número: ");
                Numero = db.TratamentoDado(Console.ReadLine());
                if (Numero.Length == 0)
                    Console.WriteLine("Campo Obrigatório!");
                if (Numero == "0")
                    return;
            } while (Numero.Length == 0);

            //Altera o Complemento
            do
            {
                Console.Write("Digite o complemento([N] Caso não Possua): ");
                Complemento = db.TratamentoDado(Console.ReadLine());
                if (Complemento.Length == 0)
                    Console.WriteLine("Campo Obrigatório!");
                if (Complemento == "0")
                    return;
            } while (Complemento.Length == 0);

            //Altera o Bairro
            do
            {
                Console.Write("Digite seu bairro: ");
                Bairro = db.TratamentoDado(Console.ReadLine());
                if (Bairro.Length == 0)
                    Console.WriteLine("Campo Obrigatório!");
                if (Bairro == "0")
                    return;
            } while (Bairro.Length == 0);

            //Altera a Cidade
            do
            {
                Console.Write("Digite sua cidade: ");
                Cidade = db.TratamentoDado(Console.ReadLine());
                if (Cidade.Length == 0)
                    Console.WriteLine("Campo Obrigatório!");
                if (Cidade == "0")
                    return;
            } while (Cidade.Length == 0);

            //Altera o Estado
            do
            {
                Console.Write("Digite seu estado: ");
                Estado = db.TratamentoDado(Console.ReadLine());
                if (Estado.Length == 0)
                    Console.WriteLine("Campo Obrigatório!");
                if (Estado == "0")
                    return;
            } while (Estado.Length == 0);

            //Altera o Cep
            do
            {
                Console.Write("Digite seu CEP: ");
                Cep = db.TratamentoDado(Console.ReadLine());
                if (Cep.Length == 0)
                    Console.WriteLine("Campo Obrigatório!");
                if (Cep == "0")
                    return;
            } while (Cep.Length == 0);

            //Query para Alterar os Dados no banco
            string query = $"UPDATE Adotante SET Nome = '{Nome}', Sexo = '{Sexo}', Telefone = '{telefone}', Logradouro = '{Logradouro}', Numero = '{Numero}'" +
                $", Complemento = '{Complemento}', Bairro = '{Bairro}', Cidade = '{Cidade}', Estado = '{Estado}', Cep = '{Cep}' WHERE CPF = '{Cpf}';";

            //Metodo para Inserir os Dados no Banco
            db.SqlExecute(query, "Adotante", "DbOng");
        }

        //Método Para Validar o CPF 
        private static bool ValidaCPF(string vrCPF)
        {
            string valor = vrCPF.Replace(".", "");

            valor = valor.Replace("-", "");

            if (valor.Length != 11)
                return false;

            bool igual = true;

            for (int i = 1; i < 11 && igual; i++)

                if (valor[i] != valor[0])

                    igual = false;

            if (igual || valor == "12345678909")
                return false;

            int[] numeros = new int[11];

            for (int i = 0; i < 11; i++)

                numeros[i] = int.Parse(

                  valor[i].ToString());

            int soma = 0;

            for (int i = 0; i < 9; i++)

                soma += (10 - i) * numeros[i];

            int resultado = soma % 11;

            if (resultado == 1 || resultado == 0)

            {
                if (numeros[9] != 0)
                    return false;
            }

            else if (numeros[9] != 11 - resultado)
                return false;

            soma = 0;

            for (int i = 0; i < 10; i++)

                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)

            {
                if (numeros[10] != 0)
                    return false;
            }

            else
                if (numeros[10] != 11 - resultado)
                return false;

            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ONGAbracaPets
{
  
    internal class ControlDB
    {
        //String de Conexão com o Banco de Dados
        private static string Conexao = "Data Source=localhost; Initial Catalog=DbOng; User Id=sa; Password=pass;";

        //Construtor Para Iniciar A Conexão
        private static SqlConnection Connection = new SqlConnection(Conexao);
        public ControlDB()
        {

        }

        //Método para Executar os Comados de INSERT e UPDATE no BAnco de Dados
        public void SqlExecute(string query, string table, string db)
        {
            string queryString = query;

            try
            {
                //Cria um SqlDataAdapter para a tabela de banco de dados.
                SqlDataAdapter adapter = new SqlDataAdapter();

                // Um mapeamento de tabela.
                adapter.TableMappings.Add(table, db);

                // Abre a Conexão
                Connection.Open();

                // Cria um SqlCommand para recuperar dados do banco.
                SqlCommand command = new SqlCommand(queryString, Connection);

                command.CommandType = CommandType.Text;

                // Define o SelectCommand do SqlDataAdapter.
                adapter.SelectCommand = command;

                //Preenche o DataSet.
                DataSet dataSet = new DataSet(db);
                adapter.Fill(dataSet);

                //Fecha a Conexão
                Connection.Close();

                Console.WriteLine("Dados Atualizados com sucesso!!!!\n");
                Thread.Sleep(2000);
            }
            catch (Exception e)
            {
                Connection.Close();
                Console.WriteLine($"Erro ao Atualizar os Dados!!!\n{e.Message}");
                Console.WriteLine("Tecle Enter para continuar....");
                Console.ReadKey();
            }
        }
        //Mostra na Tela Todos os Adotantes
        public void ReadAdotante()
        {
            string queryString = "SELECT CPF, Nome, Sexo, dataNasc, Telefone, Logradouro, Numero, Complemento, Bairro, Cidade, Estado, Cep FROM Adotante;";

            try
            {
                SqlCommand command = new SqlCommand(queryString, Connection);

                Connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(">>>>> DADOS DO ADOTANTE <<<<<\n");
                        Console.WriteLine($"CPF: {reader.GetString(0)}");
                        Console.WriteLine($"Nome: {reader.GetString(1)}");
                        Console.WriteLine($"Sexo: {reader.GetString(2)}");
                        Console.WriteLine($"Data de nascimento: {reader.GetDateTime(3).ToString("dd/MM/yyyy")}");
                        Console.WriteLine($"Telefone: {reader.GetString(4)}");
                        Console.WriteLine($"Logradouro: {reader.GetString(5)}");
                        Console.WriteLine($"Número: {reader.GetString(6)}");
                        Console.WriteLine($"Complemento: {reader.GetString(7)}");
                        Console.WriteLine($"Bairro: {reader.GetString(8)}");
                        Console.WriteLine($"Cidade: {reader.GetString(9)}");
                        Console.WriteLine($"Estado: {reader.GetString(10)}");
                        Console.WriteLine($"Cep: {reader.GetString(11)}\n");
                    }
                }
                Connection.Close();
                Console.WriteLine("Tecle Enter para continuar....");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Connection.Close();
                Console.WriteLine($"Erro ao acessar o Banco de Dados!!!\n{e.Message}");
                Console.WriteLine("Tecle Enter para continuar....");
                Console.ReadKey();
            }
        }

        //Sobrecarga do ReadAdotante para Buscar um Adotante pelo CPF
        public void ReadAdotante(string cpf)
        {
            string queryString = $"SELECT CPF, Nome, Sexo, dataNasc, Telefone, Logradouro, Numero, Complemento, Bairro, Cidade, Estado, Cep FROM Adotante WHERE CPF = {cpf};";

            try
            {
                SqlCommand command = new SqlCommand(queryString, Connection);

                Connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(">>>>> DADOS DO ADOTANTE <<<<<\n");
                        Console.WriteLine($"CPF: {reader.GetString(0)}");
                        Console.WriteLine($"Nome: {reader.GetString(1)}");
                        Console.WriteLine($"Sexo: {reader.GetString(2)}");
                        Console.WriteLine($"Data de nascimento: {reader.GetDateTime(3).ToString("dd/MM/yyyy")}");
                        Console.WriteLine($"Telefone: {reader.GetString(4)}");
                        Console.WriteLine($"Logradouro: {reader.GetString(5)}");
                        Console.WriteLine($"Número: {reader.GetString(6)}");
                        Console.WriteLine($"Complemento: {reader.GetString(7)}");
                        Console.WriteLine($"Bairro: {reader.GetString(8)}");
                        Console.WriteLine($"Cidade: {reader.GetString(9)}");
                        Console.WriteLine($"Estado: {reader.GetString(10)}");
                        Console.WriteLine($"Cep: {reader.GetString(11)}\n");
                    }
                }
                Connection.Close();
                Console.WriteLine("Tecle Enter para continuar....");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Connection.Close();
                Console.WriteLine($"Erro ao acessar o Banco de Dados!!!\n{e.Message}");
                Console.WriteLine("Tecle Enter para continuar....");
                Console.ReadKey();
            }
        }

        //Mostra na Tela Todos os Animais
        public void ReadAnimal()
        {
            string queryString = "SELECT NumChip, Familia, Raca, Sexo, Nome FROM Animal;";
            try
            {
                SqlCommand command = new SqlCommand(queryString, Connection);

                Connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(">>>>> DADOS DO ANIMAL <<<<<\n");
                        Console.WriteLine($"Número do Chip: {reader.GetInt32(0)}");
                        Console.WriteLine($"Familia: {reader.GetString(1)}");
                        Console.WriteLine($"Raça: {reader.GetString(2)}");
                        Console.WriteLine($"Sexo: {reader.GetString(3)}");
                        Console.WriteLine($"Nome: {reader.GetString(4)}\n");
                    }
                }
                Connection.Close();
                Console.WriteLine("Tecle Enter para continuar....");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Connection.Close();
                Console.WriteLine($"Erro ao acessar o Banco de Dados!!!\n{e.Message}");
                Console.WriteLine("Tecle Enter para continuar....");
                Console.ReadKey();
            }
        }

        //Sobrecarga do ReadAnimal para Buscar um Animal pelo Número do Chip
        public void ReadAnimal(int NumChip)
        {
            string queryString = $"SELECT NumChip, Familia, Raca, Sexo, Nome FROM Animal WHERE NumChip = {NumChip};";

            try
            {
                SqlCommand command = new SqlCommand(queryString, Connection);

                Connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(">>>>> DADOS DO ANIMAL <<<<<\n");
                        Console.WriteLine($"Número do Chip: {reader.GetInt32(0)}");
                        Console.WriteLine($"Familia: {reader.GetString(1)}");
                        Console.WriteLine($"Raça: {reader.GetString(2)}");
                        Console.WriteLine($"Sexo: {reader.GetString(3)}");
                        Console.WriteLine($"Nome: {reader.GetString(4)}\n");
                    }
                }
                Connection.Close();
                Console.WriteLine("Tecle Enter para continuar....");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Connection.Close();
                Console.WriteLine($"Erro ao acessar o Banco de Dados!!!\n{e.Message}");
                Console.WriteLine("Tecle Enter para continuar....");
                Console.ReadKey();
            }
        }

        //Mostra na Tela Todos as Adoções Ocorridas na Ong
        public void ReadAdocoes()
        {
            string queryString = "SELECT d.CPF, d.Nome,n.NumChip, n.Familia, n.Raca,a.DataAdocao  " +
                "FROM Adocao a, Adotante d, Animal n " +
                "WHERE d.CPF = a.FK_Adotante_CPF AND n.NumChip = a.FK_Animal_NumChip;";

            try
            {
                SqlCommand command = new SqlCommand(queryString, Connection);

                Connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(">>> DADOS DA ADOÇÃO <<<\n");
                        Console.WriteLine($"CPF do Adotante: {reader.GetString(0)}");
                        Console.WriteLine($"Nome do Adotante: {reader.GetString(1)}");
                        Console.WriteLine($"Número do Chip do Animal: {reader.GetInt32(2)}");
                        Console.WriteLine($"Familia do Animal: {reader.GetString(3)}");
                        Console.WriteLine($"Raça do Animal: {reader.GetString(4)}");
                        Console.WriteLine($"Data da Adoção: {reader.GetDateTime(5).ToString("dd/MM/yyyy")}\n");
                    }
                }
                Connection.Close();
                Console.WriteLine("Tecle Enter para continuar....");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Connection.Close();
                Console.WriteLine($"Erro ao acessar o Banco de Dados!!!\n{e.Message}");
                Console.WriteLine("Tecle Enter para continuar....");
                Console.ReadKey();
            }
        }

        //Verifica se o CPF já Está Cadastrado
        public bool VerifCpfExistente(string dado,string campo, string tabela)
        {
            string queryString = $"SELECT {campo} FROM {tabela} WHERE {campo} = '{dado}'";
            try
            {
                SqlCommand command = new SqlCommand(queryString, Connection);

                Connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Connection.Close();
                        return true;
                    }
                    else
                    {
                        Connection.Close();
                        return false;
                    }

                }
            }
            catch (Exception e)
            {
                Connection.Close();
                Console.WriteLine($"Erro ao acessar o Banco de Dados!!!\n{e.Message}");
                Console.WriteLine("Tecle Enter para continuar....");
                Console.ReadKey();
                return false;
            }



        }

        //Verifica se o Animal já está Cadastrado
        public bool VerifChipExistente(int dado, string campo, string tabela)
        {
            string queryString = $"SELECT {campo} FROM {tabela} WHERE {campo} = {dado}";

            try
            {
                SqlCommand command = new SqlCommand(queryString, Connection);

                Connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Connection.Close();
                        return true;
                    }
                    else
                    {
                        Connection.Close();
                        return false;
                    }

                }
            }
            catch (Exception e)
            {
                Connection.Close();
                Console.WriteLine($"Erro ao acessar o Banco de Dados!!!\n{e.Message}");
                Console.WriteLine("Tecle Enter para continuar....");
                Console.ReadKey();
                return false;
            }



        }

        //Método Para Tratar os Dados que Serão Inseridos no Banco Pelo Usuário
        public string TratamentoDado(string dado)
        {
            string dadoTratado = dado.Replace(".", "").Replace("-", "").Replace("'", "").Replace("]", "").Replace("[", "");
            return dadoTratado;
        }
    }
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;

namespace ONGAbracaPets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }
        //Menu Principal
        static void Menu()
        {
            string op;
            do
            {
                do
                {
                    Console.WriteLine(">>> ONG ABRAÇA PETS <<<\n");
                    Console.WriteLine("Escolha a Opção:\n\n");
                    Console.WriteLine("[1] Cadastro\n[2] Editar Registro\n[3] Consultas\n[0] Sair");
                    Console.Write("Opção: ");
                    op = Console.ReadLine();
                    if (op == "0")
                        return;
                    if (op != "1" && op != "2" && op != "3" && op != "0")
                    {
                        Console.Clear();
                        Console.WriteLine("Opção Inválida !!!");
                        Thread.Sleep(2000);
                        Console.Clear();
                    }
                } while (op != "1" && op != "2" && op != "3");

                switch (op)
                {
                    case "1":
                        Console.Clear();
                        MenuCadastro();
                        Console.Clear();
                        break;

                    case "2":
                        Console.Clear();
                        MenuEditar();
                        Console.Clear();
                        break;

                    case "3":
                        Console.Clear();
                        MenuConsulta();
                        Console.Clear();
                        break;
                }
            }while (op != "0");
           

        }

        //Menu de Cadastro
        static void MenuCadastro()
        {
            string op;
            Animal animal = new();
            Adotante adotante = new();
            do
            {
                Console.WriteLine(">>> ONG ABRAÇA PETS <<<\n");
                Console.WriteLine(">>> CADASTRO <<<\n");
                Console.WriteLine("Escolha a Opção:\n\n");
                Console.WriteLine("[1] Cadastro Adotante\n[2] Cadastro Animal\n[3] Cadastrar Adoção\n[0] Sair");
                Console.Write("Opção: ");
                op = Console.ReadLine();

                if (op == "0")
                    return;
                if (op != "1" && op != "2" && op != "3" && op != "0")
                {
                    Console.Clear();
                    Console.WriteLine("Opção Inválida !!!");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            } while (op != "1" && op != "2" && op != "3");

            switch (op)
            {
                case "1":
                    adotante.CadastraAdotante();
                    Console.Clear();
                    break;

                case "2":
                    animal.CadastraAnimal();
                    Console.Clear();
                    break;

                case "3":
                    new Adocao();
                    Console.Clear();
                    break;
            }
        }

        //Menu de Edição de Cadastro
        static void MenuEditar()
        {
            string op;
            Animal animal = new();
            Adotante adotante = new();
            do
            {
                Console.WriteLine(">>> ONG ABRAÇA PETS <<<\n");
                Console.WriteLine(">>> EDIÇÃO DE CADASTRO <<<\n");
                Console.WriteLine("Escolha a Opção:\n\n");
                Console.WriteLine("[1] Editar Adotante\n[2] Editar Animal\n[0] Sair");
                Console.Write("Opção: ");
                op = Console.ReadLine();

                if (op == "0")
                    return;
                if (op != "1" && op != "2" && op != "0")
                {
                    Console.Clear();
                    Console.WriteLine("Opção Inválida !!!");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            } while (op != "1" && op != "2");

            switch (op)
            {
                case "1":
                    adotante.AlteraAdotante();
                    Console.Clear();
                    break;

                case "2":
                    animal.AlteraAnimal();
                    Console.Clear();
                    break;
            }
        }
        //Menu de Consultas
        static void MenuConsulta()
        {
            string op;
            ControlDB db = new ControlDB(); 
            do
            {
                Console.WriteLine(">>> ONG ABRAÇA PETS <<<\n");
                Console.WriteLine(">>> CONSULTAS <<<\n");
                Console.WriteLine("Escolha a Opção:\n\n");
                Console.WriteLine("[1] Consulta Adotante\n[2] Consulta Animal\n[3] Consulta Adoção\n[0] Sair");
                Console.Write("Opção: ");
                op = Console.ReadLine();

                if (op == "0")
                    return;
                if (op != "1" && op != "2" && op != "3" && op != "0")
                {
                    Console.Clear();
                    Console.WriteLine("Opção Inválida !!!");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            } while (op != "1" && op != "2" && op != "3");

            switch (op)
            {
                case "1":
                    db.ReadAdotante();  
                    Console.Clear();
                    break;

                case "2":
                    db.ReadAnimal();
                    Console.Clear();
                    break;

                case "3":
                    db.ReadAdocoes();
                    Console.Clear();
                    break;
            }
        }
    }
}

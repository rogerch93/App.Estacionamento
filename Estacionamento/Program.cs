using System;

namespace AppEstacioanamento
{
    class Program
    {
        static void Main(string[] args)
        {
            Carros[] carros = new Carros[5];
            var indiceCarro = 0;

            string opcaoCarros = obterLista();

            //instanciar a classe carro.
            Carros carro = new Carros();
            //instancia a classe vaga.
            Validar valida = new Validar();

            while (opcaoCarros.ToUpper() != "X")
            {
                switch (opcaoCarros)
                {   
                    //A função deste bloca de códigos é coletar informações do usuario 
                    case "1":
                        Console.WriteLine("   " + "Informe o modelo.");
                        carro.Marca = Console.ReadLine();

                        Console.WriteLine("   " + "Informe o marca:");
                        carro.Modelo = Console.ReadLine();

                        Console.WriteLine("   " + "Informe a Placa:");
                        carro.Placa = Console.ReadLine();

                        Console.WriteLine("   " + "Nome:");
                        carro.NomePessoa = Console.ReadLine();
                        
                        //Verifica se cpf é valido
                        Console.WriteLine("   " + "CPF:");
                        bool cpf = Validar.validar(Console.ReadLine());
                        while (cpf == false)
                        {
                            cpf = Validar.validar(Console.ReadLine());
                            if (cpf == false)
                            {
                                Console.WriteLine("   " + "CPF inválido!");
                            }
                        }

                        /*Verifica se sera cadastrado um numero maior do que contem em vagas
                        se caso houver sera exibido um alerta */
                        Console.WriteLine("   " + "Numero da Vaga:");
                        carro.NumVaga = Console.ReadLine();

                        while (Convert.ToInt32(carro.NumVaga) > 5)
                        {
                            if (Convert.ToInt32(carro.NumVaga) > 5)
                            {
                                Console.WriteLine("   " + "Não temos mais espaço! informe para o cliente o segundo estacionamento.");
                            }
                            break;
                        }
                        Console.WriteLine();

                        /*Captura a hora de entrada */
                        Console.WriteLine("   " + "Hora de entrada:");
                        carro.HoraEntrada = Console.ReadLine();
                        Console.WriteLine(carro.HoraEntrada + " " + DateTime.Now.ToString("dd/M/yyyy"));

                        carros[indiceCarro] = carro;
                        indiceCarro++;
                        break;

                    /*Imprime uma lista contendo todas informações dos clientes e seus carros*/
                    case "2":
                        foreach (var a in carros)
                        {

                            if (!string.IsNullOrEmpty(a.NomePessoa))
                            {
                                Console.WriteLine("*********************************************");
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("   "+$"NOME:{a.NomePessoa}");
                                Console.WriteLine("   " + $"CPF:{a.CPF}");
                                Console.WriteLine("   " + $"CARRO:{a.Marca}");
                                Console.WriteLine("   " + $"MARCA: {a.Modelo}");
                                Console.WriteLine("   " + $"PLACA: {a.Placa}");
                                Console.WriteLine("   " + $"VAGA: {a.NumVaga}");
                                Console.WriteLine("   " + $"HORA DE ENTRADA: {a.HoraEntrada + " " + DateTime.Now.ToString("dd/M/yyyy")}");
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("*********************************************");
                            }
                        }
                        break;

                    case "3":
                        //informar valor de cada cliente.
                        Console.WriteLine("Informe o CPF:");
                        carro.CPF = Console.ReadLine();
                        foreach (var a in carros)
                        {
                            if (carro.CPF != carro.CPF)
                            {
                                Console.WriteLine("Cliente Inexistente");
                            }
                            else
                            {
                                Console.WriteLine($"NOME:{a.NomePessoa}");
                                Console.WriteLine($"CARRO:{a.Modelo}");
                                Console.WriteLine($"PLACA:{a.Placa}");
                                Console.WriteLine($"HORA DE ENTRADA:{a.HoraEntrada}");
                            }
                        }
                       break;

                    default:
                        throw new ArgumentOutOfRangeException();

                }
                opcaoCarros = obterLista();
            }
        }
        /*Interface do sistema*/
        private static string obterLista()
        {
            Console.WriteLine();
            Console.WriteLine("     "+"***SITEMA PARA ESTACIONAMENTO***");
            Console.WriteLine("     " + "----------------------------------");
            Console.WriteLine();
            Console.WriteLine("     " + " Informe qual opção desejada");
            Console.WriteLine("     " + "==================================");
            Console.WriteLine("     " + " 1 - Inserir novo veiculo:");
            Console.WriteLine("     " + "==================================");
            Console.WriteLine("     " + " 2 - Listar veiculos:");
            Console.WriteLine("     " + "==================================");
            Console.WriteLine("     " + " 3 - Informar valor ao cliente:");
            Console.WriteLine("     " + "==================================");
            Console.WriteLine("     " + " X - Sair");
            Console.WriteLine();

            string opcaoCarros = Console.ReadLine();
            return opcaoCarros;
        }
    }
}

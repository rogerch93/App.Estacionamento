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
                        Console.WriteLine("   " + "Numero da Vaga: " +
                            " Obs: Comece sempre do numero 0 para identificar a vaga.");
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
                            Console.WriteLine();

                            Console.WriteLine("Informar valor a algum cliente ? Y/N");
                            if(Console.ReadKey(true).Key != ConsoleKey.Y)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("insira o horario no seguinte formato (1, 2, 3");
                                Console.WriteLine("Insira a hora de entrada");
                                carro.HoraEntrada = Console.ReadLine();
                                Console.WriteLine("");

                                Console.WriteLine("Insira a hora de saida");
                                carro.HoraSaida =( Console.ReadLine());
                                Console.WriteLine("");

                                Convert.ToDateTime(carro.HoraEntrada);
                                Convert.ToDateTime(carro.HoraSaida);
                                

                                TimeSpan parsed1 = TimeSpan.Parse(carro.HoraEntrada);
                                TimeSpan parsed2 = TimeSpan.Parse(carro.HoraSaida);

                                var soma = parsed1 - parsed2;

                                Console.WriteLine("Horas consumidas no estacionamento:");
                                Console.WriteLine(soma);

                                Console.WriteLine();

                                Console.WriteLine("Informe as horas que o veiculo ficou no estacionamento");
                                carro.Total = Console.ReadLine();
                                
                                var valor =  Convert.ToDouble(carro.Total) * 5;

                                Console.WriteLine();

                                Console.WriteLine("Valor a ser pago: " + valor);

                                Console.WriteLine("Liberar vaga");

                                var e1 = Console.ReadLine();
                                var e2 = Console.ReadLine();

                                Array.Clear(carros,Convert.ToInt32(e1),Convert.ToInt32(e2));
                                
                                

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

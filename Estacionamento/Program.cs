﻿using System;

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
            Vaga vaga = new Vaga();

            while (opcaoCarros.ToUpper() != "X")
            {
                switch (opcaoCarros)
                {
                    case "1":
                        // Adc Carro a lista.
                        Console.WriteLine("Informe o modelo.");
                        carro.Marca = Console.ReadLine();

                        Console.WriteLine("Informe o marca:");
                        carro.Modelo = Console.ReadLine();

                        Console.WriteLine("Informe a Placa:");
                        carro.Placa = Console.ReadLine();

                        Console.WriteLine("Nome:");
                        carro.NomePessoa = Console.ReadLine();

                        Console.WriteLine("CPF:");
                        bool cpf = Vaga.validar(Console.ReadLine());
                        while (cpf == false)
                        {
                            cpf = Vaga.validar(Console.ReadLine());
                            if (cpf == false)
                            {
                                Console.WriteLine("CPF inválido!");
                            }
                        }
                        carros[indiceCarro] = carro;
                        indiceCarro++;
                        break;

                    case "2":
                        foreach (var a in carros)
                        {

                            if (!string.IsNullOrEmpty(a.NomePessoa))
                            {
                                Console.WriteLine($"NOME:{a.NomePessoa}");
                                Console.WriteLine($"CARRO:{a.Marca}");
                                Console.WriteLine($"MARCA: {a.Modelo}");
                                Console.WriteLine($"PLACA: {a.Placa}");
                                Console.WriteLine();
                            }
                        }
                        break;

                    case "3":
                        Console.WriteLine("Numero da Vaga:");
                        vaga.NumVaga = Console.ReadLine();

                        while(Convert.ToInt32(vaga.NumVaga) > 5)
                        {
                            if (Convert.ToInt32(vaga.NumVaga) > 5)
                            {
                                Console.WriteLine("Não temos mais espaço! informe para o cliente o segundo estacionamento.");
                            }
                            break;
                        }
                        Console.WriteLine();
                        
                        Console.WriteLine("Hora de entrada:");
                        Console.ReadLine();
                        break;

                    case "4":
                        //informar valor de cada cliente.
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();

                }
                opcaoCarros = obterLista();
            }
        }
        private static string obterLista()
        {
            Console.WriteLine();
            Console.WriteLine("***SITEMA PARA ESTACIONAMENTO***");
            Console.WriteLine("----------------------------------");
            Console.WriteLine();
            Console.WriteLine(" Informe qual opção desejada");
            Console.WriteLine("==================================");
            Console.WriteLine(" 1 - Inserir novo veiculo:");
            Console.WriteLine("==================================");
            Console.WriteLine(" 2 - Listar veiculos:");
            Console.WriteLine("==================================");
            Console.WriteLine(" 3 - Numero da vaga");
            Console.WriteLine("==================================");
            Console.WriteLine(" 4 - Informar valor ao cliente:");
            Console.WriteLine("==================================");
            Console.WriteLine(" X - Sair");
            Console.WriteLine();

            string opcaoCarros = Console.ReadLine();
            return opcaoCarros;
        }
    }
}

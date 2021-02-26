using System;
using System.Collections.Generic;

namespace Bank
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X"){
                
                switch(opcaoUsuario){

                     case "1":
                         ListarContas();
                        break;
                     case "2":
                         InserirConta();
                        break;
                     case "3":
                         Transferir();
                        break;
                     case "4":
                        Sacar();
                        break;
                      case "5":
                        Depositar();
                        break;
                     case "C":
                        Console.Clear();
                        break;  
                     default:
                        throw new ArgumentOutOfRangeException();                     
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Finalizando!");
            Console.ReadLine();
        }

        private static void Sacar(){
            Console.WriteLine("Digite o numero da conta: ");            
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Sacar(valorSaque);
        }
         private static void Depositar(){
            Console.WriteLine("Digite o numero da conta: ");            
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Transferir(){
            Console.WriteLine("Digite o numero da conta de origem: ");            
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o numero da conta de destino: ");            
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser transferido: ");
            double valorTransferecia = double.Parse(Console.ReadLine());

            listaContas[indiceContaOrigem].Transferir(valorTransferecia,listaContas[indiceContaDestino]);
        }
        private static void ListarContas(){
            Console.WriteLine("Listar Contas");
            if(listaContas.Count == 0){
                Console.WriteLine("Nenhuma Conta Cadastrada");
                return;
            }

            for(int i = 0; i < listaContas.Count; i++){
                Conta conta = listaContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }


        }
        private static void InserirConta(){
            Console.WriteLine("Inserir Nova Conta");

            Console.Write("Digite 1 para conta pessoa fisica ou 2 para conta juridica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial da conta: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o credito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                                     nome: entradaNome, 
                                                     credito:entradaCredito,
                                                     saldo:entradaSaldo);

            listaContas.Add(novaConta);                                         
        }

        private static string ObterOpcaoUsuario(){

            Console.WriteLine();
            Console.WriteLine("Bank | Informe a opção desejada");
            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Inserir Nova Conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine("A opção do usuario é: {0}",opcaoUsuario);
            return opcaoUsuario;
        }
    }
}
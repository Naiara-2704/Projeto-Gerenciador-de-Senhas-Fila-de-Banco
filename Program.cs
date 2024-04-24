using System;
using System.Collections.Generic;
using System.Linq;


namespace GerenciadorDeSenhas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string SEPARADOR = "-------------------------------------------------------";
            const string OPCAOINVALIDA = "------------------- Opção Inválida -------------------- ";
            const string SENHAVAZIA = "---------------- Nenhuma senha na fila ----------------";
            const string ENCERRAMENTO = "Atendimento Encerrado!";
            const string CLIENTENAFILA = "Programa não pode ser encerrado, existem cliente na fila aguardando atendimento!";
            const string MSGSENHACOMUM = "Chamando senha COMUM: ";
            const string MSGSENHAPRIORITARIA = "Chamando senha PRIORITÁRIA: ";
            const string MSGGERARSENHACOMUM = "Senha COMUM foi gerada: ";
            const string MSGGERARSENHAPRIORITARIA = "Senha PRIORITÁRIA foi gerada: ";
            const string MSGVISUALIZARLISTACOMUM = "*** Senha(s) na fila de atendimento COMUM(s) ***";
            const string MSGVISUALIZARLISTAPRIORITARIA = "*** Senha(s) na fila de atendimento PRIORITÁRIA(s) ***";

            bool existeAtendimento = true;
            int contadorComum = 1;
            int contadorPrioritaria = 1;
            string opcaoInformada;
            int opcaoMenu = 0;
            string senhaAtual = "0";

            Queue<string> filaAtendimentoComum = new Queue<string>();
            Queue<string> filaAtendimentoPrioritario = new Queue<string>();

            Console.WriteLine(SEPARADOR);
            Console.WriteLine("------ Bem vindo ao Sistema Gerenciador de Senhas -----");
            Console.WriteLine(SEPARADOR);
            pularLinha(2);


            while (existeAtendimento)
            {
                Console.WriteLine(SEPARADOR);
                Console.WriteLine("------------- Menu - Gerenciador de Senhas ------------");
                Console.WriteLine(SEPARADOR);
                pularLinha(1);

                Console.WriteLine(" 1- Gerar senha para atendimento comum:");
                Console.WriteLine(" 2- Gerar senha para atendimento prioritário:");
                Console.WriteLine(" 3- Chamar senha para atendimento:");
                Console.WriteLine(" 4- Encerrar atendimento:");
                Console.WriteLine(" 5- Visualizar fila de atendimento:");
                pularLinha(1);

                Console.Write("Digite sua opção: ");
                opcaoInformada = Console.ReadLine();
                pularLinha(2);

                if (validaNumeroInteiro(opcaoInformada))
                {
                    opcaoMenu = int.Parse(opcaoInformada);
                }

                switch (opcaoMenu)
                {
                    case 1:
                        gerarSenha(false);
                        break;
                    case 2:
                        gerarSenha(true);
                        break;
                    case 3:
                        chamarSenha();
                        break;
                    case 4:
                        encerrarAtendimento(false);
                        break;
                    case 5:
                        visualizarSenhas();
                        break;
                    default:
                        Console.WriteLine(OPCAOINVALIDA);
                        pularLinha(2);
                        break;
                }
            }

            void gerarSenha(bool prioritária)
            {
                if (prioritária)
                {
                    senhaAtual = "P" + contadorPrioritaria++;
                    filaAtendimentoPrioritario.Enqueue(senhaAtual);
                    Console.WriteLine(MSGGERARSENHAPRIORITARIA + senhaAtual);
                }
                else
                {
                    senhaAtual = "C" + contadorComum++;
                    filaAtendimentoComum.Enqueue(senhaAtual);
                    Console.WriteLine(MSGGERARSENHACOMUM + senhaAtual);
                }   
                pularLinha(1);
            }

            void chamarSenha()
            {
                if (filaAtendimentoPrioritario.Count > 0)
                {
                    senhaAtual = filaAtendimentoPrioritario.Dequeue();
                    Console.WriteLine(MSGSENHAPRIORITARIA + senhaAtual);
                }
                else if (filaAtendimentoComum.Count > 0)
                {
                    senhaAtual = filaAtendimentoComum.Dequeue();
                    Console.WriteLine(MSGSENHACOMUM + senhaAtual);
                }
                else
                {
                    Console.WriteLine(SENHAVAZIA);
                }
                pularLinha(1);
            }

            void visualizarSenhas()
            {
                if (filaAtendimentoPrioritario.Count == 0 && filaAtendimentoComum.Count == 0)
                {
                    Console.WriteLine(SENHAVAZIA);
                    pularLinha(2);
                }
                else if (filaAtendimentoPrioritario.Count > 0)
                {
                    Console.WriteLine(MSGVISUALIZARLISTAPRIORITARIA);
                    foreach (var senhaPritoritaria in filaAtendimentoPrioritario)
                    {
                        Console.WriteLine(senhaPritoritaria);
                    }
                }
                else if (filaAtendimentoComum.Count > 0)
                {
                    Console.WriteLine(MSGVISUALIZARLISTACOMUM);
                    foreach (var senhaComum in filaAtendimentoComum)
                    {
                        Console.WriteLine(senhaComum);
                    }
                }
                pularLinha(1);

            }      

            void encerrarAtendimento(bool finalizar) 
            {
                if (filaAtendimentoPrioritario.Count == 0 && filaAtendimentoComum.Count == 0)
                {
                    Console.WriteLine(ENCERRAMENTO);
                    existeAtendimento = finalizar;
                }
                else
                {
                    Console.WriteLine(CLIENTENAFILA);
                }
                pularLinha(1);
            }

            void pularLinha(int contador)
            {
                for(int i =0; i < contador;i++)
                {
                    Console.WriteLine("");
                }               
            }

            bool validaNumeroInteiro(string numero)
            {
                return int.TryParse(numero, out _);
            }

            pularLinha(3);
            Console.WriteLine(SEPARADOR);
            Console.WriteLine("---------------- Aperte Enter para sair ---------------");
            Console.WriteLine(SEPARADOR);
            Console.ReadLine();
            

        }
    }
}

using System;
using System.Collections.Generic;

namespace transacao
{ 
    class Program 
    {
        static void Main(string[] args)
        {
            int ProgramaRoda;
            var transacoes = new List<Transacao>();
            do
            {
                Console.Clear();

                Console.WriteLine("Selecione uma opção:\n 1-Nova Transação\n2-Estorno de Transação\n");
                int Opcao = Convert.ToInt32(Console.ReadLine());
                
                if (Opcao.Equals(1))
                {

                    Console.WriteLine("Insira o valor da transação\n");
                    int ValorDaTransacao = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("\nInsira o método de pagamento\n 1- Crédito\n 2- Débito\n 3- Voucher\n 4- Crediário\n");
                    int TipoCompra = Convert.ToInt32(Console.ReadLine());

                    if (TipoCompra.Equals(1))
                    {
                        

                        Console.WriteLine("Em quantas parcelas deseja dividir?\n Número máximo de parcelas:12\n");
                        int Parcelas = Convert.ToInt32(Console.ReadLine());
                        var transacao = new Credito();
                        transacao.ValorDaTransacao = ValorDaTransacao;
                        transacao.Parcelas = Parcelas;

                        if (transacao.ValidaTransacao())
                        {
                            
                            double ValorDaParcela = ValorDaTransacao / Parcelas;
                            double ValorFinal = ValorDaTransacao;
                            Console.WriteLine($"Compra parcelada em {Parcelas} parcelas de R$ {ValorDaParcela} totalizando: R${ValorFinal}\n");
                            Console.WriteLine("Solicitação enviada ao banco, aguarde a confirmação do banco.\n");
                            Console.ReadKey();
                            
                            if (transacao.Autorizacao())
                            {
                                Console.WriteLine("Transação confirmada com sucesso.");

                                Console.WriteLine($"Número de identificação: {transacao.Id}");
                            }
                            else
                            {
                                Console.WriteLine("Erro:1739 Transação não confirmada pelo banco.");
                            }

                            transacoes.Add(transacao);

                        }
                        else
                        {
                            Console.WriteLine("Erro:1621 número de parcelas não permitido!\n Reinicie a transação.");
                            Console.ReadKey();

                        }



                    }

                    if (TipoCompra.Equals(2))
                    {
                        var transacao = new Debito();
                        transacao.ValorDaTransacao = ValorDaTransacao;

                       Console.WriteLine($"Pagamento à vista no valor total de: R${ValorDaTransacao}\n");
                       Console.WriteLine("Solicitação enviada ao banco, aguarde a confirmação do banco.\n");
                       Console.ReadKey();

                       if (transacao.Autorizacao())
                        {
                            Console.WriteLine("Transação confirmada com sucesso.");

                            Console.WriteLine($"Número de identificação: {transacao.Id}");
                        }
                        else
                        {
                            Console.WriteLine("Erro:1739 Transação não confirmada pelo banco.");
                        }
                        transacoes.Add(transacao);
                    }

                    if (TipoCompra.Equals(3))
                    {
                        var transacao = new Voucher();
                        transacao.ValorDaTransacao = ValorDaTransacao;

                        Console.WriteLine($"Pagamento à vista no valor total de: R${ValorDaTransacao}\n");
                        Console.WriteLine("Solicitação enviada ao banco, aguarde a confirmação do banco.\n");
                        Console.ReadKey();

                        if (transacao.Autorizacao())
                        {
                            Console.WriteLine("Transação confirmada com sucesso.");

                            Console.WriteLine($"Número de identificação: {transacao.Id}");
                        }
                        else
                        {
                            Console.WriteLine("Erro:1739 transação não confirmada pelo banco.");
                        }
                        transacoes.Add(transacao);
                    }

                    if (TipoCompra.Equals(4))
                    {
                        Console.WriteLine("Em quantas parcelas deseja dividir?\n Número máximo de parcelas:24\n");
                        int Parcelas = Convert.ToInt32(Console.ReadLine());
                        var transacao = new Crediario(ValorDaTransacao, Parcelas);
                        if (transacao.Autorizacao())
                        {
                        double ValorDaParcela = ValorDaTransacao / Parcelas;
                        Console.WriteLine($"Compra parcelada em {Parcelas} parcelas de R$ {ValorDaParcela} totalizando: R${transacao.ValorDaTransacao}\n");
                        Console.WriteLine("Solicitação enviada ao banco, aguarde a confirmação do banco.\n");
                        Console.ReadKey();

                        if (transacao.Autorizacao())
                        {
                            Console.WriteLine("Transação confirmada com sucesso.");

                            Console.WriteLine($"Número de identificação: {transacao.Id}");
                        }
                        else
                        {
                            Console.WriteLine("Erro:1739 Transação não confirmada pelo banco.");
                        }

                        transacoes.Add(transacao);

                    }
                    else
                    {
                        Console.WriteLine("Erro:1621 Número de parcelas não permitido!\n Reinicie a transação.");
                        Console.ReadKey();

                    }



                }
            }
                else
                {
                    Console.WriteLine("Digite o número da transação para estorno:\n");
                    int NumeroEstorno = Convert.ToInt32(Console.ReadLine());
                    var TransacaoExiste = false;
                    foreach (var item in transacoes)
                    {
                        TransacaoExiste = item.Id == NumeroEstorno;
                        if (TransacaoExiste)
                        {
                            var transacao = new TransacaoDeEstorno(item as TransacaoDePagamento);
                            if (transacao.Autorizacao())
                            {
                                transacoes.Remove(item);
                                Console.WriteLine($"\nFoi realizado o estorno da transação:{item.Id}, no valor de R$ {item.ValorDaTransacao}");
                                break;
                            }
                            Console.WriteLine("O banco recusou o estorno");
                            break;
                        }
                        
                    }
                    if (!TransacaoExiste)
                    {
                        Console.WriteLine("\nNão há nenhuma transação nesse ID.");
                    }
                }
                
                Console.WriteLine("Deseja Inicar uma nova transação?\n 1-Sim \n 2-Não ");
                ProgramaRoda = Convert.ToInt32(Console.ReadLine());               
            } while (ProgramaRoda.Equals(1));
                
           
        }
    }
}

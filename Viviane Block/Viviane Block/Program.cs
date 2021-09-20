using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Viviane_Block
{
    class Program
    {
        static void Main(string[] args)
        {
            int dia = 0, cont = 0;
            List<string> aux = new List<string>();                 //Criação de uma lista auxiliar para ser usada no decorrer do codigo, tanto para entrda quanto para saida de cargas.  

            //  Criando os estoques por meio de uma função para não ficar repetindo:

            int[][] estoque1 = new int[6][];
            estoque1 = CriaEstoque(1);

            int[][] estoque2 = new int[6][];
            estoque2 = CriaEstoque(2);

            int[][] estoque3 = new int[6][];
            estoque3 = CriaEstoque(3);

            int[][] estoque4 = new int[6][];
            estoque4 = CriaEstoque(4);

            while (dia != 6) // Para "rodar por 6 dias"
            {
                Console.WriteLine("\n\n  DIA: {0}", dia + 1);        // Marcação do dia atual.
                cont = 0;

                List<string> entrada = new List<string>();
                aux = new List<string>();                           // "crio a lista auxiliar" para organizar e armazenar as entradas em um vetor de inteiros.
                Console.WriteLine("\n  CARGAS RECEBIDAS: \n");
                for (int i = 0; i <= (Geradores.Qtd()); i++)
                {
                    entrada = Geradores.GeraEntrada();              // Gerando a lista pelo codigo de "Geradores"
                    
                    foreach (var item in entrada)                   // Mostrando na tela conforme adiciono as entradas na lista.
                    {
                        Console.Write("  " + item);                        
                        aux.Add(item);
                        cont = cont + 1;                           //Contador para saber o tamanho do vetor a ser criado.
                    }

                    Console.WriteLine();
                }

                Console.ReadKey();                                //Enter para proxima etapa.

                Console.WriteLine("\n  CARGAS PARA ARMAZENAMENTO NOS ESTOQUES:");   
                
                int[] vetorentrada = new int[cont];               //Criando o vetor.
                vetorentrada = TransformaEmVetor(cont,aux);       //Chamo a função que recebe a lista e transforma os elementos dela em um vetor de inteiros.
                Console.WriteLine();
                Console.Write("~>");                              //pra ficar bonitinho...
                for (int i = 0; i < cont; i++)                    //Conforme mostro na tela o vetor de inteiros já vou armazenando no estoque.
                {
                    Console.Write("  " + vetorentrada[i]);
                    if (vetorentrada[i] == 1)
                    {
                        InsereNoEstoque(1, estoque1);
                    }
                    else if (vetorentrada[i] == 2)
                    {
                        InsereNoEstoque(2, estoque2);
                    }
                    else if (vetorentrada[i] == 3)
                    {
                        InsereNoEstoque(3, estoque3);
                    }
                    else if (vetorentrada[i] == 4)
                    {
                        InsereNoEstoque(4, estoque4);
                    }
                }

                //"zero" as variaveis para poder usar as mesmas na continuação do codigo;               
                aux = null;
                cont = 0;

                Console.WriteLine("\n");
                Console.ReadKey();                                // Separação de etapas

                Console.WriteLine("  ESTOQUE ATUAL:\n\n");        //Mostra todos os estoques depois de alocar as cargas    
                MostraEstoque(estoque1);
                MostraEstoque(estoque2);
                MostraEstoque(estoque3);
                MostraEstoque(estoque4);

                Console.ReadKey();                               // Separação de etapas...               

                aux = new List<string>();                
                string saida;
                Console.WriteLine("\n  ORDEM DE SERVIÇO: \n");
                for (int i = 0; i <= (Geradores.Qtd()); i++)
                {
                    saida = Geradores.OrdemDeServico();          // Gerando string pelo codigo de "Geradores"
                    
                    for (int j = 0; j < (saida.Length); j++)     //mesma coisa que foi feita na chegada de cargas porém agora com string //
                    {
                        Console.Write("  " + saida[j]); 
                        aux.Add(Char.ToString(saida[j]));        // Converto de Char para String para poder aplicar o mesmo metodo feito na entrada de cargas (para criar o vetor)
                        cont = cont + 1;                         // contador para saber o tamanho do vetor.
                    }

                    Console.WriteLine();
                }

                Console.ReadKey();                                // Separa etapa...

                Console.WriteLine("\n  CARGAS A SEREM RETIRADAS DOS ESTOQUES:");
                int[] vetorsaida = new int[cont];                //criando o vetor e chamando a função.
                vetorsaida = TransformaEmVetor(cont, aux); 
                Console.WriteLine();

                Console.Write("~>");                             //pra ficar bonitinho...
                for (int i = 0; i < cont; i++)                  //Conforme mostro na tela o vetor já vou retirando do estoque.
                {
                    Console.Write("  " + vetorsaida[i]);
                    if (vetorsaida[i] == 1)
                    {
                        RetiraDoEstoque(1, estoque1);
                    }
                    else if (vetorsaida[i] == 2)
                    {
                        RetiraDoEstoque(2, estoque2);
                    }
                    else if (vetorsaida[i] == 3)
                    {
                        RetiraDoEstoque(3, estoque3);
                    }
                    else if (vetorsaida[i] == 4)
                    {
                        RetiraDoEstoque(4, estoque4);
                    }
                }

                //zero as variaveis para poder usar as mesmas na continuação do codigo;
                aux = null;
                cont = 0;

                Console.ReadKey();

                Console.WriteLine("\n\n  ESTOQUE ATUAL:\n\n");  //Mostro todos os estoques depois de retirar/enviar as cargas    
                MostraEstoque(estoque1);
                MostraEstoque(estoque2);
                MostraEstoque(estoque3);
                MostraEstoque(estoque4);

                Console.WriteLine("\n\n  ... ");                //"enter para continuar"
                Console.ReadKey();
                Console.Clear();                                //limpo a tela "para o dia seguinte"

                dia++; 
                
            }
        }

        public static int[][] CriaEstoque(int numero)
        {
            int[][] estoque = new int[6][];
            for (int i = 0; i < estoque.Length; i++) // percorre todas as linhas
            {
                estoque[i] = new int[6]; // gera minhas colunas
            }

            for (int i = 0; i < estoque.Length; i++)
            {
                for (int j = 0; j < estoque[i].Length; j++)
                {
                    if (i <= 2 && j <= 5)    //preencher até a metade com o valor passado como parametro.
                    {
                        estoque[i][j] = numero;
                    }
                    else
                    {
                        estoque[i][j] = 0;
                    }
                }
            }
            return estoque;
        }

        public static int[][] RetiraDoEstoque(int carga, int[][] estoque)
        {
            //percorre a matriz de estoque começando pelo ultimo elemento para fazer a retirada da carga.
            for (int i = (estoque.Length) - 1; i >= 0; i--)
            {
                for (int j = (estoque[i].Length) - 1; j >= 0; j--)
                {
                    if (estoque[i][j] == carga)
                    {
                        estoque[i][j] = 0;
                        return estoque;
                    }
                }
            }
            return estoque;
        }

        public static int[][] InsereNoEstoque(int carga, int[][] estoque)
        {
            for (int i = 0; i < estoque.Length; i++)
            {
                for (int j = 0; j < estoque[i].Length; j++)
                {
                    if (estoque[i][j] == 0) // somente essa condição pois caso não haja espaço a carga é perdida.
                    {
                        estoque[i][j] = carga;
                        return estoque;
                    }
                }
            }
            return estoque;
        }

        public static void MostraEstoque(int[][] matriz)
        {
            for (int i = 0; i < matriz.Length; i++)
            {
                for (int j = 0; j < matriz[i].Length; j++)
                {
                    Console.Write("  " + matriz[i][j]);
                }

                Console.WriteLine("\t");
            }

            Console.WriteLine();
        }
     
        public static int[] TransformaEmVetor(int cont, List<string> aux)
        {
            aux.Sort(); //Organizo a lista

            int[] vetor = new int[cont]; // crio o vetor

            for (int i = 0; i < cont; i++) 
            {
                vetor[i] = Convert.ToInt32(aux[i]); //converto o elemento da lisata para um inteiro e armazeno no vetor.

            }

            return vetor;
        }


    }
}
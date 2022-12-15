using ScreenHandler;

namespace Jogo{
    class Jogo{
        /*
            Essa será a classe principal onde o jogo ocorre
        */
        static void Main(){
            Screen Tela = new Screen(100,9);
            Thread.Sleep(500);
            Tela.InserirCaracter('H',0,0);
            Thread.Sleep(500);
            Tela.EscreverTela();
            Tela.InserirCaracter('e',1,0);
            Thread.Sleep(500);
            Tela.EscreverTela();
            Tela.InserirCaracter('l',2,0);
            Thread.Sleep(500);
            Tela.EscreverTela();
            Tela.InserirCaracter('l',3,0);
            Thread.Sleep(500);
            Tela.EscreverTela();
            Tela.InserirCaracter('o',4,0);
            Thread.Sleep(500);
            Tela.EscreverTela();
            Tela.InserirCaracter(',',5,0);
            Thread.Sleep(500);
            Tela.EscreverTela();
            Tela.InserirCaracter(' ',6,0);
            Thread.Sleep(500);
            Tela.EscreverTela();
            Tela.InserirCaracter('W',7,0);
            Thread.Sleep(500);
            Tela.EscreverTela();
            Tela.InserirCaracter('o',8,0);
            Thread.Sleep(500);
            Tela.EscreverTela();
            Tela.InserirCaracter('r',9,0);
            Thread.Sleep(500);
            Tela.EscreverTela();
            Tela.InserirCaracter('l',10,0);
            Thread.Sleep(500);
            Tela.EscreverTela();
            Tela.InserirCaracter('d',11,0);
            Thread.Sleep(500);
            Tela.EscreverTela();
            Tela.InserirCaracter('!',12,0);
            Tela.EscreverTela();

            // Definir uma velocidade para o Loop do Jogo 
            // Definir tamanho da tela

            // Gerar Tela

            // Iniciar jogo

            // Gerar snake na posicao correta

            // Checar se Snake comeu o alimento
            //   Se sim, então gerar outro alimento

            // Andar com a Snake
        }
    }
    public class Snake{
        /*
            Essa classe será a Snake
        */

        // Criar Snake com 1 dot

        // Metodo para crescer a Snake

        // 
        private class Dot{
        /*
            Essa classe será cada pedaço da Snake
        */
        }
    }
    public class Alimento{
        /*
            Essa classe será o pontinho de alimento da Snake
        */
    }
    public class Pontuacao{
        private int Pontos { get; set; }
        /*
            Essa classe será responsável pela contagem
            de pontos do jogo
        */
    }
}
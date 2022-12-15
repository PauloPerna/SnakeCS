namespace Jogo{
    class Jogo{
        /*
            Essa será a classe principal onde o jogo ocorre
        */
        static void Main(){
            // Criamos a tela: Screen(largura, altura)
            Screen Tela = new Screen(100,9);
            // Tempo em milisegundos de atualização da tela
            int speed = 250;
            
            // Criar snake
            Snake cobrinha = new Snake(50,5);
            Tela.InserirCobra(cobrinha);

            // Criar alimento
            Alimento Comida = new Alimento(cobrinha,Tela.Largura,Tela.Altura);
            Tela.InserirAlimento(Comida);

            // Gerar Tela
            Tela.AtualizarTela();

            // Iniciar jogo
            while(cobrinha.Viva == true){
                // Capturamos o proximo movimento
                if(Console.KeyAvailable){
                    ConsoleKeyInfo key = Console.ReadKey(false);
                    switch(key.Key){
                        case ConsoleKey.UpArrow:
                            cobrinha.MovimentoDirecao = 0;
                            break;
                        case ConsoleKey.RightArrow:
                            cobrinha.MovimentoDirecao = 1;
                            break;
                        case ConsoleKey.DownArrow:
                            cobrinha.MovimentoDirecao = 2;
                            break;
                        case ConsoleKey.LeftArrow:
                            cobrinha.MovimentoDirecao = 3;
                            break;
                        default:
                            break;
                    }
                }

                // Andar com a Snake
                Tela.RemoverCobra(cobrinha);
                cobrinha.Andar(cobrinha.MovimentoDirecao);
                Tela.InserirCobra(cobrinha);
                
                // Checar sobreposições da cabeça com
                //   com paredes
                if(cobrinha.PosicaoX == 0 || 
                    cobrinha.PosicaoX == Tela.Largura || 
                    cobrinha.PosicaoY == 0 || 
                    cobrinha.PosicaoY == Tela.Altura){
                        cobrinha.Viva = false;
                    }
                //   com alimento
                if(cobrinha.PosicaoX == Comida.PosicaoX &&
                    cobrinha.PosicaoY == Comida.PosicaoY){
                        cobrinha.Alimentar(Comida);
                    }
                //   com o corpo
                if(cobrinha.Corpo.FirstOrDefault(c => c.PosicaoX == cobrinha.PosicaoX &&
                                                 c.PosicaoY == cobrinha.PosicaoY, null)!= null){
                        cobrinha.Viva = false;
                    }

                Tela.AtualizarTela();
                System.Threading.Thread.Sleep(speed);
            }
            Tela.FimDeJogo();
        }
    }
}
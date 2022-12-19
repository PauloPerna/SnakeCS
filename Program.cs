namespace Jogo{
    class Jogo{
        /*
            Essa será a classe principal onde o jogo ocorre
        */
        static void Main(){
            // Criamos a tela: Tela(largura, altura)
            Tela tela = new Tela(50,9);
            // Tempo em milisegundos de atualização da tela
            int tempoAtualizacao = 125;
            
            // Criar Cobra
            Cobra cobrinha = new Cobra(25,5);
            tela.InserirCobra(cobrinha);

            // Criar alimento
            Alimento comida = new Alimento(cobrinha,tela.Largura,tela.Altura);
            tela.InserirAlimento(comida);

            // Gerar Tela
            tela.AtualizarTela();

            // Iniciar jogo
            while(cobrinha.Viva == true){
                // Capturamos o proximo movimento
                if(Console.KeyAvailable){
                    ConsoleKeyInfo key = Console.ReadKey(false);
                    switch(key.Key){
                        case ConsoleKey.UpArrow:
                            cobrinha.MudarDirecaoCobra(0);
                            break;
                        case ConsoleKey.RightArrow:
                            cobrinha.MudarDirecaoCobra(1);
                            break;
                        case ConsoleKey.DownArrow:
                            cobrinha.MudarDirecaoCobra(2);
                            break;
                        case ConsoleKey.LeftArrow:
                            cobrinha.MudarDirecaoCobra(3);
                            break;
                        default:
                            break;
                    }
                }

                // Andar com a Cobra
                tela.RemoverCobra(cobrinha);
                cobrinha.Andar();
                tela.InserirCobra(cobrinha);
                
                // Checar sobreposições da cabeça com
                //   com paredes
                if(cobrinha.PosicaoX == 0 || 
                    cobrinha.PosicaoX == tela.Largura || 
                    cobrinha.PosicaoY == 0 || 
                    cobrinha.PosicaoY == tela.Altura){
                        cobrinha.Viva = false;
                    }
                //   com alimento
                if(cobrinha.PosicaoX == comida.PosicaoX &&
                    cobrinha.PosicaoY == comida.PosicaoY){
                        cobrinha.Alimentar(comida);
                        comida = new Alimento(cobrinha,tela.Largura,tela.Altura);
                        tela.InserirAlimento(comida);
                    }
                //   com o corpo
                if(cobrinha.Corpo.FirstOrDefault(c => c.PosicaoX == cobrinha.PosicaoX &&
                                                 c.PosicaoY == cobrinha.PosicaoY, null)!= null){
                        cobrinha.Viva = false;
                    }

                tela.AtualizarTela();
                System.Threading.Thread.Sleep(tempoAtualizacao);
            }
            tela.FimDeJogo();
        }
        public bool ChecarColisao(){
            throw new NotImplementedException();
        }
    }
}
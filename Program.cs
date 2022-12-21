namespace Jogo{
    class Jogo{
        /*
            Essa será a classe principal onde o jogo ocorre
        */
        static void Main(){
            // Criamos a tela: Tela(largura, altura)
            Tela tela = new Tela(100,13);
            // Tempo em milisegundos de atualização da tela
            int tempoAtualizacao = 125;
            
            // Criar Cobra no centro da tela
            Cobra cobrinha = new Cobra(tela.Largura/2,tela.Altura/2);
            tela.InserirCobra(cobrinha);

            // Criar alimento, cobra, tela largura e tela altura devem ser passados como
            //  argumentos para evitar sobreposição
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
                            cobrinha.MudarDirecaoCobra(0); // cima
                            break;
                        case ConsoleKey.RightArrow:
                            cobrinha.MudarDirecaoCobra(1); // direita
                            break;
                        case ConsoleKey.DownArrow:
                            cobrinha.MudarDirecaoCobra(2); // baixo
                            break;
                        case ConsoleKey.LeftArrow:
                            cobrinha.MudarDirecaoCobra(3); // esquerda
                            break;
                        default:
                            break;
                    }
                }

                // Andar com a Cobra
                tela.RemoverCobra(cobrinha);
                cobrinha.Andar();
                tela.InserirCobra(cobrinha);
                
                // TODO: separar a parte de checar sobreposições em um método
                // Checar sobreposições da cabeça com
                //   com paredes
                if(cobrinha.PosicaoX == 0 || 
                    cobrinha.PosicaoX == tela.Largura-1 || 
                    cobrinha.PosicaoY == 0 || 
                    cobrinha.PosicaoY == tela.Altura-1){
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
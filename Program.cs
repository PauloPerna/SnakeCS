namespace Jogo{
    class Jogo{
        /*
            Essa será a classe principal onde o jogo ocorre
        */
        static void Main(){
            // Criamos a tela: Screen(largura, altura)
            Screen Tela = new Screen(100,9);
            // Tempo em milisegundos de atualização da tela
            int speed = 500;
            
            // Criar snake
            Snake cobrinha = new Snake(50,5);
            Tela.InserirCobra(cobrinha);

            // Criar alimento
            Random rnd = new Random();
            // TODO: impedir sobreposicao alimento com cobra
            Alimento Comida = new Alimento(rnd.Next(1,Tela.Largura-1),rnd.Next(1,Tela.Altura-1));
            Tela.InserirAlimento(Comida);

            // Gerar Tela
            Tela.AtualizarTela();

            // Iniciar jogo
            while(cobrinha.Viva == true){
                // Andar com a Snake
                Tela.RemoverCobra(cobrinha);
                cobrinha.Andar(cobrinha.MovimentoDirecao);
                Tela.InserirCobra(cobrinha);
                
                // Checar sobreposições da cabeça com
                //   com alimento
                //   com paredes
                //   com o corpo
                //   Se sim, então gerar outro alimento
                Tela.AtualizarTela();
                
                System.Threading.Thread.Sleep(speed);
            }

        }
    }
}
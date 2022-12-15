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
            Tela.AtualizarTela();
            // Gerar Tela

            // Iniciar jogo



            // Gerar snake na posicao correta

            // Checar se Snake comeu o alimento
            //   Se sim, então gerar outro alimento

            // Andar com a Snake
        }
    }
}
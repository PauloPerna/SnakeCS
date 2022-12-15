namespace ScreenHandler{
    /*
        Esse namespace é responsável pela interface com o usuário através do jogo.
        Deve conter funções para:
        1. Controlar o tamanho da interface do jogo
        2. Controlar output de caracteres nas posições dadas
    */
    class Screen{
        // Altura da Tela
        private int Altura { get; set; }
        // Largura da Tela
        private int Largura { get; set; }
        // A tela será um array de strings que serão escritas na tela do jogador
        //  com a função WriteLine
        private string[] Tela { get; set; }
        public Screen(int altura, int largura){
            /*
                Repare que o construtor também escreve a tela inicial do jogo
            */
            // TODO
            this.Altura = altura;
            this.Largura = largura;
        }
        public void EscreverTela(){
            /*
                Atualiza a tela do jogo
            */
            // TODO
            throw new NotImplementedException();
        }
        public void InserirCaracter(string caracter, int x, int y){
            /*
                Insere na tela o caracter nas posições corretas
            */
            // TODO
            throw new NotImplementedException();
        }

    }
}
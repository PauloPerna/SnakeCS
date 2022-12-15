namespace ScreenHandler{
    /*
        Esse namespace é responsável pela interface com o usuário através do jogo.
        Deve conter funções para:
        1. Controlar o tamanho da interface do jogo
        2. Controlar output de caracteres nas posições dadas
    */
    class Screen{
        // Largura da Tela
        private int Largura { get; set; }
        // Altura da Tela
        private int Altura { get; set; }
        // A tela será uma matriz de Chars que serão escritas na tela do jogador
        //  com a função Write
        private char[,] Tela { get; set; }
        public Screen(int largura, int altura){
            /*
                Repare que o construtor também escreve a tela inicial do jogo,
                 isso é necessário para que já saibamos onde posicionar o cursor
                 na hora de atualizar a tela
            */
            // Cria a tela
            this.Largura = largura;
            this.Altura = altura;
            this.Tela = new char[this.Altura,this.Largura];
            for(int i = 0; i < this.Altura; i++){
                for(int j = 0; j < this.Largura; j++){
                    this.Tela[i,j] = '*';
                }
            }
            // Inicializa a tela
            for(int i = 0; i < this.Altura; i++){
                for(int j = 0; j < this.Largura; j++){
                    Console.Write(this.Tela[i,j]);
                }
                Console.Write("\n");
            }
        }
        public void EscreverTela(){
            // Reposicionar Cursor
            Console.SetCursorPosition(0, Console.CursorTop -this.Altura); 
            // Escrever tela
            for(int i = 0; i < this.Altura; i++){
                for(int j = 0; j < this.Largura; j++){
                    Console.Write(this.Tela[i,j]);
                }
                Console.Write("\n");
            }
        }
        public void InserirCaracter(char caracter, int x, int y){
            this.Tela[y,x] = caracter;
        }
    }
}
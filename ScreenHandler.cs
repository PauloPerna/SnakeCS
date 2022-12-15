namespace Jogo{
    /*
        Esse namespace é responsável pela interface com o usuário através do jogo.
        Deve conter funções para:
        1. Controlar o tamanho da interface do jogo
        2. Controlar output de caracteres nas posições dadas
    */
    class Screen{
        // Largura da Tela
        public int Largura { get; set; }
        // Altura da Tela
        public int Altura { get; set; }
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
                    // Essa condicao é para fazermos a 'borda' do jogo
                    if(i == 0  || i == this.Altura-1 || j == 0 || j == this.Largura-1){
                        this.Tela[i,j] = 'x';
                    } else {
                        this.Tela[i,j] = ' ';
                    }
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
        // Atualiza toda a tela
        public void AtualizarTela(){
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
        // Insere um caracter na tela
        public void InserirCaracter(char caracter, int x, int y){
            this.Tela[y,x] = caracter;
        }
        // Insere a cobra na tela
        public void InserirCobra(Snake cobrinha){
            // Insere a cabeça
            InserirCaracter(cobrinha.SimboloCabeca,cobrinha.PosicaoX,cobrinha.PosicaoY);
            // Insere o corpo
            foreach(Dot ponto in cobrinha.Corpo){
                InserirCaracter(ponto.Simbolo,ponto.PosicaoX,ponto.PosicaoY);
            }
        }
        public void RemoverCobra(Snake cobrinha){
            // Insere a cabeça
            InserirCaracter(' ',cobrinha.PosicaoX,cobrinha.PosicaoY);
            // Insere o corpo
            foreach(Dot ponto in cobrinha.Corpo){
                InserirCaracter(' ',ponto.PosicaoX,ponto.PosicaoY);
            }
        }
        public void InserirAlimento(Alimento alimento){
            InserirCaracter(alimento.Simbolo,alimento.PosicaoX,alimento.PosicaoY);
        }
        public void FimDeJogo(){
            InserirCaracter('F',this.Largura/2 - 5, this.Altura/2);
            InserirCaracter('I',this.Largura/2 - 4, this.Altura/2);
            InserirCaracter('M',this.Largura/2 - 3, this.Altura/2);
            InserirCaracter(' ',this.Largura/2 - 2, this.Altura/2);
            InserirCaracter('D',this.Largura/2 - 1, this.Altura/2);
            InserirCaracter('E',this.Largura/2, this.Altura/2);
            InserirCaracter(' ',this.Largura/2 + 1, this.Altura/2);
            InserirCaracter('J',this.Largura/2 + 2, this.Altura/2);
            InserirCaracter('O',this.Largura/2 + 3, this.Altura/2);
            InserirCaracter('G',this.Largura/2 + 4, this.Altura/2);
            InserirCaracter('O',this.Largura/2 + 5, this.Altura/2);
            this.AtualizarTela();
        }
    }
}
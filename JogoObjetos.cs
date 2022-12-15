namespace Jogo{
    public class Snake{
        /*
            Essa classe será a Snake
        */
        public char SimboloCabeca { get; set; }
        public List<Dot> Corpo { get; set; }
        public int PosicaoX { get; set; }
        public int PosicaoY { get; set; }

        // Criar Snake com 1 dot
        public Snake(int posicaoX, int posicaoY){
            this.PosicaoX = posicaoX;
            this.PosicaoY = posicaoY;
            this.SimboloCabeca = '0';
            this.Corpo = new List<Dot> {new Dot(this.PosicaoX,this.PosicaoY+1)};
        }

        /*
            Metodo para crescer a Snake
                O novo tamanho será adicionado no próximo movimento,
                onde o corpo todo ficará imóvel e o novo dot será adicionado
                no local que estava o último dot 
        */
        public void Alimentar(Alimento alimento){
            throw new NotImplementedException();
        }
    }
    public class Dot{
    /*
        Essa classe será cada pedaço da Snake
    */
        public char Simbolo { get; set; }
        public int PosicaoX { get; set; }
        public int PosicaoY { get; set; }
        public Dot(int posicaoX, int posicaoY){
            this.PosicaoX = posicaoX;
            this.PosicaoY = posicaoY;
            this.Simbolo = 'o';
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
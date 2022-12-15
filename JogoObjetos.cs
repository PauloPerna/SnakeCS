using System.Linq;

namespace Jogo{
    public class Snake{
        /*
            Essa classe será a Snake
        */
        public char SimboloCabeca { get; set; }
        public List<Dot> Corpo { get; set; }
        public int PosicaoX { get; set; }
        public int PosicaoY { get; set; }
        public bool Viva { get; set; }
        // Code smell forte aqui, mas ainda n sei como resolver
        // movimento 0: cima, 1: direita, 2: baixo, 3: esquerda
        public int MovimentoDirecao;

        // Criar Snake com 1 dot
        public Snake(int posicaoX, int posicaoY){
            this.PosicaoX = posicaoX;
            this.PosicaoY = posicaoY;
            this.SimboloCabeca = 'O';
            this.MovimentoDirecao = 0;
            this.Viva = true;
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
        public void Andar(int direcao){
            // Trocamos a posicao do ultimo pedaco do corpo pela posicao que estava a cabeca
            this.Corpo[this.Corpo.Count-1].PosicaoX = this.PosicaoX;
            this.Corpo[this.Corpo.Count-1].PosicaoY = this.PosicaoY;
            switch(direcao){
                case 0: // Cima
                    this.PosicaoY--;
                    break;
                case 1: // Direita
                    this.PosicaoX++;
                    break;
                case 2: // Baixo
                    this.PosicaoY++;
                    break;
                case 3: // Esquerda
                    this.PosicaoX--;
                    break;
                default: // Nenhum
                    break;
            }
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
        public char Simbolo { get; set; }
        public int PosicaoX { get; set; }
        public int PosicaoY { get; set; }
        public Alimento(int posicaoX, int posicaoY){
            this.PosicaoX = posicaoX;
            this.PosicaoY = posicaoY;
            this.Simbolo = '*';
        }
    }
    public class Pontuacao{
        private int Pontos { get; set; }
        /*
            Essa classe será responsável pela contagem
            de pontos do jogo
        */
    }
}
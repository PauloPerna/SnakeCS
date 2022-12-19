using System.Linq;

namespace Jogo{
    public class Cobra{
        /*
            Essa classe será a Cobra
        */
        public char SimboloCabeca { get; set; }
        public List<Dot> Corpo { get; set; }
        public int PosicaoX { get; set; }
        public int PosicaoY { get; set; }
        public bool Viva { get; set; }
        // Code smell forte aqui, mas ainda n sei como resolver
        // movimento 0: cima, 1: direita, 2: baixo, 3: esquerda
        public int MovimentoDirecao;

        // Criar Cobra com 1 dot
        public Cobra(int posicaoX, int posicaoY){
            this.PosicaoX = posicaoX;
            this.PosicaoY = posicaoY;
            this.SimboloCabeca = 'O';
            this.MovimentoDirecao = 0;
            this.Viva = true;
            this.Corpo = new List<Dot> {new Dot(this.PosicaoX,this.PosicaoY+1)};
        }

        /*
            Metodo para crescer a Cobra
                O novo tamanho será adicionado no próximo movimento,
                onde o corpo todo ficará imóvel e o novo dot será adicionado
                no local que estava o último dot 
        */
        public void Alimentar(Alimento alimento){
            // Criamos o novo dot na posicao imediatamente abaixo do ultimo dot
            int posicaoX = this.Corpo[this.Corpo.Count-1].PosicaoX;
            int posicaoY = this.Corpo[this.Corpo.Count-1].PosicaoY+1;
            this.Corpo.Add(new Dot(posicaoX,posicaoY));
        }
        public void Andar(int direcao){
            //Andar por 'rolamento': Vamos colocar o último dot do corpo na posicação atual da cabeça
            // depois atualizar a posição de todos os dots "O último vira o primeiro, o primeiro vira o segundo etc"
            // depois andar com a cabeça
            Corpo.Select(c => c.)
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
        Essa classe será cada pedaço da Cobra
    */
        public char Simbolo { get; set; }
        public int PosicaoX { get; set; }
        public int PosicaoY { get; set; }
        public int PosicaoNoCorpo;
        public Dot(int posicaoX, int posicaoY, int posicaoNoCorpo){
            this.PosicaoX = posicaoX;
            this.PosicaoY = posicaoY;
            this.Simbolo = 'o';
            this.PosicaoNoCorpo = posicaoNoCorpo;
        }
    }
    public class Alimento{
        /*
            Essa classe será o pontinho de alimento da Cobra
        */
        public char Simbolo { get; set; }
        public int PosicaoX { get; set; }
        public int PosicaoY { get; set; }
        public Alimento(Cobra cobrinha, int telaLargura, int telaAltura){
            Random rnd = new Random();
            bool sobreposicaoCabeca = true;
            bool sobreposicaoCorpo = true;
            // Testamos a sobreposicao com a cobra, caso exista nós recriamos o alimento
            while(sobreposicaoCabeca || sobreposicaoCorpo){
                // Geramos uma posicao dentro da tela do jogo
                this.PosicaoX = rnd.Next(1,telaLargura-1);
                this.PosicaoY = rnd.Next(1,telaAltura-1);
                // Testamos a sobreposicao com a cabeça
                sobreposicaoCabeca = this.PosicaoX == cobrinha.PosicaoX && this.PosicaoY == cobrinha.PosicaoY;
                // Testamos a sobreposicao com o corpo, tentando encontrar alguma parte do corpo com a posicao identica
                //  a do alimento
                Dot CorpoSobreposto = cobrinha.Corpo.FirstOrDefault(c => c.PosicaoX == this.PosicaoX && c.PosicaoY == this.PosicaoY,null);
                sobreposicaoCorpo = CorpoSobreposto != null;
            }
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
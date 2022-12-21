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
        // TODO: Mudar o MovimentoDirecao para um ENUM
        public int MovimentoDirecao { get; set; }

        // Criar Cobra com 1 dot
        public Cobra(int posicaoX, int posicaoY){
            this.PosicaoX = posicaoX;
            this.PosicaoY = posicaoY;
            this.SimboloCabeca = 'O';
            this.MovimentoDirecao = 0;
            this.Viva = true;
            this.Corpo = new List<Dot> {new Dot(this.PosicaoX,this.PosicaoY+1,1)};
        }

        public void MudarDirecaoCobra(int novaDirecao){
            // A seguinte lógica procura impedir que a cobra volte-se para trás
            //  se vamos para a direita não podemos ir para a esquerda, se vamos
            //  para cima não podemos ir para baixo etc
            // Isso ocorre quando a soma de this.MovimentoDirecao com value é igual
            //  a 2 ou igual a 4.
            if(this.MovimentoDirecao + novaDirecao != 2 && this.MovimentoDirecao + novaDirecao != 4){
                this.MovimentoDirecao = novaDirecao;
            }
        }
        /*
            Metodo para crescer a Cobra
        */
        public void Alimentar(Alimento alimento){
            // Criamos o novo dot na posicao 0,0
            //  esses valores não importam muito, já que no próximo movimento ele toma
            //  a posicao do ultimo dot
            int posicaoX = 0;
            int posicaoY = 0;
            int posicaoNoCorpo = this.Corpo.Count()+1;
            this.Corpo.Add(new Dot(posicaoX,posicaoY,posicaoNoCorpo));
        }

        /*
            Metodo para fazer a Cobra andar 
        */
        public void Andar(){
            // Andar por 'rolamento': Vamos colocar o último dot do corpo na posicação atual da cabeça
            //  depois atualizar a posição de todos os dots "O último vira o primeiro, o primeiro vira o segundo etc"
            //  depois andar com a cabeça
            this.Corpo.FirstOrDefault(c => c.PosicaoNoCorpo == this.Corpo.Count).PosicaoX = this.PosicaoX;
            this.Corpo.FirstOrDefault(c => c.PosicaoNoCorpo == this.Corpo.Count).PosicaoY = this.PosicaoY;
            this.Corpo.FirstOrDefault(c => c.PosicaoNoCorpo == this.Corpo.Count).PosicaoNoCorpo = 0;
            foreach(Dot dot in this.Corpo){
                dot.PosicaoNoCorpo++;
            }
            switch(this.MovimentoDirecao){
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
namespace Game
{
    public class Entidades
    {
        public int timerTurno { get; set; } // Timer para o turno da entidade, usado em batalhas
        public string Nome { get; set; } // Nome da entidade
        public Vida Vida { get; set; } // Status de vida da entidade
        public Ataque Ataque { get; set; } // Status de ataque da entidade
        public Defesa Defesa { get; set; } // Status de defesa da entidade
        public Mente Mente { get; set; } // Status de mente da entidade
        public Velocidade Velocidade { get; set; } // Status de velocidade da entidade
        public List<Habilidades> Habilidades { get; set; } // Lista de habilidades da entidade
        public Tiles Caractere { get; set; } // Caractere que representa a entidade no mapa
        public Tiles pisandoSobre { get; set; } // Tile sobre o qual a entidade está pisando
        public int posX { get; set; } // Posição X da entidade no mapa
        public int posY { get; set; } // Posições X e Y da entidade no mapa

        public void movimentar(int x, int y, List<List<Tiles>> mapa)
        {
            // Método para mover a entidade para uma nova posição no mapa
            // x e y são as coordenadas da nova posição
            // mapa é o layout do mapa onde a entidade se moverá
            if (x >= 0 && x < mapa[0].Count && y >= 0 && y < mapa.Count)
            {
                this.pisandoSobre = mapa[y][x]; // Atualiza o tile sobre o qual a entidade está pisando
                mapa[y][x] = this.Caractere; // Coloca o caractere da entidade no novo tile
            }
        }
        public void detectarMovimentoTecla(List<List<Tiles>> mapa)
        {
            ConsoleKeyInfo tecla = Console.ReadKey(intercept: true);
            mapa[this.posY][this.posX] = this.pisandoSobre;
            switch (tecla.Key)
            {
                case ConsoleKey.UpArrow:
                    // Remove o caractere do tile atual
                    if (!mapa[this.posY - 1][this.posX].solido) {
                        this.posY--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (!mapa[this.posY + 1][this.posX].solido)
                    {
                        this.posY++;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (!mapa[this.posY][this.posX-1].solido)
                    {
                        this.posX--;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (!mapa[this.posY][this.posX+1].solido)
                    {
                        this.posX++;
                    }
                    break;
            }
            movimentar(x: this.posX, y: this.posY, mapa); // Move para cima
        }
        public Entidades(string nome, int vida, int ataque, int defesa, int mente, int velocidade, Tiles caractere)
        {
            this.Nome = nome; // Inicializa o nome da entidade
            this.Vida = new Vida(vida); // Inicializa o status de vida
            this.Ataque = new Ataque(ataque); // Inicializa o status de ataque
            this.Defesa = new Defesa(defesa); // Inicializa o status de defesa
            this.Mente = new Mente(mente); // Inicializa o status de mente
            this.Velocidade = new Velocidade(velocidade); // Inicializa o status de velocidade
            this.Habilidades = new List<Habilidades>(); // Inicializa a lista de habilidades
            this.Caractere = caractere; // Define o caractere que representa a entidade no mapa
            this.pisandoSobre = new Piso(); // Inicializa o tile sobre o qual a entidade está pisando
            this.posX = 0; // Inicializa a posição X da entidade
            this.posY = 0; // Inicializa a posição Y da entidade
        }

        
        public override string ToString()
        {
            return $"{this.Nome} - Vida: {this.Vida.getValorAtual()}/{this.Vida.getValorMaximo()}, " +
                   $"Ataque: {this.Ataque.getValorAtual()}, Defesa: {this.Defesa.getValorAtual()}, " +
                   $"Mente: {this.Mente.getValorAtual()}, Velocidade: {this.Velocidade.getValorAtual()}," +
                   $"Posição: ({this.posX}, {this.posY})"; // Retorna uma string com as informações da entidade
        }
        public void adicionarHabilidade(Habilidades habilidade)
        {
            this.Habilidades.Add(habilidade); // Adiciona uma nova habilidade à lista
        }
    }





}
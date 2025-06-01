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
        }

        
        public override string ToString()
        {
            return $"{this.Nome} - Vida: {this.Vida.getValorAtual()}/{this.Vida.getValorMaximo()}, " +
                   $"Ataque: {this.Ataque.getValorAtual()}, Defesa: {this.Defesa.getValorAtual()}, " +
                   $"Mente: {this.Mente.getValorAtual()}, Velocidade: {this.Velocidade.getValorAtual()},";
        }
        public void adicionarHabilidade(Habilidades habilidade)
        {
            this.Habilidades.Add(habilidade); // Adiciona uma nova habilidade à lista
        }
    }





}
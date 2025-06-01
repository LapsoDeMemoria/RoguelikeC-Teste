namespace Game
{
    public class Tiles
    {
        public string Nome { get; set; } // Nome do tile
        public string Caractere { get; set; } // Caractere que representa o tile
        public bool solido { get; set; } // Indica se o tile é sólido (não pode ser atravessado)
        public Tiles(string nome, string caractere, bool solido = false)
        {
            this.Nome = nome; // Inicializa o nome do tile
            this.Caractere = caractere; // Inicializa o caractere do tile
            this.solido = solido; // Define se o tile é sólido
        }
    }
    public class Parede : Tiles
    {
        public Parede(string nome = "Parede", string caractere = "# ") : base(nome, caractere, true)
        {
            // Inicializa o tile de parede com nome e caractere padrão
        }
    }
    public class Piso : Tiles
    {
        public Piso(string nome = "Piso", string caractere = ". ") : base(nome, caractere, false)
        {
            // Inicializa o tile de piso com nome e caractere padrão
        }
    }
    public class CentroSala : Tiles
    {
        public CentroSala(string nome = "Centro da Sala", string caractere = ", ") : base(nome, caractere, false)
        {
            // Inicializa o tile de centro de sala com nome e caractere padrão
        }
    }
    public class JogadorTile : Tiles
    {
        public JogadorTile(string nome = "Jogador", string caractere = "@ ") : base(nome, caractere, false)
        {
            // Inicializa o tile do jogador com nome e caractere padrão
        }
    }
}
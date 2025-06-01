namespace Game
{
    public class Mapa
    {
        protected const int LARGURA = 60; // Largura do mapa
        protected const int ALTURA = 40; // Altura do mapa
        protected int quantidadeSalas { get; set; } // Quantidade de salas no mapa
        public List<List<Tiles>> Layout = new List<List<Tiles>>(); // Layout do mapa, representado por uma lista de tiles

        public void iniciarMapa()
        {
            for (int y=0; y < ALTURA; y++) // Percorre cada linha do mapa
            {
                List<Tiles> linha = new List<Tiles>(); // Cria uma nova linha de tiles
                for (int x = 0; x < LARGURA; x++) // Percorre cada coluna da linha
                {
                    linha.Add(new Parede()); // Adiciona um tile de parede
                }
                this.Layout.Add(linha); // Adiciona a linha ao layout do mapa
            }
        }


        public void conectarSalas(int x1, int y1, int x2, int y2) // Método para conectar duas salas com um corredor
        {
            int xAtual = x1;
            int yAtual = y1;

            while (xAtual != x2) // Conecta horizontalmente
            {
            this.Layout[yAtual][xAtual] = new Piso(); // Substitui o tile por piso
            xAtual += xAtual < x2 ? 1 : -1; // Move na direção do destino
            }

            while (yAtual != y2) // Conecta verticalmente
            {
            this.Layout[yAtual][xAtual] = new Piso(); // Substitui o tile por piso
            yAtual += yAtual < y2 ? 1 : -1; // Move na direção do destino
            }
        }
        public List<List<Tiles>> gerarSala(int width, int height) // Método para gerar uma sala com largura e altura especificadas
        {
            List<List<Tiles>> sala = new List<List<Tiles>>(); // Cria uma nova lista para a sala
            for (int y = 0; y < height; y++) // Percorre cada linha da sala
            {
                List<Tiles> linha = new List<Tiles>(); // Cria uma nova linha de tiles
                for (int x = 0; x < width; x++) // Percorre cada coluna da linha
                {
                    linha.Add(new Piso()); // Adiciona um tile de piso
                }
                sala.Add(linha); // Adiciona a linha à sala
            }
            sala[(int)height / 2][(int)width / 2] = new CentroSala(); // Define o centro da sala com um tile especial
            return sala; // Retorna a sala gerada
        }
        public void adicionarSala(int x, int y, List<List<Tiles>> sala) // Método para adicionar uma sala ao mapa em uma posição específica
        {

                for (int i = 0; i < sala.Count; i++) // Percorre cada linha da sala
                {
                    for (int j = 0; j < sala[i].Count; j++) // Percorre cada tile na linha
                    {
                        if (y + i < ALTURA && x + j < LARGURA) // Verifica se a posição está dentro dos limites do mapa
                        {
                            this.Layout[y + i][x + j] = sala[i][j]; // Adiciona o tile da sala ao layout do mapa
                        }
                        

                    }
                }      
        }
        public bool overlapSalas(int x, int y, List<List<Tiles>> sala) // Verifica se há overlap com outra sala
        {
            for (int i = 0; i < sala.Count; i++) // Percorre cada linha da sala
            {
                for (int j = 0; j < sala[i].Count; j++) // Percorre cada tile na linha
                {
                    int posY = y + i; // Calcula a posição Y no mapa
                    int posX = x + j; // Calcula a posição X no mapa

                    if (posY >= ALTURA || posX >= LARGURA || posY < 0 || posX < 0) // Verifica se está fora dos limites do mapa
                    {
                    return true; // Retorna verdadeiro se estiver fora dos limites
                    }

                    if (this.Layout[posY][posX] is not Parede) // Verifica se o tile no mapa não é uma parede
                    {
                    return true; // Retorna verdadeiro se houver overlap
                    }
                }
            }
            return false; // Retorna falso se não houver overlap
        }


        public void gerarMapa() // Método para gerar o mapa
        {
            const int  larguraMinima = 3; // Largura mínima da sala
            const int alturaMinima = 3; // Altura mínima da sala
            const int larguraMaxima = 15; // Largura máxima da sala
            const int alturaMaxima = 15; // Altura máxima da sala
            List<int> coordenadaSalasX = new List<int>(); // Lista para armazenar as coordenadas das salas
            List<int> coordenadaSalasY = new List<int>();
            List<int> larguraSalas = new List<int>(); // Lista para armazenar as larguras das salas
            List<int> alturaSalas = new List<int>(); // Lista para armazenar as alturas das salas
            List<List<List<Tiles>>> salas = new List<List<List<Tiles>>>(); // Lista para armazenar as salas
            iniciarMapa(); // Inicializa o mapa com paredes
            Random random = new Random(); // Cria uma instância de Random para gerar números aleatórios
            for (int i = 0; i < quantidadeSalas; i++) // Percorre a quantidade de salas a serem geradas
            {
                int larguraSala = random.Next(larguraMinima, larguraMaxima); // Largura aleatória da sala entre 5 e 10
                int alturaSala = random.Next(alturaMinima, alturaMaxima); // Altura aleatória da sala entre 5 e 10
                int posX = random.Next(1, LARGURA - larguraSala - 1); // Posição X aleatória dentro dos limites do mapa
                int posY = random.Next(1, ALTURA - alturaSala - 1); // Posição Y aleatória dentro dos limites do mapa
                coordenadaSalasX.Add(posX); // Adiciona a posição X à lista de coordenadas
                coordenadaSalasY.Add(posY); // Adiciona a posição Y à lista de coordenadas
                larguraSalas.Add(larguraSala); // Adiciona a largura da sala à lista de larguras
                alturaSalas.Add(alturaSala); // Adiciona a altura da sala à lista de alturas
                List<List<Tiles>> sala = gerarSala(larguraSala, alturaSala); // Gera a sala com as dimensões especificadas
                if (!overlapSalas(posX, posY, sala)) // Verifica se o local está livre para adicionar a sala
                {
                    adicionarSala(posX, posY, sala);
                }
                 // Adiciona a sala ao mapa na posição especificada
                salas.Add(sala); // Adiciona a sala à lista de salas
                if (i > 0 && i< quantidadeSalas) // Se não for a primeira sala, conecta com a sala anterior
                {
                    int posXAnterior = random.Next(1, LARGURA - larguraSala - 1); // Posição X aleatória para a conexão
                    int posYAnterior = random.Next(1, ALTURA - alturaSala - 1); // Posição Y aleatória para a conexão
                    conectarSalas(coordenadaSalasX[i - 1] + (int)larguraSalas[i - 1] / 2, coordenadaSalasY[i - 1] + (int)alturaSalas[i - 1] / 2, posX + larguraSala / 2, posY + (int)alturaSala / 2); // Conecta as salas
                }
            }
        }
        public void colocarJogador(Entidades jogador, List<List<Tiles>> mapa) // Método para colocar o jogador no mapa
        {
            Random random = new Random(); // Cria uma instância de Random para gerar números aleatórios
            jogador.posX = random.Next(1, LARGURA - 1); // Posição X aleatória dentro dos limites do mapa
            jogador.posY = random.Next(1, ALTURA - 1); // Posição Y aleatória dentro dos limites do mapa
            while (mapa[jogador.posY][jogador.posX] is not Piso) // Enquanto o tile na posição não for piso
            {
                jogador.posX = random.Next(1, LARGURA - 1); // Gera uma nova posição X
                jogador.posY = random.Next(1, ALTURA - 1); // Gera uma nova posição Y
            }
            mapa[jogador.posY][jogador.posX] = jogador.Caractere; // Coloca o tile do jogador no mapa na posição especificada

        }


        public void exibirMapa()
        {
            foreach (List<Tiles> linha in Layout) // Percorre cada linha do layout
            {
                foreach (Tiles tile in linha) // Percorre cada tile na linha
                {
                    Console.Write(tile.Caractere); // Exibe o caractere do tile
                }
                Console.WriteLine(); // Nova linha após exibir todos os tiles da linha
            }
        }
        public Mapa(int quantidadeSalas = 10) // Construtor que recebe a quantidade de salas
        {
            this.quantidadeSalas = quantidadeSalas; // Inicializa a quantidade de salas
        }

    }
}
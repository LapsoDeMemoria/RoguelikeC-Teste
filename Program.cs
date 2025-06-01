using System.Diagnostics.Contracts;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Game;
using Recursos;


// Classe para definir cores de texto no terminal
// Classe para exibir mensagens no terminal com opções de formatação

// Classe base para representar um status com valor atual e máximo






// Classe principal do programa
public class Program
{
    public Entidades Jogador;

    public Program()
    {
        Jogador = new Entidades(nome: "Jogador", vida: 100, ataque: 20, defesa: 15, mente: 10, velocidade: 5, caractere: new JogadorTile()); // Cria uma instância do jogador com atributos iniciais
        Jogador.adicionarHabilidade(new Soco()); // Adiciona a habilidade "Soco" ao jogador

    }
    public static void Main(string[] args)
    {
        Console.Clear();
        Random random = new Random(); // Cria uma instância de Random para gerar números aleatórios
        // Exibe uma mensagem de teste no terminal
        Program programInstance = new Program();
        Mapa mapa = new Mapa(quantidadeSalas: random.Next(3,30)); // Cria uma instância do mapa com 10 salas
        mapa.gerarMapa(); // Gera o mapa com as salas e conexões
        mapa.colocarJogador(programInstance.Jogador, mapa.Layout); // Coloca o jogador no mapa
        Console.CursorVisible = false; // Oculta o cursor do terminal para uma melhor visualização do jogo
        while (true) // Loop principal do jogo
        {
            Console.SetCursorPosition(0, 0);
            Log.log(programInstance.Jogador.ToString(), cor: Cor.INFO, delay: 0.00, limpar_terminal: false); // Exibe as informações do jogador no terminal
            mapa.exibirMapa(); // Exibe o mapa no terminal
            programInstance.Jogador.detectarMovimentoTecla(mapa.Layout); // Detecta o movimento do jogador com base nas teclas pressionadas

        }

    }
}

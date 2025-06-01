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
        Random random = new Random(); // Cria uma instância de Random para gerar números aleatórios
        // Exibe uma mensagem de teste no terminal
        Program programInstance = new Program();
        Mapa mapa = new Mapa(quantidadeSalas: random.Next(3,20)); // Cria uma instância do mapa com 10 salas
        Log.cursorTop();
        Log.log(programInstance.Jogador.ToString(), cor: Cor.INFO, delay: 0.00, limpar_terminal: true);
        mapa.gerarMapa(); // Gera o mapa com as salas e conexões
        mapa.exibirMapa(); // Exibe o mapa no terminal

    }
}

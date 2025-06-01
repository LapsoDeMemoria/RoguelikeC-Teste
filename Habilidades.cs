namespace Game
{
    public class Habilidades
{
    protected string Nome { get; set; } // Nome da habilidade
    protected string Descricao { get; set; } // Descrição da habilidade
    protected int custoVelocidade { get; set; } // Custo de velocidade para usar a habilidade

    public string getNome()
    {
        return this.Nome; // Retorna o nome da habilidade
    }
    public int getCustoVelocidade()
    {
        return this.custoVelocidade; // Retorna o custo de velocidade
    }

    public Habilidades(string nome, string descricao, int custoVelocidade)
    {
        this.Nome = nome; // Inicializa o nome da habilidade
        this.Descricao = descricao; // Inicializa a descrição da habilidade
        this.custoVelocidade = custoVelocidade; // Inicializa o custo de velocidade
    }
    public override string ToString()
    {
        return $"{this.Nome}: {this.Descricao} (Custo: {this.custoVelocidade} de Velocidade)"; // Retorna uma representação da habilidade
    }

}

public class Soco: Habilidades
{
    public int dano;

    public void usarHabilidade(Entidades alvo, Entidades usuario)
    {
        if (usuario.Velocidade.getValorAtual() >= custoVelocidade)
        {

            int novaVidaAlvo = alvo.Vida.getValorAtual() - dano; // Calcula a nova vida do alvo após o ataque
            alvo.Vida.setValorAtual(novaVidaAlvo);
        } // Atualiza a vida do alvo
    }
    public Soco(string nome="Soco", string descricao="Ataque corpo-a-corpo com as mãos") : base(nome, descricao, custoVelocidade:2)
    {
        this.custoVelocidade = 1; // Inicializa o custo de velocidade
        this.dano = 10; // Define o dano da habilidade Soco
        // Inicializa a habilidade Soco com nome, descrição e custo de velocidade
    }

}


}
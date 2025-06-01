namespace Game
{
    public class Status
{
    protected int valorAtual { get; set; } // Valor atual do status
    protected int valorMaximo { get; set; } // Valor máximo do status
    protected double modificador { get; set; } // Modificador do status, se aplicável

    public Status(int valor)
        {
            this.valorMaximo = valor; // Inicializa o valor máximo
            this.valorAtual = valor; // Inicializa o valor atual
        }

    public int getValorAtual()
    {
        return this.valorAtual; // Retorna o valor atual
    }

    public void setValorAtual(int valor)
    {
        // Define o valor atual, garantindo que esteja entre 0 e o valor máximo
        if (valor < 0)
        {
            this.valorAtual = 0;
        }
        else if (valor > this.valorMaximo)
        {
            this.valorAtual = this.valorMaximo;
        }
        else
        {
            this.valorAtual = valor;
        }
    }

    public int getValorMaximo()
    {
        return this.valorMaximo; // Retorna o valor máximo
    }

    public void setValorMaximo(int valor)
    {
        this.valorMaximo = valor; // Define o valor máximo
    }
}

// Classe para representar o status de ataque
public class Ataque : Status
{


    public Ataque(int valor) : base(valor)
    {
        this.modificador = 1.0; // Inicializa o modificador
    }

    public double getModificador()
    {
        return this.modificador; // Retorna o modificador
    }

    public void setModificador(double modificador)
    {
        // Define o modificador, garantindo que seja maior ou igual a 0
        if (modificador < 0)
        {
            this.modificador = 0;
        }
        else
        {
            this.modificador = modificador;
        }
    }
}

public class Velocidade : Status
{
 

    public Velocidade(int valor) : base(valor)
    {
        this.modificador = 1.0; // Inicializa o modificador
    }

    public double getModificador()
    {
        return this.modificador; // Retorna o modificador
    }

    public void setModificador(double modificador)
    {
        // Define o modificador, garantindo que seja maior ou igual a 0
        if (modificador < 0)
        {
            this.modificador = 0;
        }
        else
        {
            this.modificador = modificador;
        }
    }
}

// Classe para representar o status de defesa
public class Defesa : Status
{


    public Defesa(int valor) : base(valor)
    {
        this.modificador = 1.0; // Inicializa o modificador
    }

    public double getModificador()
    {
        return this.modificador; // Retorna o modificador
    }

    public void setModificador(double modificador)
    {
        // Define o modificador, garantindo que seja maior ou igual a 0
        if (modificador < 0)
        {
            this.modificador = 0;
        }
        else
        {
            this.modificador = modificador;
        }
    }
}

// Classe para representar o status de mente
public class Mente : Status
{


    public Mente(int valor) : base(valor)
    {
        this.modificador = 1.0; // Inicializa o modificador
    }

    public double getModificador()
    {
        return this.modificador; // Retorna o modificador
    }

    public void setModificador(double modificador)
    {
        // Define o modificador, garantindo que seja maior ou igual a 0
        if (modificador < 0)
        {
            this.modificador = 0;
        }
        else
        {
            this.modificador = modificador;
        }
    }

    // Métodos específicos para Mente podem ser adicionados aqui
}

// Classe para representar o status de vida
public class Vida : Status
{
    private int danoVeneno { get; set; } // Dano causado por veneno
    private int duracaoVeneno { get; set; } // Duração do veneno
    private int regeneracao { get; set; } // Valor de regeneração

    public int getDanoVeneno()
    {
        return this.danoVeneno; // Retorna o dano causado por veneno
    }

    public void setDanoVeneno(int dano)
    {
        // Define o dano causado por veneno, garantindo que seja maior ou igual a 0
        if (dano < 0)
        {
            this.danoVeneno = 0;
        }
        else
        {
            this.danoVeneno = dano;
        }
    }

    public int getDuracaoVeneno()
    {
        return this.duracaoVeneno; // Retorna a duração do veneno
    }

    public void setDuracaoVeneno(int duracao)
    {
        // Define a duração do veneno, garantindo que seja maior ou igual a 0
        if (duracao < 0)
        {
            this.duracaoVeneno = 0;
        }
        else
        {
            this.duracaoVeneno = duracao;
        }
    }

    public int getRegeneracao()
    {
        return this.regeneracao; // Retorna o valor de regeneração
    }

    public void setRegeneracao(int valor)
    {
        // Define o valor de regeneração, garantindo que seja maior ou igual a 0
        if (valor < 0)
        {
            this.regeneracao = 0;
        }
        else
        {
            this.regeneracao = valor;
        }
    }

    public Vida(int valor) : base(valor)
    {
        this.danoVeneno = 0; // Inicializa o dano causado por veneno
        this.duracaoVeneno = 0; // Inicializa a duração do veneno
        this.regeneracao = 0; // Inicializa o valor de regeneração
    }

    public void aplicarEfeitoVeneno(int dano, int duracao)
    {
        // Aplica o efeito de veneno, reduzindo o valor atual e diminuindo a duração
        if (this.danoVeneno > 0 && this.duracaoVeneno > 0)
        {
            this.setValorAtual(this.getValorAtual() - this.danoVeneno);
            this.duracaoVeneno--;
        }
    }

    public void aplicarRegeneracao(int valor)
    {
        // Aplica regeneração, aumentando o valor atual até o máximo permitido
        if (this.regeneracao > 0)
        {
            int novo_valor = this.getValorAtual() + valor;
            this.setValorAtual(novo_valor);
            if (this.getValorAtual() > this.getValorMaximo())
            {
                this.setValorAtual(this.getValorMaximo());
            }
        }
    }
}


}
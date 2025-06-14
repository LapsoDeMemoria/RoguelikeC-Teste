using System;
using System.Runtime.InteropServices;

namespace Recursos
{
    public class Tick()
    {
        public static void tick(double delay = 0.01)
        {
            System.Threading.Thread.Sleep((int)(delay * 1000)); // Pausa a execução por um tempo especificado em segundos
        }
    }
    public class Cor
    {
        public const string RESET = "\x1b[0m";
        public const string INFO = "\x1b[94m";
        public const string ALERTA = "\x1b[93m";
        public const string ERRO = "\x1b[91m";
        public const string PADRAO = "\x1b[0m";
        public const string SUCESSO = "\x1b[92m";
        public const string DEBUG = "\x1b[95m";
        public const string NEGRITO = "\x1b[1m";
        public const string SUBLINHADO = "\x1b[4m";
        public const string PRETO = "\x1b[30m";
        public const string VERMELHO = "\x1b[31m";
        public const string VERDE = "\x1b[32m";
        public const string AMARELO = "\x1b[33m";
        public const string AZUL = "\x1b[34m";
        public const string MAGENTA = "\x1b[35m";
        public const string CIANO = "\x1b[36m";
        public const string BRANCO = "\x1b[37m";
    }

    public class CorFundo
    {
        public const string RESET = "\x1b[0m";
        public const string PRETO = "\x1b[40m";
        public const string VERMELHO = "\x1b[41m";
        public const string VERDE = "\x1b[42m";
        public const string AMARELO = "\x1b[43m";
        public const string AZUL = "\x1b[44m";
        public const string MAGENTA = "\x1b[45m";
        public const string CIANO = "\x1b[46m";
        public const string BRANCO = "\x1b[47m";
        public const string CINZA_CLARO = "\x1b[47;1m";
        public const string CINZA_ESCURO = "\x1b[40;1m";
        public const string VERMELHO_CLARO = "\x1b[41;1m";
        public const string VERDE_CLARO = "\x1b[42;1m";
        public const string AMARELO_CLARO = "\x1b[43;1m";
        public const string AZUL_CLARO = "\x1b[44;1m";
        public const string MAGENTA_CLARO = "\x1b[45;1m";
        public const string CIANO_CLARO = "\x1b[46;1m";

        // Tons mais escuros
        public const string VERMELHO_ESCURO = "\x1b[41;2m";
        public const string VERDE_ESCURO = "\x1b[42;2m";
        public const string AMARELO_ESCURO = "\x1b[43;2m";
        public const string AZUL_ESCURO = "\x1b[44;2m";
        public const string MAGENTA_ESCURO = "\x1b[45;2m";
        public const string CIANO_ESCURO = "\x1b[46;2m";
        public const string CINZA_MUITO_ESCURO = "\x1b[40;2m";
    }

    public class Log
    {
        private static List<string> logBox = new List<string>();

        const int STD_OUTPUT_HANDLE = -11;
        const uint ENABLE_VIRTUAL_TERMINAL_PROCESSING = 0x0004;

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetStdHandle(int nStdHandle);

        [DllImport("kernel32.dll")]
        static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);

        [DllImport("kernel32.dll")]
        static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);

        static bool HabilitarCoresANSI()
        {
            IntPtr handle = GetStdHandle(STD_OUTPUT_HANDLE);
            if (!GetConsoleMode(handle, out uint mode))
                return false;

            mode |= ENABLE_VIRTUAL_TERMINAL_PROCESSING;
            return SetConsoleMode(handle, mode);
        }
        public static void cursorTop(int linha = 0, int coluna = 0)
        {
            Console.SetCursorPosition(coluna, linha); // Move o cursor para a posição especificada
        }
        public static void mudarPosicaoCursor(int linha, int coluna)
        {
            Console.SetCursorPosition(coluna, linha); // Muda a posição do cursor para a linha e coluna especificadas
        }

        public static void logBoxLog(string msg, string cor, double delay = 0.01, bool nova_linha = true, bool limpar_terminal = false)
        {
            logBox.Add(msg); // Adiciona a mensagem ao logBox
            if (logBox.Count > 10)
            {
                logBox.RemoveAt(0); // Remove o primeiro item se a lista tiver mais de 10 itens
            }
            if (HabilitarCoresANSI())
            {
                if (limpar_terminal)
                {
                    Console.Clear();
                }
                foreach (string log in logBox)
                {
                    foreach (char c in log)
                    {
                        Console.Write($"{cor}{c}{Cor.RESET}");
                        System.Threading.Thread.Sleep((int)(delay * 1000));
                    }
                    Console.WriteLine();
                }


                if (nova_linha)
                    Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Seu terminal não suporta ANSI.");
            }
        }
public static void log(string msg, string cor, double delay = 0.01, bool nova_linha = true, bool limpar_terminal = false)
        {
            if (HabilitarCoresANSI())
            {
                if (limpar_terminal)
                {
                    Console.Clear();
                }
                foreach (char c in msg)
                {
                    Console.Write($"{cor}{c}{Cor.RESET}");
                    System.Threading.Thread.Sleep((int)(delay * 1000));
                }
                

                if (nova_linha)
                    Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Seu terminal não suporta ANSI.");
            }
        }

    }
}


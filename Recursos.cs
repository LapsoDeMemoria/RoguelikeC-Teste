using System;
using System.Runtime.InteropServices;

namespace Recursos
{
    public class Cor
    {
        public const string RESET = "\x1b[0m";
        public const string INFO = "\x1b[94m";
        public const string ALERTA = "\x1b[93m";
        public const string ERRO = "\x1b[91m";
        public const string PADRAO = "\x1b[0m";
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

        public static void log(string msg, string cor, double delay = 0.01, bool nova_linha = true, bool limpar_terminal = false)
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

    }
}


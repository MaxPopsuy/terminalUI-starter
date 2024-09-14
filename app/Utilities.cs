using static App.Common;

namespace App
{
    internal static class Utilities
    {
        internal static void AppScreen()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"████████╗███████╗██████╗ ███╗   ███╗██╗███╗   ██╗ █████╗ ██╗             ██╗   ██╗██╗ ");
            Console.WriteLine($"╚══██╔══╝██╔════╝██╔══██╗████╗ ████║██║████╗  ██║██╔══██╗██║             ██║   ██║██║ ");
            Console.WriteLine($"   ██║   █████╗  ██████╔╝██╔████╔██║██║██╔██╗ ██║███████║██║             ██║   ██║██║ ");
            Console.WriteLine($"   ██║   ██╔══╝  ██╔══██╗██║╚██╔╝██║██║██║╚██╗██║██╔══██║██║             ██║   ██║██║ v - {Common.AppVersion}");
            Console.WriteLine($"   ██║   ███████╗██║  ██║██║ ╚═╝ ██║██║██║ ╚████║██║  ██║███████╗███████╗╚██████╔╝██║ ");
            Console.WriteLine($"   ╚═╝   ╚══════╝╚═╝  ╚═╝╚═╝     ╚═╝╚═╝╚═╝  ╚═══╝╚═╝  ╚═╝╚══════╝╚══════╝ ╚═════╝ ╚═╝ ");

            Console.WriteLine("Write 'h' or 'help' for a list of commands. Welcome to App!");

            Console.ResetColor();
        }

        internal static void AppWaitAnimation()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write(">>");
            Thread.Sleep(50);
            Console.Write("\b");
            Console.Write(">>");
            Thread.Sleep(50);
            Console.Write("\b");
            Console.Write(">>");
            Thread.Sleep(50);
            Console.Write("\b");
            Console.Write(": ");
            Console.ResetColor();
        }

        internal static string AppGetCommandFromAlias(string command)
        {
            foreach (var entry in Commands._commandsAliases)
            {
                if (entry.Value.Contains(command))
                {
                    return entry.Key;
                }
            }
            return command;
        }

        internal static void AppWrite(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
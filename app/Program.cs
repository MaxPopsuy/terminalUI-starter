using App;
using static App.Common;

namespace App
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Title = "TUI";
            Utilities.AppScreen();

            while (true)
            {
                Utilities.AppWaitAnimation();

                var input = Console.ReadLine();
                var outputs = input?.Split("&") ?? Array.Empty<string>();

                Console.ForegroundColor = ConsoleColor.DarkMagenta;

                foreach (var raw in outputs)
                {
                    var inputArray = raw?.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries) ?? Array.Empty<string>();

                    if (inputArray.Length > 0)
                    {
                        var command = Utilities.AppGetCommandFromAlias(inputArray[0]);
                        var firstArgument = inputArray.Length > 1 ? inputArray[1] : null;
                        var secondArgument = inputArray.Length > 2 ? inputArray[2] : null;

                        if (Commands._commands.TryGetValue(command, out var commandMethod))
                        {
                            try
                            {
                                commandMethod.Invoke(firstArgument ?? string.Empty, secondArgument ?? string.Empty);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error executing command '{command}': {ex.Message}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"{command} is an unknown command. For help, type 'help'.\n");
                        }
                    }
                }
            }
        }
    }
}
using System.Reflection;
using static App.Functions;


namespace App
{
    internal class Common
    {
        internal static string AppAssemblyVersion = Assembly.GetEntryAssembly()?.GetName().Version?.ToString() ?? "Unknown Version";
        internal static string AppVersion = AppAssemblyVersion.Substring(0, AppAssemblyVersion.Length - 2);
       
        internal class Commands
        {
            public static Dictionary<string, string[]> _commandsDsc = new() // string[] = ["parameters", "description"]
            {
                ["help"] = ["<mode> | <command>", "Displays a list of all available commands with descriptions. Use `<mode>` to specify the format (s for short, d for detailed). If `<command>` is provided, it shows detailed information about the specified command."],
                ["clear"] = ["", "Clears the console screen, removing all previously displayed text."],
            };

            public static Dictionary<string, string[]> _commandsAliases = new()
            {
                ["help"] = ["h", "g"],
                ["clear"] = ["clr", "cls",],
            };


            public static Dictionary<string, Action<string, string>> _commands = new Dictionary<string, Action<string, string>>()
            {
                ["help"] = HelpFunction,
                ["clear"] = ClearFunction,
            };
        }
    }
}
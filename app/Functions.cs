using Spectre.Console;
using static App.Utilities;
using static App.Common;

namespace App
{
    internal static class Functions
    {
        internal static void HelpFunction(string mode, string command)
        {
            Console.ResetColor();
            if (string.IsNullOrWhiteSpace(mode) || mode == "d")
            {
                mode = "detailed";
            }
            if (!string.IsNullOrWhiteSpace(command))
            {
                string fullCommand = Utilities.AppGetCommandFromAlias(command);

                if (Commands._commandsDsc.ContainsKey(fullCommand))
                {
                    var commandInfo = Commands._commandsDsc[fullCommand];
                    var aliases = Commands._commandsAliases.ContainsKey(fullCommand)
                        ? string.Join(", ", Commands._commandsAliases[fullCommand])
                        : "None";

                    Console.ResetColor();
                    Panel result;

                    if (mode == "detailed")
                    {
                        result = new Panel(
                            $"[purple]Command:[/] [white]{fullCommand}[/]\n" +
                            $"[purple]Aliases:[/] [yellow1]{aliases}[/]\n" +
                            $"[purple]Parameters:[/] [green1]{(commandInfo[0].Length == 0 ? "-" : commandInfo[0])}[/]\n" +
                            $"[purple]Description:[/] [white]{commandInfo[1]}[/]"
                        )
                        {
                            Border = BoxBorder.Double
                        };
                        result.Header($"[purple]Help: [white]{fullCommand}[/][/]").HeaderAlignment(Justify.Center);
                    }
                    else
                    {
                        result = new Panel(
                            $"[purple]Command:[/] [white]{fullCommand}[/]\n" +
                            $"[purple]Aliases:[/] [yellow1]{aliases}[/]\n" +
                            $"[purple]Parameters:[/] [green1]{(commandInfo[0].Length == 0 ? "-" : commandInfo[0])}[/]"
                        )
                        {
                            Border = BoxBorder.Double
                        };
                        result.Header($"[purple]Help: [white]{fullCommand}[/][/]").HeaderAlignment(Justify.Center);
                    }

                    AnsiConsole.Write(result);
                }
                else
                {
                    AnsiConsole.Markup($"[red]No such command '{command}' found.[/]");
                }
            }
            else
            {
                Table helpTable = new Table().Centered().Expand();
                helpTable.Border = TableBorder.Double;

                helpTable.AddColumn(new TableColumn("COMMAND").Centered()).Alignment(Justify.Center);
                helpTable.AddColumn(new TableColumn("PARAMS").Centered());
                helpTable.AddColumn(new TableColumn("ALIASES").Centered());
                helpTable.Alignment(Justify.Center);

                if (mode == "detailed")
                {
                    helpTable.AddColumn(new TableColumn("DESCRIPTION").Centered());
                    helpTable.Alignment(Justify.Center);
                }

                helpTable.Columns[0].Padding(2, 10);
                helpTable.Columns[1].Padding(2, 10);
                helpTable.Columns[2].Padding(2, 10);

                if (mode == "detailed")
                {
                    helpTable.Columns[3].Padding(2, 10);
                }
                else
                {
                    helpTable.Collapse().Alignment(Justify.Left);
                }

                foreach (var (key, value) in Commands._commandsDsc)
                {
                    var aliases = Commands._commandsAliases.ContainsKey(key)
                        ? string.Join(", ", Commands._commandsAliases[key])
                        : "None";

                    if (mode == "detailed")
                    {
                        helpTable.AddRow(
                            $"[white]{key}[/]",
                            $"[green1]{(value[0].Length == 0 ? "-" : value[0])}[/]",
                            $"[yellow1]{aliases}[/]",
                            $"[white]{value[1]}[/]"
                        );
                    }
                    else
                    {
                        helpTable.AddRow(
                            $"[white]{key}[/]",
                            $"[green1]{(value[0].Length == 0 ? "-" : value[0])}[/]",
                            $"[yellow1]{aliases}[/]"
                        );
                    }
                }

                AnsiConsole.Write(helpTable);
            }

            Console.WriteLine();
        }


        internal static void ClearFunction(string _, string __)
        {
            Console.Write("\f\u001bc\x1b[3J");
            AppScreen();
        }
    }
}
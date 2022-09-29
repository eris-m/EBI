/*
 * This file is part of EBI.
 *
 * EBI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, 
 * either version 3 of the License, or (at your option) any later version.
 *
 * EBI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; 
 * without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License along with EBI. If not, see <https://www.gnu.org/licenses/>.
 */ 

namespace ebi;

public enum CommandType
{
    Add, Sub,
    Left, Right,
    LoopStart, LoopEnd,
    Print, Read,
}

public sealed class Command
{
    public readonly CommandType? Type;
    public readonly int Times;

    private Command(CommandType? type, int times)
    {
        Type = type;
        Times = times;
    }

    public static CommandType? CommandTypeOfChar(char c)
    {
        return c switch
        {
            '+' => CommandType.Add,
            '-' => CommandType.Sub,
            '<' => CommandType.Left,
            '>' => CommandType.Right,
            '[' => CommandType.LoopStart,
            ']' => CommandType.LoopEnd,
            '.' => CommandType.Print,
            ',' => CommandType.Read,
            _ => null
        };
    }
    
    private static Command FirstInString(ReadOnlySpan<char> s)
    {
        var baseType = CommandTypeOfChar(s[0]);
        var times = 0;

        foreach (var c in s)
        {
            if (CommandTypeOfChar(c) == baseType)
            {
                times++;
            }
            else
            {
                break;
            }
        }
        
        return new Command(baseType, times);
    }

    public static Command[] CommandsInString(string s)
    {
        ReadOnlySpan<char> code = s;
        var commands = new List<Command>();

        for (var i = 0; i < s.Length;)
        {
            var command = FirstInString(code[i..]);
            commands.Add(command);
            i += command.Times;
        }

        return commands.ToArray();
    }
}
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

using ebi.tape;

namespace ebi;

public sealed class Machine<T> 
where T: Tape, new()
{
    private readonly Command[] _code;
    private T _tape;
    private List<uint> _loops = new List<uint>();
    private uint _index = 0;

    public Machine(Command[] code)
    {
        _code = code;
        _tape = new T();
    }

    public Machine(T tape, Command[] code)
    {
        _code = code;
        this._tape = tape;
    }

    public void ExecuteCommand(Command c)
    {
        switch(c.Type)
        {
            case CommandType.Add:
                _tape.ChangeCell(c.Times);
                break;
            case CommandType.Sub:
                _tape.ChangeCell(-c.Times);
                break;
            case CommandType.Left:
                _tape.ChangeIndex(-c.Times);
                break;
            case CommandType.Right:
                _tape.ChangeIndex(c.Times);
                break;
            case CommandType.LoopStart:
                //TODO: add this
                break;
            case CommandType.LoopEnd:
                //TODO: add this as well
                break;
            case CommandType.Print:
                Console.WriteLine((char) _tape.GetCell());
                break;
            case CommandType.Read: 
                _tape.SetCell(Console.Read());
                break;
            default: break; 
        }
    }

    public void Execute()
    {
        while (_index < _code.Length)
        {
            ExecuteCommand(_code[_index]);
            _index++;
        }
    }
}
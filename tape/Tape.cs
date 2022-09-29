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
namespace ebi.tape;

public abstract class Tape
{
    protected const int DefaultSize = 16; 
    protected List<int> Cells;
    protected int Index;

    protected Tape(int size = DefaultSize)
    {
        Cells = new List<int>(size);
        Cells.AddRange(new int[size]);
    }
    
    public int GetCell()
    {
        return Cells[Index];
    }

    public void SetCell(int to)
    {
        Cells[Index] = to;
    }
    
    public void ChangeCell(int amount)
    {
        Cells[Index] += amount;
    }

    protected abstract void IndexOverflow(int amount);
    protected abstract void IndexUnderflow(int amount);
    
    public void ChangeIndex(int amount)
    {
        if (Index + amount > Cells.Count)
        {
            IndexOverflow(Index + amount - Cells.Count);
        } else if (Index + amount < 0)
        {
            IndexUnderflow(Index - amount);
        }

        Index += amount;
    }
}
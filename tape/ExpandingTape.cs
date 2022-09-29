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

public sealed class ExpandingTape : Tape
{
    public ExpandingTape() : base() {}
    public ExpandingTape(int size = DefaultSize) : base(size) {}
    
    protected override void IndexOverflow(int amount)
    {
        var newCells = new int[amount];
        Cells.AddRange(newCells);
    }

    protected override void IndexUnderflow(int amount)
    {
        Index = Cells.Count;
    }
}
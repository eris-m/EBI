﻿/*
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

using System;
using System.Collections;
using System.IO;
using ebi;
using ebi.tape;

// test code, print 'L'
var codeString = "++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++.";
var code = Command.CommandsInString(codeString);

var machine = new Machine<WrappingTape>(code);
machine.Execute();
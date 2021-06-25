/**
 * Copyright (C) 2021 Emilian Roman
 * 
 * This file is part of Elevator.
 * 
 * Elevator is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 2 of the License, or
 * (at your option) any later version.
 * 
 * Elevator is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with Elevator.  If not, see <http://www.gnu.org/licenses/>.
 */

using Mono.Options;
using static System.Console;
using static System.Diagnostics.Process;

namespace Elevator
{
	public static class Program
	{
		public static readonly OptionSet OptionSet = new OptionSet
		{
			{
				"e|executable=", "executable to invoke with elevated privileges",
				s => Executable = s
			}
		};

		private static string Executable { get; set; } = string.Empty;

		public static void Main(string[] args)
		{
			OptionSet.WriteOptionDescriptions(Out);
			OptionSet.Parse(args);

			Start(Executable);
		}
	}
}
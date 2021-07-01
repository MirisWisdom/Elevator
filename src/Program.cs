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

using System.Diagnostics;
using Mono.Options;
using static System.Console;
using static System.Diagnostics.Process;
using static System.Environment;

namespace Elevator
{
	/**
	 * Elevator Program.
	 */
	public static class Program
	{
		public static readonly OptionSet OptionSet = new OptionSet
		{
			{
				"e|executable=", "executable to invoke with elevated privileges",
				s => Executable = s
			}
		};

		/**
		 * Executable to invoke with elevated privileges.
		 */
		private static string Executable { get; set; } = string.Empty;

		/**
		 * Elevator Main entry.
		 */
		public static void Main(string[] args)
		{
			OptionSet.WriteOptionDescriptions(Out);

			var remaining = OptionSet.Parse(args);
			var arguments  = string.Join(" ", remaining.ToArray());

			WriteLine($"Invoking '{Executable}' with arguments:\n{arguments}");

			var invokable = Start(new ProcessStartInfo
			{
				FileName               = Executable,
				Arguments              = arguments,
				RedirectStandardOutput = true,
				RedirectStandardError  = true
			});

			WriteLine(invokable?.StandardOutput.ReadToEnd());
			Error.WriteLine(invokable?.StandardError.ReadToEnd());

			invokable?.WaitForExit();

			if (invokable != null)
				Exit(invokable.ExitCode);
		}
	}
}
//
//  NameGenerator.cs
//
//  Author:
//       Willem Van Onsem <vanonsem.willem@gmail.com>
//
//  Copyright (c) 2014 Willem Van Onsem
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using System.Text;

namespace MagicEngine.Information {
	public static class NameGenerator {
		private static readonly int FirstNameSyllablesMin = 1;
		private static readonly int FirstNameSyllablesMax = 5;
		private static readonly int LastNameSyllablesMin = 2;
		private static readonly int LastNameSyllablesMax = 8;
		private static readonly int TotalNameSyllablesMax = 10;
		private static readonly double ChanceForExtraSyllable = 0.5d;
		private static readonly string[] Syllables = {
			"ar", "el", "thor", "hjal", "hu", "thur", "sac", "nor", "cam", "al", "wulf", "lot", "ba", "mar",
			"du", "ge", "wo", "si", "da", "es", "vi", "ko", "lu", "bur", "fur", "gan", "gnus", "gus", "gnar",
			"li", "lin", "lir", "mli", "nar", "nus", "rin", "ran", "sin", "sil", "sur"
		};
		private static readonly string[] OtherSyllables = { "a", "e", "i", "o", "u", "y" };
		private static readonly int MaxOtherSyllablesAtOnce = 2;
		private static readonly string[] LastNameLastSyllable = {"kor", "dor", "dan", "ran", "kar", "dwarf",
			"gar", "lot", "gon", "kan", "elf", "krad", "sac", "man", "thar", "thor", "gron", "sson", "wyr",
			"sdale", "born"
		};
		private static readonly string[] ExtraSyllables = { "de ", "de la ", "of ", "le ", "d'", "ir", "ar" };

		public static string GenerateFirstName (int nbSyllablesFirst) {
			StringBuilder sb = new StringBuilder ();
			sb.Append (ProbabilityUtils.RandomElement<string> (Syllables));
			int extrasUsed = 0x00;
			for (int i = 0x02; i < nbSyllablesFirst; i++) {
				if (extrasUsed == MaxOtherSyllablesAtOnce || ProbabilityUtils.Chance (Syllables.Length / (ExtraSyllables.Length + Syllables.Length))) {
					sb.Append (ProbabilityUtils.RandomElement<string> (Syllables));
					extrasUsed = 0x00;
				} else {
					sb.Append (ProbabilityUtils.RandomElement<string> (OtherSyllables));
					extrasUsed++;
				}
			}
			sb.Append (ProbabilityUtils.RandomElement<string> (Syllables));
			return sb.ToString ();
		}

		public static string GenerateLastName (int nbSyllablesLast) {
			StringBuilder sb = new StringBuilder ();
			String[] localSyllables = new String[nbSyllablesLast];
			sb.Append (ProbabilityUtils.RandomElement<string> (Syllables));
			int extrasUsed = 0x00;
			for (int i = 0x02; i < nbSyllablesLast; i++) {
				if (extrasUsed == MaxOtherSyllablesAtOnce || ProbabilityUtils.Chance (Syllables.Length / (ExtraSyllables.Length + Syllables.Length))) {
					sb.Append (ProbabilityUtils.RandomElement<string> (Syllables));
					extrasUsed = 0x00;
				} else {
					sb.Append (ProbabilityUtils.RandomElement<string> (OtherSyllables));
					extrasUsed++;
				}
			}
			sb.Append (ProbabilityUtils.RandomElement<string> (LastNameLastSyllable));
			return sb.ToString ();
		}

		public static string GenerateExtraName () {
			if (ProbabilityUtils.Chance (ChanceForExtraSyllable)) {
				return ProbabilityUtils.RandomElement<string> (ExtraSyllables);
			} else {
				return string.Empty;
			}
		}

		public static string GenerateName () {
			StringBuilder sb = new StringBuilder ();
			int nbSyllablesFirst = ProbabilityUtils.Next (LastNameSyllablesMin, LastNameSyllablesMax);
			int nbSyllablesLast = ProbabilityUtils.Next (FirstNameSyllablesMin, Math.Min (FirstNameSyllablesMax, TotalNameSyllablesMax));
			sb.Append (GenerateFirstName (nbSyllablesFirst));
			sb.Append (' ');
			sb.Append (GenerateExtraName ());
			sb.Append (GenerateLastName (nbSyllablesLast));
			return sb.ToString ();
		}
	}
}


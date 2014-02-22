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

namespace MagicEngine.Information {
	public static class NameGenerator {
		private static readonly int FIRST_NAME_SYLLABLES_MIN = 1;
		private static readonly int FIRST_NAME_SYLLABLES_MAX = 5;
		private static readonly int LAST_NAME_SYLLABLES_MIN = 2;
		private static readonly int LAST_NAME_SYLLABLES_MAX = 8;
		private static readonly int TOTAL_NAME_SYLLABLES_MAX = 10;
		private static readonly double CHANCE_FOR_EXTRA_SYLLABLE = 0.5;
		private static readonly string[] SYLLABLES = {
			"ar", "el", "thor", "hjal", "hu", "thur", "sac", "nor", "cam", "al", "wulf", "lot", "ba", "mar",
			"du", "ge", "wo", "si", "da", "es", "vi", "ko", "lu", "bur", "fur", "gan", "gnus", "gus", "gnar",
			"li", "lin", "lir", "mli", "nar", "nus", "rin", "ran", "sin", "sil", "sur"
		};
		private static readonly string[] OTHER_SYLLABLES = { "a", "e", "i", "o", "u", "y" };
		private static readonly int MAX_OTHER_SYLLABLES_AT_ONCE = 2;
		private static readonly string[] LAST_NAME_LAST_SYLLABLE = {"kor", "dor", "dan", "ran", "kar", "dwarf",
			"gar", "lot", "gon", "kan", "elf", "krad", "sac", "man", "thar", "thor", "gron", "sson", "wyr",
			"sdale", "born"
		};
		private static readonly string[] EXTRA_SYLLABLE = { "de ", "de la ", "of ", "le ", "d'", "ir", "ar" };

		private string GenerateFirstName (int nbSyllablesFirst) {
			string ret = "";
			string[] localSyllables = new String[nbSyllablesFirst];
			localSyllables [0] = Leader.SYLLABLES [Chance.randomInt (0, SYLLABLES.length - 1)];
			int extrasUsed = 0;
			for (int i = 1; i < localSyllables.length - 1; i++) {
				if (extrasUsed == Leader.MAX_OTHER_SYLLABLES_AT_ONCE || Chance.succeeds (Leader.SYLLABLES.length / (Leader.EXTRA_SYLLABLE.length + Leader.SYLLABLES.length))) {
					localSyllables [i] = Leader.getRandomElement (SYLLABLES);
					extrasUsed = 0;
				} else {
					localSyllables [i] = Leader.getRandomElement (OTHER_SYLLABLES);
					extrasUsed++;
				}
			}
			localSyllables [localSyllables.length - 1] = Leader.SYLLABLES [Chance.randomInt (0, Leader.SYLLABLES.length - 1)];
			foreach (string syllable in localSyllables) {
				ret += syllable;
			}
			return ret;
		}
	}
}


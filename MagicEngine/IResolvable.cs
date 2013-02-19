using System;
using System.Collections.Generic;

namespace MagicEngine {

	public interface IResolvable<TKey,TValue> {

		void Resolve (Dictionary<TKey,TValue> dictionary);

	}
}


using System;
using System.Collections.Generic;

namespace MagicEngine.Information {

	public interface IResolvable<TKey,TValue> {

		void Resolve (Dictionary<TKey,TValue> dictionary);

	}
}


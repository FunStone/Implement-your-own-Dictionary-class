using System;
using System.Collections.Generic;

namespace 实现MyDictionary;

interface IMyDictionary<Key, Value>
{
	int Count { get; }

	int Capacity { get; }

	Key[] Keys { get; }

	Value[] Values { get; }

	Value this[Key key] { get; set; }

	void Add(Key key, Value value);

	void Clear();

	bool ContainsKey(Key key);

	bool ContainsValue(Value value);
	
	void EnsureCapacity(int capacity);

	bool Remove(Key key);

	void TrimExcess();

	bool TryGetValue(Key key, out Value value);

	bool TryAdd(Key key, Value value);
}

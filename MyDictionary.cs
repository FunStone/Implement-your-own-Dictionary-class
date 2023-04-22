#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;

namespace 实现MyDictionary;

public sealed class MyDictionary<Key, Value> : IMyDictionary<Key, Value>
{
	(Key, Value)[] data;
	int count = 0;
	int capacity;
	Key[] keys;
	Value[] values;

	public int Count
	{
		get { return count; }
	}
	public int Capacity
	{
		get { return capacity; }
	}

	public Key[] Keys
	{
		get
		{
			keys = new Key[count];
			for (int i = 0; i < keys.Length; i++)
			{
				keys[i] = data[i].Item1;
			}
			return keys;
		}
	}

	public Value[] Values
	{
		get
		{
			values = new Value[count];
			for (int i = 0; i < values.Length; i++)
			{
				values[i] = data[i].Item2;
			}
			return values;
		}
	}

	public Value this[Key key]
	{
		get
		{
			for (int i = 0; i < count; i++)
			{
				if ((dynamic)key == data[i].Item1)
				{
					return data[i].Item2;
				}
			}
			throw new KeyNotFoundException($"The given key \"{key}\" does not exist");
		}
		set
		{
			for (int i = 0; i < data.Length; i++)
			{
				if ((dynamic)key == data[i].Item1)
				{
					data[i].Item2 = value;
					return;
				}
			}
			Add(key, value);
		}
	}

	public MyDictionary(int? capacity)
	{
		this.capacity = capacity ?? 4;
		data = new (Key, Value)[this.capacity];
	}

	public MyDictionary() : this(4) { }

	public void Add(Key key, Value value)
	{
		for (int i = 0; i < count; i++)
		{
			if ((dynamic)key == data[i].Item1)
			{
				throw new ArgumentException($"The same key has been added, project is: \"{key}\"");
			}
		}
		if (count >= data.Length)
		{
			var tempArray = data.ToArray();
			data = new (Key, Value)[(capacity *= 4)];
			for (int i = 0; i < tempArray.Length; i++)
			{
				data[i] = tempArray[i];
			}
		}
		data[count] = new(key, value);
		count++;
	}

	public void Clear()
	{
		data = new (Key, Value)[(count = 0)];
	}

	public bool ContainsKey(Key key)
	{
		for (int i = 0; i < count; i++)
		{
			if ((dynamic)key == data[i].Item1)
			{
				return true;
			}
		}
		return false;
	}

	public bool ContainsValue(Value value)
	{
		for (int i = 0; i < count; i++)
		{
			if ((dynamic)value == data[i].Item2)
			{
				return true;
			}
		}
		return false;
	}
	
	public void EnsureCapacity(int capacity)
	{
		if(this.capacity < capacity)
		{
			this.capacity = capacity;
		}
	}

	public bool Remove(Key key)
	{
		int remove_Index = -1;
		for (int i = 0; i < count; i++)
		{
			if ((dynamic)data[i].Item1 == key)
			{
				remove_Index = i;
				break;
			}
		}
		if (remove_Index == -1)
		{
			return false;
		}
		if (remove_Index == count - 1)
		{
			var tempArray = new (Key, Value)[(count--)];
			for (int i = 0; i < tempArray.Length; i++)
			{
				tempArray[i].Item1 = data[i].Item1;
				tempArray[i].Item2 = data[i].Item2;
			}
			data = new (Key, Value)[data.Length];
			for (int i = 0; i < tempArray.Length; i++)
			{
				data[i].Item1 = tempArray[i].Item1;
				data[i].Item2 = tempArray[i].Item2;
			}
			return true;
		}
		for (int i = remove_Index; i < count - 1; i++)
		{
			data[i] = data[i + 1];
		}
		count--;
		return true;
	}

	public void TrimExcess()
	{
		var tempArray = new (Key, Value)[count];
		for (int i = 0; i < count; i++)
		{
			tempArray[i].Item1 = data[i].Item1;
			tempArray[i].Item2 = data[i].Item2;
		}
		data = new (Key, Value)[(capacity = count)];
		data = tempArray.ToArray();
	}

	public bool TryGetValue(Key key, out Value value)
	{
		for (int i = 0; i < count; i++)
		{
			if ((dynamic)key == data[i].Item1)
			{
				value = data[i].Item2;
				return true;
			}
		}
		value = default(Value);
		return false;
	}
	
	public bool TryAdd(Key key,Value value)
	{
		for (int i = 0; i < count; i++)
		{
			if ((dynamic)key == data[i].Item1)
			{
				return false;
			}
		}
		if (count >= data.Length)
		{
			var tempArray = data.ToArray();
			data = new (Key, Value)[(capacity *= 4)];
			for (int i = 0; i < tempArray.Length; i++)
			{
				data[i] = tempArray[i];
			}
		}
		data[count] = new(key, value);
		count++;
		return true;
	}
}

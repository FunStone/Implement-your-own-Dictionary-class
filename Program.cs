#nullable enable

using System;
using System.Linq;
using System.Collections.Generic;

namespace 实现MyDictionary;

public static class Program
{
	public static void Main()
	{
		//创建MyDictionary
		IMyDictionary<string,int> myDic = new MyDictionary<string,int>();
		Dictionary<string,int> dic = new Dictionary<string, int>();
		//已测试完所以函数和属性,没有任何问题,基本功能都一样,就是代码有点憨憨
		
		//添加数据
		myDic.Add("Key1",1);
		myDic.Add("Key2",2);
		//myDic.Add("Key1",1); 用Add方法添加相同的Key会抛出异常ArgumentException
		//尝试添加数据,如果成功则返回true,否则返回false;
		Console.WriteLine($"添加数据的结果为: {myDic.TryAdd("Key3",3)}");
		//添加了相同键的数据,添加失败
		Console.WriteLine($"添加数据的结果为: {myDic.TryAdd("Key3",4)}");
		Console.WriteLine("Key:");
		foreach(var item in myDic.Keys)
		{
			Console.Write("\t" +item + " ");
		}
		Console.WriteLine("\nValue:");
		foreach(var item in myDic.Values)
		{
			Console.Write("\t" +item + " ");
		}
		//删除Key/Value
		myDic.Remove("Key1");
		Console.WriteLine("\n删除Key1之后:");
		Console.WriteLine("Key:");
		foreach(var item in myDic.Keys)
		{
			Console.Write("\t" +item + " ");
		}
		Console.WriteLine("\nValue:");
		foreach(var item in myDic.Values)
		{
			Console.Write("\t" +item + " ");
		}
		myDic.Remove("Key3");
		Console.WriteLine("\n删除Key3之后:");
		Console.WriteLine("Key:");
		foreach(var item in myDic.Keys)
		{
			Console.Write("\t" +item + " ");
		}
		Console.WriteLine("\nValue:");
		foreach(var item in myDic.Values)
		{
			Console.Write("\t" +item + " ");
		}
		//清空所以键/值对
		myDic.Clear();
		Console.WriteLine("\nClear()之后:");
		Console.WriteLine("Key:");
		foreach(var item in myDic.Keys)
		{
			Console.Write("\t" +item + " ");
		}
		Console.WriteLine("\nValue:");
		foreach(var item in myDic.Values)
		{
			Console.Write("\t" +item + " ");
		}
		
		//剩下的就不一一测试了,都是没有问题的
		//本人比较菜,代码也写的很简单,请大佬轻喷!!!
	}
}  
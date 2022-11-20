namespace LaboratoryWork5
{
    internal class Node<T> : IComparable, IComparable<T>
		where T : IComparable, IComparable<T>
	{
		public T? Data { get; set; }

		public Node<T>? Left { get; set; }

		public Node<T>? Right { get; private set; }

		public Node(T data)
		{
			Data = data;
		}

		public Node(T data, Node<T> left, Node<T> right)
		{
			Data = data;
			Left = left;
			Right = right;
		}

		public void Add(T data)
		{
			Node<T> node = new(data);

			if (node!.Data!.CompareTo(Data) == -1)
			{
				if (Left == null)
				{
					Left = node;
				}

				else
				{
					Left.Add(data);
				}
			}

			else
			{
				if (Right == null)
				{
					Right = node;
				}
				else
				{
					Right.Add(data);
				}
			}
		}

		public void Remove(T data)
		{
			Node<T> node = new(data);

			if (node!.Data!.CompareTo(Data) == -1)
			{
				Left?.Remove(data);
			}

			else
			{
				Right?.Remove(data);
			}
		}

		public int CompareTo(object? obj)
		{
			return obj is Node<T> item ? Data!.CompareTo(obj: item) : throw new Exception(message: "Не совпадает тип");
		}

		public int CompareTo(T? other)
		{
			return Data!.CompareTo(other as Node<T>);
		}

		public override string ToString()
		{
			return Data!.ToString()!;
		}
	}
}
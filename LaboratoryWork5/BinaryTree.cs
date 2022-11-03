namespace LaboratoryWork5
{
	public class BinaryTree<T> where T : IComparable<T>
	{
		private BinaryTree<T>? _parent;

		private BinaryTree<T>? _left;

		private BinaryTree<T>? _right;

		private T _val;

		private List<T> _listForPrint = new();

		public BinaryTree(T val, BinaryTree<T>? parent = null)
		{
			_val = val;
			_parent = parent;
		}

		public void Add(T val)
		{
			if (val.CompareTo(_val) < 0)
			{
				if (_left == null)
				{
					_left = new BinaryTree<T>(val, this);
				}

				else if (_left != null)
				{
					_left.Add(val);
				}
			}

			else
			{
				if (_right == null)
				{
					_right = new BinaryTree<T>(val, this);
				}

				else if (_right != null)
				{
					_right.Add(val);
				}
			}
		}

		private BinaryTree<T>? Search(BinaryTree<T> tree, T val)
		{
			if (tree == null)
			{
				return null;
			}

			return val.CompareTo(tree._val) switch
			{
				1 => Search(tree!._right!, val),
				-1 => Search(tree!._left!, val),
				0 => tree,
				_ => null,
			};
		}

		public BinaryTree<T>? Search(T val)
		{
			return Search(this!, val!);
		}

		public bool Remove(T val)
		{
			BinaryTree<T>? tree = Search(val);
			if (tree == null)
			{
				return false;
			}

			BinaryTree<T> curTree;

			if (tree == this)
			{
				if (tree._right != null)
				{
					curTree = tree._right;
				}

				else
				{
					curTree = tree!._left!;
				}

				while (curTree._left != null)
				{
					curTree = curTree._left;
				}

				T temp = curTree._val;
				Remove(temp);
				tree._val = temp;

				return true;
			}

			if (tree._left == null && tree._right == null && tree._parent != null)
			{
				if (tree == tree._parent._left)
				{
					tree._parent._left = null;
				}

				else
				{
					tree._parent._right = null;
				}

				return true;
			}

			if (tree._left != null && tree._right == null)
			{
				tree._left._parent = tree._parent;

				if (tree == tree!._parent!._left)
				{
					tree._parent._left = tree._left;
				}

				else if (tree == tree._parent._right)
				{
					tree._parent._right = tree._left;
				}

				return true;
			}

			if (tree._left == null && tree._right != null)
			{
				tree._right._parent = tree._parent;

				if (tree == tree!._parent!._left)
				{
					tree._parent._left = tree._right;
				}

				else if (tree == tree._parent._right)
				{
					tree._parent._right = tree._right;
				}

				return true;
			}

			if (tree._right != null && tree._left != null)
			{
				curTree = tree._right;

				while (curTree._left != null)
				{
					curTree = curTree._left;
				}

				if (curTree._parent == tree)
				{
					curTree._left = tree._left;
					tree._left._parent = curTree;
					curTree._parent = tree._parent;
					if (tree == tree!._parent!._left)
					{
						tree._parent._left = curTree;
					}

					else if (tree == tree._parent._right)
					{
						tree._parent._right = curTree;
					}

					return true;
				}

				else
				{
					if (curTree._right != null)
					{
						curTree._right._parent = curTree._parent;
					}

					curTree!._parent!._left = curTree._right;
					curTree._right = tree._right;
					curTree._left = tree._left;
					tree._left._parent = curTree;
					tree._right._parent = curTree;
					curTree._parent = tree._parent;

					if (tree == tree!._parent!._left)
					{
						tree._parent._left = curTree;
					}

					else if (tree == tree._parent._right)
					{
						tree._parent._right = curTree;
					}

					return true;
				}
			}
			return false;
		}

		private void Print(BinaryTree<T> node)
		{
			if (node == null)
			{
				return;
			}

			Print(node!._left!);

			_listForPrint.Add(node._val);

			Console.Write($"{node} ");

			if (node._right != null)
			{
				Print(node._right);
			}
		}
		public void Print()
		{
			_listForPrint.Clear();
			Print(this);
			Console.WriteLine();
		}

		public override string ToString()
		{
			return _val!.ToString()!;
		}
	}
}
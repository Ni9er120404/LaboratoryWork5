namespace LaboratoryWork5
{
    internal class Program
	{
		private static void Main()
		{
			BinaryTree<int> tree = new();
			for(int i=0; i<10; i++)
			{
				tree.Add(i);
			}tree.Remove(1);
			foreach (var item in tree.Preorder())
			{
				Console.WriteLine(item);
			}

			
		}
	}
}
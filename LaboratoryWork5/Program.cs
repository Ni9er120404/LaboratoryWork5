namespace LaboratoryWork5
{
	internal class Program
	{
		private static void Main()
		{
			BinaryTree<int> binaryTree = new(5);

			for (int i = 0; i < 20; i++)
			{
				binaryTree.Add(i);
			}


			binaryTree.Print();
			binaryTree.Remove(7);
			binaryTree.Print();

			Console.WriteLine(binaryTree.Search(8));
		}
	}
}
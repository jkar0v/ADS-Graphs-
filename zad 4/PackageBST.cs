using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad_4
{
    internal class PackageBST
    {
        private PackageNode root;

        public void Insert(Package package)
        {
            root = InsertRec(root, package);
        }

        private PackageNode InsertRec(PackageNode node, Package package)
        {
            if (node == null) return new PackageNode(package);

            if (package.Id < node.Data.Id)
                node.Left = InsertRec(node.Left, package);
            else if (package.Id > node.Data.Id)
                node.Right = InsertRec(node.Right, package);

            return node;
        }

        public Package Search(int id)
        {
            return SearchRec(root, id);
        }

        private Package SearchRec(PackageNode node, int id)
        {
            if (node == null) return null;
            if (id == node.Data.Id) return node.Data;
            if (id < node.Data.Id) return SearchRec(node.Left, id);
            return SearchRec(node.Right, id);
        }

        public void InOrderTraversal()
        {
            InOrderRec(root);
        }

        private void InOrderRec(PackageNode node)
        {
            if (node == null) return;
            InOrderRec(node.Left);
            Console.WriteLine(node.Data);
            InOrderRec(node.Right);
        }

        public void FilterByDistance(int minDistance)
        {
            FilterRec(root, minDistance);
        }

        private void FilterRec(PackageNode node, int minDistance)
        {
            if (node == null) return;
            FilterRec(node.Left, minDistance);
            if (node.Data.Distance > minDistance)
                Console.WriteLine(node.Data);
            FilterRec(node.Right, minDistance);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//27/04/2017 coffey.niall.com
//attempt to build a binary search tree from scratch
//build a tree from an array

//RULES:
//There is precisely one root.
//All nodes except the root have precisely one parent.
//There are no cycles.That is, starting at any given node,
//there is not some path that can take you back to the starting node.
//The first two properties—that there exists one root and
//that all nodes save the root have one parent—guarantee that no cycles exist.

//A binary tree is a special kind of tree, one in which all nodes have at most two children.
//    For a given node in a binary tree, the first child is referred to as the left child,
//    while the second child is referred to as the right child
namespace BST
{
    //    The First Step: Creating a Node Class
    
    
    public class Node
    {

        public int data;
        public Node left;
        public Node right;

        public Node(int value)
        {
            this.data = value;
            left = null;
            right = null;
           
        }

       
    }

    public class BinarySearchTree
    {
        public Node root;
        public int count;

        int leftHeight = 1;
        int rightHeight = 1;
        public BinarySearchTree()
        {
            root = null;
        }

        public BinarySearchTree(int value)
        {
            root = new BST.Node(value);
            count++;
           
        }
      
        public int getHeight()
        {
            Node current = root;
            int heightLeft = getHeightLeft(current);
            current = root;
            int heightRight = getHeightRight(current);

            int height = leftHeight > rightHeight ? leftHeight : rightHeight;

            return height;
        }
        public int getHeightLeft(Node current)
        {
            int height = 0;
           
            //check left
            if(current.left != null)
            {
                leftHeight++;
                current = current.left;
                getHeightLeft(current);
            }
           
            return height;
        }

        public int getHeightRight(Node current)
        {
            int height = 0;

            //check left
            if (current.right != null)
            {
                rightHeight++;
                current = current.right;
                getHeightRight(current);
            }

            return height;
        }
        public void AddNode(int value)
        {
            Node myNode = new Node(value);
            count++;
            Node current = root;
            AddRC(myNode, current);
        }
        public void AddRC(Node myNode, Node current)
        {
            //LEFTSIDE
            //check  if value is less than or equal root
            if(myNode.data <= current.data)
            {
                //if root.left is null add it there
                if(current.left == null)
                {

                    current.left = myNode;
                    return;
                }
                //if node on the left is not null
                //
                else
                {
                    //move left and call method again
                    if (current.left != null)
                    {
                        
                        current = current.left;
                        AddRC(myNode, current);
                    }
                    else
                    {
                        throw new Exception("Oops forgot this one!!!");
                    }
                    
                }
            }
            //RIGHTSIDE
            //check  if value is greater than root
            else if (myNode.data > current.data)
            {
                //if root.left is null add it there
                if (current.right == null)
                {

                    current.right = myNode;
                    return;
                }
                //if node on the left is not null
                //
                else
                {
                    //move left and call method again
                    if (current.right != null)
                    {
                        
                        current = current.right;
                        AddRC(myNode, current);
                    }
                    else
                    {
                        throw new Exception("Oops forgot right one!!!");
                    }

                }
            }

        }

        public void PrintInOrder()
        {
            Node current = root;
            PrintInOrder(current);
        }
        public void PrintInOrder(Node current)
        {
            if (current != null)
            {
                PrintInOrder(current.left);
                Console.Write(" " + current.data + " ");
                PrintInOrder(current.right);
            }
           
        }

       
    }

  
    class Program
    {
        static void Main(string[] args)
        {
            //working creates new tree
            //first node has the value 12 this is the root node
            BinarySearchTree tree = new BinarySearchTree(12);

            //add to tree using recursion
            tree.AddNode(7);
            tree.AddNode(4);
            tree.AddNode(5);
            tree.AddNode(16);
            tree.AddNode(1);
            tree.AddNode(3);
           
            tree.AddNode(17);
            tree.AddNode(18);
            tree.AddNode(22);
            tree.AddNode(4);

            Console.WriteLine("There are {0} nodes in this tree", tree.count);
            
           
            Console.WriteLine("The height of this tree is {0}", tree.getHeight());
            tree.PrintInOrder();
            
           
            Console.ReadLine();

        }
    }
}

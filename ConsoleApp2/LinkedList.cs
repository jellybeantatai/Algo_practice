using System;

namespace LinkedList
{
    public class SNode
    {
        public int data;
        public SNode next;

        public SNode(int SNodeData)
        {
            data = SNodeData;
            next = null;
        }

        public void PrintList()
        {
            Console.Write("|"+data+"|"+"->");
            if (next != null)
            {
                next.PrintList();
            }
            Console.WriteLine();
        }

        public void AddToEnd(int dataToAddToEnd)
        {
            if (next != null)
            {
                next.AddToEnd(dataToAddToEnd);
            }
            else
            {
                next = new SNode(dataToAddToEnd);
            }
        }
    }

    public class DNode
    {
        public int data;
        public DNode next;
        public DNode previous;

        public DNode(int DNodeData)
        {
            previous = null;
            data = DNodeData;
            next = null;
        }

        public void PrintList()
        {
            Console.Write("="+"|" + data + "|" + "=");
            if (next != null)
            {
                next.PrintList();
            }
            Console.WriteLine();
        }

        public void AddToEnd(int dataToAddToEnd)
        {
            if (next != null)
            {
                next.AddToEnd(dataToAddToEnd);
            }
            else
            {
                next = new DNode(dataToAddToEnd);
                next.previous = this;
            }
        }
    }

    public class MyLinkedList
    {
        public SNode headNode;

        public MyLinkedList()
        {
            headNode = null;
        }

        public void AddToEnd(int dataToAdd)
        {
            if(headNode == null)
            {
                headNode = new SNode(dataToAdd);
            }
            else
            {
                headNode.AddToEnd(dataToAdd);
            }
        }

        public void Print()
        {
            if (headNode != null)
            {
                headNode.PrintList();
            }
        }
    }

    class Program
    {
        static void Main()
        {
            MyLinkedList list = new MyLinkedList();
            list.AddToEnd(35);
            list.AddToEnd(124);
            list.AddToEnd(34);
            list.Print();
        }
    }
}

using System;

public class Node
{
    public object value;
    public Node next;
    public Node prev;

    public Node(object item, Node next, Node prev)
    {
        this.value = item;
        this.next = next;
        this.prev = prev;
    }
}

public class Dequeue
{
    public int length;
    public Node head;
    public Node tail;

    public Dequeue()
    {
        this.length = 0;
        this.head = this.tail = new Node(null, null, null);
    }

    public string AddFirst(object item)
    {
        this.length++;
        Node node = new Node(item, null, null);
        if (this.head.value == null)
        {
            this.head = this.tail = node;
            return "ok";
        }
        node.next = this.head;
        this.head.prev = node;
        this.head = node;
        return "ok";
    }

    public string AddLast(object item)
    {
        this.length++;
        Node node = new Node(item, null, null);
        if (this.tail.value == null)
        {
            this.tail = this.head = node;
            return "ok";
        }
        node.prev = this.tail;
        this.tail.next = node;
        this.tail = node;
        return "ok";
    }

    public object RemoveLast()
    {
        if (this.head.value == null) return null;

        this.length--;
        if (this.length == 0)
        {
            Node head = this.head;
            this.head = this.tail = new Node(null, null, null);
            return head.value;
        }
        Node tail = this.tail;
        this.tail.prev.next = null;
        this.tail = this.tail.prev;
        return tail.value;
    }

    public object RemoveFirst()
    {
        if (this.head.value == null) return null;

        this.length--;
        if (this.length == 0)
        {
            Node head1 = this.head;
            this.head = this.tail = new Node(null, null, null);
            return head1.value;
        }
        Node head = this.head;
        this.head.next.prev = null;
        this.head = this.head.next;
        return head.value;
    }

    public void PrintAll()
    {
        if (this.length == 1 || this.length == 0)
        {
            Console.WriteLine(this.head.value);
            return;
        }
        Node head = this.head;
        for (int i = 0; i < this.length; i++)
        {
            Console.Write(head.value);
            Console.Write(' ');
            head = head.next;
        }
    }

    public int FindItem(object item)
    {
        Node current = this.head;
        for (int i = 0; i < this.length; i++)
        {
            if (Convert.ToString(current.value) == Convert.ToString(item))
            {
                return i;
            }
            current = current.next;
        }
        return -1;
    }

    public int Size()
    {
        return this.length;
    }
}

public class Program
{
    public static void Main()
    {
        Dequeue dequeue = new Dequeue();
        while (true)
        {
            string prompt = Console.ReadLine();
            string[] substrings = prompt.Split(' ');
            switch (substrings[0].ToLower())
            {
                case "addfirst":
                    Console.WriteLine(dequeue.AddFirst(substrings[1]));
                    break;
                case "addlast":
                    Console.WriteLine(dequeue.AddLast(substrings[1]));
                    break;
                case "removefirst":
                    Console.WriteLine(dequeue.RemoveFirst());
                    break;
                case "removelast":
                    Console.WriteLine(dequeue.RemoveLast());
                    break;
                case "finditem":
                    Console.WriteLine(dequeue.FindItem(substrings[1]));
                    break;
                case "size":
                    Console.WriteLine(dequeue.Size());
                    break;
                case "printall":
                    dequeue.PrintAll();
                    break;
                case "exit":
                    Console.WriteLine("bye");
                    return;
            }
        }
    }
}
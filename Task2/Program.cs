using System;


public class Node
{
    public object value;
    public Node next;

    public Node(object item, Node next)
    {
        this.value = item;
        this.next = next;
    }
}

public class Queue
{
    public int length;
    public Node head;
    public Node tail;

    public Queue()
    {
        this.length = 0;
        this.head = this.tail = new Node(null, null);
    }

    public string push(object item)
    {
        this.length++;
        Node node = new Node(item, null);
        if (this.tail.value == null)
        {
            this.head = this.tail = node;
        }
        else
        {
            this.tail.next = node;
            this.tail = node;
        }
        return "ok";
    }

    public object pop()
    {
        if (this.head.value == null) return null;

        this.length--;
        Node head = this.head;
        if (this.length == 0)
        {
            this.head = this.tail = new Node(null, null);
        }
        else
        {
            this.head = this.head.next;
        }
        return head.value;
    }

    public int size()
    {
        return this.length;
    }

    public object front()
    {
        return this.head.value;
    }

    public string clear()
    {
        this.head.next = null;
        this.head = this.tail = new Node(null, null);
        this.length = 0;
        return "ok";
    }
}

public class Program
{
    public static void Main()
    {
        Queue queue = new Queue();
        while (true)
        {
            string prompt = Console.ReadLine();
            string[] substrings = prompt.Split(' ');
            switch (substrings[0])
            {
                case "push":
                    Console.WriteLine(queue.push(substrings[1]));
                    break;
                case "pop":
                    Console.WriteLine(queue.pop());
                    break;
                case "front":
                    Console.WriteLine(queue.front());
                    break;
                case "size":
                    Console.WriteLine(queue.size());
                    break;
                case "clear":
                    Console.WriteLine("ok");
                    queue = new Queue();
                    break;
                case "exit":
                    Console.WriteLine("bye");
                    return;
            }
        }
    }
}
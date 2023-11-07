using System;


public class Node
{
    public object value;
    public Node prev;

    public Node(object item, Node node)
    {
        this.value = item;
        this.prev = node;
    }
}

public class Stack
{
    public int length;
    public Node head;

    public Stack()
    {
        this.length = 0;
        this.head = new Node(null, null);
    }

    public string push(object item)
    {
        this.length++;
        Node node = new Node(item, null);
        if (this.head.value == null)
        {
            this.head = node;
        }
        else
        {
            node.prev = this.head;
            this.head = node;
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
            this.head = new Node(null, null);
        }
        else
        {
            this.head = this.head.prev;
        }
        return head.value;
    }

    public int size()
    {
        return this.length;
    }

    public object back()
    {
        return this.head.value;
    }

    public string clear()
    {
        this.head.prev = null;
        this.head = new Node(null, null);
        this.length = 0;
        return "ok";
    }
}

public class Program
{
    public static void Main()
    {
        Stack stack = new Stack();
        while (true)
        {
            string prompt = Console.ReadLine();
            string[] substrings = prompt.Split(' ');
            switch (substrings[0])
            {
                case "push":
                    Console.WriteLine(stack.push(substrings[1]));
                    break;
                case "pop":
                    Console.WriteLine(stack.pop());
                    break;
                case "back":
                    Console.WriteLine(stack.back());
                    break;
                case "size":
                    Console.WriteLine(stack.size());
                    break;
                case "clear":
                    Console.WriteLine("ok");
                    stack = new Stack();
                    break;
                case "exit":
                    Console.WriteLine("bye");
                    return;
            }
        }
    }
}
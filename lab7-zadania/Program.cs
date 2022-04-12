using System;

namespace lab7_zadania
{
    class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }
    }

    class Stack<T>
    {
        private Node<T> _head;
        public void Push(T value)
        {
            Node<T> newNode = new Node<T> { Value = value, Next = _head };
            _head = newNode;
        }

        public bool isEmpty()
        {
            return _head == null;
        }

        public T Pop()
        {
            if (isEmpty())
            {
                throw new Exception("Stack is empty");
            }
            T result = _head.Value;
            _head = _head.Next;
            return result;
        }
        public Stack<T> Reverse(Stack<T> stack)
        {
            Stack<T> reversed = new Stack<T> { };
            while (!stack.isEmpty())
            {
                reversed.Push(stack.Pop());
            }
            return reversed;
        }
    }

    class Queue<T>
    {
        private Node<T> _head;
        private Node<T> _tail;
        private int _count;

        public bool IsEmpty()
        {
            return _head == null;
        }

        public void Insert(T value)
        {
            Node<T> node = new Node<T> { Value = value };
            if (IsEmpty())
            {
                _head = node;
                _tail = _head;
                return;
            }
            _count++;
            _tail.Next = node;
            _tail = node;
        }

        public T Remove()
        {
            if (IsEmpty())
            {
                throw new Exception("Queue is empty!");
            }
            T result = _head.Value;
            _head = _head.Next;
            _count--;
            return result;

        }

        public T[] ToArray()
        {
            if (IsEmpty())
            {
                return new T[0];
            }
            T[] array = new T[_count];
            Node<T> node = _head;
            int i = 0;
            while (node != null)
            {
                array[i++] = node.Value;
                node = node.Next;
            }
            return array;

        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            // NODE
            Node<string> node = new Node<string> { Value = "Adam" };
            node.Next = new Node<string> { Value = "Ewa" };
            node.Next.Next = new Node<string> { Value = "Karol" };
            Node<string> head = node;
            while (node != null)
            {
                Console.WriteLine(node.Value);
                node = node.Next;
            }

            // STACK
            Stack<string> stack = new Stack<string> { };
            stack.Push("Agnieszka");
            stack.Push("Marian");
            stack.Push("Heniek");
            Console.WriteLine("Stos: ");
            while (!stack.isEmpty())
            {
                Console.WriteLine(stack.Pop());
            }
            
            Console.WriteLine("Stos odwrócony: ");
            stack.Reverse(stack);
            while (!stack.isEmpty())
            {
                Console.WriteLine(stack.Pop());
            }

            // QUEUE
            Queue<string> queue = new Queue<string> { };
            queue.Insert("Halina");
            queue.Insert("Mariola");
            queue.Insert("Eustafa");
            // string[] vs = queue.ToArray();
            // Console.WriteLine(string.Join(", ", arr));
            //while (!queue.IsEmpty())
            //{
            //    Console.WriteLine(queue.Remove());
            //}
        }
    }
}

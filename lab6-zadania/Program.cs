using System;

namespace lab6_zadania
{
    class IntQueue
    {
        public static readonly int Capacity = 5; 
        private int[] _arr = new int[Capacity];
        private int last = -1;
        private int first = -1;

        public bool Insert (int item)
        {
            if (last >= Capacity - 1)
            { 
                return false;
            }
            _arr[++last] = item;
            if (first == -1 )
            {
                first = last;
            }
            return true;
        }

        public int Remove ()
        {
            if (first == -1)
            {
                throw new Exception();
            }
            if (first >= Capacity - 1)
            {
                int result = _arr[first];
                first = -1;
                return result;
            }
            return _arr[first++];
        }

        public int Count()
        {
            if (first == -1)
            {
                return 0;
            }
            return last - first +1;
        }
    }

    class PriorityQueue
    {
        public static readonly int Capacity = 5;
        public int[] _arr = new int[Capacity];
        private int last = -1;

        private int left(int parent)
        {
            return parent * 2 + 1;
        }
        private int right(int parent)
        {
            return parent * 2 + 2;
        }
        private int parent(int child)
        {
            return (child - 1) / 2;
        }
        public bool Insert(int item)
        {
            // utworzyć większą tablicę copy
            // skopiować do z _arr do copy
            // przypisać copy do arr

            if (last == Capacity - 1)
            {
                return false;
            }
            _arr[++last] = item;
            RebuildUp(last);
            return true;
        }

        private void RebuildUp(int child)
        {
            while(true)
            {
                int p = parent(child);
                if (_arr[p] < _arr[child])
                {
                    //(_arr[p], _arr[child]) = (_arr[child], _arr[p]);
                    int temp = _arr[p];
                    _arr[p] = _arr[child];
                    _arr[child] = temp;
                    child = p;
                }
            }
            throw new NotImplementedException();
        }

        private void RebuildDown()
        {
            int node = 0;
            while(node <= last)
            {
                int leftValue = _arr[left(node)];
                int rightValue = _arr[right(node)];
                if (_arr[node] >= leftValue && _arr[node] >= rightValue)
                    break;

                if (leftValue > rightValue)
                    //zamień wartość z node z leftvalue
                    node = left(node);
                else
                    // a w przeciwnym wypadku z node z rightvalue
                    node = right(node);
                    
                       
            }
            throw new NotImplementedException();
        }
        public int Remove()
        {
            // waruneczki & zachowanie dla pustej kolejki
            int removed = _arr[0];
            _arr[0] = _arr[last--];
            RebuildDown();
            return removed;
        }

        public int Count()
        {
            return last + 1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IntQueue queue = new IntQueue();
            queue.Insert(5);
            queue.Insert(8);
            queue.Insert(10);

            if (queue.Count() == 3)
            {
                Console.WriteLine("Ok");
            }

            int removed = queue.Remove();
            if (removed == 5)
            {
                Console.WriteLine("Ok");
            }

            if (queue.Count() == 2)
            {
                Console.WriteLine("Ok");
            }
            queue.Insert(3);
            queue.Insert(6);
            queue.Insert(9);
            Console.WriteLine(queue.Count());

            PriorityQueue priorityQueue = new PriorityQueue();
            priorityQueue.Insert(4);
            priorityQueue.Insert(7);
            priorityQueue.Insert(9);
            priorityQueue.Insert(1);
            Console.WriteLine("Kolejka priorytetowa");
            foreach ( int item in priorityQueue._arr)
            {
                Console.Write(" " + item);
            }
        }
    }
}

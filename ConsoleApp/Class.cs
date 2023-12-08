/*namespace console
{
    public class Node
    {
        public Node Next { get; set; }
        public object Data;
        public Node() { }
        public Node(object data) { Data = data; }
    }
    public class StackEventArgs : EventArgs
    {
        public string EventMessage { get; }
        public StackEventArgs(string eventMessage) { EventMessage = eventMessage; }
    }

    public class Stack : Node
    {
        Node? Top;
        public delegate void StackClearingHandler(object sender, StackEventArgs e);
        public event StackClearingHandler StackEvent;
        public Stack() { }
        public void Pop()
        {
            if (Top == null) return;
            Node n = Top;
            Top = Top.Next;
            OnStackEvent("Top element removed.");
        }
        public void Push(object i)
        {
            Node n = new Node(i);
            n.Next = Top;
            Top = n;
            OnStackEvent("Added the element to the top.");
        }
        public void Clear()
        {
            Top = null;
            OnStackEvent("Stack is empty now.");
        }


        private void OnStackEvent(string message)
        {
            StackEvent?.Invoke(this, new StackEventArgs(message));
        }

    }

}
*/

namespace console
{
    public class Node
    {
        public Node Next { get; set; }
        public object Data;
        public Node() { }
        public Node(object data) { Data = data; }
    }

    public class StackEventArgs : EventArgs
    {
        public string EventMessage { get; }
        public StackEventArgs(string eventMessage) { EventMessage = eventMessage; }
    }

    public class Stack : Node
    {
        private Node? Top;
        private int Capacity;
        private int Count;

        public delegate void StackClearingHandler(object sender, StackEventArgs e);
        public event StackClearingHandler StackEvent;

        public Stack(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentException("Capacity must be greater than zero.");
            }

            Capacity = capacity;
            Count = 0;
        }

        public void Pop()
        {
            if (Top == null) return;
            Node n = Top;
            Top = Top.Next;
            Count--;
            OnStackEvent("Top element removed.");
        }

        public void Push(object i)
        {
            if (Count == Capacity || Count > Capacity)
            {
                OnStackEvent("Stack overflow. Capacity exceeded.");
                return;
            }

            Node n = new Node(i);
            n.Next = Top;
            Top = n;
            Count++;
            OnStackEvent("Added the element to the top.");
        }

        public void Clear()
        {
            Top = null;
            Count = 0;
            OnStackEvent("Stack is empty now.");
        }

        private void OnStackEvent(string message)
        {
            StackEvent?.Invoke(this, new StackEventArgs(message));
        }
    }
}
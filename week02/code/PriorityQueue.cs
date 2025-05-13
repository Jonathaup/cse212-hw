public class PriorityQueue
{
    private List<PriorityItem> _queue = new();
    private int _sequenceCounter = 0; // Para mantener el orden de llegada

    /// <summary>
    /// Add a new value to the queue with an associated priority.  The
    /// node is always added to the back of the queue regardless of 
    /// the priority.
    /// </summary>
    /// <param name="value">The value</param>
    /// <param name="priority">The priority</param>
    public void Enqueue(string value, int priority)
    {
        var newNode = new PriorityItem(value, priority, _sequenceCounter++);
        _queue.Add(newNode);
    }

    public string Dequeue()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }
        // Find the index of the item with the highest priority to remove
        // find the item with the highest priority and lowest sequence
        var highPriorityIndex = 0;
        for (int index = 1; index < _queue.Count; index++)
        {
            if (_queue[index].Priority > _queue[highPriorityIndex].Priority ||
                (_queue[index].Priority == _queue[highPriorityIndex].Priority && 
                 _queue[index].Sequence < _queue[highPriorityIndex].Sequence))
            {
                highPriorityIndex = index;
            }
        }
        // Remove and return the item with the highest priority
        var value = _queue[highPriorityIndex].Value;
        _queue.RemoveAt(highPriorityIndex);
        return value;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}

internal class PriorityItem
{
    internal string Value { get; set; }
    internal int Priority { get; set; }
    internal int Sequence { get; set; }

    internal PriorityItem(string value, int priority, int sequence)
    {
        Value = value;
        Priority = priority;
        Sequence = sequence;
    }

    public override string ToString()
    {
        return $"{Value} (Pri:{Priority})";
    }
}
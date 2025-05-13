using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add elements with different priorities to the queue
    // Expected Result: Elements should be removed in order of priority (highest to lowest).
    // Defect(s) Found:  The Dequeue method is removing the element with the lowest priority instead of the highest.
    public void TestPriorityQueue_1()
    {
       var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("LowPriority", 1);
        priorityQueue.Enqueue("HighPriority", 5);
        priorityQueue.Enqueue("MediumPriority", 3);

        // The first element with the highest priority is "HighPriority".
        var result = priorityQueue.Dequeue();
        Assert.AreEqual("HighPriority", result);
        
        // The next highest priority item is "Medium Priority".
        result = priorityQueue.Dequeue();
        Assert.AreEqual("MediumPriority", result);
        
        // Finally, the last element with the lowest priority is "Low Priority".
        result = priorityQueue.Dequeue();
        Assert.AreEqual("LowPriority", result);
    }

    [TestMethod]
    // Scenario: Add elements with the same priority and check the FIFO order.
    // Expected Result: Elements with the same priority should be removed in the order they were added (FIFO)
    // Defect(s) Found: The FIFO behavior is not working correctly.  
    public void TestPriorityQueue_2()
    {
       var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 3);
        priorityQueue.Enqueue("Second", 3);
        priorityQueue.Enqueue("Third", 3);

        // All have the same priority, so they should be removed in the order they were added..
        var result = priorityQueue.Dequeue();
        Assert.AreEqual("First", result);
        
        result = priorityQueue.Dequeue();
        Assert.AreEqual("Second", result);
        
        result = priorityQueue.Dequeue();
        Assert.AreEqual("Third", result);
    }

     [TestMethod]
     [ExpectedException(typeof(InvalidOperationException))]

    // Scenario: Try to dequeue an element from an empty queue.
    // Expected Result: The queue should throw an InvalidOperationException.
    // Defect(s) Found:  The queue does not throw an exception when trying to dequeue from an empty queue.  
    public void TestPriorityQueue_3()
    {
          var priorityQueue = new PriorityQueue();
        
        // Attempting to dequeue when the queue is empty.
        priorityQueue.Dequeue();
    }

 [TestMethod]
 
    // Scenario: Add elements with different priorities and check the removal order.
    // Expected Result:  Elements with the highest priority should be removed first, and in case of a tie, they should be removed in FIFO order
    // Defect(s) Found: The queue is not removing elements with the highest priority first.  
    public void TestPriorityQueue_4()
    {
           var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 2);
        priorityQueue.Enqueue("Second", 3);
        priorityQueue.Enqueue("Third", 3);
        priorityQueue.Enqueue("Fourth", 1);

        // The first element to be removed should be "Second", followed by "Third".
        var result = priorityQueue.Dequeue();
        Assert.AreEqual("Second", result);

        result = priorityQueue.Dequeue();
        Assert.AreEqual("Third", result);

        // Then "First" is removed.
        result = priorityQueue.Dequeue();
        Assert.AreEqual("First", result);

        // Finally, the last element will be "Fourth".
        result = priorityQueue.Dequeue();
        Assert.AreEqual("Fourth", result);
    }


    // Add more test cases as needed below.
}
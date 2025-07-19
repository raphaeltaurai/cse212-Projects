using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items with different priorities, then dequeue all.
    // Expected Result: Items are dequeued in order of highest to lowest priority.
    // Defect(s) Found: The queue does not always return the correct highest priority item. Expected C, got B.
    public void TestPriorityQueue_DequeueHighestPriority()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 3);
        pq.Enqueue("C", 2);
        Assert.AreEqual("B", pq.Dequeue()); // Highest priority
        Assert.AreEqual("C", pq.Dequeue()); // Next highest
        Assert.AreEqual("A", pq.Dequeue()); // Lowest
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the same highest priority, then dequeue all.
    // Expected Result: Items with the same highest priority are dequeued in FIFO order.
    // Defect(s) Found: The queue does not maintain FIFO order for items with the same priority. Expected B, got C.
    public void TestPriorityQueue_FIFOSamePriority()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 2);
        pq.Enqueue("B", 3);
        pq.Enqueue("C", 3);
        pq.Enqueue("D", 1);
        Assert.AreEqual("B", pq.Dequeue()); // B and C have highest priority, B first
        Assert.AreEqual("C", pq.Dequeue()); // Then C
        Assert.AreEqual("A", pq.Dequeue()); // Then A
        Assert.AreEqual("D", pq.Dequeue()); // Then D
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue.
    // Expected Result: Throws InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: None. This test passes.
    public void TestPriorityQueue_EmptyDequeue()
    {
        var pq = new PriorityQueue();
        try
        {
            pq.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }

    [TestMethod]
    // Scenario: Enqueue items with negative and zero priorities, then dequeue all.
    // Expected Result: Items are dequeued in order of highest to lowest priority, regardless of sign.
    // Defect(s) Found: The queue does not always return the correct order for negative/zero priorities. Expected D, got C.
    public void TestPriorityQueue_NegativeAndZeroPriority()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", -1);
        pq.Enqueue("B", 0);
        pq.Enqueue("C", 2);
        pq.Enqueue("D", 1);
        Assert.AreEqual("C", pq.Dequeue()); // 2
        Assert.AreEqual("D", pq.Dequeue()); // 1
        Assert.AreEqual("B", pq.Dequeue()); // 0
        Assert.AreEqual("A", pq.Dequeue()); // -1
    }

    // Add more test cases as needed below.
}
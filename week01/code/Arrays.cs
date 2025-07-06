public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.
    /// </summary>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step-by-step plan:
        // 1. Create a result array of size 'length'.
        // 2. Loop from 0 to length-1 and assign number * (i+1) to the array.
        // 3. Return the array.

        double[] multiples = new double[length];

        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  
    /// For example, if the data is {1,2,3,4,5,6,7,8,9} and amount is 3 → Result: {7,8,9,1,2,3,4,5,6}
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Copy the last 'amount' elements into a temporary list.
        List<int> tail = data.GetRange(data.Count - amount, amount);

        // Step 2: Remove the last 'amount' elements from the original list.
        data.RemoveRange(data.Count - amount, amount);

        // Step 3: Insert those elements at the front.
        data.InsertRange(0, tail);
    }

}
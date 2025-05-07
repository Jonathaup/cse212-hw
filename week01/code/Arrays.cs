public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Create an array of doubles with a size of 'length'
    double[] multiples = new double[length];
    
    // Use a for loop to populate the array with multiples of 'number'
    for (int i = 1; i <= length; i++)
    {
        multiples[i - 1] = number * i; // i-1 because array index starts at 0
    }

    // Return the array
    return multiples;
}

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
       //  Calculate the effective rotation amount to handle large inputs
    amount = amount % data.Count;  // Ensures we don't rotate more than necessary

    // If amount is 0, no rotation is needed
    if (amount == 0)
        return;

    // Split the list into two parts
    List<int> lastPart = data.GetRange(data.Count - amount, amount);  // Last 'amount' elements
    List<int> firstPart = data.GetRange(0, data.Count - amount);      // Rest of the elements

    // Combine the two parts to get the rotated list
    data.Clear();  // Clear the original list
    data.AddRange(lastPart);  // Add the last 'amount' elements to the front
    data.AddRange(firstPart); // Add the rest of the elements to the back
}
}

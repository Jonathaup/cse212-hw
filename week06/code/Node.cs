public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

   public void Insert(int value)
{
    // Prevent duplicates: do nothing if the value already exists in the tree
    if (value == Data)
    {
        return;
    }

    if (value < Data)
    {
        // Insert into the left subtree
        if (Left is null)
            Left = new Node(value);
        else
            Left.Insert(value);
    }
    else // value > Data
    {
        // Insert into the right subtree
        if (Right is null)
            Right = new Node(value);
        else
            Right.Insert(value);
    }
}

    public bool Contains(int value)
{
    // If the current node's value matches, we've found the value
    if (value == Data)
    {
        return true;
    }

    // If the value is less than the current node's value, search the left subtree
    if (value < Data)
    {
        if (Left is null)
            return false;
        else
            return Left.Contains(value);
    }
    else // value > Data
    {
        // If the value is greater than the current node's value, search the right subtree
        if (Right is null)
            return false;
        else
            return Right.Contains(value);
    }
}

    public int GetHeight()
{
    // Base case: if both children are null, this is a leaf node, so height is 1
    if (Left is null && Right is null)
    {
        return 1;
    }

    // Recursively get the height of left and right subtrees
    int leftHeight = Left?.GetHeight() ?? 0;
    int rightHeight = Right?.GetHeight() ?? 0;

    // Height of the current node is 1 + max height of the two subtrees
    return 1 + Math.Max(leftHeight, rightHeight);
}
}
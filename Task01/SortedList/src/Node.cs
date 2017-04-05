namespace CSharpBasics.src
{
    // node for custom list
    public class Node
    {
        public TestStruct Data { get; private set; }
        public Node Next { get; set; }

        public Node(TestStruct data)
        {
            Data = data;
        }
    }
}

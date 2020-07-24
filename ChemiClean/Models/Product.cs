namespace ChemiClean.Models
{
    public class Product
    {
        public string Name;
        public string Supplier;
        public string Url;
        public bool IsUpdated;

        public Product(string name, string supplier, string url)
        {
            Name = name;
            Supplier = supplier;
            Url = url;
        }
    }
}

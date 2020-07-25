using System;

namespace ChemiClean.Models
{
    public class Product
    {
        public string Name;
        public string Supplier;
        public string Url;
        public string LastBackup;
        public bool IsUpdated;
        public bool IsUrlBroken;

        public Product(string name, string supplier, string url, string lastBackup)
        {
            Name = name;
            Supplier = supplier;
            Url = url;
            LastBackup = lastBackup;
        }
    }
}

namespace BuilderPattern.Models
{
    public class FurnitureItem
    {
        public string Name { get; }
        public string Material { get; }
        public string Size { get; }

        public FurnitureItem(string name, string material, string size)
        {
            Name = name;
            Material = material;
            Size = size;
        }

        public override string ToString()
        {
            return $"{Name} - {Material} - {Size}";
        }
    }
}

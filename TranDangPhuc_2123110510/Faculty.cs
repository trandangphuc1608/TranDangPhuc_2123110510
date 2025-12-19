namespace TranDangPhuc_2123110510
{
    public class Faculty
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

        public Faculty(string id, string name, int quantity)
        {
            this.Id = id;
            this.Name = name;
            this.Quantity = quantity;
        }

        // Constructor mặc định
        public Faculty() { }
    }
}
namespace BorderControl.Models
{
    public class Robot : Entered
    {
        public Robot(string model, string id) 
            : base(id)
        {
            this.Model = model;
        }

        public string Model { get; private set; }
    }
}

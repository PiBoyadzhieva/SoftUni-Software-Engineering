namespace BirthdayCelebrations.Models
{
    public abstract class Entered
    {
        protected Entered(string id)
        {
            this.Id = id;
        }

        public string Id { get; protected set; }
    }
}

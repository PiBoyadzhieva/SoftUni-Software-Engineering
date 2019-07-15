namespace Ferrari
{
    public interface ICar
    {
        string Model { get; }
        string DriverName { get; }
        string Gas();
        string Brakes();
    }
}

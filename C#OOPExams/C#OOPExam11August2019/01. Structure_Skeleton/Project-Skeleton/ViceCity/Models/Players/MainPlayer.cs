namespace ViceCity.Models.Players
{
    public class MainPlayer : Player
    {
        private const int initialLifePoints = 100;
        private const string InitialName = "Tommy Vercetti";

        public MainPlayer() 
            : base(InitialName, initialLifePoints)
        {
        }
    }
}

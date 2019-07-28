using System.Collections.Generic;

namespace AnimalCentre.Models.Contracts
{
    public interface IHotel
    {
        IReadOnlyDictionary<string, IAnimal> Animals { get; }
        void Accommodate(IAnimal animal);
        void Adopt(string animalName, string owner);
    }
}

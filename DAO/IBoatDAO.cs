using System;

namespace KnorishBoatProject.DAO
{
    public interface IBoatDAO
    {
        bool CheckIfBoatAlreadyRegistred(string boatName);
        Guid RegisterBoat(string boatName, Int32 hourlyRate);
        bool BookBoat(Guid boatNumber, string customerName);
    }
}

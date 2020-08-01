using System;
namespace KnorishBoatProject
{
    public interface IBoatActivities
    {
        Guid RegisterBoat(string boatName, Int32 hourlyRate);
        bool BookBoat(Guid boatNumber, string customerName);
    }
}

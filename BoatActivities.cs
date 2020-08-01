using System;
using KnorishBoatProject.DAO;
namespace KnorishBoatProject
{
    public class BoatActivities : IBoatActivities
    {
        IBoatDAO boatDAO;
        public BoatActivities(IBoatDAO _boatDAO)
        {
            boatDAO = _boatDAO;
        }
       
        public Guid RegisterBoat(string boatName, Int32 hourlyRate)
        {
            if (boatDAO.CheckIfBoatAlreadyRegistred(boatName))
                throw new Exception("Boat already registred.");
            return boatDAO.RegisterBoat(boatName, hourlyRate);
        }

        public bool BookBoat(Guid boatNumber, string customerName)
        {
            return boatDAO.BookBoat(boatNumber, customerName);
        }
    }
}

using System;

namespace Aircompany.Planes
{
    public class PassengerPlane : Plane
    {
        //6
        public int passengersCapacity;

        public PassengerPlane(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity, int passengersCapacity)
            :base(model, maxSpeed, maxFlightDistance, maxLoadCapacity)
        {
            //7
            this.passengersCapacity = passengersCapacity;
        }

        public override bool Equals(object objectToCompare)
        {
            //8
            return (objectToCompare as PassengerPlane) != null &&
                   base.Equals(objectToCompare) &&
                   passengersCapacity == (objectToCompare as PassengerPlane).passengersCapacity;
        }

        public override int GetHashCode()
        {
            //9
            var hashCode = 751774561;
            return (hashCode * -1521134295 + base.GetHashCode())
                * hashCode * -1521134295 + passengersCapacity.GetHashCode();
        }

        public int GetPassengersCapacityIs()
        {
            return passengersCapacity;
        }

       
        public override string ToString()
        {
            return base.ToString().Replace("}",", passengersCapacity=" + passengersCapacity + '}');
        }       
    }
}

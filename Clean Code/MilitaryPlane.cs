using Aircompany.Models;

namespace Aircompany.Planes
{
    public class MilitaryPlane : Plane
    {
        //1
        public MilitaryType militaryType;

        public MilitaryPlane(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity, MilitaryType militaryType)
            : base(model, maxSpeed, maxFlightDistance, maxLoadCapacity)
        {
            //2
            this.militaryType = militaryType;
        }

        public override bool Equals(object objectToCompare)
        {
            //3
            return (objectToCompare as MilitaryPlane) != null &&
                   base.Equals(objectToCompare) &&
                   militaryType == (objectToCompare as MilitaryPlane).militaryType;
        }

        public override int GetHashCode()
        {
            //4
            var hashCode = 1701194404;
            return (hashCode * -1521134295 + base.GetHashCode())
                * hashCode * -1521134295 + militaryType.GetHashCode();
        }

        public MilitaryType GetPlaneTypeIs()
        {
            //5
            return militaryType;
        }

        public override string ToString()
        {
            return base.ToString().Replace("}",", type=" + militaryType +'}');
        }        
    }
}

using MethodsAndLists.Core.Enums;

namespace MethodsAndLists.Core.Models
{
    public class City
    {
        public string Name { get; set; }
        public int Population { get; set; }

        public CityType CitySize
        {
            get
            {
                if (Population >= 1_000_000)
                {
                    return CityType.Large;
                }
                else if (Population< 1_000_000 && Population >= 500_000)
                {
                    return CityType.Medium;
                }
                else if (Population< 500_000 && Population>= 20_000)
                {
                    return CityType.Normal;
                }
                else if (Population < 20_000)
                {
                    return CityType.Small;
                }
                return CityType.Unknown;
            }
        }

        public override string ToString()
        {
            return $"{Name}, {Population.ToString()}";
        }
    }
}

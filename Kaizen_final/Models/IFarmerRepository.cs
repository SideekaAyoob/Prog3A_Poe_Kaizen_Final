using System.Collections.Generic;

namespace Kaizen_final.Models
{
    public interface IFarmerRepository
    {

        IEnumerable<Farmer> GetAllFarmers { get; }

    }
}

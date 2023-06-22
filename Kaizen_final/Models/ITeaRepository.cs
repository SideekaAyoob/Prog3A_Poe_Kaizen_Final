using System.Collections.Generic;

namespace Kaizen_final.Models
{
    public interface ITeaRepository
    {
        IEnumerable<Tea> GetAllTeas { get; }
        // IEnumerable<Tea> GetTeasFarmers { get; }

        //how-->ID

        Tea GetTeasById(int teaId);

    }
}

using Kaizen_final.Data;
using System.Collections.Generic;

namespace Kaizen_final.Models
{
    public class FarmerRepository:IFarmerRepository
    {


        private readonly Data.ApplicationDbContext _appDbcontext;

        public FarmerRepository(ApplicationDbContext appDbcontext)
        {
            _appDbcontext = appDbcontext;
        }

        public IEnumerable<Farmer> GetAllFarmers => _appDbcontext.Farmers;

        //public IEnumerable<Farmer> GetAllFarmers => new List<Farmer>
        //        {//populating the Ienumerable

        //    new Farmer{farmerId=1,farmerName="Jhon",farmerEmail="jhon@gmail.com",farmerPhoneNumber="1234567890"},
        //     new Farmer{farmerId=2,farmerName="tyreece",farmerEmail="Tyreece@gmail.com",farmerPhoneNumber="1234567899"},
        //      new Farmer{farmerId=3,farmerName="Hella",farmerEmail="Hella@gmail.com",farmerPhoneNumber="1234567888"}
        ////             new Tea{TeaId=1,TeaName="Sencha",TeaDescription="greenTea",Price=50.99M,
        ////             Season=_seasonRepository.GetAllSeasons.ToList()[1],Seasonid=1,Tea_Stock=15 },

        ////             new Tea{TeaId=2,TeaName="Fukamushi Sencha",TeaDescription="greenTea",Price=55.99M,
        ////             Season=_seasonRepository.GetAllSeasons.ToList()[1],Seasonid=1,Tea_Stock=10 },

        ////             new Tea{TeaId=3,TeaName="Gyokuro",TeaDescription="greenTea",Price=60.99M,
        ////             Season=_seasonRepository.GetAllSeasons.ToList()[3],Seasonid=2,Tea_Stock=10 },

        //        };


    }
}

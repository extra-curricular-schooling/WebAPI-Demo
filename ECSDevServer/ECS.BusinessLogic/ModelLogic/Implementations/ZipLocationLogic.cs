using ECS.Models;
using ECS.Repositories.Implementations;

namespace ECS.BusinessLogic.ModelLogic.Implementations
{
    public class ZipLocationLogic
    {
        private readonly IZipLocationRepository _zipLocationRepository;

        public ZipLocationLogic ()
        {
            _zipLocationRepository = new ZipLocationRepository();
        }

        public void Create(ZipLocation zipLocation)
        {
            _zipLocationRepository.Insert(zipLocation);
        }

        public ZipLocation GetSingle(int zipCodeId)
        {
            return _zipLocationRepository.GetSingle(d => d.ZipCodeId == zipCodeId, d => d.Users);
        }

        public void Delete(ZipLocation zipLocation)
        {
            _zipLocationRepository.Delete(zipLocation);
        }

        public void Update(ZipLocation zipLocation)
        {
            _zipLocationRepository.Update(zipLocation);
        }
    }
}

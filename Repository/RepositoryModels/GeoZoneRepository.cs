using Contract.IRepositoryModels;
using Repository;

public class GeoZoneRepository : RepositoryBase<GeoZoneEntitity>, IGeoZoneRepository
{
    public GeoZoneRepository(AplicationContext _context) : base(_context)
    {
    }
}
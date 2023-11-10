using Contract.IRepositoryModels;
using Repository;

public class ImageRepository : RepositoryBase<ImagesProductsEntity>, IImagesRepository
{
    public ImageRepository(AplicationContext _context) : base(_context)
    {
    }
}
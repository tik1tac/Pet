using AutoMapper;

using PetProjectMarket.Shared.ModelDTO.Account;
using PetProjectMarket.Shared.ModelDTO.Product;

namespace PetProjectMarket.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegistration, UserEntity>();
            CreateMap<UserLogin, UserEntity>();
            CreateMap<UserRegistration, UserEntity>();
            CreateMap<CreateProductDTO, ProductsEntity>();
            CreateMap<UpdateProducts, ProductsEntity>();
            CreateMap<DeleteProduct, ProductsEntity>();
        }
    }
}

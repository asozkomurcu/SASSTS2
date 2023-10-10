using AutoMapper;
using SASSTS2.Application.Models.Dtos.AccountDtos;
using SASSTS2.Application.Models.Dtos.BillsDtos;
using SASSTS2.Application.Models.Dtos.CategoryDtos;
using SASSTS2.Application.Models.Dtos.CompanyDtos;
using SASSTS2.Application.Models.Dtos.CustomerDtos;
using SASSTS2.Application.Models.Dtos.DepartmentDtos;
using SASSTS2.Application.Models.Dtos.PriceOfferDtos;
using SASSTS2.Application.Models.Dtos.ProductDtos;
using SASSTS2.Application.Models.Dtos.ProductRequestDtos;
using SASSTS2.Application.Models.Dtos.PurchasedProductDtos;
using SASSTS2.Application.Models.Dtos.PurchaseRequestDtos;
using SASSTS2.Application.Models.Dtos.WholesalerDtos;
using SASSTS2.Domain.Entities;

namespace SASSTS2.Application.Automappings
{
    public class DomainToDto : Profile
    {
        public DomainToDto()
        {
            CreateMap<Account, AccountDto>();

            CreateMap<Bill, BillDto>();

            CreateMap<Category, CategoryDto>();

            CreateMap<Company, CompanyDto>();

            CreateMap<Customer, CustomerDto>();

            CreateMap<Department, DepartmentDto>();

            CreateMap<PriceOffer, PriceOfferDto>()
                .ForMember(x=>x.CustomerName,y=>y.MapFrom(e=>e.Customer.Name+' '+e.Customer.Surname));

            CreateMap<Product, ProductDto>();

            CreateMap<ProductRequest, ProductRequestDto>()
                .ForMember(x => x.CustomerName, y => y.MapFrom(e => e.Customer.Name + ' ' + e.Customer.Surname));

            CreateMap<PurchasedProduct, PurchasedProductDto>()
                .ForMember(x => x.CustomerName, y => y.MapFrom(e => e.Customer.Name + ' ' + e.Customer.Surname));

            CreateMap<PurchaseRequest, PurchaseRequestDto>()
                .ForMember(x => x.CustomerName, y => y.MapFrom(e => e.Customer.Name + ' ' + e.Customer.Surname));

            CreateMap<Wholesaler, WholesalerDto>();

        }
    }
}

namespace CarDealer
{
    using AutoMapper;
    using CarDealer.Dtos.Export;
    using CarDealer.Dtos.Import;
    using CarDealer.Models;
    using System.Linq;

    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<ImportSupplierDto, Supplier>();

            this.CreateMap<ImportPartDto, Part>();

            this.CreateMap<ImportCustomerDto, Customer>();

            this.CreateMap<ImportSaleDto, Sale>();

            //Problem 16
            this.CreateMap<Supplier, SupplierWithPartsCountDto>()
                .ForMember(x => x.PartsCount, y => y.MapFrom(x => x.Parts.Count));

            //Problem 17
            this.CreateMap<Part, PartDto>();
            this.CreateMap<Car, CarsWithTheirListOfPartsDto>()
                .ForMember(x => x.PartsDto, y => y.MapFrom(x => x.PartCars.Select(pc => pc.Part)));
        }
    }
}

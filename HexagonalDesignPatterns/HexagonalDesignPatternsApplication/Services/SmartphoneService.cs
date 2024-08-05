using HexagonalDesignPatterns.Application.DTOs.SmartphoneDTO;
using HexagonalDesignPatterns.Application.DTOs.SpecificationDTO;
using HexagonalDesignPatterns.Application.Ports.Driven;
using HexagonalDesignPatterns.Application.Ports.Driving;
using HexagonalDesignPatterns.Domain.Entities;
using HexagonalDesignPatterns.Domain.Factories;
using HexagonalDesignPatterns.Domain.Strategies;
using HexagonalDesignPatterns.SharedKarnel.Models;

namespace HexagonalDesignPatterns.Application.Services
{
    public class SmartphoneService : ISmartphoneService
    {
        #region Variables + Constructor
        private readonly ISmartphoneRepository _smartphoneRepository;
        private readonly IPricingStrategyFactory _pricingStrategyFactory;

        public SmartphoneService(ISmartphoneRepository smartphoneRepository, IPricingStrategyFactory pricingStrategyFactory)
        {
            _smartphoneRepository = smartphoneRepository;
            _pricingStrategyFactory = pricingStrategyFactory;
        }
        #endregion

        #region Get All 
        public async Task<GetAllSmartphonesResponse> GetAllAsync(int currentPage, int pageSize)
        {
            int totalCount = await _smartphoneRepository.GetTotalCountAsync();
            IEnumerable<Smartphone> smartphones = await _smartphoneRepository.GetAllAsync(currentPage, pageSize);

            IEnumerable<GetAllSmartphonesResponse.SmartphoneDTO> smartphoneDtos = smartphones.Select(smartphone => new GetAllSmartphonesResponse.SmartphoneDTO
            {
                Id = smartphone.Id,
                Model = smartphone.Model,
                Manufacturer = smartphone.Manufacturer,
                Specifications = new GetAllSmartphonesResponse.SpecificationsDTO
                {
                    ScreenSize = smartphone.Specifications?.ScreenSize,
                    BatteryLife = smartphone.Specifications?.BatteryLife ?? 0
                },
                Price = smartphone.PricingStrategy != null ? smartphone.GetPrice() : smartphone.BasePrice // Ensure default pricing
            });

            PagedList<GetAllSmartphonesResponse.SmartphoneDTO> pagedList = new PagedList<GetAllSmartphonesResponse.SmartphoneDTO>(
                smartphoneDtos.ToList(),
                totalCount,
                currentPage,
                pageSize
            );

            return new GetAllSmartphonesResponse
            {
                Smartphones = pagedList
            };
        }

        #endregion

        #region Get By Id
        public async Task<GetSmartphoneByIdResponse?> GetByIdAsync(GetSmartphoneByIdRequest request)
        {
            Smartphone smartphone = await _smartphoneRepository.GetByIdAsync(request.Id);
            if (smartphone == null) return null;

            return new GetSmartphoneByIdResponse
            {
                Id = smartphone.Id,
                Model = smartphone.Model,
                Manufacturer = smartphone.Manufacturer,
                Specifications = new SpecificationsResponse
                {
                    ScreenSize = smartphone.Specifications?.ScreenSize,
                    BatteryLife = smartphone.Specifications?.BatteryLife ?? 0
                },
                BasePrice = smartphone.BasePrice,
                Price = smartphone.PricingStrategy != null ? smartphone.GetPrice() : smartphone.BasePrice // Ensure default pricing
            };
        }

        #endregion

        #region Add 
        public async Task<AddSmartphoneResponse> AddAsync(AddSmartphoneRequest request)
        {
            IPricingStrategy pricingStrategy = _pricingStrategyFactory.CreateStrategy(request.PricingStrategyType);

            Smartphone smartphone = new Smartphone
            {
                Model = request.Model,
                Manufacturer = request.Manufacturer,
                Specifications = new Specifications
                {
                    ScreenSize = request.Specifications.ScreenSize,
                    BatteryLife = request.Specifications.BatteryLife
                },
                BasePrice = request.BasePrice,
                PricingStrategy = pricingStrategy ?? throw new ArgumentException("Invalid PricingStrategyType")
            };

            await _smartphoneRepository.AddAsync(smartphone);

            return new AddSmartphoneResponse
            {
                Id = smartphone.Id,
                Model = smartphone.Model,
                Manufacturer = smartphone.Manufacturer,
                Specifications = new SpecificationsResponse
                {
                    ScreenSize = smartphone.Specifications.ScreenSize,
                    BatteryLife = smartphone.Specifications.BatteryLife
                },
                Price = smartphone.GetPrice()
            };
        }

        #endregion

        #region Delet
        public async Task<DeleteSmartphoneResponse> DeleteAsync(DeleteSmartphoneRequest request)
        {
            Smartphone? smartphone = await _smartphoneRepository.GetByIdAsync(request.Id);
            if (smartphone == null)
            {
                return new DeleteSmartphoneResponse { Success = false };
            }

            await _smartphoneRepository.DeleteAsync(request.Id);
            return new DeleteSmartphoneResponse { Success = true };
        }
        #endregion
    }
}

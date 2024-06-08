using Orders.Backend.Repositories.Interfaces;
using Orders.Backend.UnitsOfWork.Interfaces;
using Orders.Shared.DTOs;
using Orders.Shared.Entities;
using Orders.Shared.Responses;

namespace Orders.Backend.UnitsOfWork.Implementations
{
    public class CitiesUnitOfWork : GenericUnitOfWork<City>, ICitiesUnitOfWork
    {
        private readonly ICitiesRepository _repository;
        public CitiesUnitOfWork(IGenericRepository<City> repository, ICitiesRepository ctiesRepository) : base(repository)
        {
            _repository = ctiesRepository;
        }

        public override async Task<ActionResponse<IEnumerable<City>>> GetAsync(PaginationDTO paginationDTO) => await _repository.GetAsync(paginationDTO);
        public override async Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO paginationDTO) => await _repository.GetTotalPagesAsync(paginationDTO);

    }
}

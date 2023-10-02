using Domain.Entities;
using Infrastructure.Data;
using MediatR;

namespace Application.Bars.Commands.CreateBar
{
    public record CreateBarCommand : IRequest<int>
    {
        public string? Name { get; init; }
        public string? Address { get; init; }
        public string? City { get; init; }
        public string? Zipcode { get; init; }
        public bool IsOpen { get; init; }
        public double Fee { get; init; }
        public Guid User { get; init; }
    }

    public class CreateBarCommandHandler : IRequestHandler<CreateBarCommand, int>
    {
        private readonly AuthDbContext _context;

        public CreateBarCommandHandler(AuthDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateBarCommand request, CancellationToken cancellationToken)
        {
            var entity = new Bar
            {
                Name = request.Name,
                Address = request.Address,
                City = request.City,
                Zipcode = request.Zipcode,
                IsOpen = request.IsOpen,
                Fee = request.Fee,
                User = request.User
            };

            _context.Bars.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
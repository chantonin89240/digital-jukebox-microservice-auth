using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Bars.Commands.DeleteBar
{
    public record DeleteBarCommand(int Id) : IRequest;

    public class DeleteBarCommandHandler : IRequestHandler<DeleteBarCommand>
    {
        private readonly AuthDbContext _context;

        public DeleteBarCommandHandler(AuthDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteBarCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Bars
                .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

            if (entity != null)
            {
                _context.Bars.Remove(entity);
            }

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
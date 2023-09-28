using Domain.Entities;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;
using System.Reflection.Emit;

namespace Application.Bars.Commands.UpdateBar
{
    public record UpdateBarCommand : IRequest
    {
        public int Id { get; init; }
        public string? Name { get; init; }
        public string? Address { get; init; }
        public string? City { get; init; }
        public string? Zipcode { get; init; }
        public bool IsOpen { get; init; }
        public double Fee { get; init; }
        public Guid User { get; init; }
    }

    public class UpdateBarCommandHandler : IRequestHandler<UpdateBarCommand>
    {
        private readonly AuthDbContext _context;

        public UpdateBarCommandHandler(AuthDbContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateBarCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Bars
               .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

            if (entity != null)
            {
                entity.Name = request.Name;
                entity.Address = request.Address;
                entity.City = request.City;
                entity.Zipcode = request.Zipcode;
                entity.IsOpen = request.IsOpen;
                entity.Fee = request.Fee;
                entity.User = request.User;
            }

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
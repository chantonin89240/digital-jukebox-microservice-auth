using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Bars.Queries
{
    public record GetBarsQuery : IRequest<List<BarDto>> { }

    public class GetBarsQueryHandler : IRequestHandler<GetBarsQuery, List<BarDto>>
    {
        private readonly AuthDbContext _context;

        public GetBarsQueryHandler(AuthDbContext context)
        {
            _context = context;
        }

        public async Task<List<BarDto>> Handle(GetBarsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Bars
                .Select(x => new BarDto { Id = x.Id, Name = x.Name, Address = x.Address, City = x.City, Zipcode = x.Zipcode, Fee = x.Fee, IsOpen = x.IsOpen, User = x.User })
                .ToListAsync(cancellationToken);
        }
    }
}
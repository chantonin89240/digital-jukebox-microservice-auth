using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Runtime.InteropServices;
using Domain.Entities;
using System.Data;

namespace Infrastructure.Data
{
    public static class InitialiserExtensions
    {
        public static async Task InitialiseDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var initialiser = scope.ServiceProvider.GetRequiredService<AuthDbContextInitialiser>();

            await initialiser.InitialiseAsync();
        }
    }

    public class AuthDbContextInitialiser
    {
        private readonly ILogger<AuthDbContextInitialiser> _logger;
        private readonly AuthDbContext _context;

        public AuthDbContextInitialiser(ILogger<AuthDbContextInitialiser> logger, AuthDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task InitialiseAsync()
        {
            try
            {
                await _context.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while initialising the database.");
                throw;
            }
        }
    }
}
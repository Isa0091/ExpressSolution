using Isa0091.Domain.Context;
using Isa0091.Domain.Core.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.Data
{
    public class StoreContext : BaseContext<StoreContext>
    {
        public StoreContext(DbContextOptions<StoreContext> options, IMediator mediator,IIntegrationEventSender sender, ILogger<StoreContext> logger) : base(options, mediator, sender, logger)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Store> Stores { get; set; }

        protected override void OnModelCreating(ModelBuilder b)
        {
            base.OnModelCreating(b);
            b.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

    }
}
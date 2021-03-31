using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PantheonBankingSolution.Domain;
using PantheonBankingSolution.Persistance;

namespace PantheonBankingSolution.Application.Customers
{
    public class List {

     
        public class Query : IRequest<List<Customer>> {

        }

        public class Handler : IRequestHandler<Query, List<Customer>> {
            private readonly DataContext _context;

            public Handler (DataContext context, ILogger<List> logger) {
                _context = context;
                _logger = logger;
            }

            public ILogger<List> _logger { get; }

            public async Task<List<Customer>> Handle (Query request, CancellationToken cancellationToken) 
            {
                var customers = await _context.Customers
                    .ToListAsync();

                return customers;
                
            }
        }
    }
}
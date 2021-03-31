using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PantheonBankingSolution.Application.Errors;
using PantheonBankingSolution.Domain;
using PantheonBankingSolution.Persistance;

namespace PantheonBankingSolution.Application.Transactions
{
    public class Details {
        public class Query : IRequest<List<Transaction>> {
            public int AccountNumber { get; set; }

        }

        public class Handler : IRequestHandler<Query, List<Transaction>> {
            private readonly DataContext _context;

            public Handler (DataContext context) {
                this._context = context;
            }

            public async Task<List<Transaction>> Handle (Query request, CancellationToken cancellationToken) {

                var transaction = await _context.Transactions
                    .FindAsync (request.AccountNumber);
                if (transaction == null) {
                    throw new RestException (HttpStatusCode.NotFound, new { activity = "Not found" });
                }
                var transactions = new List<Transaction>();
                return transactions;
            }

        }
    }
}
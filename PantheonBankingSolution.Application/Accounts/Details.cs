using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PantheonBankingSolution.Application.Errors;
using PantheonBankingSolution.Domain;
using PantheonBankingSolution.Persistance;

namespace PantheonBankingSolution.Application.Accounts
{
    public class Details {
        public class Query : IRequest<Account> {
            public int AccountNumber { get; set; }

        }

        public class Handler : IRequestHandler<Query, Account> {
            private readonly DataContext _context;

            public Handler (DataContext context) {
                _context = context;
            }

            public async Task<Account> Handle(Query request, CancellationToken cancellationToken)
            {
                var account = await _context.Accounts
                    .FindAsync (request.AccountNumber);
                if (account == null) {
                    throw new RestException (HttpStatusCode.NotFound, new { activity = "Not found" });
                }
                return account;
            }

        }
    }
}
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using PantheonBankingSolution.Application.Errors;
using PantheonBankingSolution.Persistance;

namespace PantheonBankingSolution.Application.Accounts
{
    public class Edit
    {
        public class Command : IRequest
        {
            public int AccountNumber{ get; set; }
            public decimal Amount { get; set; }
        }
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.AccountNumber).NotEmpty();
                RuleFor(x => x.Amount).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Command>
        {
            public Handler(DataContext context)
            {
                _context = context;
            }
        
            public DataContext _context { get; }
        
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var account = await _context.Accounts.FindAsync(request.AccountNumber);

                if (account == null)
                {
                    throw new RestException(HttpStatusCode.NotFound, new {activity="Not found"});
                }
                account.CurrentBalance = request.Amount;

                var success = await _context.SaveChangesAsync() > 0;
                if(success) return Unit.Value;
        
                throw new Exception("Problem Saving Changes");
        
            }
        }
    }
}
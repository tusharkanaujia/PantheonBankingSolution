using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PantheonBankingSolution.Application.Accounts;
using PantheonBankingSolution.Application.Transactions;
using PantheonBankingSolution.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accounts = PantheonBankingSolution.Application.Accounts.Details;
using Transactions = PantheonBankingSolution.Application.Transactions.Details;

namespace PantheonBankingSolution.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankingActivityController : BaseController
    {
     
        private readonly ILogger<BankingActivityController> _logger;

        public BankingActivityController(ILogger<BankingActivityController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<Account>> GetBalance(int accountNumber)
        {
            return await Mediator.Send(new Accounts.Query { AccountNumber = accountNumber });
        }

        [HttpGet]
        public async Task<ActionResult<List<Transaction>>> GetLatestTransaction(int accountNumber)
        {
            return await Mediator.Send(new Transactions.Query { AccountNumber = accountNumber });

        }

        [HttpPut]
        public async Task<ActionResult<Unit>> Withdraw(int accountNumber, decimal amount)
        {
            return await Mediator.Send(new Edit.Command { AccountNumber = accountNumber, Amount = -1 * amount });
        }

        [HttpPut]
        public async Task<ActionResult<Unit>> Deposit(int accountNumber, decimal amount)
        {
            return await Mediator.Send(new Edit.Command { AccountNumber = accountNumber, Amount = amount });
        }
    }
}

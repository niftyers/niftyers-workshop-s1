using Microsoft.AspNetCore.Mvc;
using RuralBank;

namespace Niftyers {

    [ApiController]
    [Route("[controller]")]
    public class RuralController : ControllerBase {

        public static List<BankAccount> Accounts = new List<BankAccount>();

        public IActionResult AccountList() {
            return Ok(Accounts);
        }

        [HttpPost("Create")]
        public IActionResult Create(string Name, double InitialDeposit) {

            var newAccount = new BankAccount();

            newAccount.Name = Name;
            newAccount.No = Guid.NewGuid().ToString();
            newAccount.Balance = newAccount.Balance + InitialDeposit;

            Accounts.Add(newAccount);

            return Ok(newAccount);
        }

 
        [HttpPost("Deposit")]
        public IActionResult Deposit(string No, double Amount) {

            var currentAccount = Accounts.Find(account => account.No == No);

            if (currentAccount == null) return Ok("Invalid Account");

            currentAccount.Balance = currentAccount.Balance + Amount;

            return Ok(currentAccount);
        }


        [HttpPost("Withraw")]
        public IActionResult Withraw(string No, double Amount) {

             var currentAccount = Accounts.Find(account => account.No == No);

            if (currentAccount == null) return Ok("Invalid Account");
            if (currentAccount.Balance < Amount) return Ok("Insufficient Balace");

            currentAccount.Balance = currentAccount.Balance - Amount;

            return Ok(currentAccount);
        }


    }

}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Programmentwurf_BankingApi._3Domain.Others;
using Programmentwurf_BankingApi.Domain.Entities;
using Programmentwurf_BankingApi.Domain.Repositories;
using Programmentwurf_BankingApi.Plugin.Konto;
using Programmentwurf_BankingApi.Plugin.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Programmentwurf_BankingApi.Plugin.Transaction
{
    public class TransactionRepositoryBridge : TransactionRepository
    {
        private BankingContext Context;
        private KontoRepositoryBridge KontoRepositoryBridge;
        private readonly IMailService MailService;
        private readonly UserRepositoryBridge UserRepositoryBridge;

        public TransactionRepositoryBridge(
            BankingContext context, 
            KontoRepositoryBridge kontoRepositoryBridge, 
            IMailService mailService, 
            UserRepositoryBridge userRepositoryBridge)
        {
            Context = context;
            KontoRepositoryBridge = kontoRepositoryBridge;
            MailService = mailService;
            UserRepositoryBridge = userRepositoryBridge;
        }

        public async Task<List<TransactionEntity>> getAllTransactions(int kontoid)
        {
            var transactionIds = new List<int>();
            foreach(var transaction in Context.Transaction)
            {
                if (transaction.TransactionInfo.getKontoIdSender() == kontoid || transaction.TransactionInfo.getKontoIdEmpfänger() == kontoid)
                {
                    transactionIds.Add(transaction.Id);
                }
            }
            var list = new List<TransactionEntity>();
            foreach(var id in transactionIds)
            {
                var transaction = await findById(id);
                list.Add(transaction);
            }
            return list;
        }

        public async void create(TransactionEntity transaction)
        {
            
            var senderKonto = await KontoRepositoryBridge.findById(transaction.TransactionInfo.getKontoIdSender());
            var empfängerKonto = await KontoRepositoryBridge.findById(transaction.TransactionInfo.getKontoIdEmpfänger());

            senderKonto.Kontostand -= transaction.TransactionInfo.getBetrag();
            empfängerKonto.Kontostand += transaction.TransactionInfo.getBetrag();

            try
            {
                Context.Entry(senderKonto).State = EntityState.Modified;
                Context.Entry(empfängerKonto).State = EntityState.Modified;
                Context.Transaction.Add(transaction);
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KontoRepositoryBridge.KontoEntityExists(senderKonto.Id) || !KontoRepositoryBridge.KontoEntityExists(empfängerKonto.Id))
                {
                    System.Console.WriteLine("One konto doesn't exist");
                }
                else
                {
                    throw;
                }
            }
        }
        public async Task<TransactionEntity> findById(int transactionid)
        {
            var transactionEntity = await Context.Transaction.FindAsync(transactionid);
            if (transactionEntity == null)
            {
                System.Console.WriteLine("Transaction not found");
            }
            return transactionEntity;
        }

        public async Task<IActionResult> getTransactionsAsMail(int kontoid) 
        {
            var konto = await KontoRepositoryBridge.findById(kontoid);
            var transactions = await getAllTransactions(kontoid);
            var owner = await UserRepositoryBridge.findById(konto.UserId);

            var mailRequest = new MailRequest();
            mailRequest.ToEmail = owner.Email;
            mailRequest.Subject = "Transactions of konto with id: " + kontoid;
            mailRequest.Body += "Konto: " + konto.Id + " contains following amount of money: " + konto.Kontostand + "\n"; 
            foreach(var transaction in transactions) 
            {
                mailRequest.Body += transaction.Date.ToString() + ": " + transaction.Id.ToString() + ": " + 
                    transaction.TransactionInfo.getBetrag() + "€ from Konto: " + 
                    transaction.TransactionInfo.getKontoIdSender() + 
                    " to Konto:" + transaction.TransactionInfo.getKontoIdEmpfänger() + "\n";
            }

            try
            {
                await MailService.SendEmailAsync(mailRequest);
                return new OkObjectResult("Email sent");
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Programmentwurf_BankingApi.Plugin.Konto;
using Programmentwurf_BankingApi.Plugin.User;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using _3_Domain.Domain.Aggregates;
using _3_Domain.Domain.Entities;
using _3_Domain.Domain.Others;
using _3_Domain.Domain.Others.Email;
using _3_Domain.Domain.Repositories;

namespace Programmentwurf_BankingApi.Plugin.Transaction
{
    public class TransactionRepositoryImpl : TransactionRepository
    {
        private IBankingContext _context;
        private KontoRepositoryImpl KontoRepositoryImpl;
        private readonly IMailService MailService;
        private readonly UserRepositoryImpl UserRepositoryImpl;

        public TransactionRepositoryImpl(
            IBankingContext context, 
            KontoRepositoryImpl kontoRepositoryImpl, 
            IMailService mailService, 
            UserRepositoryImpl userRepositoryImpl)
        {
            _context = context;
            KontoRepositoryImpl = kontoRepositoryImpl;
            MailService = mailService;
            UserRepositoryImpl = userRepositoryImpl;
        }

        public async Task<List<TransactionAggregate>> getAllTransactions(int kontoid)
        {
            var transactionIds = new List<int>();
            foreach(var transaction in _context.Transaction)
            {
                if (transaction.TransactionInfo.getKontoIdSender() == kontoid || 
                    transaction.TransactionInfo.getKontoIdEmpfänger() == kontoid)
                {
                    transactionIds.Add(transaction.Id);
                }
            }
            var list = new List<TransactionAggregate>();
            foreach(var id in transactionIds)
            {
                var transaction = await findById(id);
                list.Add(transaction);
            }
            return list;
        }

        public async Task<bool> überweisen(TransactionAggregate transaction)
        {
            
            var senderKonto = await KontoRepositoryImpl.findById(transaction.TransactionInfo.getKontoIdSender());
            var empfängerKonto = await KontoRepositoryImpl.findById(transaction.TransactionInfo.getKontoIdEmpfänger());

            senderKonto.Kontostand -= transaction.TransactionInfo.getBetrag();
            empfängerKonto.Kontostand += transaction.TransactionInfo.getBetrag();

            try
            {
                _context.Update(senderKonto);
                _context.Update(empfängerKonto);

                _context.Transaction.Add(transaction);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KontoRepositoryImpl.KontoEntityExists(senderKonto.Id) || 
                    !KontoRepositoryImpl.KontoEntityExists(empfängerKonto.Id))
                {
                    System.Console.WriteLine("One konto doesn't exist");
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }
        public async Task<TransactionAggregate> findById(int transactionid)
        {
            var transactionEntity = await _context.Transaction.FindAsync(transactionid);
            if (transactionEntity == null)
            {
                System.Console.WriteLine("Transaction not found");
            }
            return transactionEntity;
        }

        public async Task<IActionResult> getTransactionsAsMail(int kontoid) 
        {
            var konto = await KontoRepositoryImpl.findById(kontoid);
            var transactions = await getAllTransactions(kontoid);
            var owner = await UserRepositoryImpl.findById(konto.UserId);

            var mailRequest = CreateMailRequest(kontoid, owner, konto, transactions);

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

        private static MailRequest CreateMailRequest(int kontoid, UserEntity owner, KontoEntity konto, List<TransactionAggregate> transactions)
        {
            var mailRequest = new MailRequest();
            mailRequest.ToEmail = owner.Email;
            mailRequest.Subject = "Transactions of konto with id: " + kontoid;
            mailRequest.Body += "Konto: " + konto.Id + " contains following amount of money: " + konto.Kontostand + "\n";
            foreach (var transaction in transactions)
            {
                mailRequest.Body += transaction.TransactionInfo.getDate().ToString(CultureInfo.InvariantCulture) + ": " + transaction.Id + ": " +
                                    transaction.TransactionInfo.getBetrag() + "€ from Konto: " +
                                    transaction.TransactionInfo.getKontoIdSender() +
                                    " to Konto:" + transaction.TransactionInfo.getKontoIdEmpfänger() + "\n";
            }

            return mailRequest;
        }
    }
}

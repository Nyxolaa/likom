using erp_likom_model.DTOs;
using erp_likom_model.Models;
using erp_likom_repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erp_likom_business
{
    public class FinancialTransactionService : IFinancialTransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public FinancialTransactionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        private FinancialTransactionDto ToDTO(FinancialTransaction transaction) => new FinancialTransactionDto
        {
            Id = transaction.Id,
            OrderId = transaction.OrderId,
            TransactionDate = transaction.TransactionDate,
            Amount = transaction.Amount,
            TransactionType = transaction.TransactionType,
            Description = transaction.Description
        };

        private FinancialTransaction ToDomainModel(FinancialTransactionDto dto) => new FinancialTransaction
        {
            Id = dto.Id,
            OrderId = dto.OrderId,
            TransactionDate = dto.TransactionDate,
            Amount = dto.Amount,
            TransactionType = dto.TransactionType,
            Description = dto.Description
        };
        
        private FinancialTransaction ToDomainModel(FinancialTransactionCreateDto dto) => new FinancialTransaction
        {
            OrderId = dto.OrderId,
            TransactionDate = dto.TransactionDate,
            Amount = dto.Amount,
            TransactionType = dto.TransactionType,
            Description = dto.Description
        };

        public async Task<FinancialTransactionDto> GetByIdAsync(int id)
        {
            var transaction = await _unitOfWork.FinancialTransactions.GetByIdAsync(id);
            return transaction == null ? null : ToDTO(transaction);
        }

        public async Task<IEnumerable<FinancialTransactionDto>> GetByOrderIdAsync(int orderId)
        {
            var transactions = await _unitOfWork.FinancialTransactions.GetByOrderIdAsync(orderId);
            return transactions.Select(ToDTO);
        }

        public async Task CreateAsync(FinancialTransactionCreateDto dto)
        {
            var transaction = ToDomainModel(dto);
            await _unitOfWork.FinancialTransactions.AddAsync(transaction);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(FinancialTransactionDto dto)
        {
            var transaction = ToDomainModel(dto);
            await _unitOfWork.FinancialTransactions.UpdateAsync(transaction);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.FinancialTransactions.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }
    }
}

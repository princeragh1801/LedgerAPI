﻿using LedgerAPI.Contract.Interfaces;
using LedgerAPI.Contract.Model;
using static LedgerAPI.Contract.Enum.Enums;
using LedgerAPI.Contract.Dtos;

namespace LedgerAPI.Provider.Services
{
    public class LedgerService : ILedgerService
    {
        public Ledger AddLedger(AddLedgerDto addLedgerDto)
        {
            bool credit = false;
            if (addLedgerDto.EntityRefType == EntityRefType.Purchase || addLedgerDto.EntityRefType == EntityRefType.Received)
            {
                credit = true;
            }
            var ledgerModel = new Ledger
            {
                CreatedAt = DateTime.Now,
                EntityRefType = addLedgerDto.EntityRefType,
                EntityRefId = addLedgerDto.EntityRefId,
                RefType = addLedgerDto.RefType,
                RefId = addLedgerDto.RefId,
                Particulars = $"By {addLedgerDto.EntityRefType.ToString()}",
                Debit = credit ? null : addLedgerDto.Amount,
                Credit = credit ? addLedgerDto.Amount : null,
            };
            return ledgerModel;
        }

        public ShowLedgerDto ShowLedger(List<LedgerDto> open, List<LedgerDto> close)
        {
            var ledgers = new ShowLedgerDto();
            return ledgers;
        }
    }
}

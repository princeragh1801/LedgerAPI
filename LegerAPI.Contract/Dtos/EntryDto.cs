namespace Ledger.Contract.Dtos
{
    public class EntryDto
    {
        public List<LedgerDto> Ledgers { get; set; }
        public decimal? Credit { get; set; }
        public decimal? Debit { get; set; }
    }
}

namespace LegerAPI.Contract.Dtos
{
    public class ShowLedgerDto
    {
        public List<LedgerDto> ledgers { get; set; }
        public decimal ? Credit {  get; set; }
        public decimal ? Debit {  get; set; }
    }
}

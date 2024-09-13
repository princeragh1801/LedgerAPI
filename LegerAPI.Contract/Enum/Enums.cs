namespace LegerAPI.Contract.Enum
{
    public class Enums
    {
        public enum EntityRefType : byte
        {
            Purchase =0,
            Sale =1,
            Received =2,
            Payment = 3
        }
        public enum RefType : byte
        {
            Customer =0,
            Vendor =1
        }
    }
}

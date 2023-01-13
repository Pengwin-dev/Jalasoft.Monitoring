namespace WACO
{
    public class Payment
    {
        
        public Payment(int ci, double lastAmount, string period)
        {
            this.UserCi = ci;
            this.amount = lastAmount;
            this.period = period;
            paymentExecuted= false;
        }

        public int UserCi { get; set; }
        public double amount { get; set; }
        public bool paymentExecuted { get; set; }
        public string period { get; set; }
    }
}
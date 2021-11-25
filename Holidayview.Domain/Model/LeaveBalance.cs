namespace Holidayview.Domain.Model
{
    public class LeaveBalance
    {
        public int Id { get; set; }
        public double BalanceOfLeave { get; set; } //Saldo urlopu
        public double LeaveLeft { get; set; } //Pozostało urlopu
        public double LeaveTaken { get; set; } //Ilość dni wybranych
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
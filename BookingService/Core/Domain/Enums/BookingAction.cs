namespace Domain.Enums
{
    public enum BookingAction
    {
        Pay = 1,
        Finish = 2, // after paid and used
        Cancel = 3, // can never be paid
        Refound = 4, // paid then refound
        Reopen = 5 // canceled
    }
}
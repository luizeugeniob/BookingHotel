using Domain.Enums;

namespace Domain.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime PlacedAt { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        private BookingStatus Status { get; set; }

        public BookingStatus CurrentStatus
        { get { return this.Status; } }

        public void ChangeState(BookingAction bookingAction)
        {
            this.Status = (this.Status, bookingAction) switch
            {
                (BookingStatus.Created, BookingAction.Pay) => BookingStatus.Paid,
                (BookingStatus.Created, BookingAction.Cancel) => BookingStatus.Canceled,
                (BookingStatus.Paid, BookingAction.Finish) => BookingStatus.Finished,
                (BookingStatus.Paid, BookingAction.Refound) => BookingStatus.Refounded,
                (BookingStatus.Canceled, BookingAction.Reopen) => BookingStatus.Created,
                _ => this.Status
            };
        }
    }
}
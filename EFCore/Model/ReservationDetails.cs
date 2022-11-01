namespace FacilityDbManager.Model
{
    public class ReservationDetails
    {

        public int Id { get; set; }
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; } = null!;
        public int Fac_Id { get; set; }
        public Facility Facility { get; set; } = null!;
        public string Fac_Name { get; set; } = null!;
        public string Fac_ClosestAdr { get; set; } = null!;
        public string Fac_Type { get; set; } = null!;
        public string Fac_Rules { get; set; } = null!;
        public string Fac_Items { get; set; } = null!;
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int CVR { get; set; }
        public int PhoneNumber { get; set; }
    }
}
namespace Entities.Models
{
    public class Talk
    {
        public int CompanyId { get; set; }

        public String? CompanyName { get; set; }
        public String? CompanyLogoUrl { get; set; }

        public int TalkId { get; set; }

        public String? TalkName { get; set; } = String.Empty;

        public String? Explanation { get; set; }

        public String? Employee { get; set; }

        public String? State { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly FinishDate { get; set; }
        public TimeSpan  StartHour { get; set; }

        public TimeSpan FinishHour { get; set; }


    }
}
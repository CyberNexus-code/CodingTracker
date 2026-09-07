

namespace CodingTracker.Entities
{
    internal class CodingSession
    {
        public int Id { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public string? Duration { get; private set; }
    }


}

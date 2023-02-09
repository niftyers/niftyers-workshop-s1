
namespace Niftyers {

    public class Response {
        public bool Success { get; set; } = false;
        public string Message { get; set; } = "";
        public string Stamp { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    }

    public class ResponseAnnouncement : Response {
        public Announcement Data { get; set; } = new Announcement();
    }

    public class ResponseAnnouncementList : Response {
        public IEnumerable<Announcement> Data { get; set; } = new List<Announcement>();
    }
}
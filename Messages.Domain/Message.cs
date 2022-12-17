using System;

namespace Messages.Domain
{
    public class Message
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string UploadUrl { get; set; }
        public bool DeleteAfterUpload { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditTime { get; set; }
    }
}

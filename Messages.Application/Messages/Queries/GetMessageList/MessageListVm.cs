using System.Collections.Generic;

namespace Messages.Application.Messages.Queries.GetMessageList
{
    public class MessageListVm
    {
        public IList<MessageLookupDto> Messages { get; set; }
    }
}

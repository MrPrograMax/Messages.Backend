using Messages.Persistance;
using System;
using System.Collections.Generic;   
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages.Tests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly MessagesDbContext Context;

        public TestCommandBase()
        {
            Context = MessagesContextFactory.Create();
        }

        public void Dispose()
        {
            MessagesContextFactory.Destroy(Context); 
        } //Время видео 6.03
    }
}

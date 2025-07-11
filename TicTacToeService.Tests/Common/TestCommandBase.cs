using TicTacToeService.Utils.Data;

namespace TicTacToeService.Tests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        private readonly DatabaseContext _context;
        
        public TestCommandBase()
        {
            _context = TicTacDatabaseContext.CreateContext();
        }

        protected DatabaseContext Context => _context;

        public void Dispose()
        {
            TicTacDatabaseContext.Destroy(_context);
        }
    }
}

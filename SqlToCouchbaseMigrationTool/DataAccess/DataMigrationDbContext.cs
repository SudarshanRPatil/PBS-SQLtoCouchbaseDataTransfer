using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public sealed class DataMigrationDbContext : IDisposable
    {
                public static void UsingCommonContentDbRead(Action<DataMigrationToolDataContext> action)
        {
            using (var context = new DataMigrationDbContext())
            {
                action(context.Read);
            }
        }

        public static void UsingCommonContentDbWrite(Action<DataMigrationToolDataContext> action)
        {
            using (var context = new DataMigrationDbContext())
            {
                action(context.Write);
            }
        }

        public DataMigrationDbContext()
        {
            if (_stack == null)
            {
                _stack = new Stack<DataMigrationDbContext>();
                this.Depth = 1;
                this.Read = new DataMigrationToolDataContext(DbConfigurations.ReadDataMigrationDatabaseConnection);
                this.Write = new DataMigrationToolDataContext(DbConfigurations.WriteDataMigrationDatabaseConnection);
            }
            else
            {
                var parent = _stack.Peek();
                // Increment level of node.
                this.Depth = parent.Depth + 1;
                // Copy data context from the parent
                this.Read = parent.Read;
                this.Write = parent.Write;
            }
            _stack.Push(this);
        }

        public int Depth { get; private set; }

        public bool IsRoot
        {
            get { return this.Depth == 1; }
        }

        [ThreadStatic] private static Stack<DataMigrationDbContext> _stack;
        public DataMigrationToolDataContext Read { get; private set; }
        public DataMigrationToolDataContext Write { get; private set; }

        public void Dispose()
        {
            var context = _stack.Pop();
            if (context.IsRoot == true)
            {
                context.Read.Dispose();
                context.Write.Dispose();
                _stack = null;
            }
        }
    }
}

using Jason.Redis.Libs.Init;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jason.Redis.Libs.Interface
{
    public abstract class RedisBase : IDisposable
    {
        public IRedisClient IClient { get; private set; }

        /// <summary>
        /// Open Redis when construction
        /// </summary>
        public RedisBase()
        {
            IClient = RedisManager.GetClient();
        }

        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    IClient.Dispose();
                    IClient = null;
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}

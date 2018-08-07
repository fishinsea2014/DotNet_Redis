using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jason.Redis.Libs.Init
{
    /// <summary>
    /// redis configration
    /// Could put into a config file
    /// </summary>
    public sealed class RedisConfigInfo
    {
        /// <summary>
        /// format:ip1,ip2
        /// 
        /// Default port: 6379
        /// </summary>
        public string WriteServerList = "127.0.0.1:6379";
        /// <summary>
        /// Readble Redis Urls        /// 
        /// format:ip1,ip2
        /// </summary>
        public string ReadServerList = "127.0.0.1:6379";
        /// <summary>
        /// Maximum writing connections
        /// </summary>
        public int MaxWritePoolSize = 60;
        /// <summary>
        /// Maximum reading connections
        /// </summary>
        public int MaxReadPoolSize = 60;
        /// <summary>
        /// Local cache life time
        /// </summary>
        public int LocalCacheTime = 180;
        /// <summary>
        /// Auto restart
        /// </summary>
        public bool AutoStart = true;
        /// <summary>
        /// Log or not, only log when problem solving        /// 
        /// </summary>
        public bool RecordeLog = false;
    }
}

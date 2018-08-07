using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Redis;

namespace Jason.Redis.Libs.Init
{
    public class RedisManager
    {
        /// <summary>
        /// Redis configurations
        /// </summary>
        private static RedisConfigInfo RedisConfigInfo = new RedisConfigInfo();

        /// <summary>
        /// Redis client pool manager
        /// </summary>
        private static PooledRedisClientManager prcManager;
        /// <summary>
        /// Static construction method, initiate client pool management object.
        /// </summary>
        static RedisManager()
        {
            CreateManager();
        }

        private static void CreateManager()
        {
            string[] WriteServerConStr = RedisConfigInfo.WriteServerList.Split(',');
            string[] ReadServerConStr = RedisConfigInfo.ReadServerList.Split(',');
            prcManager = new PooledRedisClientManager(ReadServerConStr, WriteServerConStr,
                            new RedisClientManagerConfig
                            {
                                MaxWritePoolSize = RedisConfigInfo.MaxWritePoolSize,
                                MaxReadPoolSize = RedisConfigInfo.MaxReadPoolSize,
                                AutoStart = RedisConfigInfo.AutoStart
        });
        }

        public static IRedisClient GetClient()
        {
            return prcManager.GetClient();
        }
    }
}

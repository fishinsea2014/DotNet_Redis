using Jason.Redis.Libs.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jason.Redis.Libs.Service
{
    public class RedisStringService : RedisBase
    {
        #region The assignment
        /// <summary>
        /// Set the value of a key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Set<T> (string key, T value)
        {
            return base.IClient.Set<T>(key, value);
        }

        /// <summary>
        /// Set the value of key with time
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public bool Set<T> (string key, T value, DateTime dt)
        {
            return base.IClient.Set<T>(key, value, dt);
        }
        /// <summary>
        /// Set the value of a key with expire time
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="sp"></param>
        /// <returns></returns>
        public bool Set<T>(string key, T value, TimeSpan sp)
        {
            return base.IClient.Set<T>(key, value, sp);
        }
        #endregion

        #region Appdending
        /// <summary>
        /// Append value after orginal value.
        /// If original value do not exist, then add a new one.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public long Append (string key, string value)
        {
            return base.IClient.AppendToValue(key, value);
        }

        #endregion
        #region Get values of keys
        /// <summary>
        /// Get the value of a key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string Get(string key)
        {
            return base.IClient.GetValue(key);
        }
        /// <summary>
        /// Get multiple values of a list of keys
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public List<string> Get(List<string> keys)
        {
            return base.IClient.GetValues(keys);
        }

        /// <summary>
        /// Get multiple values of a list of keys in manner of generic
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keys"></param>
        /// <returns></returns>
        public List<string> Get<T>(List<string> keys)
        {
            return base.IClient.GetValues(keys);
        }

        #endregion

        #region Get then set value
        /// <summary>
        /// Get the value of a key and then update the value.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public string GetAndSetValue(string key, string value)
        {
            return base.IClient.GetAndSetValue(key, value);
        }
        #endregion

        #region Helper methods
        /// <summary>
        /// Increments the number stored at key by one.  
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public long Incr (string key)
        {
            return base.IClient.IncrementValue(key);
        }
        /// <summary>
        /// Increments the number stored at key by count. 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public long IncrBy(string key, int count)
        {
            return base.IClient.IncrementValueBy(key,count);
        }
        /// <summary>
        /// Decrements the number stored at key by one.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public long Decr(string key)
        {
            return base.IClient.DecrementValue(key);
        }
        /// <summary>
        /// Decrements the number stored at key by count.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public long DecrBy(string key, int count)
        {
            return base.IClient.DecrementValueBy(key, count);
        }
        #endregion


    }
}

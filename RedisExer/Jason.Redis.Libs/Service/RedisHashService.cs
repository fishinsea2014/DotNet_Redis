using Jason.Redis.Libs.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jason.Redis.Libs.Service
{
    public class RedisHashService : RedisBase
    {
        #region Add new item
        
        /// <summary>
        /// Add a pair of key and value to a harshid item.
        /// </summary>
        /// <param name="hashid"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetEntryInHash (string hashid, string key, string value)
        {
            return base.IClient.SetEntryInHash(hashid, key, value);
        }

        /// <summary>
        /// If a harshid item has key and value, then do nothing and return false
        /// Or add a pair of key and value , and return true
        /// </summary>
        /// <param name="hashid"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetEntryInHashIfNotExists(string hashid, string key, string value)
        {
            return base.IClient.SetEntryInHashIfNotExists(hashid, key, value);
        }
        /// <summary>
        /// Store an object to a hash set
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        public void StoreAsHash<T>(T t)
        {
            base.IClient.StoreAsHash<T>(t);
        }
        #endregion

        #region Retrive data from hash set

        /// <summary>
        /// Get the object of an id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetFromHash<T> (object id)
        {
            return base.IClient.GetFromHash<T>(id);
        }
        /// <summary>
        /// Get all data set of a hasid 
        /// </summary>
        /// <param name="hashid"></param>
        /// <returns></returns>
        public Dictionary<string, string> GetAllEntriesFromHash(string hashid)
        {
            return base.IClient.GetAllEntriesFromHash(hashid);
        }

        /// <summary>
        /// Get the number of data of a hashid
        /// </summary>
        /// <param name="hashid"></param>
        /// <returns></returns>
        public long GetHashCount(string hashid)
        {
            return base.IClient.GetHashCount(hashid);
        }

        /// <summary>
        /// Get the keys of data set of a hashid
        /// </summary>
        /// <param name="hashid"></param>
        /// <returns></returns>
        public List<string> GetHashKeys(string hashid)
        {
            return base.IClient.GetHashKeys(hashid);
        }

        /// <summary>
        /// Get the values of data set of a hashid
        /// </summary>
        /// <param name="hashid"></param>
        /// <returns></returns>
        public List<string> GetHashValues(string hashid)
        {
            return base.IClient.GetHashValues(hashid);
        }
        /// <summary>
        /// Get the value of a key in data set of a hashid
        /// </summary>
        /// <param name="hashid"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetValueFromHash(string hashid, string key)
        {
            return base.IClient.GetValueFromHash(hashid, key);
        }

        /// <summary>
        /// Get the values of a list of keys in data set of a hashid
        /// </summary>
        /// <param name="hashid"></param>
        /// <param name="keys"></param>
        /// <returns></returns>
        public List<string> GetValuesFromHash(string hashid, string[] keys)
        {
            return base.IClient.GetValuesFromHash(hashid, keys);
        }



        #endregion

        #region Delete
        /// <summary>
        /// Delete the value of a key in data set of a hashid
        /// </summary>
        /// <param name="hashid"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool RemoveEntryFromHash (string hashid, string key)
        {
            return base.IClient.RemoveEntryFromHash(hashid, key);
        }
        #endregion

        #region Helper method
        /// <summary>
        /// Add the countby to the value of a key in data set of a hashid. 
        /// </summary>
        /// <param name="hashid"></param>
        /// <param name="key"></param>
        /// <param name="countBy"></param>
        /// <returns></returns>
        public double IncrementValueInHash(string hashid, string key, double countBy)
        {
            return base.IClient.IncrementValueInHash(hashid, key, countBy);
        }
        #endregion

    }
}

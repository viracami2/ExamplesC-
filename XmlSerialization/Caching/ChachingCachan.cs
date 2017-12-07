using System;
using System.Configuration;
using System.Linq;
using System.Runtime.Caching;

namespace XmlSerialization
{

	public static class ChachingCachan//RepositoryBaseCache
	{
		private static readonly ObjectCache _cache = MemoryCache.Default;

		private static double _expirationInMinutes = 0;
		private static double ExpirationInMinutes
		{
			get
			{
				if (_expirationInMinutes == 0)
				{
					_expirationInMinutes = Convert.ToDouble(ConfigurationManager.AppSettings.Get("Cache.Expiration.Minutes"));
					if (_expirationInMinutes == 0)
					{
						_expirationInMinutes = 5;
					}
				}
				return _expirationInMinutes;
			}
		}

		public static object Get(string key)
		{
			return _cache[key];
		}

		public static void Add(string key, object result, double expirationInMinutes)
		{
			var expiration = expirationInMinutes > 0 ? expirationInMinutes : ExpirationInMinutes;
			CacheItemPolicy policy = new CacheItemPolicy { AbsoluteExpiration = new DateTimeOffset(DateTime.Now.AddMinutes(expiration)) };
			// WARNING: cuando el valor es "null", no acepta guardar items con Set()
			if (result == null)
			{
				_cache.Remove(key);
			}
			else
			{
				_cache.Set(key, result, policy);
			}
		}

		public static string GetKeyName(CacheKeyNameEnum cacheKeyName, params object[] cacheKeyParams)
		{
			var key = string.Join("-", cacheKeyParams.Select(t => t?.ToString()));
			return $"{cacheKeyName}-{key}";
		}

		public static void Remove(CacheKeyNameEnum cacheKeyName, params object[] cacheKeyParams)
		{
			var key = GetKeyName(cacheKeyName, cacheKeyParams);
			_cache.Remove(key);
		}

		public static void Remove(string key)
		{
			_cache.Remove(key);
		}
	}
	public enum CacheKeyNameEnum
	{
		hayCache
	}



}

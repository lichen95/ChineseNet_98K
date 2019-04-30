using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChineseNet_98K.Reception.Content
{
    public class CommonManager
    {
        private static readonly object lockobj = new object();
        private static volatile Cache _cache = null;
        /// <summary>
        /// Cache
        /// </summary>
        public static Cache CacheObj
        {
            get
            {
                if (_cache == null)
                {
                    lock (lockobj)
                    {
                        if (_cache == null)
                            _cache = new Cache();
                    }
                }
                return _cache;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChineseNet_98K.Reception.Content
{
    public static class RedisConfig
    {
        public static string configname { get; set; }
        public static string Connection { get; set; }
        public static int DefaultDatabase { get; set; }
        public static string InstanceName { get; set; }
    }
}

using System;

namespace ChineseNet_98K.Common
{
    /// <summary>
    /// BaseRandom
    /// 产生随机数
    /// 随机数管理，最大值、最小值可以自己进行设定。
    /// </summary>
    public class BaseRandom
    {
        private int Minimum { set; get; }
        private int Maximal { set; get; }
        private int RandomLength { set; get; }

        private string RandomString { set; get; } = "0123456789ABCDEFGHIJKMLNOPQRSTUVWXYZ";
        private readonly Random Random = new Random(DateTime.Now.Second);

        #region constructor
        public BaseRandom()
        {
            Minimum = 1;
            Maximal = 9999;
            RandomLength = 6;
        }

        public BaseRandom(int Max, int Min)
        {
            Minimum = Min;
            Maximal = Max;
        }

        public BaseRandom(int Length)
        {
            RandomLength = Length;
        }
        #endregion


        #region public string GetRandomString() 产生随机字符
        /// <summary>
        /// 产生随机字符
        /// </summary>
        /// <returns>字符串</returns>
        public string GetRandomString()
        {
            return GetRandomString(RandomLength);
        }

        public string GetRandomString(int stringLength)
        {
            string returnValue = string.Empty;
            for (int i = 0; i < stringLength; i++)
            {
                int r = Random.Next(0, RandomString.Length - 1);
                returnValue += RandomString[r];
            }
            return returnValue;
        }
        #endregion

        #region public static int GetRandom()
        /// <summary>
        /// 产生随机数
        /// </summary>
        /// <returns>随机数</returns>
        public int GetRandom()
        {
            return Random.Next(Minimum, Maximal);
        }
        #endregion

        #region public static int GetRandom(int minimum, int maximal)
        /// <summary>
        /// 产生随机数
        /// </summary>
        /// <param name="minNumber">最小值</param>
        /// <param name="maxNumber">最大值</param>
        /// <returns>随机数</returns>
        public int GetRandom(int minNumber, int maxNumber)
        {
            return Random.Next(minNumber, maxNumber);
        }
        #endregion

        /// <summary>
        /// 如果你想生成一个数字序列而不是字符串，你将会获得一个19位长的序列。下面的方法会把GUID转换为Int64的数字序列。
        /// </summary>
        /// <returns></returns>
        public static long GenerateIntID()
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            return BitConverter.ToInt64(buffer, 0);
        }
    }
}
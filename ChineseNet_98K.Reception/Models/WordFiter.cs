using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ChineseNet_98K.Reception.Models
{
    public class WordFiter
    {
        //加载appsetting.json
        static IConfiguration configuration = new ConfigurationBuilder()
         .SetBasePath(Directory.GetCurrentDirectory())
         .AddJsonFile("appsettings.json").Build();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text">文本</param>
        /// <returns></returns>
        public string GetValues(string text)
        {
            Dictionary<int, List<string>> dicList = new Dictionary<int, List<string>>();
            System.Text.StringBuilder sb = new System.Text.StringBuilder(text.Length);
            string filterText = "中国|共产党|操|日|操你妈";
            //脏字 可根据自己的方式用分隔符
            string[] filterData = filterText.Split('|');
            foreach (var item in filterData)
            {
                char value = item[0];
                if (dicList.ContainsKey(value))
                    dicList[value].Add(item);
                else
                    dicList.Add(value, new List<string>() { item });
            }
            int count = text.Length;
            for (int i = 0; i < count; i++)
            {
                char word = text[i];
                if (dicList.ContainsKey(word))//如果在字典表中存在这个key
                {
                    int num = 0;//是否找到匹配的关键字 1找到0未找到
                    var data = dicList[word].OrderBy(g => g.Length);
                    //把该key的字典集合按 字符数排序(方便下面从少往多截取字符串查找)
                    foreach (var wordbook in data)
                    {
                        if (i + wordbook.Length <= count)
                        //如果需截取的字符串的索引小于总长度 则执行截取
                        {
                            string result = text.Substring(i, wordbook.Length);
                            //根据关键字长度往后截取相同的字符数进行比较
                            if (result == wordbook)
                            {
                                num = 1;
                                sb.Append(GetString(result));
                                i = i + wordbook.Length - 1;
                                //比较成功 同时改变i的索引
                                break;
                            }
                        }
                    }
                    if (num == 0)
                        sb.Append(word);
                }
                else
                    sb.Append(word);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 替换星号
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string GetString(string value)
        {
            string starNum = string.Empty;
            for (int i = 0; i < value.Length; i++)
            {
                starNum += "*";
            }
            return starNum;
        }
    }
}

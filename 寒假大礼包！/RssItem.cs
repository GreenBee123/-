using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Text.RegularExpressions;

namespace 寒假大礼包_
{
    public class RssItem//RSS文章内容实体类封装
    {
        /// <summary>
        /// 初始化一个RSS目录
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="summary">内容</param>
        /// <param name="publishedDate">发表时间</param>
        /// <param name="url">文章地址</param>
        public RssItem(string title, string summary, string publishedDate, string url)
        {
            Title = title;
            Summary = summary;
            PublishedDate = publishedDate;
            Url = url;
            //解析html
            PlainSummary = WebUtility.HtmlDecode(Regex.Replace(summary, "<[^>]+?>", ""));
        }

        public string Title { get; set; }//标题

        public string Summary { get; set; }//内容

        public string PublishedDate { get; set; }//发表时间

        public string Url { get; set; }//文章地址

        public string PlainSummary { get; set; }//解析的文本内容
    }
}

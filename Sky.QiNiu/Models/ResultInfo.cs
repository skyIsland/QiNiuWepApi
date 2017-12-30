using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sky.QiNiu.Models
{
    /// <summary>
    /// 请求返回类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResultInfo<T>
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        public bool Result { get; set; } = false;
        /// <summary>
        /// 返回信息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 返回数据
        /// </summary>
        public T Data { get; set; }
    }
}
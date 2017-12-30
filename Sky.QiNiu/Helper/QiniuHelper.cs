using Qiniu.Storage;
using Qiniu.Util;
using Sky.QiNiu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Qiniu.Http;

namespace Sky.QiNiu.Helper
{
    /// <summary>
    /// 七牛上传辅助类
    /// </summary>
    public class QiniuHelper
    {
        private string AccessKey;
        private string SecretKey;
        private string Bucket;
        private Mac mac;
        public QiniuHelper(string accessKey, string secretKey, string bucket)
        {
            if (string.IsNullOrEmpty(AccessKey))
            {
                if (string.IsNullOrEmpty(accessKey))
                {
                    throw new ArgumentNullException(nameof(accessKey));
                }
                AccessKey = accessKey;
            }

            if (string.IsNullOrEmpty(SecretKey))
            {
                if (string.IsNullOrEmpty(secretKey))
                {
                    throw new ArgumentNullException(nameof(secretKey));
                }
                SecretKey = secretKey;
            }

            if (string.IsNullOrEmpty(Bucket))
            {
                if (string.IsNullOrEmpty(bucket))
                {
                    throw new ArgumentNullException(nameof(bucket));
                }
                Bucket = bucket;
            }

            // 实例化密钥类
            mac = new Mac(accessKey, secretKey);
        }
        public ResultInfo<object> UploadFiles(HttpPostedFile file)
        {
          
            if (file == null || file.ContentLength == 0)
            {
                return new ResultInfo<object> { Message = "请先选择文件或者选择文件大小为0" };
            }

            // 实例化文件信息
            var fileInfo = new System.IO.FileInfo(file.FileName);

            // 文件名
            var key = fileInfo.Name;

            // 上传策略 必须参数:Scope,deadline(默认值一个小时)
            var putPolicy = new PutPolicy();
            putPolicy.Scope = Bucket + ":" + key;// 指定上传的目标资源空间 Bucket 和资源键 Key（最大为 750 字节）
            putPolicy.SetExpires(3600);// 上传凭证有效时间 配置Deadline属性

            // 生成上传凭证 todo:不用每次上传都生成一个新的凭证
            var uploadToken = Auth.CreateUploadToken(mac, putPolicy.ToJsonString());

            //网络区域配置信息
            var config = new Config();
            config.Zone = Zone.ZONE_CN_East;// 设置上传区域
            config.UseHttps = true;// 采用https域名
            config.UseCdnDomains = true;// 采用cdn加速域名
            config.ChunkSize = ChunkUnit.U512K;// 分片上传对象

            // 实例化表单上传类
            var target = new FormUploader(config);
            var targetResult = target.UploadStream(file.InputStream,key, uploadToken, null);
            return SimpleMap(targetResult);
        }
        private ResultInfo<object> SimpleMap(HttpResult res)
        {
            var result = new ResultInfo<object>();
            //结果判断
            switch (res.Code)
            {
                //上传成功
                case 200:
                    result.Data = new
                    {
                        Date = DateTime.Now.ToString("yyyy年MM月dd日"),
                        Moment = DateTime.Now.ToString("HH:mm tt").Replace("上午", "AM").Replace("下午", "PM"),
                    };
                    result.Result = true;
                    break;
                case 403:
                    result.Message = "不允许的文件格式上传";
                    break;
                case 413:
                    result.Message = "文件大小超过限制";
                    break;
                case 612:
                    result.Message = "文件已存在";
                    break;
                default:
                    result.Message = "文件上传失败";
                    break;
            }
            return result;
        }
    }
}
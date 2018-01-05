using Qiniu.Http;
using Qiniu.Storage;
using Qiniu.Util;
using Sky.QiNiu.Helper;
using Sky.QiNiu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Sky.QiNiu.Controllers
{
    public class ManagerController : ApiController
    {
        private QiniuHelper client;
        private ManagerController()
        {
            string accessKey = System.Configuration.ConfigurationManager.AppSettings["AccessKey"];
            string secretKey = System.Configuration.ConfigurationManager.AppSettings["SecretKey"];
            string bucket= System.Configuration.ConfigurationManager.AppSettings["Bucket"];
            client = new QiniuHelper(accessKey, secretKey, bucket);
        }
        [HttpGet]
        [Route("Api/UploadFile")]
        public string UploadFile(string filePath)
        {
            Mac mac = new Mac("", "");
            // 上传文件名
            string key = "key";
            // 本地文件路径           
            // 存储空间名
            string Bucket = "file";
            // 设置上传策略，详见：https://developer.qiniu.com/kodo/manual/1206/put-policy
            PutPolicy putPolicy = new PutPolicy();
            putPolicy.Scope = Bucket;
            putPolicy.SetExpires(3600);
            putPolicy.DeleteAfterDays = 1;
            string token = Auth.CreateUploadToken(mac, putPolicy.ToJsonString());
            Config config = new Config();
            // 设置上传区域
            config.Zone = Zone.ZONE_CN_East;
            // 设置 http 或者 https 上传
            config.UseHttps = true;
            config.UseCdnDomains = true;
            config.ChunkSize = ChunkUnit.U512K;
            // 表单上传
            FormUploader target = new FormUploader(config);
            HttpResult result = target.UploadFile(filePath, key, token, null);

            return result.ToString();
        }
        /// <summary>
        /// 单文件上传
        /// </summary>
        /// <returns></returns>
        [Route("Api/UploadFiles")]
        public ResultInfo<object> UploadFiles()
        {
            var result = client.UploadFiles(HttpContext.Current.Request.Files[0]);
            return result;
        }
    }
}

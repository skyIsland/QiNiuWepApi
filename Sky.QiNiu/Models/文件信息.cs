using System;
using System.Collections.Generic;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Sky.Models
{
    /// <summary>文件信息</summary>
    [Serializable]
    [DataObject]
    [Description("文件信息")]
    [BindTable("FilesInfo", Description = "文件信息", ConnName = "Conn", DbType = DatabaseType.SqlServer)]
    public partial class FilesInfo : IFilesInfo
    {
        #region 属性
        private Int32 _Id;
        /// <summary>Id</summary>
        [DisplayName("Id")]
        [Description("Id")]
        [DataObjectField(true, true, false, 0)]
        [BindColumn("Id", "Id", "int")]
        public Int32 Id { get { return _Id; } set { if (OnPropertyChanging(__.Id, value)) { _Id = value; OnPropertyChanged(__.Id); } } }

        private String _Name;
        /// <summary>文件名称</summary>
        [DisplayName("文件名称")]
        [Description("文件名称")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn("Name", "文件名称", "nvarchar(500)", Master = true)]
        public String Name { get { return _Name; } set { if (OnPropertyChanging(__.Name, value)) { _Name = value; OnPropertyChanged(__.Name); } } }

        private String _InfoID;
        /// <summary>Guid</summary>
        [DisplayName("Guid")]
        [Description("Guid")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("InfoID", "Guid", "nvarchar(50)")]
        public String InfoID { get { return _InfoID; } set { if (OnPropertyChanging(__.InfoID, value)) { _InfoID = value; OnPropertyChanged(__.InfoID); } } }

        private String _FilePath;
        /// <summary>文件链接</summary>
        [DisplayName("文件链接")]
        [Description("文件链接")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("FilePath", "文件链接", "nvarchar(50)")]
        public String FilePath { get { return _FilePath; } set { if (OnPropertyChanging(__.FilePath, value)) { _FilePath = value; OnPropertyChanged(__.FilePath); } } }

        private String _FileSize;
        /// <summary>文件大小</summary>
        [DisplayName("文件大小")]
        [Description("文件大小")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("FileSize", "文件大小", "nvarchar(50)")]
        public String FileSize { get { return _FileSize; } set { if (OnPropertyChanging(__.FileSize, value)) { _FileSize = value; OnPropertyChanged(__.FileSize); } } }

        private Boolean _IsImage;
        /// <summary>是否为图片</summary>
        [DisplayName("是否为图片")]
        [Description("是否为图片")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("IsImage", "是否为图片", "bit")]
        public Boolean IsImage { get { return _IsImage; } set { if (OnPropertyChanging(__.IsImage, value)) { _IsImage = value; OnPropertyChanged(__.IsImage); } } }

        private DateTime _AddTime;
        /// <summary>添加时间</summary>
        [DisplayName("添加时间")]
        [Description("添加时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("AddTime", "添加时间", "datetime")]
        public DateTime AddTime { get { return _AddTime; } set { if (OnPropertyChanging(__.AddTime, value)) { _AddTime = value; OnPropertyChanged(__.AddTime); } } }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        public override Object this[String name]
        {
            get
            {
                switch (name)
                {
                    case __.Id : return _Id;
                    case __.Name : return _Name;
                    case __.InfoID : return _InfoID;
                    case __.FilePath : return _FilePath;
                    case __.FileSize : return _FileSize;
                    case __.IsImage : return _IsImage;
                    case __.AddTime : return _AddTime;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.Id : _Id = Convert.ToInt32(value); break;
                    case __.Name : _Name = Convert.ToString(value); break;
                    case __.InfoID : _InfoID = Convert.ToString(value); break;
                    case __.FilePath : _FilePath = Convert.ToString(value); break;
                    case __.FileSize : _FileSize = Convert.ToString(value); break;
                    case __.IsImage : _IsImage = Convert.ToBoolean(value); break;
                    case __.AddTime : _AddTime = Convert.ToDateTime(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得文件信息字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>Id</summary>
            public static readonly Field Id = FindByName(__.Id);

            /// <summary>文件名称</summary>
            public static readonly Field Name = FindByName(__.Name);

            /// <summary>Guid</summary>
            public static readonly Field InfoID = FindByName(__.InfoID);

            /// <summary>文件链接</summary>
            public static readonly Field FilePath = FindByName(__.FilePath);

            /// <summary>文件大小</summary>
            public static readonly Field FileSize = FindByName(__.FileSize);

            /// <summary>是否为图片</summary>
            public static readonly Field IsImage = FindByName(__.IsImage);

            /// <summary>添加时间</summary>
            public static readonly Field AddTime = FindByName(__.AddTime);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得文件信息字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>Id</summary>
            public const String Id = "Id";

            /// <summary>文件名称</summary>
            public const String Name = "Name";

            /// <summary>Guid</summary>
            public const String InfoID = "InfoID";

            /// <summary>文件链接</summary>
            public const String FilePath = "FilePath";

            /// <summary>文件大小</summary>
            public const String FileSize = "FileSize";

            /// <summary>是否为图片</summary>
            public const String IsImage = "IsImage";

            /// <summary>添加时间</summary>
            public const String AddTime = "AddTime";
        }
        #endregion
    }

    /// <summary>文件信息接口</summary>
    public partial interface IFilesInfo
    {
        #region 属性
        /// <summary>Id</summary>
        Int32 Id { get; set; }

        /// <summary>文件名称</summary>
        String Name { get; set; }

        /// <summary>Guid</summary>
        String InfoID { get; set; }

        /// <summary>文件链接</summary>
        String FilePath { get; set; }

        /// <summary>文件大小</summary>
        String FileSize { get; set; }

        /// <summary>是否为图片</summary>
        Boolean IsImage { get; set; }

        /// <summary>添加时间</summary>
        DateTime AddTime { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}
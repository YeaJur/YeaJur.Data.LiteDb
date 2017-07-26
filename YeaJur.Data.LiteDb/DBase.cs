#region YeaJur.Data.LiteDb 4.0

/***
 * 本代码版权归  侯兴鼎（YeaJur）  所有，All Rights Reserved (C) 2017
 * CLR版本：4.0.30319.42000
 * 唯一标识：86a69b43-0c58-4e00-922b-4146e58899e1
 **
 * 所属域：DESKTOP-Q9MAAK4
 * 机器名称：DESKTOP-Q9MAAK4
 * 登录用户：houxi
 * 创建时间：2017/5/24 20:47:23
 * 创建人：侯兴鼎（YeaJur）
 * E_mail：houxingding@hotmail.com
 **
 * 命名空间：YeaJur.Data.LiteDb
 * 类名称：DBase
 * 文件名：DBase
 * 文件描述：
 ***/

#endregion

using LiteDB;

namespace YeaJur.Data.LiteDb
{
    /// <summary>
    /// LiteDb 数据库
    /// </summary>
	public class DBase
    {

        private ObjectId _id;

        private string _idstr;

        /// <summary>
        /// Id 的字符串
        /// </summary>
        [BsonIgnore]
        public string IdString
        {
            get => _id?.ToString();
            set
            {
                _idstr = value;
                if (!string.IsNullOrEmpty(_idstr))
                    _id = new ObjectId(_idstr);
            }
        }

        /// <summary>
        /// 主键
        /// </summary>
        [BsonId]
        public ObjectId Id
        {
            get => _id; set
            {
                _id = value;
                _idstr = _id.ToString();
            }
        }
    }
}
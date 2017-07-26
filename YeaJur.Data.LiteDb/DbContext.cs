#region YeaJur.Data.LiteDb 4.0.30319.42000

/***
 *
 *	本代码版权归  侯兴鼎（YeaJur） 所有，All Rights Reserved (C) 2017
 * 	CLR版本：4.0.30319.42000
 *	唯一标识：dd2b5d8b-e90a-4a03-a2fc-d85837804070
 **
 *	所属域：DESKTOP-Q9MAAK4
 *	机器名称：DESKTOP-Q9MAAK4
 *	登录用户：houxi
 *	创建时间：2017/4/5 20:32:03
 *	作者：侯兴鼎（YeaJur）
 *	E_mail：houxingding@hotmail.com
 **
 *	命名空间：YeaJur.Data.LiteDb
 *	类名称：DbContext
 *	文件名：DbContext
 *	文件描述：
 *
 ***/

#endregion

using System;
using LiteDB;

namespace YeaJur.Data.LiteDb
{
    /// <summary>
    /// LiteDB数据库上下文
    /// </summary>
    public class DbContext : IDisposable
    {
        /// <summary>
        /// MyDb 唯一实例
        /// </summary>
        private static DbContext _mongoDbContext;

        /// <summary>
        /// 对象锁
        /// </summary>
        private static readonly object SyncObject = new object();

        /// <summary>
        /// 数据库实例对象
        /// </summary>
        public LiteDatabase DataBase { get; set; }

        public static DbContext Context(string connectionString, BsonMapper mapper = null)
        {

            if (_mongoDbContext != null) return _mongoDbContext;
            lock (SyncObject)
            {

                return _mongoDbContext ?? (_mongoDbContext = new DbContext(connectionString, mapper));
            }
        }

        /// <summary>
        /// 获取数据库实例对象
        /// </summary>
        /// <param name="connectionString">数据库连接串</param>
        /// <param name="mapper">数据映射</param>
        private DbContext(string connectionString, BsonMapper mapper = null)
        {
            DataBase = new LiteDatabase(connectionString, mapper);
        }

        public void Dispose()
        {
            //通知垃圾回收机制不再调用终结器（析构器）
            GC.SuppressFinalize(this);
        }
    }
}
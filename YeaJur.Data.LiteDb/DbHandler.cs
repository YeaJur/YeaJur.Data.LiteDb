#region YeaJur.Data.LiteDb 4.0

/***
 * 本代码版权归  侯兴鼎（YeaJur）  所有，All Rights Reserved (C) 2017
 * CLR版本：4.0.30319.42000
 * 唯一标识：723fcba6-58a4-4ab3-bb82-7962e1d16a76
 **
 * 所属域：DESKTOP-Q9MAAK4
 * 机器名称：DESKTOP-Q9MAAK4
 * 登录用户：houxi
 * 创建时间：2017/7/26 21:44:02
 * 创建人：侯兴鼎（YeaJur）
 * E_mail：houxingding@hotmail.com
 **
 * 命名空间：YeaJur.Data.LiteDb
 * 类名称：DbHandler
 * 文件名：DbHandler
 * 文件描述：
 ***/

#endregion

using LiteDB;
using System.Collections.Generic;

namespace YeaJur.Data.LiteDb
{
    /// <summary>
    /// LiteDb数据处理类
    /// </summary>
    /// <typeparam name="TDocument"></typeparam>
    public static class DbHandler<TDocument> where TDocument : class, new()
    {
        public static LiteCollection<TDocument> Collection
        {
            get
            {
                var db = new DbCollection<TDocument>();
                return db.Collection;
            }
        }

        public static LiteCollection<TDocument> GetCollection(string dbName)
        {

            var db = new DbCollection<TDocument>(dbName);
            return db.Collection;
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <typeparam name="TResult">返回结果数据类型</typeparam>
        /// <param name="model">将要添加的数据</param>
        /// <returns></returns>
        public static BsonValue Add(TDocument model)
        {
            var db = new DbCollection<TDocument>();
            var id = db.Collection.Insert(model);
            return id;
        }
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <typeparam name="TResult">返回结果数据类型</typeparam>
        /// <param name="model">将要添加的数据</param>
        /// <returns></returns>
        public static bool Adds(List<TDocument> list)
        {
            var db = new DbCollection<TDocument>();
            return db.Collection.Insert(list) > 0;
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <typeparam name="TResult">返回结果数据类型</typeparam>
        /// <param name="id">数据主键</param>
        /// <param name="data">需要更新的数据集合</param>
        /// <returns></returns>
        public static bool Update(TDocument model)
        {
            var db = new DbCollection<TDocument>();
            return db.Collection.Update(model);
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <typeparam name="TResult">返回结果数据类型</typeparam>
        /// <param name="id">数据主键</param>
        /// <param name="data">需要更新的数据集合</param>
        /// <returns></returns>
        public static bool Updates(List<TDocument> list)
        {
            var db = new DbCollection<TDocument>();
            return db.Collection.Update(list) > 0;
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <typeparam name="TResult">返回结果数据类型</typeparam>
        /// <param name="id">数据主键</param>
        /// <returns></returns>
        public static bool Delete(ObjectId id)
        {
            var db = new DbCollection<TDocument>();
            return db.Collection.Delete(id);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">数据主键</param>
        /// <returns></returns>
        public static TDocument GetModel(ObjectId id)
        {
            var db = new DbCollection<TDocument>();
            return db.Collection.FindById(id);
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <typeparam name="T">过滤器类型</typeparam>
        /// <param name="filter">过滤器</param>
        /// <returns></returns>
        public static IEnumerable<TDocument> GetList()
        {
            var db = new DbCollection<TDocument>();

            return db.Collection.FindAll();
        }
    }
}
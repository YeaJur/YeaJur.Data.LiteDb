#region YeaJur.Data.LiteDb 4.0.30319.42000

/***
 *
 *	本代码版权归  侯兴鼎（YeaJur） 所有，All Rights Reserved (C) 2017
 * 	CLR版本：4.0.30319.42000
 *	唯一标识：bbf1d394-60e4-42b4-9441-5cb966a99bb8
 **
 *	所属域：DESKTOP-Q9MAAK4
 *	机器名称：DESKTOP-Q9MAAK4
 *	登录用户：houxi
 *	创建时间：2017/4/5 20:37:59
 *	作者：侯兴鼎（YeaJur）
 *	E_mail：houxingding@hotmail.com
 **
 *	命名空间：YeaJur.Data.LiteDb
 *	类名称：DbCollection
 *	文件名：DbCollection
 *	文件描述：
 *
 ***/

#endregion

using LiteDB;
using System.IO;

namespace YeaJur.Data.LiteDb
{
    /// <summary>
    /// LiteDb实例对象设置集合实体
    /// <typeparam name="T"></typeparam>
    /// </summary>
    public class DbCollection<T> where T : new()
    {

        /// <summary>
        /// 数据库实例对象
        /// </summary>
        public LiteDatabase DataBase { get; }

        /// <summary>
        /// 数据库集合对象集合
        /// </summary>
        public LiteCollection<T> Collection { get; }
        /// <summary>
        /// 构建DbLite实例对象设置集合实体
        /// </summary>
        public DbCollection()
        {
            var path = $"{Directory.GetCurrentDirectory()}\\data\\";
 
            if (!File.Exists(path))//如果不存在就创建file文件夹
            {
                if (!Directory.Exists(path))//如果不存在就创建file文件夹
                    Directory.CreateDirectory(path);//创建该文件夹
                File.Create(path);//创建该文件夹
            }

            DataBase = DbContext.Context($"{path}YeaJur.db").DataBase;
            Collection = DataBase.GetCollection<T>(typeof(T).Name);
        }
        /// <summary>
        /// 构建DbLite实例对象设置集合实体
        /// </summary>
        public DbCollection(string dbName, BsonMapper mapper = null)
        {
            DataBase = DbContext.Context($"{Directory.GetCurrentDirectory()}\\{dbName}", mapper).DataBase;
            Collection = DataBase.GetCollection<T>(typeof(T).Name);
        }
    }
}
﻿using Newtonsoft.Json;

namespace CS.Extension
{
    /// <summary>
    /// Json相关扩展
    /// </summary>
    public static class JsonExt
    {
        /// <summary>
        /// 通过Newtonsoft转为Json，循环引用将自动忽略
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string ToJsonByJc(this object o)
        {
            return o==null? null: JsonConvert.SerializeObject(o,new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        /// <summary>
        /// 转为Joson，尽可能的忽略掉所有的null等信息
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string ToZipJsonByJc(this object o)
        {
            return o == null ? null : JsonConvert.SerializeObject(o, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore

            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static string ToJsonByJc(this object o, JsonSerializerSettings settings)
        {
            return o == null ? null : JsonConvert.SerializeObject(o,settings);
        }

        /// <summary>
        /// 通过Newtonsoft反序列化Json
        /// 注意：请自已判断是否为null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="j"></param>
        /// <returns></returns>
        public static T FromJsonByJc<T>(this string j)
        {
            //return string.IsNullOrWhiteSpace(j) ? default(T) : JsonConvert.DeserializeObject<T>(j);//当string来源为null时无法正确调用扩展方法
            return JsonConvert.DeserializeObject<T>(j);
        }

        /// <summary>
        /// 将基类转换为子类的野路子
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="o"></param>
        /// <returns></returns>
        public static T CastByJc<T>(this object o)
        {
            return o.ToJsonByJc().FromJsonByJc<T>();
        }

        /// <summary>
        /// 通过Newtonsoft反序列化Json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="j"></param>
        /// <param name="settings">反序列化设定</param>
        /// <returns></returns>
        public static T FromJsonByJc<T>(this string j,JsonSerializerSettings settings)
        {
            //return string.IsNullOrWhiteSpace(j)? default(T): JsonConvert.DeserializeObject<T>(j,settings);
            return JsonConvert.DeserializeObject<T>(j, settings);
        }

    }
}
﻿using binlu979.HttpLib.Builder;
using System;

namespace binlu979.HttpLib
{
    public static class Http
    {
       /// <summary>
       /// 获取get请求
       /// </summary>
       /// <param name="url">地址</param>
       /// <returns></returns>
        public static RequestBuilder Get(string url)
        {
            return new RequestBuilder(url, HttpVerb.Get);
        }

        public static RequestBuilder Head(string url)
        {
            return new RequestBuilder(url, HttpVerb.Head);
        }
        /// <summary>
        /// 获取POST请求
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static RequestBuilder Post(string url)
        {
            return new RequestBuilder(url, HttpVerb.Post);
        }

        public static RequestBuilder Put(string url)
        {
            return new RequestBuilder(url, HttpVerb.Put);
        }

        public static RequestBuilder Patch(string url)
        {
            return new RequestBuilder(url, HttpVerb.Patch);
        }

        public static RequestBuilder Delete(string url)
        {
            return new RequestBuilder(url, HttpVerb.Delete);
        }
    }
}

﻿using System.Reflection;
using NLite.Internal;
using System;
using NLite.Collections;
using System.Collections.Generic;

namespace NLite.Reflection
{
   

    /// <summary>
    /// 函数扩展类
    /// </summary>
    public static class FuncExtensions
    {
        //private static readonly IMap<MethodInfo, Proc> actionCache = new Map<MethodInfo, Proc>();
        private static readonly Dictionary<MethodInfo, Func> funcCache = new Dictionary<MethodInfo, Func>();
        /// <summary>
        /// 快速函数调用
        /// </summary>
        /// <param name="method">方法</param>
        /// <param name="target">目标对象</param>
        /// <param name="args">参数列表</param>
        /// <returns>返回方法调用结果</returns>
        public static object FastFuncInvoke(this MethodInfo method, object target, params object[] args)
        {
            if (method == null)
                throw new ArgumentNullException("method");

            Func func;
            if (!funcCache.TryGetValue(method, out func))
                funcCache[method] = func = method.GetFunc();

            return func(target, args);
        }

        ///// <summary>
        ///// 快速过程调用
        ///// </summary>
        ///// <param name="method">方法</param>
        ///// <param name="target">目标对象</param>
        ///// <param name="args">参数列表</param>
        //public static void FastProcInvoke(this MethodInfo method, object target, params object[] args)
        //{
        //    actionCache.GetOrAdd(method, () => method.GetProc())(target, args);
        //}
    }
}

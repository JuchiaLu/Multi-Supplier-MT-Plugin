﻿using System;
using MemoQ.MTInterfaces;

namespace MT_SDK
{
    /// <summary>
    /// Describes an MT engine that is currently active
    /// 描述当前处于活动状态的 MT 引擎。
    /// </summary>
    /// <remarks>
    /// Abstracts two distinct interfaces plugins can implement; common handling by two distinct implementation of this interface.
    /// 抽象出两个不同的插件可以实现的接口; 通过这个接口的两个不同的实现进行公共处理。
    /// </remarks>
    internal interface ICurrentEngine : IDisposable
    {
        ISession CreateLookupSession();
        ISessionForStoringTranslations CreateSessionForStoringTranslation();
    }

    /// <summary>
    /// Describes a plugin engine that implements <see cref="IEngine"/> interface.
    /// 描述实现 < see cref = “ IEngine”/> 接口的插件引擎。
    /// </summary>
    internal class CurrentEngine : ICurrentEngine
    {
        private readonly IEngine engine;
        public CurrentEngine(IEngine engine) { this.engine = engine; }

        public ISession CreateLookupSession() => engine.CreateSession();
        public void Dispose() => engine?.Dispose();
        public ISessionForStoringTranslations CreateSessionForStoringTranslation()
        {
            throw new NotSupportedException();
        }
    }

    /// <summary>
    /// Describes a plugin engine that implements <see cref="IEngine2"/> interface.
    /// 描述实现 < see cref = “ IEngine2”/> 接口的插件引擎。
    /// </summary>
    internal class CurrentEngine2 : ICurrentEngine
    {
        private readonly IEngine2 engine;
        public CurrentEngine2(IEngine2 engine) { this.engine = engine; }

        public ISession CreateLookupSession() => engine.CreateLookupSession();
        public ISessionForStoringTranslations CreateSessionForStoringTranslation() => engine.CreateStoreTranslationSession();
        public void Dispose() => engine?.Dispose();
    }
}

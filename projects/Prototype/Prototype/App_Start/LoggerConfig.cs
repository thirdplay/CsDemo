﻿using System.IO;
using System.Web.Hosting;

namespace Prototype
{
    /// <summary>
    /// ロガーの設定クラス。
    /// </summary>
    public class LoggerConfig
    {
        /// <summary>
        /// ロガーを登録します。
        /// </summary>
        public static void RegisterLoggers()
        {
            log4net.GlobalContext.Properties["outputDir"] = HostingEnvironment.MapPath("/Common/Logs");
            log4net.Config.XmlConfigurator.Configure(new FileInfo(HostingEnvironment.MapPath("~/log4net.config")));
        }
    }
}
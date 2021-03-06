﻿using Dapper;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;

namespace TrainingDemo.App_Start
{
    /// <summary>
    /// Dapperの設定クラス。
    /// </summary>
    public class DapperConfig
    {
        /// <summary>
        /// 型マッピングを設定します。
        /// </summary>
        public static void RegisterMappings(string @namespace)
        {
            var types = from type in Assembly.GetExecutingAssembly().GetTypes()
                        where type.IsClass && type.Namespace == @namespace
                        select type;
            foreach (var target in types)
            {
                SqlMapper.SetTypeMap(target, new CustomPropertyTypeMap(target, (type, columnName) =>
                {
                    return type.GetProperties()
                        .FirstOrDefault(prop =>
                            prop.GetCustomAttributes(false)
                                .OfType<ColumnAttribute>()
                                .Any(attr => attr.Name == columnName)
                    );
                }));
            }
        }
    }
}
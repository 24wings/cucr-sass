using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Cucr.CucrSaas.ZC.Provider {
    /// <summary>
    /// 
    /// </summary>
    public class NullToEmptyStringResolver : DefaultContractResolver {
        /// <summary>
        /// 创建属性
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="memberSerialization">序列化成员</param>
        /// <returns></returns>
        protected override IList<JsonProperty> CreateProperties (Type type, MemberSerialization memberSerialization) {
            return type.GetProperties ()
                .Select (x => {
                    var property = CreateProperty (x, memberSerialization);
                    property.ValueProvider = new NullToEmptyStringValueProvider (x);
                    return property;
                }).ToList ();
        }

        /// <inheritdoc />
        /// <summary>
        /// 小写
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        protected override string ResolvePropertyName (string propertyName) {
            return propertyName.ToLower ();
        }
    }
}
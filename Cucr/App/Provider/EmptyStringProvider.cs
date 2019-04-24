using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json.Serialization;

namespace Cucr.CucrSaas.ZC.Provider
{
    /// <summary>
    /// NUll字符串转为空值提供
    /// </summary>
    public class NullToEmptyStringValueProvider : IValueProvider
    {
        private readonly PropertyInfo _memberInfo;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="memberInfo"></param>
        public NullToEmptyStringValueProvider(PropertyInfo memberInfo)
        {
            _memberInfo = memberInfo;
        }

        /// <inheritdoc />
        /// <summary>
        /// 获取Value
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public object GetValue(object target)
        {
            object result = _memberInfo.GetValue(target);
            var stringType = String.Empty.GetType();
            //_memberInfo.PropertyType == typeof (string) &&
            // Console.WriteLine (_memberInfo.Name);
            if (result == null)
            {
                // result = "";
                if (_memberInfo.PropertyType == typeof(string) || _memberInfo.PropertyType == typeof(string))
                {
                    result = "";
                }
                else if (_memberInfo.PropertyType == typeof(bool) || _memberInfo.PropertyType == typeof(bool?))
                {
                    // Console.WriteLine ("bool:" + _memberInfo.Name);
                    result = false;
                }
                else if (_memberInfo.PropertyType == typeof(int) || _memberInfo.PropertyType == typeof(int?))
                {
                    result = 0;
                }
                else if (_memberInfo.PropertyType == typeof(DateTime) || _memberInfo.PropertyType == typeof(DateTime?))
                {
                    result = DateTime.Now;
                }
                else if (_memberInfo.PropertyType == typeof(System.Object[]))
                {
                    result = new Object[] { };
                }
                else if (_memberInfo.PropertyType == typeof(System.Collections.IEnumerable))
                {
                    result = new List<object>();

                }
                else if (_memberInfo.PropertyType == typeof(decimal) || _memberInfo.PropertyType == typeof(decimal?))
                {
                    result = new decimal(0);
                }
                else if (_memberInfo.PropertyType == typeof(TimeSpan) || _memberInfo.PropertyType == typeof(Nullable<TimeSpan>))
                {
                    result = new TimeSpan(0, 0, 0, 0, 0);
                }
                else
                {

                    // Console.WriteLine (_memberInfo.Name);
                    // Console.WriteLine (_memberInfo.PropertyType);
                    result = 0;
                }

            }

            return result;

        }

        /// <inheritdoc />
        /// <summary>
        /// 设置Value
        /// </summary>
        /// <param name="target"></param>
        /// <param name="value"></param>
        public void SetValue(object target, object value)
        {
            _memberInfo.SetValue(target, value);
        }
    }
}
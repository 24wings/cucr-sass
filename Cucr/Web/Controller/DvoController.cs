using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Cucr.CucrSaas.Dynamic.Com;
using Microsoft.AspNetCore.Mvc;

namespace Cucr.CucrSaas.Web.Dvo {
    /// <summary>
    /// dvo
    /// </summary>
    [Route ("api/web/dvo")]
    public class DvoController {

        /// <summary>
        /// 列出详情
        /// </summary>
        /// <param name="fullname"></param>
        /// <returns></returns>
        [HttpGet ("[action]")]
        public object getDvoInfoByFullname (string fullname) {
            var type = Assembly.GetEntryAssembly ().GetType (fullname);
            Console.WriteLine (type);
            var viewAttr = (SubQueryPageAttribute) type.GetCustomAttribute (typeof (SubQueryPageAttribute));
            viewAttr.mainQueryDynamic = (QueryViewAttribute) viewAttr.mainQueryDynamicType.GetCustomAttribute (typeof (QueryViewAttribute));
            var members = viewAttr.mainQueryDynamicType.GetMembers ();
            foreach (var m in members) {
                var queryDynamic = (IEnumerable<QueryDynamicAttribute>) m.GetCustomAttributes (typeof (QueryDynamicAttribute));

                foreach (var a in queryDynamic.ToList ()) {
                    if (this.checkCondition (a.conditions, Condtion.Eq)) {
                        a.filter.Add (new Filter { key = m.Name, condition = "eq" });
                    }
                    if (this.checkCondition (a.conditions, Condtion.Contains)) {
                        a.filter.Add (new Filter { key = m.Name, condition = "contains" });
                    }

                    if ((a.conditions & ((int) Condtion.Eq)) == ((int) Condtion.Eq)) {

                    }
                    viewAttr.mainQueryDynamic.queryDynamics.Add (a);
                }

            }
            Console.WriteLine (viewAttr);
            return viewAttr;
        }

        private bool checkCondition (int val, Condtion condition) {
            return val == (int) condition;
        }
    }
}
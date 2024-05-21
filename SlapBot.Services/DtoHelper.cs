using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Services
{
    public static class DtoHelper
    {
        public static void ConvertCollection<Tin, Tout>(ICollection<Tin> inT, ICollection<Tout> dtos, string method) where Tin : class
        {
            var fromRecordMethod = typeof(Tout).GetMethod(method);
            if (fromRecordMethod != null)
            {

                foreach (var item in inT)
                {
                    var instance = Activator.CreateInstance(typeof(Tout));
                    var d = fromRecordMethod.Invoke(instance, new object[] { item });
                    dtos.Add((Tout)d);
                }
            }
        }
    }
}

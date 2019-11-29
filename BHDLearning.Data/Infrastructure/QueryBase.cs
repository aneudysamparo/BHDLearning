using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BHDLearning.Data.Infrastructure
{
    public abstract class QueryBase<T>
    {
        public virtual bool CanExecute()
        {
            return true;
        }

        public IEnumerable<T> Query(Func<T, bool> filter = null, Func<IEnumerable<T>, object> callBack = null)
        {
            try
            {
                if (!CanExecute())
                    return default;

                IEnumerable<T> result = OnQuery(filter);
                callBack?.Invoke(result);
                return result;

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected abstract IEnumerable<T> OnQuery(Func<T, bool> filter = null);
    }
}

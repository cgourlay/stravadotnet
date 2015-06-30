using System;
using System.Collections.Generic;

namespace com.strava.api.Repositories
{
    public interface IProvider<T>
    {
        void Create(T businessObject);
        T Read(Guid businessObjectId);
        IList<T> Read();
        void Update(Guid businessObjectId, T updatedBusinessObject);
        void Delete(Guid businessObjectId);
    }
}

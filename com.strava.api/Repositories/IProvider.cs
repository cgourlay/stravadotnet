using System.Collections.Generic;

using com.Strava.api.Model.Segments;

namespace com.Strava.api.Repositories
{
    public interface IProvider
    {
        void Create(ISegment segment);
        ISegment Read(int segmentId);
        IList<ISegment> Read();
        void Update(int segmentId, ISegment updatedSegment);
        void Delete(int segmentId);
    }
}

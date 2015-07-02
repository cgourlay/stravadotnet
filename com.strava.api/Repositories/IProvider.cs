using System.Collections.Generic;

using com.strava.api.Model.Segments;

namespace com.strava.api.Repositories
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

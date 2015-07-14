using System.Collections.Generic;
using SwimBikeRun.Strive.Model.Interfaces.Segments;

namespace SwimBikeRun.Strive.Repositories
{
    public interface IRepository
    {
        void Create(ISegment segment);
        ISegment Read(int segmentId);
        IList<ISegment> Read();
        void Update(int segmentId, ISegment updatedSegment);
        void Delete(int segmentId);
    }
}

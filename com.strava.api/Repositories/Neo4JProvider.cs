using System;
using System.Linq;
using com.strava.api.Model.Segments;
using Neo4jClient;

namespace com.strava.api.Repositories
{
    public class Neo4JProvider : IProvider
    {
        private readonly IGraphClient _graphClient;

        public Neo4JProvider(IGraphClient graphClient)
        {
            // TODO: CG to complete... Work in progress, refactor this.
            var client = new GraphClient(new Uri(@"http://localhost:7474/"));
            client.Connect();
            _graphClient = graphClient;   
        }

        public Neo4JProvider()
        {
            // TODO: Complete member initialization
        }

        public void Create(ISegment segment)
        {
            throw new System.NotImplementedException();
        }

        public ISegment Read(int segmentId)
        {
            return _graphClient.Cypher.Match("(segment:Segment)")
                                      .Where((ISegment segment) => segment.Id == segmentId)
                                      .Return(segment => segment.As<ISegment>())
                                      .Results.SingleOrDefault();
        }

        public System.Collections.Generic.IList<ISegment> Read()
        {
            throw new System.NotImplementedException();
        }

        public void Update(int segmentId, ISegment updatedSegment)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int segmentId)
        {
            throw new System.NotImplementedException();
        }
    }
}

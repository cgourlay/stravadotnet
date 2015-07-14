using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using SwimBikeRun.Model.Segments;
using Neo4jClient;
using SwimBikeRun.Strive.Model.Interfaces.Segments;
using SwimBikeRun.Strive.Model.Segments;
using SwimBikeRun.Strive.Repositories;

namespace com.Strava.Api.Repositories
{
    public class Neo4JProvider : IRepository
    {
        private readonly IGraphClient _graphClient;

        public Neo4JProvider(IGraphClient graphClient)
        {
            var client = new GraphClient(new Uri(@"http://neo4j:password@localhost:7474/db/data"));
            client.Connect();
            _graphClient = graphClient;   
        }

        public Neo4JProvider()
        {
            var client = new GraphClient(new Uri(@"http://neo4j:password@localhost:7474/db/data"));
            client.Connect();
            _graphClient = client;  
        }

        public void Create(ISegment newSegment)
        {
            var fakeSegment = new Segment
            {
                Id = newSegment.Id,
                ActivityType = newSegment.ActivityType,
                Name = newSegment.Name, 
                City = newSegment.City, 
                NumberOfAthletes = newSegment.NumberOfAthletes, 
                TotalElevationGain = newSegment.TotalElevationGain
            };
            _graphClient.Cypher.Create("(segment:Segment {fakeSegment})")
                               .WithParam("fakeSegment", fakeSegment)
                               .ExecuteWithoutResults();
        }

        public ISegment Read(int segmentId)
        {
            var segment = _graphClient.Cypher
                                      .Match("(s:Segment)")
                                      .Return(s => s.Node<Segment>())
                                      .Results.FirstOrDefault();

            return new Segment();
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

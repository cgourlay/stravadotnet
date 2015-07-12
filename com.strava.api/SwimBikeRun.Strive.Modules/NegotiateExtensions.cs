﻿using System.Globalization;

using Nancy;
using Nancy.Responses.Negotiation;
using SwimBikeRun.Strive.Model.Interfaces.Segments;
using SwimBikeRun.Strive.Representations;
using SwimBikeRun.Strive.Representations.Interfaces;

namespace SwimBikeRun.Strive.Modules
{
    public static class NegotiateExtensions
    {
        public static Negotiator Content(this Negotiator negotiator, IOperationResponse<ISegment> operationResponse)
        {
            return negotiator.WithEtagHeader(operationResponse)
                             .WithLocationHeader(operationResponse)
                             .WithStatusCode((HttpStatusCode)operationResponse.Status)
                             .ForJson(operationResponse);
        }

        private static Negotiator ForJson(this Negotiator negotiator, IOperationResponse<ISegment> model)
        {
            return negotiator.WithMediaRangeModel(new MediaRange("application/json"), model.DataAsJson());
        }

        private static Negotiator WithEtagHeader(this Negotiator negotiator, IOperationResponse<ISegment> operationResponse)
        {
            return negotiator.WithHeader("ETag", string.Format("\"{0}\"", operationResponse.Data.GetHashCode().ToString(CultureInfo.InvariantCulture)));
        }

        private static Negotiator WithLocationHeader(this Negotiator negotiator, IOperationResponse<ISegment> operationResponse)
        {
            return negotiator.WithHeader("Location", string.Format(@"{0}/{1}", negotiator.NegotiationContext.ModulePath, operationResponse.Data.Id));
        }
    }   
}

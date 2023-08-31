using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLLBot.Core.Services.Api
{
    public class ApiResult
    {
        public string Error { get; init; }
        public bool Success { get; init; }
    }

    public class StageReplayResult : ApiResult
    {
        public string Id { get; init; }
        public string Location { get; init; }
        public bool Duplicate { get; init; }
    }

    public class RemoveReplayResult : ApiResult { }
}

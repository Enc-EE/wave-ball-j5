using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Waveball;

namespace WaveBall
{
    class RpcImpl : waveball.waveballBase
    {
        public override Task<InfoResponse> GetInfo(Empty request, ServerCallContext context)
        {
            return base.GetInfo(request, context);
        }
    }
}

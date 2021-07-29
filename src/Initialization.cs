using NetMQ;
using VL.Core;
using VL.Core.CompilerServices;

[assembly: AssemblyInitializer(typeof(VL.IO.NetMQ.Initialization))]

namespace VL.IO.NetMQ
{
    public sealed class Initialization : AssemblyInitializer<Initialization>
    {
        static Initialization()
        {
            BufferPool.SetCustomBufferPool(new ArrayPoolBufferPool());
        }

        protected override void RegisterServices(IVLFactory factory)
        {
        }
    }
}
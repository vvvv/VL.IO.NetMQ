using NetMQ;
using System.Buffers;

namespace VL.IO.NetMQ
{
	sealed class ArrayPoolBufferPool : IBufferPool
	{
		private readonly ArrayPool<byte> pool = ArrayPool<byte>.Create(16 * 1024 * 1024 /* 16 MB */, 50);

		public void Return(byte[] buffer)
		{
			pool.Return(buffer);
		}

		public byte[] Take(int size)
		{
			return pool.Rent(size);
		}

		public void Dispose()
		{
		}
	}
}

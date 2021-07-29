using NetMQ;
using System;

namespace VL.IO.NetMQ
{
    /// <summary>
    /// Receives one ZeroMQ frame and keeps it alive until the next frame.
    /// </summary>
    public sealed class FrameReceiver : IDisposable
    {
        private Msg msg;

        public ReadOnlyMemory<byte> ReceiveFrame(IReceivingSocket socket, out bool more)
        {
            if (msg.IsInitialised)
                msg.Close();

            msg.InitEmpty();

            socket.Receive(ref msg);

            more = msg.HasMore;

            return msg.Data.AsMemory(msg.Offset, msg.Size);
        }

        public void Dispose()
        {
            if (msg.IsInitialised)
                msg.Close();
        }
    }
}

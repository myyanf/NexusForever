using NexusForever.Shared.Network;
using NexusForever.Shared.Network.Message;
using System;
using System.Collections.Generic;
using System.Text;
using NLog;

namespace NexusForever.WorldServer.Network.Message.Model
{
    [Message(GameMessageOpcode.RandomRollResponse)]
    public class RandomRollResponse : IWritable
    {
        private static readonly ILogger log = LogManager.GetCurrentClassLogger();

        public ushort realmId { set; get; }
        public ulong characterId { set; get; }
        public int MinRandom { get; set; }
        public int MaxRandom { get; set; }
        public int RandomRollResult { get; set; }
        public int rnd { get; set; }
        
        public void Write(GamePacketWriter writer)
        {
            //writer.Write(Unknown0);

            writer.Write(realmId, 14u);
            writer.Write(characterId);
            writer.Write(MinRandom);
            writer.Write(MaxRandom);
            writer.Write(RandomRollResult);
        }
    }
}

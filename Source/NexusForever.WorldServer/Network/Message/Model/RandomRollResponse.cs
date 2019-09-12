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

        public ulong characterId { set; get; }
        public ushort realmId { set; get; }
        public ushort ChatChannel { get; set; }
        public int MaxRandom { get; set; }
        public int RandomIn { get; set; }
        public int rnd { get; set; }
        
        public void Write(GamePacketWriter writer)
        {
            writer.Write(characterId,64u);
            writer.Write(realmId,16u);
            writer.Write(ChatChannel, 14u);
            writer.Write(MaxRandom,32u);
            writer.Write(RandomIn,32u);
        }
    }
}

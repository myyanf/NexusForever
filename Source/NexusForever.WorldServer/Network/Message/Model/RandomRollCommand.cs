using System;
using System.Collections.Generic;
using System.Text;
using NexusForever.Shared.Network;
using NexusForever.Shared.Network.Message;
//using NexusForever.WorldServer.Game.Misc;
using NexusForever.WorldServer.Network.Message.Model.Shared;
using NLog;

namespace NexusForever.WorldServer.Network.Message.Model
{

    public enum RandomRollEnum : uint
    {
        Command_Random = 618615,
        Command_Roll = 618616,
        RandomRollResult = 618617
    }

    [Message(GameMessageOpcode.RandomRollCommand)]
    public class RandomRollCommand : IReadable
    {
        private static readonly ILogger log = LogManager.GetCurrentClassLogger();

        // Note that for /roll on the command line, the first two fields below,
        // realmId, characterId, and Unknown0-3 are 0.
        public ushort realmId { get; set; }
        public ulong characterId { get; set; }
        public int MinRandom { get; set; }
        public int MaxRandom { get; set; }
        public byte Unknown0 { get; set; }
        public byte Unknown1 { get; set; }
        public byte Unknown2 { get; set; }
        public byte Unknown3 { get; set; }
        public int RandomOut { get; set; }
        public Random rnd = new Random();

        public void Read(GamePacketReader reader)
        {
            realmId = reader.ReadUShort(14u);
            characterId = reader.ReadULong();
            MinRandom = reader.ReadInt();
            MaxRandom = reader.ReadInt();
            Unknown0 = reader.ReadByte();
            Unknown1 = reader.ReadByte();
            Unknown2 = reader.ReadByte();
            Unknown3 = reader.ReadByte();
            RandomOut = rnd.Next(MinRandom,MaxRandom);
        }

    }
}
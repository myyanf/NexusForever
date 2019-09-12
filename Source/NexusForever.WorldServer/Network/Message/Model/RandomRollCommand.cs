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

        public ushort Unknown0 { get; set; }
        public byte Unknown4 { get; set; }
        public byte Unknown5 { get; set; }
        public ulong Unknown1 { get; set; }
        public ushort ChatChannel { get; set; }
        public ushort Unknown3 { get; set; }
        public int MaxRandom { get; set; }
        public ulong Unknown2 { get; set; }
        public int RandomOut { get; set; }
        public Random rnd = new Random();

        public void Read(GamePacketReader reader)
        {
            Unknown0 = reader.ReadUShort(12u);
            Unknown1 = reader.ReadULong();
            ChatChannel = reader.ReadUShort(14u);
            Unknown4 = reader.ReadByte(4u);
            Unknown3 = reader.ReadUShort();
            MaxRandom = reader.ReadInt();
            Unknown2 = reader.ReadULong();
            RandomOut = rnd.Next(MaxRandom);
        }

    }
}
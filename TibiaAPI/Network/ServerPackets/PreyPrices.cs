﻿using OXGaming.TibiaAPI.Constants;

namespace OXGaming.TibiaAPI.Network.ServerPackets
{
    public class PreyPrices : ServerPacket
    {
        public uint ListRerollPrice { get; set; }

        public byte AutomaticBonusReroll { get; set; }
        public byte LockPrey { get; set; }

        public PreyPrices(Client client)
        {
            Client = client;
            PacketType = ServerPacketType.PreyPrices;
        }

        public override bool ParseFromNetworkMessage(NetworkMessage message)
        {
            if (message.ReadByte() != (byte)ServerPacketType.PreyPrices)
            {
                return false;
            }

            ListRerollPrice = message.ReadUInt32();
            if (Client.VersionNumber >= 11900000)
            {
                AutomaticBonusReroll = message.ReadByte();
                LockPrey = message.ReadByte();
            }
            return true;
        }

        public override void AppendToNetworkMessage(NetworkMessage message)
        {
            message.Write((byte)ServerPacketType.PreyPrices);
            message.Write(ListRerollPrice);
            if (Client.VersionNumber >= 11900000)
            {
                message.Write(AutomaticBonusReroll);
                message.Write(LockPrey);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeStrikeBot.Messages
{
    public class Message
    {
        private List<PacketDotNet.TcpPacket> packets;
        public ushort CheckSum;
        public uint Ack { get; set; }
        public string Id { get; set; }

        public bool Complete { get; set; }

        public MessageType Type { get; set; }
        public DateTime Timestamp { get; set; }

        public byte[] RawData { get; set; }
        public byte[] PayloadData { get; set; }
        public int Length { get; set; }

        public Message(SharpPcap.RawCapture packet)
        {
            PacketDotNet.TcpPacket tcpPacket = (PacketDotNet.TcpPacket)PacketDotNet.Packet.ParsePacket(packet.LinkLayerType, packet.Data).PayloadPacket.PayloadPacket;
            this.packets = new List<PacketDotNet.TcpPacket>();
            this.packets.Add(tcpPacket);
            this.Ack = tcpPacket.AcknowledgmentNumber;

            this.RawData = packet.Data;
            this.PayloadData = tcpPacket.PayloadData;
            this.Length = tcpPacket.PayloadData.Length;

            this.Timestamp = packet.Timeval.Date;

            this.Complete = this.Length != 1460;
        }

        public Message(Message message)
        {
            this.Id = message.Id;

            this.packets = message.packets;
            this.Ack = message.Ack;
            this.RawData = message.RawData;
            this.PayloadData = message.PayloadData;
            this.Length = message.Length;

            this.Timestamp = message.Timestamp;

            this.Complete = true;
        }

        public void AddPacket(SharpPcap.RawCapture packet)
        {
            PacketDotNet.TcpPacket tcpPacket = (PacketDotNet.TcpPacket)PacketDotNet.Packet.ParsePacket(packet.LinkLayerType, packet.Data).PayloadPacket.PayloadPacket;
            
            if (tcpPacket.AcknowledgmentNumber == this.Ack)
            {
                packets.Add(tcpPacket);

                this.Complete = tcpPacket.PayloadData.Length != 1460;

                byte[] raw = new byte[tcpPacket.PayloadData.Length + this.PayloadData.Length];

                Array.Copy(this.PayloadData, raw, this.PayloadData.Length);
                Array.Copy(tcpPacket.PayloadData, 0, raw, this.PayloadData.Length, tcpPacket.PayloadData.Length);
                this.PayloadData = raw;
                this.Length = this.PayloadData.Length;
            }
        }

        public static Message Parse(Message message)
        {
            message.PayloadData = new byte[0];

            foreach (PacketDotNet.TcpPacket p in message.packets)
            {
                byte[] newPayload = new byte[message.PayloadData.Length + p.PayloadData.Length];
                Array.Copy(message.PayloadData, newPayload, message.PayloadData.Length);
                Array.Copy(p.PayloadData, 0, newPayload, message.PayloadData.Length, p.PayloadData.Length);
                message.PayloadData = newPayload;
            }

            message.Length = message.PayloadData.Length;

            if (message.PayloadData.Length < 2)
            {
                message = new EmptyMessage(message);
            }
            else if (message.PayloadData[0] == 0x3c)
            {
                message = XmlMessage.Parse(message);
            }
            //TODO:remove after all cases found
            else
            {
                message = new EmptyMessage(message);
            }

            return message;
        }
    }

    public enum MessageType : short
    {
        Unknown = 0,
        Blank = 1,
        Chat = 2,
        March = 3,
        Rally = 4,
        TileUpdate = 5,
        SyncedData = 6
    }
}

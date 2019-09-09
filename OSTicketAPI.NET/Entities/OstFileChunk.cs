namespace OSTicketAPI.NET.Entities
{
    public class OstFileChunk
    {
        public int FileId { get; set; }
        public int ChunkId { get; set; }
        public byte[] Filedata { get; set; }
    }
}

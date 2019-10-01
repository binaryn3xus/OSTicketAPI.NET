using System.ComponentModel.DataAnnotations.Schema;

namespace OSTicketAPI.NET.Entities
{
    public class OstListItems
    {
        public int Id { get; set; }
        public int? ListId { get; set; }
        public int Status { get; set; }
        public string Value { get; set; }
        public string Extra { get; set; }
        public int Sort { get; set; }
        public string Properties { get; set; }

        [ForeignKey("ListId")]
        public virtual OstList OstList { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
namespace To_DO_List_Task.Models
{
    public class Note
    {
        public int Id { get; set; }
        [MaxLength(150)]
        public string Content { get; set; }
        public DateTime? AddTime { get; set; }
        [MaxLength(30)]
        public string? ExpectedTime { get; set; }
    }
}

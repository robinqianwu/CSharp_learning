using System;

namespace CSharp_learning.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string? ISBN { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Publisher { get; set; }
        public DateTime PublishDate { get; set; }
        public int Quantity { get; set; }
        public bool IsAvailable { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace TradeTeq.Domain
{
    public class Insight
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public InsightType Type { get; set; }
        public DateTime DatePublished { get; set; }
        public string Author { get; set; }
        public bool ActiveFlag { get; set; }

        [Column(TypeName = "varchar(MAX)")]
        public string Content { get; set; }

        [AllowNull]
        public string ImageSource { get; set; }

        public Insight(string title, InsightType type, DateTime datePublished, string author, bool activeFlag, string content, string imageSource)
        {
            Title = title;
            Type = type;
            DatePublished = datePublished;
            Author = author;
            ActiveFlag = activeFlag;
            Content = content;
            ImageSource = imageSource;
        }


        public Insight()
        {

        }
    }
}

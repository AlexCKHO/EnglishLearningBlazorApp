using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EnglishLearningBlazorApp.Shared
{
    public class Word
    {
        public int wordId { get; set; }
        public string? simpleTense { get; set; }
        public string? definition { get; set; }
        public string? UKAudioURI { get; set; }
        public string? USAudioURI { get; set; }
        public int? creatorId { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Created")]
        public DateTime DateCreated { get; init; } = DateTime.Now;
    }
}

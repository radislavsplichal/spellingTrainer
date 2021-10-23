using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SpellingTrainer
{
    class Card
    {
        [Key]
        public int cardID { get; set; }
        [Required]
        public string cardLabel { get; set; }
        public string cardSolutionBre { get; set; }
        public string cardSolutionAme { get; set; }
        public string cardImagePath { get; set; }
        [Required]
        public Deck deck { get; set; }
    }
}

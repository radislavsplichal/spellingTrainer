using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SpellingTrainer
{
    public class Deck
    {
        [Key]
        public int deckID { get; set; }
        [Required]
        public string deckLabel { get; set; }
        

    }
}

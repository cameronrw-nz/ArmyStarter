using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyStarter.Models
{
    public class Note
    {
        public Guid NoteId { get; set; }

        public string Content { get; set; }
    }
}
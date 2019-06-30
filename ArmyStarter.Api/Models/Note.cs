using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmyStarter.Api.Models
{
    public class Note
    {
        public Guid NoteId { get; set; }

        public string Content { get; set; }
    }
}
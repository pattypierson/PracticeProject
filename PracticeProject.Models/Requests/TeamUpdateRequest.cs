using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject.Models.Requests
{
    public class TeamUpdateRequest : TeamAddRequest
    {
        public int Id { get; set; }
    }
}

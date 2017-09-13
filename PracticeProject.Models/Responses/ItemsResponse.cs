using System.Collections.Generic;

namespace PracticeProject.Models.Responses
{
    public class ItemsResponse<T> : SuccessResponse
    {
        public List<T> Items { get; set; }
    }
}

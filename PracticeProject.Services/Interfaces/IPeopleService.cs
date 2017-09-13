using PracticeProject.Models.Domain;
using System.Collections.Generic;

namespace PracticeProject.Services
{
    public interface IPeopleService
    {
        List<People> Get();
    }
}
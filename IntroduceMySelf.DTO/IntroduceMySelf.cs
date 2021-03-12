using System;
using System.Collections.Generic;

namespace IntroduceMySelf.DTO
{
    public class Introduce
    {
        public Author Author { get; set; }

        public List<ProfessionalExperience> Carrer { get; set; }
    }

    public class Author
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public int CareerYear { get; set; }
    }

    public class ProfessionalExperience
    {
        public string Company { get; set; }
        
        public string ProjectName { get; set; }
        
        public string ImageLink { get; set; }

        public List<string> SkillInventory { get; set; }
    }
}

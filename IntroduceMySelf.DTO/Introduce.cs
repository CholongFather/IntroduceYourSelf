namespace IntroduceMySelf.DTO;

public class Introduce
{
	public Author Author { get; set; }

	public List<ProfessionalExperience> Career { get; set; }
}

public class Author
{
	public string Name { get; set; }

	public int Age { get; set; }

	public int CareerYear { get; set; }
}

public class ProfessionalExperience
{
	public int Index { get; set; }

	public string Company { get; set; }

	public string ProjectName { get; set; }

	public string ImageLink { get; set; }

	public List<string> SkillInventory { get; set; }
}

public class Test
{
	public string TestName { get; set; }
}

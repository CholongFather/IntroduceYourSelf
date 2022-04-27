namespace IntroduceMySelf.DTO;

using System;

public class AboutMeInfo
{
	public string Image { get; set; }

	public string Title { get; set; }

	public string Body { get; set; }
}

public class ServiceInfo
{
	public string Icon { get; set; }

	public string Title { get; set; }

	public string Body { get; set; }
}


public class SkillInfo
{
	public string Name { get; set; }
	public int Adeptness { get; set; }
	public string Description { get; set; }
}

public class CareerInfo
{
	public DateTime StartAt { get; set; }
	public DateTime EndAt { get; set; }
	public string Company { get; set; }
	public string Position { get; set; }
	public string Team { get; set; }
	public string Work { get; set; }
}

public class GetInTouch
{
	public string Body { get; set; }
	public string Name { get; set; }
	public string Address { get; set; }
	public DateTime Age { get; set; }
}

public class ContactInfo
{
	public string Name { get; set; }
	public string Email { get; set; }
	public string Subject { get; set; }
	public string Message { get; set; }
}

public class Test
{
	public string TestName { get; set; }
}

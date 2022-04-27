namespace IntroduceMySelfAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class IntroduceMySelfController : ControllerBase
{
	private readonly ILogger<IntroduceMySelfController> _logger;
	private readonly IRedisCacheClient _redisCacheClient;

	public IntroduceMySelfController(ILogger<IntroduceMySelfController> logger, IRedisCacheClient redisCacheClient)
	{
		_logger = logger;
		_redisCacheClient = redisCacheClient;
	}

	/// <summary>
	/// 소개 데이터 조회
	/// </summary>
	/// <param name="name">조회 이름</param>
	/// <returns></returns>
	[HttpGet("aboutme")]
	public async ValueTask<AboutMeInfo> GetAbountMe(string name)
	{
		if (string.IsNullOrWhiteSpace(name))
			return new();

		return await _redisCacheClient.GetDbFromConfiguration().GetAsync<AboutMeInfo>(string.Format(RedisKeys.AboutMe, name.ToLower()));
	}

	[HttpGet("service")]
	public async ValueTask<List<ServiceInfo>> GetService(string name)
	{
		var serviceInfos = await _redisCacheClient.GetDbFromConfiguration().GetAsync<List<ServiceInfo>>(string.Format(RedisKeys.Service, name.ToLower()));

		return serviceInfos.Select(c => new ServiceInfo
		{
			Icon = c.Icon,
			Title = c.Title,
			Body = c.Body,
		}).ToList();
	}

	[HttpGet("skill")]
	public async ValueTask<List<SkillInfo>> GetSkill(string name)
	{
		var skillItem = await _redisCacheClient.GetDbFromConfiguration().GetAsync<List<SkillInfo>>(string.Format(RedisKeys.SkillInventory, name.ToLower()));

		return skillItem.Select(c => new SkillInfo
		{
			Name = c.Name,
			Adeptness = c.Adeptness,
			Description = c.Description,
		}).ToList();
	}

	[HttpGet("getintouch")]
	public async ValueTask<GetInTouch> GetInTouch(string name)
	{
		var getInTouch = await _redisCacheClient.GetDbFromConfiguration().GetAsync<GetInTouch>(string.Format(RedisKeys.MyContact, name.ToLower()));

		return getInTouch;
	}

	[HttpPost("contact")]

	public async ValueTask SetContact(string name, ContactInfo contact)
	{

		if (string.IsNullOrWhiteSpace(contact.Email))
			return;
		else if (!contact.Email.IsValidEmail())
			return;

		if (string.IsNullOrWhiteSpace(contact.Name))
			return;

		if (string.IsNullOrWhiteSpace(contact.Subject))
			return;

		var contactInfos = await _redisCacheClient.GetDbFromConfiguration().GetAsync<List<ContactInfo>>(string.Format(RedisKeys.Contact, name.ToLower()));

		contactInfos.Add(contact);

		if (!await _redisCacheClient.GetDbFromConfiguration().ReplaceAsync(string.Format(RedisKeys.Contact, name.ToLower()), contactInfos))
			_logger.Log(LogLevel.Error, "저장이 되지 않았습니다.");
	}
}

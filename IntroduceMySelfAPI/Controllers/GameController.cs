using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntroduceMySelf.DTO;
using Newtonsoft.Json;
using StackExchange.Redis;
using StackExchange.Redis.Extensions.Core;
using StackExchange.Redis.Extensions.Core.Abstractions;
using StackExchange.Redis.Extensions.Newtonsoft;
using StackExchange.Redis.Extensions;

namespace IntroduceMySelfAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class GameController : ControllerBase
	{
		private readonly ILogger<GameController> _logger;
		private static string _baseball;
		private static DateTime _baseballDateTime;

		public GameController(ILogger<GameController> logger)
		{
			_logger = logger;
		}

		/// <summary>
		/// 5분마다 갱신되는 Baseball 게임
		/// </summary>
		/// <param name="number"></param>
		/// <returns></returns>
		[HttpGet("Baseball")]
		public async ValueTask<int> Baseball(string number)
		{
			if (number.Length != 4)
				return 0;

			if (string.IsNullOrWhiteSpace(_baseball))
			{
				var nums = Enumerable.Range(0, 9).OrderBy(c => Guid.NewGuid()).Take(4);
				_baseball = string.Join("", nums);
				_baseballDateTime = DateTime.Now.AddSeconds(300);
			}

			if (_baseballDateTime < DateTime.Now)
			{
				var nums = Enumerable.Range(0, 9).OrderBy(c => Guid.NewGuid()).Take(4);
				_baseball = string.Join("", nums);
				_baseballDateTime = DateTime.Now.AddSeconds(300);
			}

			var score = 0;
			for (var i = 0; i < 4; i++)
			{
				if (_baseball[i] == number[i])
					score += 10;
				else if (_baseball.Contains(number[i]))
					score += 1;
			}

			return score;
		}

		/// <summary>
		/// 랜덤 로또 제공기
		/// </summary>
		/// <returns></returns>
		[HttpGet("Lottery")]
		public async ValueTask<string> Lottery()
		{
			var Lottery = Enumerable.Range(1, 45).OrderBy(c => Guid.NewGuid()).Take(7);
			return $"Lottery : {string.Join(' ',Lottery.Take(6).OrderBy(c => c))}, Bonus : {Lottery.LastOrDefault()}";
		}

		/// <summary>
		/// 랜덤 게임 1~100
		/// </summary>
		/// <param name="guess"></param>
		/// <returns></returns>
		[HttpGet("Random")]
		public async ValueTask<bool> Random(string guess)
		{
			if (int.TryParse(guess, out var nums))
			{
				if (nums > 100)
					return false;
				else if (nums < 1)
					return false;
			}
			else
			{
				return false;
			}
			
			var number = Enumerable.Range(1, 100).OrderBy(c => Guid.NewGuid()).FirstOrDefault().ToString();
			return guess == number;
		}
	}
}

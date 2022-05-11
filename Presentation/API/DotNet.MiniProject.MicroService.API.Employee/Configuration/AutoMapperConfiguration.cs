using AutoMapper;
using DotNet.MiniAPI.MicroService.Business.Mapper;

namespace DotNet.MiniAPI.MicroService.API.Employee.Configuration
{
	public class AutoMapperConfiguration
	{
		public IMapper Configure()
		{
			var profiles = AppDomain.CurrentDomain.GetAssemblies()
			  .SelectMany(s => s.GetTypes())
			  .Where(a => typeof(ProfileMapper).IsAssignableFrom(a));

			var mapperConfiguration = new MapperConfiguration(a => profiles.ForEach(a.AddProfile));

			return mapperConfiguration.CreateMapper();
		}
	}
	public static class EnumerableExtensions
	{
		public static void ForEach<T>(this IEnumerable<T> enumerable,
				Action<T> action)
		{
			foreach (var item in enumerable) { action(item); }
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRegistration.Application.Extensions
{
	public static class GuidExtensions
	{
		public static bool IsValid(this Guid? value)
		{
			return value.HasValue && value != Guid.Empty;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Repo_pattern
{
	[Serializable]
	abstract class Entity
	{
		public UInt32 ID { get; set; }
	}
}

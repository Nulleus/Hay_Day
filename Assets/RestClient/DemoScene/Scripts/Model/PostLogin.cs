using System;

namespace Models
{
	[Serializable]
	public class Post
	{
		public string email;
		public string password;

		public override string ToString()
		{
			return UnityEngine.JsonUtility.ToJson(this, true);
		}
	}
}


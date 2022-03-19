using System;

namespace Models
{
	[Serializable]
	public class PostLogin
	{
		public string email;
		public string password;
		public string message;
		public string jwt;

		public override string ToString()
		{
			return UnityEngine.JsonUtility.ToJson(this, true);
		}
	}
}


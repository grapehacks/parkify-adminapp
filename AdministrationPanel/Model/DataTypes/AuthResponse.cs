namespace Model.DataTypes
{
    // ReSharper disable once ClassNeverInstantiated.Global
	class AuthResponse
	{
		public string message { get; set; }
		public User user { get; set; }
		public string token { get; set; }
	}
}

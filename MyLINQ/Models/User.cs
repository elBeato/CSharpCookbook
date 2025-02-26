namespace MyLINQ.Models
{
	internal class User
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public int Age { get; set; }

		public User(int seed) 
		{
			Id = new Random().Next(1_000_000);
			Name = Guid.NewGuid().ToString();
			Email = Guid.NewGuid().ToString();
			Password = Guid.NewGuid().ToString();
			Age = new Random().Next(120);
		}
	}
}

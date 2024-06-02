namespace WebApplication1.Models
{
	public class User
	{
        public int ID { get; set; }
		public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime Joindate { get; set; }
        public string Salt { get; set; }
    }
}

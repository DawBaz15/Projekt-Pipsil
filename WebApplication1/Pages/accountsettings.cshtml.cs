using System.Data;
using System.Security.Cryptography;
using LangApp.Pages;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using WebApplication1.Models;

namespace WebApplication1.Pages
{
    public class accountsettingsModel : PageModel
    {
		public string? Email { get; set; }
		public string? Name { get; set; }
		public string? Date {  get; set; }
		public string? Password1 { get; set; }
		public string? Password2 { get; set; }
		public string? Password3 { get; set; }
		public string? Message { get; set; }
		private readonly ILogger<loginpageModel> _logger;
		public accountsettingsModel(ILogger<loginpageModel> logger)
		{
			_logger = logger;
		}
		public void OnGet()
        {
			if (HttpContext.Session.GetString("_Email").IsNullOrEmpty())
			{
				Response.Redirect("welcome");
			}
			this.Email = MaskMail(HttpContext.Session.GetString("_Email"));
			this.Name = HttpContext.Session.GetString("_Name");
			this.Date = GetDate(HttpContext.Session.GetString("_Email"));
		}
		public void OnPost()
		{
			Message = "";
			Password1 = Request.Form["Password1"];
			Password2 = Request.Form["Password2"];
			Password3 = Request.Form["Password3"];
			if (PasswordCheck())
			{
				if (CheckValidity())
				{
					string Salt = CreateSalt();
					string password = SaltPassword(Password2, Salt);
					ChangePassword(password, Salt);
					_logger.LogInformation("User succeeded in changing password at {DT}", DateTime.UtcNow.ToLongTimeString());
				} else
				{
					_logger.LogInformation("User failed changing password at {DT}", DateTime.UtcNow.ToLongTimeString());
				}
			}
			else
			{
				_logger.LogInformation("User failed changing password at {DT}", DateTime.UtcNow.ToLongTimeString());
				Response.Redirect("account");
			}
		}
		protected string GetDate(string Email)
		{
			string date = "";
			Microsoft.Data.SqlClient.SqlConnection connect = new Microsoft.Data.SqlClient.SqlConnection("Server=localhost;Database=languagelearning;Trusted_Connection=True;TrustServerCertificate=True;");
			string query = "SELECT JoinDate FROM Users WHERE Email = '"+Email+"';";
			SqlCommand command = new SqlCommand(query, connect);
			try
			{
				connect.Open();
				using (SqlDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						date = reader[0].ToString();
						date = (date.Split(" ", 2))[0];
					}
				}
			}
			catch (System.Exception ex)
			{
				date = "Something went wrong.";
				Console.WriteLine("Error - " + ex);
			}
			finally
			{
				if (connect.State == ConnectionState.Open)
				{
					connect.Close();
				}
			}
			return date;
		}
		protected string MaskMail(string value)
		{
			string result = "";
			string[] temp = value.Split("@", 2);
			char[] temp2 = temp[0].ToCharArray();
			for (int x=0; x < temp2.Length;x++)
			{
				if (x == 0) result += temp2[x];
				else if (x == 1) result += temp2[x];
				else result += "*";
			}
			result += "@"+temp[1];
			return result;
		}
		protected String SaltPassword(String password, String Salt)
		{
			byte[] salt = new byte[128 / 8];
			for (int i = 0; i < (128 / 8); i++)
			{
				salt[i] = Convert.ToByte(Salt.Substring(3 * i, 2), 16);
			}
			return Convert.ToBase64String(KeyDerivation.Pbkdf2(
					password: password,
					salt: salt,
					prf: KeyDerivationPrf.HMACSHA256,
					iterationCount: 100000,
					numBytesRequested: 256 / 8
			));
		}
		protected Boolean CheckValidity()
		{
			if (Password2 != Password3)
			{
				Message = "Failed to reenter password.";
				return false;
			}
			if (Password2.Length < 6 || Password2.Length > 20)
			{
				Message = "Password length must be between 6-20 characters.";
				return false;
			}
			return true;
		}
		protected Boolean PasswordCheck()
		{
			Boolean validity = false;
			Microsoft.Data.SqlClient.SqlConnection connect = new Microsoft.Data.SqlClient.SqlConnection("Server=localhost;Database=languagelearning;Trusted_Connection=True;TrustServerCertificate=True;");
			string query = "SELECT Password,Salt FROM Users WHERE Email='" + HttpContext.Session.GetString("_Email") + "';";
			SqlCommand command = new SqlCommand(query, connect);
			try
			{
				connect.Open();
				using (SqlDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						if (SaltPassword(Password1, reader[1].ToString()) == reader[0].ToString())
						{
							validity = true;
						}
						else Message = "Incorrect password.";
					}
				}
			}
			catch (System.Exception ex)
			{
				Message = "Something went wrong.";
				Console.WriteLine("Error - " + ex);
			}
			finally
			{
				if (connect.State == ConnectionState.Open)
				{
					connect.Close();
				}
			}
			return validity;
		}
		protected void ChangePassword(string Password,string Salt)
		{
			Microsoft.Data.SqlClient.SqlConnection connect = new Microsoft.Data.SqlClient.SqlConnection("Server=localhost;Database=languagelearning;Trusted_Connection=True;TrustServerCertificate=True;");
			string query = "UPDATE Users SET Password='"+Password+"', Salt='"+Salt+"' WHERE Email='"+ HttpContext.Session.GetString("_Email") + "';";
			SqlCommand command = new SqlCommand(query, connect);
			try
			{
				connect.Open();
				command.ExecuteNonQuery();
			}
			catch (System.Exception ex)
			{
				Message = "Something went wrong.";
				Console.WriteLine("Error - " + ex);
			}
			finally
			{
				if (connect.State == ConnectionState.Open)
				{
					connect.Close();
				}
			}
		}
		protected string CreateSalt()
		{
			return BitConverter.ToString(RandomNumberGenerator.GetBytes(128 / 8));
		}
	}
}

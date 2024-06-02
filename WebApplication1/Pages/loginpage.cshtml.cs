using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Data;
using System.Data.SqlClient;
using WebApplication1.Models;
using WebApplication1.Pages;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.ComponentModel;

namespace LangApp.Pages
{
    public class loginpageModel : PageModel
    {
		public string? Email { get; set; }
		public string? Password { get; set; }
		public string? Message { get; set; }
		public string? Name { get; set; }
		private readonly ILogger<loginpageModel> _logger;
		public loginpageModel (ILogger<loginpageModel> logger)
		{
			_logger = logger;
		}
		public void OnGet()
		{
			if (!HttpContext.Session.GetString("_Email").IsNullOrEmpty())
			{
				Response.Redirect("Index");
			}
		}
		public void OnPost()
        {
			Message = "";
			Email = Request.Form["Email"];
			Password = Request.Form["Password"];
			if (CheckIfAccountExists())
			{
				if (PasswordCheck())
				{
					HttpContext.Session.SetString("_Email",Email);
					HttpContext.Session.SetString("_Name",GetName());
					_logger.LogInformation("Successfull login attempt at {DT}",DateTime.UtcNow.ToLongTimeString());
					Response.Redirect("Index");
				} else _logger.LogInformation("Failed login attempt at {DT}", DateTime.UtcNow.ToLongTimeString());
			} else _logger.LogInformation("Failed login attempt at {DT}", DateTime.UtcNow.ToLongTimeString());
		}
		protected Boolean CheckIfAccountExists()
		{
			Boolean validity = false;
			string value = "0";
			Microsoft.Data.SqlClient.SqlConnection connect = new Microsoft.Data.SqlClient.SqlConnection("Server=localhost;Database=languagelearning;Trusted_Connection=True;TrustServerCertificate=True;");
			string query = "SELECT COUNT(1) FROM Users WHERE Email='" + Email + "';";
			SqlCommand command = new SqlCommand(query, connect);
			try
			{
				connect.Open();
				using (SqlDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						value = reader[0].ToString();
					}
				}
				if (value == "1") validity = true;
				else Message = "Account not found.";
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
		protected Boolean PasswordCheck()
		{
			Boolean validity = false;
			Microsoft.Data.SqlClient.SqlConnection connect = new Microsoft.Data.SqlClient.SqlConnection("Server=localhost;Database=languagelearning;Trusted_Connection=True;TrustServerCertificate=True;");
			string query = "SELECT Password,Salt FROM Users WHERE Email='"+Email+"';";
			SqlCommand command = new SqlCommand(query, connect);
			try
			{
				connect.Open();
				using (SqlDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						if (SaltPassword(Password, reader[1].ToString()) == reader[0].ToString())
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
		protected string GetName()
		{
			string name = "User";
			Microsoft.Data.SqlClient.SqlConnection connect = new Microsoft.Data.SqlClient.SqlConnection("Server=localhost;Database=languagelearning;Trusted_Connection=True;TrustServerCertificate=True;");
			string query = "SELECT Name FROM Users WHERE Email='"+Email+"';";
			SqlCommand command = new SqlCommand(query, connect);
			try
			{
				connect.Open();
				using (SqlDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						name = reader[0].ToString();
					}
				}
			}
			catch (System.Exception ex)
			{
				Message = "Something went wrong.";
				_logger.LogError("Error while trying to login at {DT}", DateTime.UtcNow.ToLongTimeString());
			}
			finally
			{
				if (connect.State == ConnectionState.Open)
				{
					connect.Close();
				}
			}
			return name;
		}
		protected String SaltPassword(String password, String Salt)
		{
			byte[] salt = new byte[128 / 8];
			for (int i=0;i<(128/8);i++)
			{
				salt[i] = Convert.ToByte(Salt.Substring(3*i,2),16);
			}
			return Convert.ToBase64String(KeyDerivation.Pbkdf2(
					password: password,
					salt: salt,
					prf: KeyDerivationPrf.HMACSHA256,
					iterationCount: 100000,
					numBytesRequested: 256 / 8
			));
		}
	}
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Data;
using System.Data.SqlClient;
using WebApplication1.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace LangApp.Pages
{
    public class registerpageModel : PageModel
    {
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Password1 { get; set; }
        public string? Password2 { get; set; }
		public string? Message { get; set; }
		private readonly ILogger<loginpageModel> _logger;
		public registerpageModel (ILogger<loginpageModel> logger)
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
			Name = Request.Form["Name"];
			Password1 = Request.Form["Password1"];
			Password2 = Request.Form["Password2"];
			string JoinDate = DateTime.Now.ToString("yyyy-MM-dd");
			if (CheckValidity())
			{
				byte[] Salt = CreateSalt();
				String Password = SaltPassword(Password1,Salt);
				Microsoft.Data.SqlClient.SqlConnection connect = new Microsoft.Data.SqlClient.SqlConnection("Server=localhost;Database=languagelearning;Trusted_Connection=True;TrustServerCertificate=True;");
				string query = "SET IDENTITY_INSERT Users OFF;INSERT INTO Users (Email,Name,Password,Joindate,Salt) VALUES ('" + Email + "','" + Name + "','" + Password + "','" + JoinDate + "','" + BitConverter.ToString(Salt) + "');";
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
				_logger.LogInformation("Successfull account registration at {DT}", DateTime.UtcNow.ToLongTimeString());
				Response.Redirect("login");
			}
			else _logger.LogInformation("Failed account registration attempt at {DT}", DateTime.UtcNow.ToLongTimeString());
		}
		protected Boolean CheckValidity() {
			Boolean emailtaken = true;
			if (Name.Length < 1)
			{
				Message = "A name is required to register.";
				return false;
			}
			if (Name.Length > 20)
			{
				Message = "Given name must have 20 or less characters.";
				return false;
			}
			if (Password1!=Password2)
			{
				Message = "Failed to reenter password.";
				return false;
			}
			if (Password1.Length<6 || Password1.Length > 20)
			{
				Message = "Password length must be between 6-20 characters.";
				return false;
			}
			Microsoft.Data.SqlClient.SqlConnection connect = new Microsoft.Data.SqlClient.SqlConnection("Server=localhost;Database=languagelearning;Trusted_Connection=True;TrustServerCertificate=True;");
			string query = "SELECT COUNT(1) FROM Users WHERE Email='"+Email+"';";
			SqlCommand command = new SqlCommand(query, connect);
			try
			{
				connect.Open();
				using (SqlDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						Console.WriteLine(reader[0].ToString());
						if (reader[0].ToString() == "0") emailtaken = false;
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
			if (emailtaken)
			{
				Message = "Email already taken.";
				return false;
			}
			return true;
		}
		protected String SaltPassword(String password, byte[] Salt)
		{
			return Convert.ToBase64String(KeyDerivation.Pbkdf2(
					password: password,
					salt: Salt,
					prf: KeyDerivationPrf.HMACSHA256,
					iterationCount: 100000,
					numBytesRequested: 256 / 8
			));
		}
		protected byte[] CreateSalt()
		{
			return RandomNumberGenerator.GetBytes(128 / 8);
		}
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;

namespace WebApplication1.Pages
{
    public class gamepageModel : PageModel
    {
        public String[] data {  get; set; }
        public string? jpass { get; set; }
        public string lang1 { get; set; }
        public string lang2 { get; set; }
        public int module { get; set; }
        public int num { get; set; }
		public void OnGet(string lang1,string lang2,int module,int num)
        {
			if (HttpContext.Session.GetString("_Email").IsNullOrEmpty())
			{
				Response.Redirect("welcome");
			}
			this.lang1 = lang1;
            this.lang2 = lang2; 
            this.module = module;
            this.num = num;
            if (ValuesCheck())
            {
                data = Game.WordsMatch(lang1, lang2, module, num);
                jpass = Stringify(data);
            } else
            {
				Response.Redirect("/game");
			}
		}
        protected string Stringify(String[] array)
        {
            string result="";
            for (int x=0;x<array.Length; x++)
            {
                if (x != 0) result += ",";
                result += array[x];
            }
            return result;
        }
        protected bool ValuesCheck()
        {
            if (!CheckLanguage(lang1)) return false;
            if (!CheckLanguage(lang2)) return false;
            if (module < 1 || module > 8) return false;
            if (num < 1 || num > 4) return false;
            return true;

        }
        protected bool CheckLanguage(string lang)
        {
            string[] allowed =
            {
                "pl",
                "en",
                "ge"
            };
            for (int x=0;x<allowed.Length;x++)
            {
                if (lang == allowed[x]) return true;
            }
            return false;
        }
    }
}

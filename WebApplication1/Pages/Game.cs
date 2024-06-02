namespace WebApplication1.Pages;

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.IdentityModel.Tokens;
using WebApplication1.Languages;
    public class Game
    {
	protected static string[] langFrom;
	protected static string[] langTo;
	public static String[] WordsMatch (string lang1,string lang2,int module,int amount)
        {
            List<int> completedAnswers = new List<int>();
            List<int> takenWrongAnswers = new List<int>();
		    string[] chosen = new string[5*amount];
            string temp;
		    switch (lang1)
		    {
			    case "en": langFrom = English.GetModule(module); break;
			    case "pl": langFrom = Polish.GetModule(module); break;
                case "ge": langFrom = German.GetModule(module); break;
		    }
		    switch (lang2)
		    {
			    case "en": langTo = English.GetModule(module); break;
			    case "pl": langTo = Polish.GetModule(module); break;
                case "ge": langFrom = German.GetModule(module); break;
		    }
            for (int x = 0; x < amount; x++)
            {
                takenWrongAnswers.Clear();
                int rand = new Random().Next(0, langFrom.Length);
                while (CheckIfOnArray(completedAnswers, rand)) rand = new Random().Next(0, langFrom.Length);
                chosen[0 + 5 * x] = langFrom[rand];
			    chosen[1 + 5 * x] = langTo[rand];
			    temp = MakeBadAnswer(takenWrongAnswers, rand);
                takenWrongAnswers.Add(GetId(langTo, temp));
                chosen[2+ 5 * x] = temp;
			    temp = MakeBadAnswer(takenWrongAnswers, rand);
                takenWrongAnswers.Add(GetId(langTo, temp));
                chosen[3 + 5 * x] = temp;
			    completedAnswers.Add(rand);
			    chosen = Randomize(chosen, 1 + 5 * x, 3 + 5 * x);
            }
            return chosen;
	    }
        protected static string MakeBadAnswer(List<int> list,int rand)
        {
            int bad = new Random().Next(0, langFrom.Length);
            while (!CheckWrongAnswer(list,bad,rand)) bad = new Random().Next(0, langFrom.Length);
		    return langTo[bad];
        }
        protected static Boolean CheckIfOnArray(List<int> list,int number)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (number == list[i]) return true;
            }
        return false;
        }
        protected static int GetId(String[] array,string word)
        {
            for (int i = 0;i < array.Length;i++)
            {
                if (array[i] == word) return i;
            }
            return -1;
        }
        protected static Boolean CheckWrongAnswer(List<int> takenWrongAnswers,int number,int rand)
        {
            if (CheckIfOnArray(takenWrongAnswers, number)) return false;
            if (number == rand) return false;
            return true;
        }
        protected static String[] Randomize(String[] array,int from,int to)
        {
            Random random = new Random();
            int to2 = to;
            String[] TemporaryArray = array;
            string answer = array[from];
		    int AnswerID = random.Next(from,to+1);
            int temp = from+1;
		    for (int i = from; i < to2+1; i++)
		    {
			    if (i == AnswerID)
                {
                    TemporaryArray[i] = answer;
			    }
			else
			{
                TemporaryArray[i] = array[temp];
				temp++;
			}
		    }
        TemporaryArray[to2 + 1] = AnswerID.ToString();
        return TemporaryArray;
	    }
}
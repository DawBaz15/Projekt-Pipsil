namespace WebApplication1.Languages
{
    public class Polish
    {
		public static string[] GetModule(int module)
		{
			switch (module)
			{
				case 1: return Module1(); break;
				case 2: return Module2(); break;
				case 3: return Module3(); break;
				case 4: return Module4(); break;
				case 5: return Module5(); break;
				case 6: return Module6(); break;
				case 7: return Module7(); break;
				case 8: return Module8(); break;
			}
			return Module1();
		}
		protected static string[] Module1()
        {
            string[] list =
            {
                "Głowa",
                "Nos",
                "Ucho",
                "Brew",
				"Oko",
                "Szyja",
                "Klatka piersiowa",
                "Brzuch",
                "Ręka",
                "Łokieć",
                "Dłoń",
                "Palec",
                "Paznokieć",
                "Udo",
                "Kolano",
                "Noga",
                "Stopa",
                "Palec u nogi",
                "Policzek",
                "Broda",
                "Ramię",
                "Ząb",
                "Plecy",
                "Pięta",
            };
            return list;
        }
		protected static string[] Module2()
		{
			string[] list =
			{
				"Woda",
				"Sok",
				"Herbata",
				"Kawa",
				"Napój gazowany",
				"Lemoniada",
				"Mleko",
				"Piwo",
				"Wino",
				"Naleśnik",
				"Kanapka",
				"Jajko",
				"Ser",
				"Lody",
				"Ryż",
				"Ciasto",
				"Frytki",
				"Szynka",
				"Ryba",
				"Chleb",
				"Twarożek",
				"Dżem",
				"Tuńczyk"
			};
			return list;
		}
		protected static string[] Module3()
		{
			string[] list =
			{
				"Pies",
				"Kot",
				"Niedźwiedź",
				"Wielbłąd",
				"Osioł",
				"Królik",
				"Jeleń",
				"Wiewiórka",
				"Lis",
				"Świnia",
				"Koń",
				"Słoń",
				"Żyrafa",
				"Krowa",
				"Koza",
				"Gepard",
				"Lew",
				"Gęś",
				"Owca",
				"Mysz",
				"Żaba",
				"Żółw",
				"Sowa",
				"Małpa"
			};
			return list;
		}
		protected static string[] Module4()
		{
			string[] list =
			{
				"Kelner",
				"Dentysta",
				"Pielęgniarka",
				"Elektryk",
				"Biznesmen",
				"Chirurg",
				"Sekretarz",
				"Żołnierz",
				"Scientist",
				"Dziennikarz",
				"Policjant",
				"Listonosz",
				"Malarz",
				"Magik",
				"Ratownik",
				"Dozorca",
				"Ogrodnik",
				"Piłkarz",
				"Budowniczy",
				"Strażak",
				"Stolarz",
				"Inżynier",
				"Sportowiec",
				"Pisaż"
			};
			return list;
		}
		protected static string[] Module5()
		{
			string[] list =
			{
				"Galeria handlowa",
				"Kawiarnia",
				"Remiza strażacka",
				"Posterunek policyjny",
				"Bank",
				"Biblioteka",
				"Szpital",
				"Lotnisko",
				"Kościół",
				"Kino",
				"Sklep",
				"Siłownia",
				"Więzienie",
				"Poczta",
				"Szkoła",
				"Księgarnia",
				"Stacja paliw",
				"Basen",
				"Przystanek autobusowy",
				"Restauracja",
				"Drapacz chmur",
				"Kwiaciarnia"
			};
			return list;
		}
		protected static string[] Module6()
		{
			string[] list =
			{
				"Łucznictwo",
				"Lekkoatletyka",
				"Koszykówka",
				"Boks",
				"Szachy",
				"Kolarstwo",
				"Szermierka",
				"Piłka nożna",
				"Gimnastyka",
				"Golf",
				"Bieganie truchtem",
				"Jazda konna",
				"Narciarstwo",
				"Trójbój siłowy",
				"Jazda na rolkach",
				"Kajakarstwo",
				"Żeglarstwo",
				"Turystyka",
				"Sztuki walki",
				"Zapasy",
				"Pływanie"
			};
			return list;
		}
		protected static string[] Module7()
		{
			string[] list =
			{
				"Tramwaj",
				"Ambulans",
				"Balon",
				"Rower",
				"Łódź",
				"Autobus",
				"Kareta",
				"Dźwig",
				"Wózek widłowy",
				"Helikopter",
				"Motocykl",
				"Skuter",
				"Deskorolka",
				"Traktor",
				"Pociąg",
				"Ciężarówka",
				"Taksówka",
				"Metro",
				"Samochód dostawczy",
				"Łódź podwodna"
			};
			return list;
		}
		protected static string[] Module8()
		{
			string[] list =
			{
				"Kamerka internetowa",
				"Klawiatura",
				"Monitor",
				"Myszka",
				"Dysk twardy",
				"Drukarka",
				"Sprzęt komputerowy",
				"Oprogramowanie",
				"Sieć",
				"Baza danych",
				"Chmura",
				"Pobierać",
				"Wgrywać",
				"Domena",
				"Pamięć podręczna",
				"Komputer",
				"Adres",
				"Kabel",
				"Pamięć przenośna",
				"Słuchawki",
				"Drążek sterowy",
				"Mikrofon"
			};
			return list;
		}
	}
}

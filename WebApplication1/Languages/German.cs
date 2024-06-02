namespace WebApplication1.Languages
{
    public class German
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
				"Kopf",
				"Nase",
				"Ohr",
				"Augenbraue",
				"Auge",
				"Nacken",
				"Brust",
				"Magen",
				"Arm",
				"Ellbogen",
				"Hand",
				"Finger",
				"Fingernagel",
				"Oberschenkel",
				"Knie",
				"Bein",
				"Fuß",
				"Zehe",
				"Wange",
				"Kinn",
				"Schulter",
				"Zahn",
				"Zurück",
				"Hacke",
			};
            return list;
        }
        protected static string[] Module2()
        {
            string[] list =
            {
				"Wasser",
				"Saft",
				"Tee",
				"Kaffee",
				"Limonade",
				"Limonade",
				"Milch",
				"Bier",
				"Wein",
				"Pfannkuchen",
				"Sandwich",
				"Ei",
				"Käse",
				"Eiscreme",
				"Reis",
				"Kuchen",
				"Fritten",
				"Schinken",
				"Fisch",
				"Brot",
				"Hüttenkäse",
				"Marmelade",
				"Thunfisch"
			};
            return list;
        }
		protected static string[] Module3()
		{
			string[] list =
			{
				"Hund",
				"Katze",
				"Tragen",
				"Kamel",
				"Esel",
				"Kaninchen",
				"Reh",
				"Eichhörnchen",
				"Fuchs",
				"Schwein",
				"Pferd",
				"Elefant",
				"Giraffe",
				"Kuh",
				"Ziege",
				"Gepard",
				"Löwe",
				"Gans",
				"Schaf",
				"Maus",
				"Frosch",
				"Schildkröte",
				"Eule",
				"Affe"
			};
			return list;
		}
		protected static string[] Module4()
		{
			string[] list =
			{
				"Kellner",
				"Zahnarzt",
				"Krankenschwester",
				"Elektriker",
				"Geschäftsmann",
				"Der Chirurg",
				"Sekretär",
				"Soldat",
				"Wissenschaftler",
				"Reporter",
				"Polizist",
				"Briefträger",
				"Maler",
				"Zauberer",
				"Rettungsschwimmer",
				"Haushälterin",
				"Gärtner",
				"Fußballer",
				"Baumeister",
				"Feuerwehrmann",
				"Tischler",
				"Ingenieur",
				"Athlet",
				"Schriftsteller"
			};
			return list;
		}
		protected static string[] Module5()
		{
			string[] list =
			{
				"Einkaufszentrum",
				"Cafe",
				"Feuerwehr",
				"Polizeistation",
				"Bank",
				"Bibliothek",
				"Krankenhaus",
				"Flughafen",
				"Kirche",
				"Kino",
				"Geschäft",
				"Fitnessstudio",
				"Gefängnis",
				"Postamt",
				"Schule",
				"Buchhandlung",
				"Tankstelle",
				"Schwimmbad",
				"Bushaltestelle",
				"Restaurant",
				"Wolkenkratzer",
				"Floristen"
			};
			return list;
		}
		protected static string[] Module6()
		{
			string[] list =
			{
				"Bogenschießen",
				"Leichtathletik",
				"Basketball",
				"Boxen",
				"Schach",
				"Radfahren",
				"Fechten",
				"Fußball",
				"Gymnastik",
				"Golf",
				"Joggen",
				"Pferderennen",
				"Skifahren",
				"Kraftdreikampf",
				"Rollschuhlaufen",
				"Kanusport",
				"Segeln",
				"Wandern",
				"Kampfkunst",
				"Ringen",
				"Baden"
			};
			return list;
		}
		protected static string[] Module7()
		{
			string[] list =
			{
				"Straßenbahn",
				"Krankenwagen",
				"Ballon",
				"Fahrrad",
				"Boot",
				"Bus",
				"Wagen",
				"Kran",
				"Gabelstapler",
				"Hubschrauber",
				"Motorrad",
				"Roller",
				"Skateboard",
				"Traktor",
				"Zug",
				"LKW",
				"Taxi",
				"U-Bahn",
				"Van",
				"U-Boot"
			};
			return list;
		}
		protected static string[] Module8()
		{
			string[] list =
			{
				"Webcam",
				"Tastatur",
				"Monitor",
				"Maus",
				"Festplatte",
				"Drucker",
				"Hardware",
				"Software",
				"Netzwerk",
				"Datenbank",
				"Wolke",
				"Herunterladen",
				"Hochladen",
				"Domain",
				"Zwischenspeicher",
				"Computer",
				"Adresse",
				"Kabel",
				"Flash Drive",
				"Kopfhörer",
				"Joystick",
				"Mikrofon"
			};
			return list;
		}
	}
}

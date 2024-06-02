namespace WebApplication1.Languages
{
    public class English
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
                "Head",
                "Nose",
                "Ear",
                "Eyebrow",
				"Eye",
                "Neck",
                "Chest",
                "Stomach",
                "Arm",
                "Elbow",
                "Hand",
                "Finger",
                "Fingernail",
                "Thigh",
                "Knee",
                "Leg",
                "Foot",
                "Toe",
                "Cheek",
                "Chin",
                "Shoulder",
                "Tooth",
                "Back",
                "Heel",
			};
            return list;
        }
        protected static string[] Module2()
        {
            string[] list =
            {
                "Water",
				"Juice",
				"Tea",
				"Coffee",
				"Soda",
				"Lemonade",
				"Milk",
				"Beer",
				"Wine",
				"Pancake",
				"Sandwich",
				"Egg",
				"Cheese",
				"Ice cream",
				"Rice",
				"Cake",
				"Fries",
				"Ham",
				"Fish",
				"Bread",
				"Cottage cheese",
				"Jam",
				"Tuna"
            };
            return list;
        }
		protected static string[] Module3()
		{
			string[] list =
			{
				"Dog",
				"Cat",
				"Bear",
				"Camel",
				"Donkey",
				"Rabbit",
				"Deer",
				"Squirrel",
				"Fox",
				"Pig",
				"Horse",
				"Elephant",
				"Giraffe",
				"Cow",
				"Goat",
				"Cheetah",
				"Lion",
				"Goose",
				"Sheep",
				"Mouse",
				"Frog",
				"Turtle",
				"Owl",
				"Monkey"
			};
			return list;
		}
		protected static string[] Module4()
		{
			string[] list =
			{
				"Waiter",
				"Dentist",
				"Nurse",
				"Electrician",
				"Businessman",
				"Surgeon",
				"Secretary",
				"Soldier",
				"Scientist",
				"Reporter",
				"Police officer",
				"Postman",
				"Painter",
				"Magician",
				"Lifeguard",
				"Housekeeper",
				"Gardener",
				"Footballer",
				"Builder",
				"Fireman",
				"Carpenter",
				"Engineer",
				"Athlete",
				"Writer"
			};
			return list;
		}
		protected static string[] Module5()
		{
			string[] list =
			{
				"Mall",
				"Cafe",
				"Fire station",
				"Police station",
				"Bank",
				"Library",
				"Hospital",
				"Airport",
				"Church",
				"Cinema",
				"Shop",
				"Gym",
				"Jail",
				"Post office",
				"School",
				"Bookstore",
				"Gas station",
				"Pool",
				"Bus stop",
				"Restaurant",
				"Skyscraper",
				"Florist's"
			};
			return list;
		}
		protected static string[] Module6()
		{
			string[] list =
			{
				"Archery",
				"Athletics",
				"Basketball",
				"Boxing",
				"Chess",
				"Cycling",
				"Fencing",
				"Football",
				"Gymnastics",
				"Golf",
				"Jogging",
				"Horse racing",
				"Skiing",
				"Powerlifting",
				"Roller skating",
				"Canoeing",
				"Sailing",
				"Hiking",
				"Martial arts",
				"Wrestling",
				"Swimming"
			};
			return list;
		}
		protected static string[] Module7()
		{
			string[] list =
			{
				"Tram",
				"Ambulance",
				"Balloon",
				"Bicycle",
				"Boat",
				"Bus",
				"Carriage",
				"Crane",
				"Forklift",
				"Helicopter",
				"Motorcycle",
				"Scooter",
				"Skateboard",
				"Tractor",
				"Train",
				"Truck",
				"Taxi",
				"Subway",
				"Van",
				"Submarine"
			};
			return list;
		}
		protected static string[] Module8()
		{
			string[] list =
			{
				"Webcam",
				"Keyboard",
				"Monitor",
				"Mouse",
				"Hard drive",
				"Printer",
				"Hardware",
				"Software",
				"Network",
				"Database",
				"Cloud",
				"Download",
				"Upload",
				"Domain",
				"Cache",
				"Computer",
				"Address",
				"Cable",
				"Flash drive",
				"Headphones",
				"Joystick",
				"Microphone"
			};
			return list;
		}
	}
}

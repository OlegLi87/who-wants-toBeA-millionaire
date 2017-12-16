using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quest
{
    public static class QuestionsStash
    {
        public static string[] QuestStash { get; private set; }

        static QuestionsStash()
        {
            QuestStash = new string[]
            {
                "Milano,Roma,Sampdoria,Torino-Juventus comes from?-Torino-Medium",
                "West Germany,USSR,Hungary,France-First Eurocup holder was?-USSR-Medium",
                "11,12.7,25.4,36.8-How many millimeters in inch?-25.4-Easy",
                "1945,1930,1948,1546-When Independencie of Israel was declared?-1948-Easy",
                "1979,1978,1970,1982-In what year was the movie 'Grease' released?-1978-Hard",
                "Paris,Monaco,Berlin,London-The Capital city of France is?-Paris-Easy",
                "3,5,1,4-How many spinoffs has Terminator franchise?-5-Easy",
                "Berlin,Roma,Munich,Milano-Inter comes from?-Milano-Medium",
                "1930,1941,1940,1939-When WW2 began?-1939-Medium",
                "12,4,8,11-How many planets are in our Solar System?-8-Medium",
                "6,5,4,3-How many Olympics rings at it's emblem?-5-Easy",
                "Gun,Tooth,Eagle,Eye-Complete the title of the James Bond film The Man With The Golden...-Gun-Easy",
                "Soccer,Hockey,VolleyBall,Tug of War-In which sport do two teams pull at the opposite ends of a rope?-Tug of War-Easy",
                "Panda,Elephant,Jaguar,Cat-Which of these animals shares its name with a luxury car?-Jaguar-Easy",
                "Dog,Chicken,Cow,Alligator-What animal is considered sacred in India?-Cow-Easy",
                "Kangaroo,Elephant,Monkey,Dolphine-What is the national animal of Austrilia?-Kangaroo-Easy",
                "Fridge,Bank,Market,Shoe-An establishment where money can be deposited or withdrawn is called what?-Bank-Easy",
                "Ecuador,Columbia,Japan,Mexico-In which country is the Galeras Volcano?-Columbia-Hard",
                "Peter Jackson,Oliver Stone,Morgan Freeman,Clint Eastwood-Who won the Academy Award for directing the movie ‘Million Dollar Baby’?-Clint Eastwood-Hard",
                "USA,France,Germany,Austria-DAX refers to the stock market of which country?-Germany-Hard",
                "Nephrones,Nerves,Stitches,Ligaments-Which of these holds bones together at the joints of the body?-Ligaments-Hard",
                "Paris,Berlin,London,New York-Roland Garros stadium is in which city?-Paris-Medium",
                "Pascal,Ohm,Volt,Hertz-Which scientific unint is named after Italian nobleman-Volt-Medium",
                "Trees,Grain,Vegetables,Flowers-If you planted the seeds of 'Quercus robur', what would grow?-Trees-Hard",
                "Henry I,Henry II,Henry V,Richard I-Which king was married to Eleanor of Aquitaine?-Henry II-Hard",
                "Bull Latin,Duck Latin,Dog Latin,Pig Latin-In what language would you say 'ello hay' to greet your friends?-Pig Latin-Hard",
                "Zeus,Mercury,Cupid,Poseidon-What god of love is often depicted as a chubby winged infant with a bow and arrow?-Cupid-Medium",
                "Islam,Christianity,Judaism,Hinduism-Which of the following is not a monotheistic religion?-Hinduism-Medium",
                "Tail,Head,Mouth,Claw-Where is the stinger on a scorpion's body?-Tail-Medium",
                "Peru,Columbia,Cuba,Brazil-Lima beans are named for a city in what country?-Peru-Hard",
                "Cornerstone,Impost,Keystone,Lodestone-In architecture, what is the name of the center stone at the top of an arch?-Lodestone-Hard"
            };
        }
        /// <summary>
        /// creating list of GeneralQuestion derived instances
        /// </summary>
        /// <returns></returns>
        public static List<GeneralQuestion> SetQuestAnswer()
        {
            List<GeneralQuestion> list = new List<GeneralQuestion>();
            
            foreach (string element in QuestStash)
            {
                if (element.Split('-')[3] == "Easy") list.Add(new EasyQuestion(element.Split('-')[1], element.Split('-')[2], element.Split('-')[0].Split(',')));
                else if (element.Split('-')[3] == "Medium") list.Add(new MediumQuestion(element.Split('-')[1], element.Split('-')[2], element.Split('-')[0].Split(',')));
                else list.Add(new HardQuestion(element.Split('-')[1], element.Split('-')[2], element.Split('-')[0].Split(',')));
            }
            return list;
        }
    }
}

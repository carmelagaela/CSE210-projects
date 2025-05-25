using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var scriptures = new List<(Reference, string)>
        {
            (new Reference("Genesis", 1, 26, 27),
            "And God said, Let us make man in our image, after our likeness: and let them have dominion over the fish of the sea, and over the fowl of the air, and over the cattle, and over all the earth, and over every creeping thing that creepeth upon the earth. So God created man in his own image, in the image of God created he him; male and female created he them."),

            (new Reference("Genesis", 2, 24),
            "Therefore shall a man leave his father and his mother, and shall cleave unto his wife: and they shall be one flesh."),

            (new Reference("Genesis", 39, 9),
            "There is none greater in this house than I; neither hath he kept back any thing from me but thee, because thou art his wife: how then can I do this great wickedness, and sin against God?"),

            (new Reference("Exodus", 19, 5, 6),
            "Now therefore, if ye will obey my voice indeed, and keep my covenant, then ye shall be a peculiar treasure unto me above all people: for all the earth is mine: And ye shall be unto me a kingdom of priests, and an holy nation. These are the words which thou shalt speak unto the children of Israel."),

            (new Reference("Psalm", 24, 3, 4),
            "Who shall ascend into the hill of the Lord? or who shall stand in his holy place? He that hath clean hands, and a pure heart; who hath not lifted up his soul unto vanity, nor sworn deceitfully."),

            (new Reference("Psalm", 119, 105),
            "Thy word is a lamp unto my feet, and a light unto my path."),

            (new Reference("Psalm", 127, 3),
            "Lo, children are an heritage of the Lord: and the fruit of the womb is his reward."),

            (new Reference("Proverbs", 3, 5, 6),
            "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."),

            (new Reference("Isaiah", 1, 18),
            "Come now, and let us reason together, saith the Lord: though your sins be as scarlet, they shall be as white as snow; though they be red like crimson, they shall be as wool."),

            (new Reference("Isaiah", 53, 3, 5),
            "He is despised and rejected of men; a man of sorrows, and acquainted with grief: and we hid as it were our faces from him; he was despised, and we esteemed him not. Surely he hath borne our griefs, and carried our sorrows: yet we did esteem him stricken, smitten of God, and afflicted. But he was wounded for our transgressions, he was bruised for our iniquities: the chastisement of our peace was upon him; and with his stripes we are healed."),

            (new Reference("Matthew", 5, 14, 16),
            "Ye are the light of the world. A city that is set on an hill cannot be hid. Neither do men light a candle, and put it under a bushel, but on a candlestick; and it giveth light unto all that are in the house. Let your light so shine before men, that they may see your good works, and glorify your Father which is in heaven."),

            (new Reference("Matthew", 11, 28, 30),
            "Come unto me, all ye that labour and are heavy laden, and I will give you rest. Take my yoke upon you, and learn of me; for I am meek and lowly in heart: and ye shall find rest unto your souls. For my yoke is easy, and my burden is light."),

            (new Reference("Matthew", 22, 36, 39),
            "Master, which is the great commandment in the law? Jesus said unto him, Thou shalt love the Lord thy God with all thy heart, and with all thy soul, and with all thy mind. This is the first and great commandment. And the second is like unto it, Thou shalt love thy neighbour as thyself."),

            (new Reference("John", 3, 16),
            "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),

            (new Reference("John", 14, 6),
            "Jesus saith unto him, I am the way, the truth, and the life: no man cometh unto the Father, but by me."),

            (new Reference("John", 17, 3),
            "And this is life eternal, that they might know thee the only true God, and Jesus Christ, whom thou hast sent."),

            (new Reference("Acts", 2, 38),
            "Then Peter said unto them, Repent, and be baptized every one of you in the name of Jesus Christ for the remission of sins, and ye shall receive the gift of the Holy Ghost."),

            (new Reference("Romans", 1, 16),
            "For I am not ashamed of the gospel of Christ: for it is the power of God unto salvation to every one that believeth; to the Jew first, and also to the Greek."),

            (new Reference("1 Corinthians", 10, 13),
            "There hath no temptation taken you but such as is common to man: but God is faithful, who will not suffer you to be tempted above that ye are able; but will with the temptation also make a way to escape, that ye may be able to bear it."),

            (new Reference("Philippians", 4, 13),
            "I can do all things through Christ which strengtheneth me."),

            (new Reference("2 Nephi", 2, 25),
            "Adam fell that men might be; and men are, that they might have joy."),

            (new Reference("2 Nephi", 2, 27),
            "Wherefore, men are free according to the flesh; and all things are given them which are expedient unto man. And they are free to choose liberty and eternal life, through the great Mediator of all men, or to choose captivity and death, according to the captivity and power of the devil; for he seeketh that all men might be miserable like unto himself."),

            (new Reference("2 Nephi", 31, 20),
            "Wherefore, ye must press forward with a steadfastness in Christ, having a perfect brightness of hope, and a love of God and of all men. Wherefore, if ye shall press forward, feasting upon the word of Christ, and endure to the end, behold, thus saith the Father: Ye shall have eternal life."),

            (new Reference("2 Nephi", 32, 3),
            "Angels speak by the power of the Holy Ghost; wherefore, they speak the words of Christ. Wherefore, I said unto you, feast upon the words of Christ; for behold, the words of Christ will tell you all things what ye should do."),

            (new Reference("Mosiah", 2, 17),
            "When ye are in the service of your fellow beings ye are only in the service of your God."),

            (new Reference("Mosiah", 3, 19),
            "For the natural man is an enemy to God, and has been from the fall of Adam, and will be, forever and ever, unless he yields to the enticings of the Holy Spirit, and putteth off the natural man and becometh a saint through the atonement of Christ the Lord, and becometh as a child, submissive, meek, humble, patient, full of love, willing to submit to all things which the Lord seeth fit to inflict upon him, even as a child doth submit to his father."),

            (new Reference("Mosiah", 18, 8, 10),
            "...and are willing to bear one another’s burdens, that they may be light; Yea, and are willing to mourn with those that mourn; yea, and comfort those that stand in need of comfort, and to stand as witnesses of God at all times and in all things, and in all places..."),

            (new Reference("Alma", 37, 6),
            "Now ye may suppose that this is foolishness in me; but behold I say unto you, that by small and simple things are great things brought to pass; and small means in many instances doth confound the wise."),

            (new Reference("Helaman", 5, 12),
            "And now, my sons, remember, remember that it is upon the rock of our Redeemer, who is Christ, the Son of God, that ye must build your foundation; that when the devil shall send forth his mighty winds... it shall have no power over you... because of the rock upon which ye are built..."),

            (new Reference("Moroni", 10, 4, 5),
            "And when ye shall receive these things, I would exhort you that ye would ask God, the Eternal Father, in the name of Christ, if these things are not true; and if ye shall ask with a sincere heart, with real intent, having faith in Christ, he will manifest the truth of it unto you, by the power of the Holy Ghost. And by the power of the Holy Ghost ye may know the truth of all things.")
        };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Select a scripture to memorize:\n");

            for (int i = 0; i < scriptures.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {scriptures[i].Item1.GetDisplayText()}");
            }
            Console.WriteLine($"{scriptures.Count + 1}. Quit");

            Console.Write("\nEnter the number of your choice: ");
            string choiceInput = Console.ReadLine();

            if (!int.TryParse(choiceInput, out int choice) || choice < 1 || choice > scriptures.Count + 1)
            {
                Console.WriteLine("Invalid choice. Press Enter to try again.");
                Console.ReadLine();
                continue;
            }

            if (choice == scriptures.Count + 1)
                break;

            var selectedReference = scriptures[choice - 1].Item1;
            var selectedText = scriptures[choice - 1].Item2;
            var scripture = new Scripture(selectedReference, selectedText);

            bool isChecking = false;

            while (!scripture.IsCompletelyHidden() && !isChecking)
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nPress Enter to hide more words then type 'check' to test your memory.");

                string input = Console.ReadLine().Trim().ToLower();
                if (input == "check")
                {
                    isChecking = true;
                    break;
                }

                scripture.HideRandomWords(3);
            }

            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nNow, please type the entire scripture exactly as it is:");
            string userAttempt = Console.ReadLine();

            if (userAttempt.Trim().Equals(selectedText, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Great job!");
            }
            else
            {
                Console.WriteLine("Keep practicing! That wasn't quite right.");
                Console.WriteLine("Correct scripture:");
                Console.WriteLine(selectedText);
            }

            Console.WriteLine("\nWould you like to try another scripture? (yes/no)");
            string tryAgain = Console.ReadLine().Trim().ToLower();
            if (tryAgain != "yes" && tryAgain != "y")
                break;
        }
    }
}
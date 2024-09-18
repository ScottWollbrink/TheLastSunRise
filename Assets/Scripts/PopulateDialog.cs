using UnityEngine;
using UnityEngine.SceneManagement;
using static Dialog;

public class PopulateDialog : MonoBehaviour
{

    [SerializeField] Dialog herodialog;
    [SerializeField] Dialog builderdialog;
    [SerializeField] Dialog blackSmithdialog;
    [SerializeField] Dialog princedialog;

    string[] herodialogtext ={
        "Hm...",
        "It seems you are deep in thought.",
        "Your Highness! I did not see you there...",
        "Silly, isn't it?",
        "On the eve of battle, I am unable to quiet my mind.",
        "An understandable sentiment.",
        "I suspect the outcome of this war will affect many things.",
        "Indeed...",
        "All my life, I trained for combat.",
        "I trained to protect this peaceful kingdom.",
        "And you have done well.",
        "But... will it be enough?",
        "The King falls silent.",
        "After a moment, he looks at the Hero with determined eyes.",
        "It must be.",
        "The Hero takes a deep breath and sighs.",
        "Then, he nods.",
        "I understand.",
        "Leave it to me.",
        "Such a quick change of heart.",
        "Your Majesty's words struck a chord in me.",
        "You reminded me that I have a duty to fulfill.",
        "I need to do everything in my power to ensure the kingdom's survival...",
        "...For the future of all those that come after me.",
        "I knew it was right to choose you as our kingdom's hero.",
        "I do not deserve such praise.",
        "Perhaps I should wait until our victory tomorrow.",
        "The Hero manages a small chuckle.",
        "Mm...",
        "Silence falls again. Townspeople pass as the King and Hero look on.",
        "Well, I do not mean to take up your time.",
        "It was I who interrupted you.",
        "I am grateful you did.",
        "Now is not the time to be trapped in my own silent thoughts.",
        "I should prepare myself for tomorrow.",
        "Yes. It won't be long now.",
        "The King offers a confident smile.",
        "I will see you on the battlefield.",
        "Sire.",
        "The Hero bows as the King takes his leave."
    };
    string[] builderdialogtext = {
        "Oi!",
        "The Builder places his tools on a bench.",
        "He dusts his hands on his apron before extending a hand.",
        "My old friend.",
        "The King takes the Builder's hand in a firm shake.",
        "Look at ya—all dressed up for the battle, huh?",
        "Indeed.",
        "It's a shame we couldn't work things out in a more peaceful manner...",
        "Ah, it's not yer fault.",
        "In ways, it is.",
        "Nah, no need to beat yerself up about it.",
        "Ya know, when we were boys, I knew you were meant fer greatness.",
        "And look at ya now!",
        "The King of a newly formed kingdom.",
        "Yes... and already at war.",
        "Those old coots will always oppose a new power.",
        "Considering how successful ya been—",
        "Perhaps it is retribution for my greed?",
        "Don't say that!",
        "Look, I wouldn't have followed ya all this way if I didn't believe in the same things as ya.",
        "None of us would've!",
        "I also wouldn't have followed ya if I didn't believe in ya.",
        "But, I knew I could trust ya to make a better life for all of us here.",
        "Away from all that old world nonsense.",
        "Yes, but—",
        "The Builder heaves a loud sigh and looks seriously at the King.",
        "After what happened to my sister, I didn't know what I'd do.",
        "I considered lots of things, ya know. Not pretty things, either.",
        "Things she'd have been ashamed of me for even thinking.",
        "Ya pulled me outta that.",
        "Ya pulled all of us outta that.",
        "We built a new life here.",
        "I think we deserve to keep it for a bit longer, don't ya agree?",
        "The King chuckles and nods. His shoulders relax a little.",
        "Yes. I couldn't have said it better myself.",
        "Thank you, my friend.",
        "Hehe, don't mention it.",
        "The King and the Builder look upon the kingdom and the people.",
        "We all worked hard to bring this dream to fruition.",
        "I won't let us lose it so easily.",
        "None of us will.",
        "Speaking of which, I should get back to work.",
        "These walls ain't gonna fortify themselves, ya know!",
        "Hahahahaha!",
        "But, it was nice of ya to stop by and chat.",
        "Of course.",
        "Do you need any help?",
        "Nah, I can handle this.",
        "Besides, I'm sure ya got yer hands full with other things, don't ya?",
        "The Blacksmith smiles and waves as the King leaves."
    };
    string[] blacksmithdialogtext = {
      "What is Your Majesty doing here?",
      "Hello to you, too.",
      "Hmph.",
      "I don't mean to be rude, but aren't there more important things for you to do?",
      "Speaking with my subjects is important.",
      "I see.",
      "Well, is there something you wanted to talk about?",
      "Hm... I suppose... I am curious to see how you feel about our circumstances.",
      "The Blacksmith shifts his weight and releases an exasperated sigh.",
      "I never really thought I'd have to use my sword against another again...",
      "I retired for a reason.",
      "Yes, I'm aware.",
      "What makes me so worthy of taking another's life for the future of mine?",
      "We all have things we want to fight for.",
      "Anyone who chooses to go to war is aware of the consequences.",
      "I just wanted to live a peaceful life.",
      "To create ways to survive and protect.",
      "You've done a fine job.",
      "And you'll continue to do so.",
      "Of course, I wouldn't force you to fight if you do not want to—",
      "No.",
      "The Blacksmith shakes his head.",
      "I could keep making weapons for the coming battle...",
      "...But my past experiences will be a better contribution.",
      "The Blacksmith looks around at the passing townsfolk.",
      "Everyone is doing their part to help.",
      "Even though it means dirtying my hands... I need to do this.",
      "Thank you.",
      "I know that you've seen your fair share of bloodshed.",
      "Hopefully once this war is done, you can truly put your sword to rest.",
      "I look forward to living out the rest of my days in peace.",
      "We all do.",
      "And what of your apprentice?",
      "I heard you took on a young lad.",
      "I did.",
      "He will take care of the smithy while I'm away.",
      "He's much too young to fight.",
      "A wise choice.",
      "He's a fast learner, that one.",
      "I have high hopes for his future.",
      "The Blacksmith suddenly grows serious.",
      "If I should fall on the battlefield tomorrow...",
      "...Please see to it that he is taken care of.",
      "You have my word.",
      "Mm. Good.",
      "The two fall silent.",
      "After a moment, the Blacksmith clears his throat.",
      "Well, I should get back to the forge and make sure that kid is alright.",
      "Yes, indeed.",
      "The Blacksmith nods as he takes his leave."};
    string[] princedialogtext = {
          "Father! I-I mean... Sir!",
          "My son. How are you?",
          "I'm excited! I finally get to experience a real battle!",
          "Hmph. You're still so young.",
          "I wish you didn't have to be exposed to such things just yet.",
          "Why not? I'm not a kid anymore.",
          "Indeed, you've grown into a fine young man.",
          "Strong... smart... reliable.",
          "Exactly! You have nothing to worry about, father.",
          "I'm certain we'll be victorious.",
          "Hm...",
          "Sometimes I wonder if I could have done anything differently.",
          "Maybe then, I could have protected you from this for a little longer.",
          "The Prince pauses a moment, then reaches a hand out to the King.",
          "He places it on the King's shoulder and offers a reassuring squeeze.",
          "I am ready for this, father.",
          "And we will protect the future you fought so hard to build.",
          "...",
          "The King stares at the Prince. After a moment, he chuckles.",
          "He places his hand on his son's.",
          "I should be the one saying these things to you.",
          "Haha! I learned it all from you.",
          "The King and Prince smile.",
          "Anyway, did you need something from me?",
          "I just wanted to check in on you.",
          "A father can do that, can't he?",
          "Especially on a day such as this.",
          "I suppose so...",
          "But shouldn't you be talking to more important people?",
          "Like the Builder, since he's in charge of fortifying the walls?",
          "Or... the Blacksmith? He's fighting in the battle, isn't he?",
          "Does that mean his apprentice is taking over the forge in his absence?",
          "My family is important as well.",
          "It is because of you and your mother that this kingdom came to be.",
          "I know, I know—you wanted a better life for me and mother.",
          "Mother tells the story all the time.",
          "But perhaps you are right.",
          "There is still so much to do... and so little time.",
          "I can help!",
          "Just tell me what needs to be done. I'll see to it.",
          "Thank you, son... but there are certain things I personally need to see to.",
          "You may continue preparing yourself.",
          "Well, if you change your mind, I'll be around.",
          "Yes, of course.",
          "The Prince and King embrace for a brief moment before the King takes his leave."
    };

    characterSpeaking[] heroCharacterTalking = {
        characterSpeaking.npc,     // Hero
        characterSpeaking.pc,      // King
        characterSpeaking.npc,     // Hero
        characterSpeaking.npc,     // Hero
        characterSpeaking.npc,     // Hero
        characterSpeaking.pc,      // King
        characterSpeaking.pc,      // King
        characterSpeaking.npc,     // Hero
        characterSpeaking.npc,     // Hero
        characterSpeaking.npc,     // Hero
        characterSpeaking.pc,      // King
        characterSpeaking.npc,     // Hero
        characterSpeaking.narrator,// Narrator
        characterSpeaking.narrator,// Narrator
        characterSpeaking.pc,      // King
        characterSpeaking.narrator,// Narrator
        characterSpeaking.narrator,// Narrator
        characterSpeaking.npc,     // Hero
        characterSpeaking.npc,     // Hero
        characterSpeaking.pc,      // King
        characterSpeaking.npc,     // Hero
        characterSpeaking.npc,     // Hero
        characterSpeaking.npc,     // Hero
        characterSpeaking.npc,     // Hero
        characterSpeaking.pc,      // King
        characterSpeaking.npc,     // Hero
        characterSpeaking.pc,      // King
        characterSpeaking.narrator,// Narrator
        characterSpeaking.npc,     // Hero
        characterSpeaking.narrator,// Narrator
        characterSpeaking.npc,     // Hero
        characterSpeaking.pc,      // King
        characterSpeaking.npc,     // Hero
        characterSpeaking.npc,     // Hero
        characterSpeaking.npc,     // Hero
        characterSpeaking.pc,      // King
        characterSpeaking.narrator,// Narrator
        characterSpeaking.pc,      // King
        characterSpeaking.npc,     // Hero
        characterSpeaking.narrator // Narrator
    };
    characterSpeaking[] builderCharacterTalking = {
        characterSpeaking.npc,     // Builder
        characterSpeaking.narrator,// Narrator
        characterSpeaking.narrator,// Narrator
        characterSpeaking.pc,      // King
        characterSpeaking.narrator,// Narrator
        characterSpeaking.npc,     // Builder
        characterSpeaking.pc,      // King
        characterSpeaking.pc,      // King
        characterSpeaking.npc,     // Builder
        characterSpeaking.pc,      // King
        characterSpeaking.npc,     // Builder
        characterSpeaking.npc,     // Builder
        characterSpeaking.npc,     // Builder
        characterSpeaking.npc,     // Builder
        characterSpeaking.pc,      // King
        characterSpeaking.npc,     // Builder
        characterSpeaking.npc,     // Builder
        characterSpeaking.pc,      // King
        characterSpeaking.npc,
        characterSpeaking.npc,     // Builder
        characterSpeaking.npc,     // Builder
        characterSpeaking.npc,     // Builder
        characterSpeaking.npc,     // Builder
        characterSpeaking.npc,     // Builder
        characterSpeaking.pc,      // King
        characterSpeaking.narrator,// Narrator
        characterSpeaking.npc,
        characterSpeaking.npc,     // Builder
        characterSpeaking.npc,     // Builder
        characterSpeaking.npc,     // Builder
        characterSpeaking.npc,     // Builder
        characterSpeaking.npc,     // Builder
        characterSpeaking.npc,     // Builder
        characterSpeaking.narrator,// Narrator
        characterSpeaking.pc,      // King
        characterSpeaking.pc,      // King
        characterSpeaking.npc,     // Builder
        characterSpeaking.narrator,// Narrator
        characterSpeaking.pc,      // King
        characterSpeaking.pc,      // King
        characterSpeaking.npc,
        characterSpeaking.npc,     // Builder
        characterSpeaking.npc,     // Builder
        characterSpeaking.npc,     // Builder
        characterSpeaking.npc,     // Builder
        characterSpeaking.pc,      // King
        characterSpeaking.pc,      // King
        characterSpeaking.npc,     // Builder
        characterSpeaking.npc,     // Builder
        characterSpeaking.narrator // Narrator
    };
    characterSpeaking[] blacksmithcharacterTalking = {
        characterSpeaking.npc,     // Blacksmith
        characterSpeaking.pc,      // King
        characterSpeaking.npc,     // Blacksmith
        characterSpeaking.npc,     // Blacksmith
        characterSpeaking.pc,      // King
        characterSpeaking.npc,     // Blacksmith
        characterSpeaking.npc,     // Blacksmith
        characterSpeaking.pc,      // King
        characterSpeaking.narrator,// Narrator
        characterSpeaking.npc,     // Blacksmith
        characterSpeaking.npc,     // Blacksmith
        characterSpeaking.pc,      // King
        characterSpeaking.npc,     // Blacksmith
        characterSpeaking.pc,      // King
        characterSpeaking.pc,      // King
        characterSpeaking.npc,     // Blacksmith
        characterSpeaking.npc,     // Blacksmith
        characterSpeaking.pc,      // King
        characterSpeaking.pc,      // King
        characterSpeaking.pc,      // King
        characterSpeaking.npc,     // Blacksmith
        characterSpeaking.narrator,// Narrator
        characterSpeaking.npc,     // Blacksmith
        characterSpeaking.npc,     // Blacksmith
        characterSpeaking.narrator,// Narrator
        characterSpeaking.npc,     // Blacksmith
        characterSpeaking.npc,     // Blacksmith
        characterSpeaking.pc,      // King
        characterSpeaking.pc,      // King
        characterSpeaking.pc,      // King
        characterSpeaking.npc,     // Blacksmith
        characterSpeaking.pc,      // King
        characterSpeaking.pc,      // King
        characterSpeaking.pc,      // King
        characterSpeaking.npc,     // Blacksmith
        characterSpeaking.npc,     // Blacksmith
        characterSpeaking.npc,     // Blacksmith
        characterSpeaking.pc,      // King
        characterSpeaking.npc,     // Blacksmith
        characterSpeaking.npc,     // Blacksmith
        characterSpeaking.narrator,// Narrator
        characterSpeaking.npc,     // Blacksmith
        characterSpeaking.npc,     // Blacksmith
        characterSpeaking.pc,      // King
        characterSpeaking.npc,     // Blacksmith
        characterSpeaking.narrator,// Narrator
        characterSpeaking.narrator,// Narrator
        characterSpeaking.npc,     // Blacksmith
        characterSpeaking.pc,      // King
        characterSpeaking.narrator 
    };
    characterSpeaking[] princecharacterTalking = 
    {
        characterSpeaking.npc,     // Prince
        characterSpeaking.pc,      // King
        characterSpeaking.npc,     // Prince
        characterSpeaking.pc,      // King
        characterSpeaking.pc,      // King
        characterSpeaking.npc,     // Prince
        characterSpeaking.pc,      // King
        characterSpeaking.pc,      // King
        characterSpeaking.npc,     // Prince
        characterSpeaking.npc,     // Prince
        characterSpeaking.pc,      // King
        characterSpeaking.pc,      // King
        characterSpeaking.pc,      // King
        characterSpeaking.narrator,// Narrator
        characterSpeaking.narrator,// Narrator
        characterSpeaking.npc,     // Prince
        characterSpeaking.npc,     // Prince
        characterSpeaking.pc,      // King
        characterSpeaking.narrator,// Narrator
        characterSpeaking.narrator,// Narrator
        characterSpeaking.pc,      // King
        characterSpeaking.npc,     // Prince
        characterSpeaking.narrator,// Narrator
        characterSpeaking.npc,     // Prince
        characterSpeaking.pc,      // King
        characterSpeaking.pc,      // King
        characterSpeaking.pc,      // King
        characterSpeaking.npc,     // Prince
        characterSpeaking.npc,     // Prince
        characterSpeaking.npc,     // Prince
        characterSpeaking.npc,     // Prince
        characterSpeaking.npc,     // Prince
        characterSpeaking.pc,      // King
        characterSpeaking.pc,      // King
        characterSpeaking.npc,     // Prince
        characterSpeaking.npc,     // Prince
        characterSpeaking.pc,      // King
        characterSpeaking.pc,      // King
        characterSpeaking.npc,     // Prince
        characterSpeaking.npc,     // Prince
        characterSpeaking.pc,      // King
        characterSpeaking.pc,      // King
        characterSpeaking.npc,     // Prince
        characterSpeaking.pc,      // King
        characterSpeaking.narrator // Narrator
    };


    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            herodialog.sentences = herodialogtext;
            builderdialog.sentences = builderdialogtext;
            blackSmithdialog.sentences = blacksmithdialogtext;
            princedialog.sentences = princedialogtext;
            herodialog.characterToSpeak = heroCharacterTalking;
            builderdialog.characterToSpeak = builderCharacterTalking;
            blackSmithdialog.characterToSpeak = blacksmithcharacterTalking;
            princedialog.characterToSpeak = princecharacterTalking;
        }
    }
}

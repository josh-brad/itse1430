using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace JoshuaBradshaw.CharacterCreator
{
    public class Character
    {   
        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Agility { get; set; }
        public int Constitution { get; set; }
        public int Charisma { get; set; }
       
        private string _race;
        public string Race 
        {
            get { return _race ?? ""; }
            set { _race = value?.Trim() ?? ""; }
        }
       
        private string _biography;
        public string Biography
        {
            get { return _biography ?? ""; }
            set { _biography = value?.Trim() ?? ""; }
        }
        
        private string _name;
        public string Name
        {
            get { return _name ?? ""; }
            set { _name = value?.Trim() ?? ""; }
        }
        
        private string _profession;
        public string Profession
        {           
            get { return _profession ?? ""; }
            set { _profession = value?.Trim() ?? ""; }           
        }

        public override string ToString()
        {

            string[] message = { "Name: ".PadRight(20, ' ') + Name, "Race: ".PadRight(20, ' ') + Race , "Profession: ".PadRight(20, ' ') + Profession, 
                "Biography: ".PadRight(20, ' ') + Biography, "Strength: ".PadRight(20, ' ') + Strength, "Intelligence: ".PadRight(20, ' ') + Intelligence,
                "Agility: ".PadRight(20, ' ') + Agility, "Constitution: ".PadRight(20, ' ') + Constitution, "Charisma: ".PadRight(20, ' ') + Charisma};

             return string.Join("\n", message);
        }

    }
}
//string[] message = { "Name: ".PadRight(10, ' ') + Name, $"Race: ", $"Profession: {Profession}", $"Biography: {Biography}",
//                $"Strength: {Strength}", $"Inteligence: {Intelligence}", $"Agility: {Agility}", $"Constitution: {Constitution}", $"Charisma: {Charisma}"};



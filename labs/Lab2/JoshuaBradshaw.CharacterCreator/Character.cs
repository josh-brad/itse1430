using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoshuaBradshaw.CharacterCreator
{
    public class Character
    {

        private int _strength;
        public int Strength 
        {
            get { return _strength; }
            set { _strength = VerifyStats(value) ? value: 55; }
        }

        private int _intelligence;
        public int Intelligence
        {
            get { return _intelligence; }
            set { _intelligence = VerifyStats(value) ? value : 55; }
        }

        private int _agility;
        public int Agility 
        {
            get { return _agility; }
            set { _agility = VerifyStats(value) ? value : 55; }
        }

        private int _constitution;
        public int Constitution 
        {
            get { return _constitution; }
            set { _constitution = VerifyStats(value) ? value : 55; }
        }

        private int _charisma;
        public int Charisma 
        {
            get { return _charisma; }
            set { _charisma = VerifyStats(value) ? value : 55; }
        }
       
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


        ////public Character ( string name, string profession, string race )
        ////{
        ////    _name = name;
        ////   _profession = profession;
        ////  _race = race;
        ////}
       

        public void SetStrength (int strength)
        {
            if (VerifyStats(strength))
            {
                _strength = strength;
            }
        }

        private bool VerifyStats (int stat)
        {
            return stat <= 100 && stat >= 1;                           
        }

        public override string ToString()
        {
            string[] message = { $"Name: {Name}", $"Race: {Race}", $"Profession: {Profession}", $"Biography: {Biography}", 
                $"Strength: {Strength}", $"Inteligence: {Intelligence}", $"Agility: {Agility}", $"Constitution: {Constitution}", $"Charisma: {Charisma}"};

             return string.Join("\n", message);
        }

    }
}


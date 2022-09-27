using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoshuaBradshaw.CharacterCreator
{
    public class Character
    {
        private string _name;
        private string _profession;
        private string _race;
        private string _biography;
        private int _strength;
        private int _intelligence;
        private int _agility;
        private int _constitution;
        private int _charisma;

        public Character ( string name, string profession, string race )
        {
            _name = name;
            _profession = profession;
            _race = race;
        }
        public string GetName ()
        {
            return _name;
        }

        public string GetProfession()
        {
            return _profession;
        }

        public string GetRace ()
        {
            return _race;
        }
         
        public string GetBiography ()
        {
            return _biography;
        }

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
    }
}


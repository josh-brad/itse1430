using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

// Joshua Bradshaw
// ISTE 1430
// Fall Semester: 10-19-22

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
    }
}


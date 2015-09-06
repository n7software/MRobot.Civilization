using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRobot.CivilizationV.Civs
{
    public partial class Leader
    {
        private static IList<Leader> _All;
        public static IList<Leader> All
        {
            get
            {
                if (_All == null)
                    _All = Util.GetStaticFieldsOfType<Leader>();
                return _All;
            }
        }

        public static readonly Leader Washington = new Leader("Washington");
        public static readonly Leader HarunAlRashid = new Leader("Harun al-Rashid", "HARUN_AL_RASHId");
        public static readonly Leader Ashurbanipal= new Leader("Ashurbanipal");
        public static readonly Leader MariaTheresa = new Leader("Maria Theresa", "MARIA");
        public static readonly Leader Montezuma = new Leader("Montezuma");
        public static readonly Leader NebuchadnezzarII = new Leader("Nebuchadnezzar II", "NEBUCHADNEZZAR");
        public static readonly Leader PedroII = new Leader("Pedro II", "PEDRO");
        public static readonly Leader Theodora = new Leader("Theodora");
        public static readonly Leader Dido = new Leader("Dido");
        public static readonly Leader Boudicca = new Leader("Boudicca");
        public static readonly Leader WuZetian = new Leader("Wu Zetian", "WU_ZETIAN");
        public static readonly Leader HaraldBluetooth = new Leader("Harald Bluetooth", "HARALD");
        public static readonly Leader William = new Leader("William");
        public static readonly Leader Ramesses = new Leader("Ramesses II", "RAMESSES");
        public static readonly Leader Elizabeth = new Leader("Elizabeth");
        public static readonly Leader HaileSelassie = new Leader("Haile Selassie", "SELASSIE");
        public static readonly Leader Napoleon = new Leader("Napoleon");
        public static readonly Leader Bismarck = new Leader("Bismarck");
        public static readonly Leader Alexander = new Leader("Alexander");
        public static readonly Leader Atilla = new Leader("Attila");
        public static readonly Leader Pachacuti = new Leader("Pachacuti");
        public static readonly Leader Gandhi = new Leader("Gandhi");
        public static readonly Leader GajahMada = new Leader("Gajah Mada", "GAJAH_MADA");
        public static readonly Leader Hiawatha = new Leader("Hiawatha");
        public static readonly Leader OdaNobunaga = new Leader("Oda Nobunaga", "ODA_NOBUNAGA");
        public static readonly Leader Sejong = new Leader("Sejong");
        public static readonly Leader Pacal = new Leader("Pacal");
        public static readonly Leader GenghisKhan = new Leader("Genghis Khan", "GENGHIS_KHAN");
        public static readonly Leader AhmadAlMansur = new Leader("Ahmad al-Mansur", "AHMAD_ALMANSUR");
        public static readonly Leader Suleiman = new Leader("Suleiman");
        public static readonly Leader Darius = new Leader("Darius I", "DARIUS");
        public static readonly Leader Casimir = new Leader("Casimir III", "CASIMIR");
        public static readonly Leader Kamehameha = new Leader("Kamehameha");
        public static readonly Leader Maria  = new Leader("Maria I", "MARIA_I");
        public static readonly Leader AugustusCaesar = new Leader("Augustus Caesar", "AUGUSTUS");
        public static readonly Leader Catherine = new Leader("Catherine");
        public static readonly Leader Pocatello = new Leader("Pocatello");
        public static readonly Leader Ramkhamhaeng = new Leader("Ramkhamhaeng");
        public static readonly Leader Askia = new Leader("Askia");
        public static readonly Leader Isabella = new Leader("Isabella");
        public static readonly Leader GustavusAdolphus = new Leader("Gustavus Adolphus", "GUSTAVUS_ADOLPHUS");
        public static readonly Leader EnricoDandolo = new Leader("Enrico Dandolo", "ENRICO_DANDOLO");
        public static readonly Leader Shaka = new Leader("Shaka");
        public static readonly Leader Barbarian = new Leader("Barbarian");
    }
}

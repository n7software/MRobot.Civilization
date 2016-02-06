using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRobot.Civilization.Civ5
{

    public sealed partial class DefaultCivilizations
    {
        private static IDictionary<string, Func<ICivilization>> _CivsByName;
        public static ICivilization FindBySaveName(SaveString name)
        {
            if (_CivsByName == null)
                _CivsByName = Utils.GetStaticGettersOfType<string, ICivilization>(typeof(Civilization), civ => civ.SaveName);

            if (_CivsByName.ContainsKey(name))
                return _CivsByName[name]();
            else return null;
        }

        private static IDictionary<int, Func<ICivilization>> _CivsById;

        public static ICivilization FindById(int id)
        {
            VerifyCivsByIdDict();

            if (_CivsById.ContainsKey(id))
                return _CivsById[id]();
            else return null;
        }

        private static void VerifyCivsByIdDict()
        {
            if (_CivsById == null)
                _CivsById = Utils.GetStaticGettersOfType<int, ICivilization>(typeof(Civilization), civ => civ.Id);
        }

        public static IEnumerable<ICivilization> GetAll()
        {
            VerifyCivsByIdDict();
            return _CivsById.Values.Select(create => create());
        }

        public static ICivilization America
        {
            get
            {
                return new Civilization
                (
                    id: 1,
                    name: "America",
                    color: DefaultPlayerColors.America,
                    leader: DefaultLeaders.Washington
                );
            }
        }
        public static ICivilization Arabia
		{
			get
			{
				return new Civilization
                (
                    id: 2,
                    name: "Arabia",
                    color: DefaultPlayerColors.Arabia,
                    leader: DefaultLeaders.HarunAlRashid
                );
			}
		}
        public static ICivilization Assyria
		{
			get
			{
				return new Civilization
                (
                    id: 3,
                    name: "Assyria",
                    color: DefaultPlayerColors.Assyria, 
                    requirement: Expansion.BraveNewWorld,
                    leader: DefaultLeaders.Ashurbanipal
                );
			}
		}
        public static ICivilization Austria
		{
			get
			{
				return new Civilization
                (
                    id: 4,
                    name: "Austria",
                    color: DefaultPlayerColors.Austria, 
                    requirement: Expansion.GodsAndKings,
                    leader: DefaultLeaders.MariaTheresa
                );
			}
		}
        public static ICivilization Aztecs
		{
			get
			{
				return new Civilization
                (
                    id: 5,
                    name: "Aztec",
                    color: DefaultPlayerColors.Aztecs,
                    leader: DefaultLeaders.Montezuma
                );
			}
		}
        public static ICivilization Babylon
		{
			get
			{
				return new Civilization
                (
                    id: 6,
                    name: "Babylon",
                    color: DefaultPlayerColors.Babylon, 
                    requirement: Expansion.Babylon,
                    leader: DefaultLeaders.NebuchadnezzarII
                );
			}
		}
        public static ICivilization Brazil
		{
			get
			{
				return new Civilization
                (
                    id: 7,
                    name: "Brazil",
                    color: DefaultPlayerColors.Brazil, 
                    requirement: Expansion.BraveNewWorld,
                    leader: DefaultLeaders.PedroII
                );
			}
		}
        public static ICivilization Byzantium
		{
			get
			{
				return new Civilization
                (
                    id: 8,
                    name: "Byzantium",
                    color: DefaultPlayerColors.Byzantium, 
                    requirement: Expansion.GodsAndKings,
                    leader: DefaultLeaders.Theodora
                );
			}
		}
        public static ICivilization Carthage
		{
			get
			{
				return new Civilization
                (
                    id: 9,
                    name: "Carthage",
                    color: DefaultPlayerColors.Carthage, 
                    requirement: Expansion.GodsAndKings,
                    leader: DefaultLeaders.Dido
                );
			}
		}
        public static ICivilization Celts
		{
			get
			{
				return new Civilization
                (
                    id: 10,
                    name: "Celts",
                    color: DefaultPlayerColors.Celts, 
                    requirement: Expansion.GodsAndKings,
                    leader: DefaultLeaders.Boudicca
                );
			}
		}
        public static ICivilization China
		{
			get
			{
				return new Civilization
                (
                    id: 11,
                    name: "China",
                    color: DefaultPlayerColors.China,
                    leader: DefaultLeaders.WuZetian
                );
			}
		}
        public static ICivilization Denmark
		{
			get
			{
				return new Civilization
                (
                    id: 12,
                    name: "Denmark",
                    color: DefaultPlayerColors.Denmark, 
                    requirement: Expansion.Denmark,
                    leader: DefaultLeaders.HaraldBluetooth
                );
			}
		}
        public static ICivilization Egypt
		{
			get
			{
				return new Civilization
                (
                    id: 13,
                    name: "Egypt",
                    color: DefaultPlayerColors.Egypt,
                    leader: DefaultLeaders.Ramesses
                );
			}
		}
        public static ICivilization England
		{
			get
			{
				return new Civilization
                (
                    id: 14,
                    name: "England",
                    color: DefaultPlayerColors.England,
                    leader: DefaultLeaders.Elizabeth
                );
			}
		}
        public static ICivilization Ethiopia
		{
			get
			{
				return new Civilization
                (
                    id: 15,
                    name: "Ethiopia",
                    color: DefaultPlayerColors.Ethiopia,
                    requirement: Expansion.GodsAndKings,
                    leader: DefaultLeaders.HaileSelassie
                );
			}
		}
        public static ICivilization France
		{
			get
			{
				return new Civilization
                (
                    id: 16,
                    name: "France",
                    color: DefaultPlayerColors.France,
                    leader: DefaultLeaders.Napoleon
                );
			}
		}
        public static ICivilization Germany
		{
			get
			{
				return new Civilization
                (
                    id: 17,
                    name: "Germany",
                    color: DefaultPlayerColors.Germany,
                    leader: DefaultLeaders.Bismarck
                );
			}
		}
        public static ICivilization Greece
		{
			get
			{
				return new Civilization
                (
                    id: 18,
                    name: "Greece",
                    color: DefaultPlayerColors.Greece,
                    leader: DefaultLeaders.Alexander
                );
			}
		}
        public static ICivilization Huns
		{
			get
			{
				return new Civilization
                (
                    id: 19,
                    name: "Huns",
                    color: DefaultPlayerColors.Huns,
                    requirement: Expansion.GodsAndKings,
                    leader: DefaultLeaders.Atilla
                );
			}
		}
        public static ICivilization Inca
		{
			get
			{
				return new Civilization
                (
                    id: 20,
                    name: "Inca",
                    color: DefaultPlayerColors.Inca,
                    requirement: Expansion.SpainAndInca,
                    leader: DefaultLeaders.Pachacuti
                );
			}
		}
        public static ICivilization India
		{
			get
			{
				return new Civilization
                (
                    id: 21,
                    name: "India",
                    color: DefaultPlayerColors.India,
                    leader: DefaultLeaders.Gandhi
                );
			}
		}
        public static ICivilization Indonesia
		{
			get
			{
				return new Civilization
                (
                    id: 22,
                    name: "Indonesia",
                    color: DefaultPlayerColors.Indonesia,
                    requirement: Expansion.BraveNewWorld,
                    leader: DefaultLeaders.GajahMada
                );
			}
		}
        public static ICivilization Iroquois
		{
			get
			{
				return new Civilization
                (
                    id: 23,
                    name: "Iroquois",
                    color: DefaultPlayerColors.Iroquois,
                    leader: DefaultLeaders.Hiawatha
                );
			}
		}
        public static ICivilization Japan
		{
			get
			{
				return new Civilization
                (
                    id: 24,
                    name: "Japan",
                    color: DefaultPlayerColors.Japan,
                    leader: DefaultLeaders.OdaNobunaga
                );
			}
		}
        public static ICivilization Korea
		{
			get
			{
				return new Civilization
                (
                    id: 25,
                    name: "Korea",
                    color: DefaultPlayerColors.Korea,
                    requirement: Expansion.Korea,
                    leader: DefaultLeaders.Sejong
                );
			}
		}
        public static ICivilization Maya
		{
			get
			{
				return new Civilization
                (
                    id: 26,
                    name: "Maya",
                    color: DefaultPlayerColors.Maya,
                    requirement: Expansion.GodsAndKings,
                    leader: DefaultLeaders.Pacal
                );
			}
		}
        public static ICivilization Mongolia
		{
			get
			{
				return new Civilization
                (
                    id: 27,
                    name: "Mongolia",
                    color: DefaultPlayerColors.Mongolia,
                    requirement: Expansion.Mongolia,
                    leader: DefaultLeaders.GenghisKhan
                );
			}
		}
        public static ICivilization Morocco
		{
			get
			{
				return new Civilization
                (
                    id: 28,
                    name: "Morocco",
                    color: DefaultPlayerColors.Morocco,
                    requirement: Expansion.BraveNewWorld,
                    leader: DefaultLeaders.AhmadAlMansur
                );
			}
		}
        public static ICivilization Netherlands
		{
			get
			{
				return new Civilization
                (
                    id: 29,
                    name: "Netherlands",
                    color: DefaultPlayerColors.Netherlands,
                    requirement: Expansion.GodsAndKings,
                    leader: DefaultLeaders.William
                );
			}
		}
        public static ICivilization Ottomans
		{
			get
			{
				return new Civilization
                (
                    id: 30,
                    name: "Ottoman",
                    color: DefaultPlayerColors.Ottomans,
                    leader: DefaultLeaders.Suleiman
                );
			}
		}
        public static ICivilization Persia
		{
			get
			{
				return new Civilization
                (
                    id: 31,
                    name: "Persia",
                    color: DefaultPlayerColors.Persia,
                    leader: DefaultLeaders.Darius
                );
			}
		}
        public static ICivilization Poland
		{
			get
			{
				return new Civilization
                (
                    id: 32,
                    name: "Poland",
                    color: DefaultPlayerColors.Poland,
                    requirement: Expansion.BraveNewWorld,
                    leader: DefaultLeaders.Casimir
                );
			}
		}
        public static ICivilization Polynesia
		{
			get
			{
				return new Civilization
                (
                    id: 33,
                    name: "Polynesia",
                    color: DefaultPlayerColors.Polynesia,
                    requirement: Expansion.Polynesia,
                    leader: DefaultLeaders.Kamehameha
                );
			}
		}
        public static ICivilization Portugal
		{
			get
			{
				return new Civilization
                (
                    id: 34,
                    name: "Portugal",
                    color: DefaultPlayerColors.Portugal,
                    requirement: Expansion.BraveNewWorld,
                    leader: DefaultLeaders.Maria
                );
			}
		}
        public static ICivilization Rome
		{
			get
			{
				return new Civilization
                (
                    id: 35,
                    name: "Rome",
                    color: DefaultPlayerColors.Rome,
                    leader: DefaultLeaders.AugustusCaesar
                );
			}
		}
        public static ICivilization Russia
		{
			get
			{
				return new Civilization
                (
                    id: 36,
                    name: "Russia",
                    color: DefaultPlayerColors.Russia,
                    leader: DefaultLeaders.Catherine
                );
			}
		}
        public static ICivilization Shoshone
		{
			get
			{
				return new Civilization
                (
                    id: 37,
                    name: "Shoshone",
                    color: DefaultPlayerColors.Shoshone,
                    requirement: Expansion.BraveNewWorld,
                    leader: DefaultLeaders.Pocatello
                );
			}
		}
        public static ICivilization Siam
		{
			get
			{
				return new Civilization
                (
                    id: 38,
                    name: "Siam",
                    color: DefaultPlayerColors.Siam,
                    leader: DefaultLeaders.Ramkhamhaeng
                );
			}
		}
        public static ICivilization Songhai
		{
			get
			{
				return new Civilization
                (
                    id: 39,
                    name: "Songhai",
                    color: DefaultPlayerColors.Songhai,
                    leader: DefaultLeaders.Askia
                );
			}
		}
        public static ICivilization Spain
		{
			get
			{
				return new Civilization
                (
                    id: 40,
                    name: "Spain",
                    color: DefaultPlayerColors.Spain,
                    requirement: Expansion.SpainAndInca,
                    leader: DefaultLeaders.Isabella
                );
			}
		}
        public static ICivilization Sweden
		{
			get
			{
				return new Civilization
                (
                    id: 41,
                    name: "Sweden",
                    color: DefaultPlayerColors.Sweden,
                    requirement: Expansion.GodsAndKings,
                    leader: DefaultLeaders.GustavusAdolphus
                );
			}
		}
        public static ICivilization Venice
		{
			get
			{
				return new Civilization
                (
                    id: 42,
                    name: "Venice",
                    color: DefaultPlayerColors.Venice,
                    requirement: Expansion.BraveNewWorld,
                    leader: DefaultLeaders.EnricoDandolo
                );
			}
		}
        public static ICivilization Zulus
		{
			get
			{
				return new Civilization
                (
                    id: 43,
                    name: "Zulu",
                    color: DefaultPlayerColors.Zulus,
                    requirement: Expansion.BraveNewWorld,
                    leader: DefaultLeaders.Shaka
                );
			}
		}
        public static ICivilization Unknown
		{
			get
			{
                return new Civilization
                (
                    id: 0,
                    name: String.Empty,
                    leader: DefaultLeaders.Barbarian
                );
			}
		}
    }
}

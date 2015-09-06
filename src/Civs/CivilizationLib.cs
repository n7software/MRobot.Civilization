using MRobot.CivilizationV.Color;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRobot.CivilizationV.Civs
{
    using System.Net.Mail;

    public sealed partial class Civilization
    {
        private static IDictionary<string, Func<ICivilization>> _CivsByName;
        public static ICivilization FindBySaveName(SaveString name)
        {
            if (_CivsByName == null)
                _CivsByName = Util.GetStaticGettersOfType<string, ICivilization>(typeof(Civilization), civ => civ.SaveName);

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
                _CivsById = Util.GetStaticGettersOfType<int, ICivilization>(typeof(Civilization), civ => civ.Id);
        }

        public static IEnumerable<ICivilization> GetAllDefaultCivs()
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
                    color: PlayerColor.America,
                    leader: Leader.Washington
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
                    color: PlayerColor.Arabia,
                    leader: Leader.HarunAlRashid
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
                    color: PlayerColor.Assyria, 
                    requirement: Expansion.BraveNewWorld,
                    leader: Leader.Ashurbanipal
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
                    color: PlayerColor.Austria, 
                    requirement: Expansion.GodsAndKings,
                    leader: Leader.MariaTheresa
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
                    color: PlayerColor.Aztecs,
                    leader: Leader.Montezuma
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
                    color: PlayerColor.Babylon, 
                    requirement: Expansion.Babylon,
                    leader: Leader.NebuchadnezzarII
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
                    color: PlayerColor.Brazil, 
                    requirement: Expansion.BraveNewWorld,
                    leader: Leader.PedroII
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
                    color: PlayerColor.Byzantium, 
                    requirement: Expansion.GodsAndKings,
                    leader: Leader.Theodora
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
                    color: PlayerColor.Carthage, 
                    requirement: Expansion.GodsAndKings,
                    leader: Leader.Dido
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
                    color: PlayerColor.Celts, 
                    requirement: Expansion.GodsAndKings,
                    leader: Leader.Boudicca
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
                    color: PlayerColor.China,
                    leader: Leader.WuZetian
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
                    color: PlayerColor.Denmark, 
                    requirement: Expansion.Denmark,
                    leader: Leader.HaraldBluetooth
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
                    color: PlayerColor.Egypt,
                    leader: Leader.Ramesses
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
                    color: PlayerColor.England,
                    leader: Leader.Elizabeth
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
                    color: PlayerColor.Ethiopia,
                    requirement: Expansion.GodsAndKings,
                    leader: Leader.HaileSelassie
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
                    color: PlayerColor.France,
                    leader: Leader.Napoleon
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
                    color: PlayerColor.Germany,
                    leader: Leader.Bismarck
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
                    color: PlayerColor.Greece,
                    leader: Leader.Alexander
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
                    color: PlayerColor.Huns,
                    requirement: Expansion.GodsAndKings,
                    leader: Leader.Atilla
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
                    color: PlayerColor.Inca,
                    requirement: Expansion.SpainAndInca,
                    leader: Leader.Pachacuti
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
                    color: PlayerColor.India,
                    leader: Leader.Gandhi
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
                    color: PlayerColor.Indonesia,
                    requirement: Expansion.BraveNewWorld,
                    leader: Leader.GajahMada
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
                    color: PlayerColor.Iroquois,
                    leader: Leader.Hiawatha
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
                    color: PlayerColor.Japan,
                    leader: Leader.OdaNobunaga
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
                    color: PlayerColor.Korea,
                    requirement: Expansion.Korea,
                    leader: Leader.Sejong
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
                    color: PlayerColor.Maya,
                    requirement: Expansion.GodsAndKings,
                    leader: Leader.Pacal
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
                    color: PlayerColor.Mongolia,
                    requirement: Expansion.Mongolia,
                    leader: Leader.GenghisKhan
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
                    color: PlayerColor.Morocco,
                    requirement: Expansion.BraveNewWorld,
                    leader: Leader.AhmadAlMansur
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
                    color: PlayerColor.Netherlands,
                    requirement: Expansion.GodsAndKings,
                    leader: Leader.William
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
                    color: PlayerColor.Ottomans,
                    leader: Leader.Suleiman
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
                    color: PlayerColor.Persia,
                    leader: Leader.Darius
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
                    color: PlayerColor.Poland,
                    requirement: Expansion.BraveNewWorld,
                    leader: Leader.Casimir
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
                    color: PlayerColor.Polynesia,
                    requirement: Expansion.Polynesia,
                    leader: Leader.Kamehameha
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
                    color: PlayerColor.Portugal,
                    requirement: Expansion.BraveNewWorld,
                    leader: Leader.Maria
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
                    color: PlayerColor.Rome,
                    leader: Leader.AugustusCaesar
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
                    color: PlayerColor.Russia,
                    leader: Leader.Catherine
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
                    color: PlayerColor.Shoshone,
                    requirement: Expansion.BraveNewWorld,
                    leader: Leader.Pocatello
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
                    color: PlayerColor.Siam,
                    leader: Leader.Ramkhamhaeng
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
                    color: PlayerColor.Songhai,
                    leader: Leader.Askia
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
                    color: PlayerColor.Spain,
                    requirement: Expansion.SpainAndInca,
                    leader: Leader.Isabella
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
                    color: PlayerColor.Sweden,
                    requirement: Expansion.GodsAndKings,
                    leader: Leader.GustavusAdolphus
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
                    color: PlayerColor.Venice,
                    requirement: Expansion.BraveNewWorld,
                    leader: Leader.EnricoDandolo
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
                    color: PlayerColor.Zulus,
                    requirement: Expansion.BraveNewWorld,
                    leader: Leader.Shaka
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
                    leader: Leader.Barbarian
                );
			}
		}
    }
}

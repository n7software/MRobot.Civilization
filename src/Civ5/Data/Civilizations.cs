using System;
using System.Collections.Generic;
using System.Linq;
using MRobot.Civilization.Base;

namespace MRobot.Civilization.Civ5.Data
{
    public static class Civilizations
    {
        private static IDictionary<string, Func<ICivilization>> _CivsByName;
        public static ICivilization FindBySaveName(SaveString name)
        {
            if (_CivsByName == null)
                _CivsByName = Utils.GetStaticGettersOfType<string, ICivilization>(typeof(Base.Civilization), civ => civ.SaveName);

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
                _CivsById = Utils.GetStaticGettersOfType<int, ICivilization>(typeof(Base.Civilization), civ => civ.Id);
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
                return new Base.Civilization
                (
                    id: 1,
                    name: "America",
                    color: PlayerColors.America,
                    leader: Leaders.Washington
                );
            }
        }
        public static ICivilization Arabia
		{
			get
			{
				return new Base.Civilization
                (
                    id: 2,
                    name: "Arabia",
                    color: PlayerColors.Arabia,
                    leader: Leaders.HarunAlRashid
                );
			}
		}
        public static ICivilization Assyria
		{
			get
			{
				return new Base.Civilization
                (
                    id: 3,
                    name: "Assyria",
                    color: PlayerColors.Assyria, 
                    requirement: Expansions.BraveNewWorld,
                    leader: Leaders.Ashurbanipal
                );
			}
		}
        public static ICivilization Austria
		{
			get
			{
				return new Base.Civilization
                (
                    id: 4,
                    name: "Austria",
                    color: PlayerColors.Austria, 
                    requirement: Expansions.GodsAndKings,
                    leader: Leaders.MariaTheresa
                );
			}
		}
        public static ICivilization Aztecs
		{
			get
			{
				return new Base.Civilization
                (
                    id: 5,
                    name: "Aztec",
                    color: PlayerColors.Aztecs,
                    leader: Leaders.Montezuma
                );
			}
		}
        public static ICivilization Babylon
		{
			get
			{
				return new Base.Civilization
                (
                    id: 6,
                    name: "Babylon",
                    color: PlayerColors.Babylon, 
                    requirement: Expansions.Babylon,
                    leader: Leaders.NebuchadnezzarII
                );
			}
		}
        public static ICivilization Brazil
		{
			get
			{
				return new Base.Civilization
                (
                    id: 7,
                    name: "Brazil",
                    color: PlayerColors.Brazil, 
                    requirement: Expansions.BraveNewWorld,
                    leader: Leaders.PedroII
                );
			}
		}
        public static ICivilization Byzantium
		{
			get
			{
				return new Base.Civilization
                (
                    id: 8,
                    name: "Byzantium",
                    color: PlayerColors.Byzantium, 
                    requirement: Expansions.GodsAndKings,
                    leader: Leaders.Theodora
                );
			}
		}
        public static ICivilization Carthage
		{
			get
			{
				return new Base.Civilization
                (
                    id: 9,
                    name: "Carthage",
                    color: PlayerColors.Carthage, 
                    requirement: Expansions.GodsAndKings,
                    leader: Leaders.Dido
                );
			}
		}
        public static ICivilization Celts
		{
			get
			{
				return new Base.Civilization
                (
                    id: 10,
                    name: "Celts",
                    color: PlayerColors.Celts, 
                    requirement: Expansions.GodsAndKings,
                    leader: Leaders.Boudicca
                );
			}
		}
        public static ICivilization China
		{
			get
			{
				return new Base.Civilization
                (
                    id: 11,
                    name: "China",
                    color: PlayerColors.China,
                    leader: Leaders.WuZetian
                );
			}
		}
        public static ICivilization Denmark
		{
			get
			{
				return new Base.Civilization
                (
                    id: 12,
                    name: "Denmark",
                    color: PlayerColors.Denmark, 
                    requirement: Expansions.Denmark,
                    leader: Leaders.HaraldBluetooth
                );
			}
		}
        public static ICivilization Egypt
		{
			get
			{
				return new Base.Civilization
                (
                    id: 13,
                    name: "Egypt",
                    color: PlayerColors.Egypt,
                    leader: Leaders.Ramesses
                );
			}
		}
        public static ICivilization England
		{
			get
			{
				return new Base.Civilization
                (
                    id: 14,
                    name: "England",
                    color: PlayerColors.England,
                    leader: Leaders.Elizabeth
                );
			}
		}
        public static ICivilization Ethiopia
		{
			get
			{
				return new Base.Civilization
                (
                    id: 15,
                    name: "Ethiopia",
                    color: PlayerColors.Ethiopia,
                    requirement: Expansions.GodsAndKings,
                    leader: Leaders.HaileSelassie
                );
			}
		}
        public static ICivilization France
		{
			get
			{
				return new Base.Civilization
                (
                    id: 16,
                    name: "France",
                    color: PlayerColors.France,
                    leader: Leaders.Napoleon
                );
			}
		}
        public static ICivilization Germany
		{
			get
			{
				return new Base.Civilization
                (
                    id: 17,
                    name: "Germany",
                    color: PlayerColors.Germany,
                    leader: Leaders.Bismarck
                );
			}
		}
        public static ICivilization Greece
		{
			get
			{
				return new Base.Civilization
                (
                    id: 18,
                    name: "Greece",
                    color: PlayerColors.Greece,
                    leader: Leaders.Alexander
                );
			}
		}
        public static ICivilization Huns
		{
			get
			{
				return new Base.Civilization
                (
                    id: 19,
                    name: "Huns",
                    color: PlayerColors.Huns,
                    requirement: Expansions.GodsAndKings,
                    leader: Leaders.Atilla
                );
			}
		}
        public static ICivilization Inca
		{
			get
			{
				return new Base.Civilization
                (
                    id: 20,
                    name: "Inca",
                    color: PlayerColors.Inca,
                    requirement: Expansions.SpainAndInca,
                    leader: Leaders.Pachacuti
                );
			}
		}
        public static ICivilization India
		{
			get
			{
				return new Base.Civilization
                (
                    id: 21,
                    name: "India",
                    color: PlayerColors.India,
                    leader: Leaders.Gandhi
                );
			}
		}
        public static ICivilization Indonesia
		{
			get
			{
				return new Base.Civilization
                (
                    id: 22,
                    name: "Indonesia",
                    color: PlayerColors.Indonesia,
                    requirement: Expansions.BraveNewWorld,
                    leader: Leaders.GajahMada
                );
			}
		}
        public static ICivilization Iroquois
		{
			get
			{
				return new Base.Civilization
                (
                    id: 23,
                    name: "Iroquois",
                    color: PlayerColors.Iroquois,
                    leader: Leaders.Hiawatha
                );
			}
		}
        public static ICivilization Japan
		{
			get
			{
				return new Base.Civilization
                (
                    id: 24,
                    name: "Japan",
                    color: PlayerColors.Japan,
                    leader: Leaders.OdaNobunaga
                );
			}
		}
        public static ICivilization Korea
		{
			get
			{
				return new Base.Civilization
                (
                    id: 25,
                    name: "Korea",
                    color: PlayerColors.Korea,
                    requirement: Expansions.Korea,
                    leader: Leaders.Sejong
                );
			}
		}
        public static ICivilization Maya
		{
			get
			{
				return new Base.Civilization
                (
                    id: 26,
                    name: "Maya",
                    color: PlayerColors.Maya,
                    requirement: Expansions.GodsAndKings,
                    leader: Leaders.Pacal
                );
			}
		}
        public static ICivilization Mongolia
		{
			get
			{
				return new Base.Civilization
                (
                    id: 27,
                    name: "Mongolia",
                    color: PlayerColors.Mongolia,
                    requirement: Expansions.Mongolia,
                    leader: Leaders.GenghisKhan
                );
			}
		}
        public static ICivilization Morocco
		{
			get
			{
				return new Base.Civilization
                (
                    id: 28,
                    name: "Morocco",
                    color: PlayerColors.Morocco,
                    requirement: Expansions.BraveNewWorld,
                    leader: Leaders.AhmadAlMansur
                );
			}
		}
        public static ICivilization Netherlands
		{
			get
			{
				return new Base.Civilization
                (
                    id: 29,
                    name: "Netherlands",
                    color: PlayerColors.Netherlands,
                    requirement: Expansions.GodsAndKings,
                    leader: Leaders.William
                );
			}
		}
        public static ICivilization Ottomans
		{
			get
			{
				return new Base.Civilization
                (
                    id: 30,
                    name: "Ottoman",
                    color: PlayerColors.Ottomans,
                    leader: Leaders.Suleiman
                );
			}
		}
        public static ICivilization Persia
		{
			get
			{
				return new Base.Civilization
                (
                    id: 31,
                    name: "Persia",
                    color: PlayerColors.Persia,
                    leader: Leaders.Darius
                );
			}
		}
        public static ICivilization Poland
		{
			get
			{
				return new Base.Civilization
                (
                    id: 32,
                    name: "Poland",
                    color: PlayerColors.Poland,
                    requirement: Expansions.BraveNewWorld,
                    leader: Leaders.Casimir
                );
			}
		}
        public static ICivilization Polynesia
		{
			get
			{
				return new Base.Civilization
                (
                    id: 33,
                    name: "Polynesia",
                    color: PlayerColors.Polynesia,
                    requirement: Expansions.Polynesia,
                    leader: Leaders.Kamehameha
                );
			}
		}
        public static ICivilization Portugal
		{
			get
			{
				return new Base.Civilization
                (
                    id: 34,
                    name: "Portugal",
                    color: PlayerColors.Portugal,
                    requirement: Expansions.BraveNewWorld,
                    leader: Leaders.Maria
                );
			}
		}
        public static ICivilization Rome
		{
			get
			{
				return new Base.Civilization
                (
                    id: 35,
                    name: "Rome",
                    color: PlayerColors.Rome,
                    leader: Leaders.AugustusCaesar
                );
			}
		}
        public static ICivilization Russia
		{
			get
			{
				return new Base.Civilization
                (
                    id: 36,
                    name: "Russia",
                    color: PlayerColors.Russia,
                    leader: Leaders.Catherine
                );
			}
		}
        public static ICivilization Shoshone
		{
			get
			{
				return new Base.Civilization
                (
                    id: 37,
                    name: "Shoshone",
                    color: PlayerColors.Shoshone,
                    requirement: Expansions.BraveNewWorld,
                    leader: Leaders.Pocatello
                );
			}
		}
        public static ICivilization Siam
		{
			get
			{
				return new Base.Civilization
                (
                    id: 38,
                    name: "Siam",
                    color: PlayerColors.Siam,
                    leader: Leaders.Ramkhamhaeng
                );
			}
		}
        public static ICivilization Songhai
		{
			get
			{
				return new Base.Civilization
                (
                    id: 39,
                    name: "Songhai",
                    color: PlayerColors.Songhai,
                    leader: Leaders.Askia
                );
			}
		}
        public static ICivilization Spain
		{
			get
			{
				return new Base.Civilization
                (
                    id: 40,
                    name: "Spain",
                    color: PlayerColors.Spain,
                    requirement: Expansions.SpainAndInca,
                    leader: Leaders.Isabella
                );
			}
		}
        public static ICivilization Sweden
		{
			get
			{
				return new Base.Civilization
                (
                    id: 41,
                    name: "Sweden",
                    color: PlayerColors.Sweden,
                    requirement: Expansions.GodsAndKings,
                    leader: Leaders.GustavusAdolphus
                );
			}
		}
        public static ICivilization Venice
		{
			get
			{
				return new Base.Civilization
                (
                    id: 42,
                    name: "Venice",
                    color: PlayerColors.Venice,
                    requirement: Expansions.BraveNewWorld,
                    leader: Leaders.EnricoDandolo
                );
			}
		}
        public static ICivilization Zulus
		{
			get
			{
				return new Base.Civilization
                (
                    id: 43,
                    name: "Zulu",
                    color: PlayerColors.Zulus,
                    requirement: Expansions.BraveNewWorld,
                    leader: Leaders.Shaka
                );
			}
		}
        public static ICivilization Unknown
		{
			get
			{
                return new Base.Civilization
                (
                    id: 0,
                    name: string.Empty,
                    leader: Leaders.Barbarian
                );
			}
		}
    }
}

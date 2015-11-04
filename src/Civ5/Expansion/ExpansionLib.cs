using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRobot.CivilizationV
{
    public partial class Expansion
    {
        private static IList<Expansion> _all;
        public static IList<Expansion> All
        {
            get
            {
                if (_all == null)
                    _all = Utils.GetStaticFieldsOfType<Expansion>();
                return _all;
            }
        }

        internal static IList<Expansion> _allWithInternal;
        internal static IList<Expansion> AllWithInternal
        {
            get
            {
                if (_allWithInternal == null)
                {
                    _allWithInternal = new List<Expansion>(All)
                    {
                        Mongolia, 
                        Upgrade1, 
                        CivilizationVComplete
                    };
                }

                return _allWithInternal;
            }
        }

        public static readonly Expansion SpainAndInca = new Expansion
        (
            id: 2,
            name: "Spain and Inca", 
            saveName: "Spain and Inca", 
            steamId: "16867",
            isFullExpansion: false,
            prefixBytes: new byte[] { 0xDE, 0xD5, 0x85, 0xB6, 0xCA, 0x7C, 0x75, 0x4E, 0x81, 0xB4, 0x2F, 0x60, 0x75, 0x4E, 0x63, 0x30 }
        );
        public static readonly Expansion Polynesia = new Expansion
        (
            id: 3,
            name: "Polynesia", 
            saveName: "Polynesia", 
            steamId: "99610",
            isFullExpansion: false,
            prefixBytes: new byte[] { 0x05, 0xC6, 0xF7, 0xEC, 0x11, 0xBA, 0xAC, 0x4C, 0x8D, 0x80, 0xD7, 0x13, 0x06, 0xAA, 0xC4, 0x71 }
        );
        public static readonly Expansion Denmark = new Expansion
        (
            id: 4,
            name: "Denmark", 
            saveName: "Denmark", 
            steamId: "99611",
            isFullExpansion: false,
            prefixBytes: new byte[] { 0x39, 0x0D, 0x03, 0xB3, 0xD8, 0xC0, 0xC7, 0x4B, 0x91, 0xB1, 0x7A, 0xD1, 0xCA, 0xF5, 0x85, 0xAB }
        );
        public static readonly Expansion Korea = new Expansion
        (
            id: 5,
            name: "Korea", 
            saveName: "Korea", 
            steamId: "99612",
            isFullExpansion: false,
            prefixBytes: new byte[] { 0xB2, 0x22, 0x2C, 0x11, 0x08, 0x53, 0xB6, 0x42, 0xB7, 0x34, 0x17, 0x1C, 0xCA, 0xB3, 0x03, 0x7B }
        );
        public static readonly Expansion Babylon = new Expansion
        (
            id: 6,
            name: "Babylon",
            saveName: "Babylon",
            steamId: "16868",
            isFullExpansion: false,
            prefixBytes: new byte[] { 0x32, 0xBA, 0x59, 0x74, 0x64, 0x57, 0xAE, 0x44, 0x8E, 0x95, 0x01, 0xAD, 0x0E, 0x0E, 0xFD, 0x48 }
        );
        public static readonly Expansion AncientWonders = new Expansion
        (
            id: 7,
            name: "Ancient Wonders", 
            saveName: "Ancient Wonders", 
            steamId: "99614",
            isFullExpansion: false,
            prefixBytes: new byte[] { 0x85, 0xD0, 0xB0, 0xBB, 0xB1, 0xA0, 0x75, 0x44, 0xB0, 0x07, 0x3E, 0x54, 0x9C, 0xF3, 0xAD, 0xC3 }
        );
        public static readonly Expansion ExplorersMapPack = new Expansion
        (
            id: 8,
            name: "Explorer\'s Map Pack", 
            saveName: "DLC_SP_Maps", 
            steamId: "16866",
            isFullExpansion: false,
            prefixBytes: new byte[] { 0x54, 0xDF, 0x49, 0x3F, 0xB6, 0x68, 0xD1, 0x44, 0xA9, 0x30, 0xA1, 0x68, 0x62, 0x8F, 0xAA, 0x59 }
        );
        public static readonly Expansion GodsAndKings = new Expansion
        (
            id: 9,
            name: "Gods and Kings", 
            saveName: "Expansion - Gods and Kings", 
            steamId: "16870",
            isFullExpansion: true,
            prefixBytes: new byte[] { 0xA1, 0x51, 0x37, 0x0E, 0x40, 0xF8, 0x1B, 0x4E, 0x97, 0x06, 0x51, 0x9B, 0xF4, 0x84, 0xE5, 0x9D }
        );
        public static readonly Expansion BraveNewWorld = new Expansion
        (
            id: 10,
            name: "Brave New World", 
            saveName: "Expansion - Brave New World", 
            steamId: "235580",
            isFullExpansion: true,
            prefixBytes: new byte[] { 0x36, 0x76, 0xA0, 0x6D, 0x23, 0x41, 0x18, 0x40, 0xB6, 0x43, 0x65, 0x75, 0xB4, 0xEC, 0x33, 0x6B }
        );
        public static readonly Expansion ScrambledContinents = new Expansion
        (
            id: 11,
            name: "Scrambled Continents Map Pack",
            saveName: "DLC_SP_Maps_2",
            steamId: "235584",
            isFullExpansion: false,
            prefixBytes: new byte[] { 0xFC, 0xEF, 0xEA, 0x46, 0x1D, 0x7B, 0x3D, 0x44, 0xBF, 0xC8, 0xF8, 0x25, 0xDF, 0xEF, 0xB0, 0x94 }
        );
        public static readonly Expansion ScrambledNations = new Expansion
        (
            id: 12,
            name: "Scrambled Nations Map Pack",
            saveName: "DLC_SP_Maps_3",
            steamId: "235585",
            isFullExpansion: false,
            prefixBytes: new byte[] { 0xF7, 0xF5, 0x55, 0x42, 0xAB, 0xD3, 0x55, 0x4E, 0xAC, 0xEE, 0x46, 0x70, 0x08, 0x20, 0x40, 0xED }
        );

        //Automatically managed expansions

        //Free - everyone has it
        internal static readonly Expansion Mongolia = new Expansion
        (
            id: 1,
            name: "Mongolia",
            saveName: "Mongolia",
            steamId: String.Empty,
            isFullExpansion: false,
            prefixBytes: new byte[] { 0xE3, 0x1E, 0x3C, 0x29, 0x76, 0x11, 0xF6, 0x44, 0xAC, 0x1F, 0x59, 0x66, 0x38, 0x26, 0xDE, 0x74 }
        );
        //Mandatory for every game
        internal static readonly Expansion Upgrade1 = new Expansion
        (
            id: 13,
            name: "Upgrade 1",
            saveName: "Upgrade 1",
            steamId: null,
            isFullExpansion: false,
            prefixBytes: new byte[] { 0x48, 0xE7, 0x71, 0x88, 0xA4, 0x29, 0x10, 0x49, 0x8C, 0x57, 0x8C, 0x99, 0xE3, 0x2D, 0x01, 0x67 }
        );
        //Automatically added when all other expansions are present
        internal static readonly Expansion CivilizationVComplete = new Expansion
        (
            id: 14,
            name: "Civilization 5 Complete",
            saveName: "Civilization 5 Complete",
            steamId: "36075",
            isFullExpansion: true,
            prefixBytes: new byte[] { 0xD5, 0xAE, 0x67, 0xEA, 0x59, 0x58, 0x75, 0x48, 0xBF, 0x3A, 0x36, 0x0F, 0xE9, 0xE5, 0x5D, 0x1B }
        );
    }
}

using System.Collections.Generic;
using System.Linq;

namespace BlazorApps.BlazorMusicKeyboard.Model
{
    public class Instrument
    {
        public IReadOnlyList<Pitch> Accidentals =>
            CurrentScale.Pitches.Where(p => p.Accidental != Model.Accidentals.Natural).ToList();

        public List<Scale> AvailableScales { get; init; }
        public Scale CurrentScale { get; set; }

        public InstrumentType InstrumentType { get; init; }
        public string Name { get; init; } = string.Empty;

        public IReadOnlyList<Pitch> Naturals =>
            CurrentScale.Pitches.Where(p => p.Accidental == Model.Accidentals.Natural).ToList();

        public string SoundFilePrefix { get; init; }
    }


    public static class Instruments
    {
        public static Instrument[] All => new[] {SopranoXylophone, AltoXylophone, BassXylophone, Piano};

        public static Instrument AltoXylophone => new()
        {
            Name = "Alto Xylophone",
            InstrumentType = InstrumentType.Xylophone,
            CurrentScale = Scales.C3Diatonic,
            SoundFilePrefix = "xyl",
            AvailableScales = new List<Scale>
            {
                Scales.C3Diatonic, Scales.F3Diatonic, Scales.G3Diatonic,
                Scales.C3Pentatonic, Scales.F3Pentatonic, Scales.G3Pentatonic
            }
        };

        public static Instrument BassXylophone => new()
        {
            Name = "Bass Xylophone",
            InstrumentType = InstrumentType.Xylophone,
            CurrentScale = Scales.C2Diatonic,
            SoundFilePrefix = "xyl",
            AvailableScales = new List<Scale>
            {
                Scales.C2Diatonic, Scales.F2Diatonic, Scales.G2Diatonic,
                Scales.C2Pentatonic, Scales.F2Pentatonic, Scales.G2Pentatonic
            }
        };

        public static Instrument Find(string name)
        {
            return All.FirstOrDefault(i => i.Name == name);
        }

        private static Instrument SopranoXylophone => new()
        {
            Name = "Soprano Xylophone",
            InstrumentType = InstrumentType.Xylophone,
            CurrentScale = Scales.C4Diatonic,
            SoundFilePrefix = "xyl",
            AvailableScales = new List<Scale>
            {
                Scales.C4Diatonic, Scales.F4Diatonic, Scales.G4Diatonic,
                Scales.C4Pentatonic, Scales.F4Pentatonic, Scales.G4Pentatonic
            }
        };

        private static Instrument Piano => new()
        {
            Name = "Piano",
            InstrumentType = InstrumentType.Piano,
            CurrentScale = Scales.Chromatic3,
            AvailableScales = new List<Scale> {Scales.Chromatic2, Scales.Chromatic3},
            SoundFilePrefix = "piano"
        };
    }


    public enum InstrumentType
    {
        Xylophone,
        Glockenspiel,
        Piano
    }
}
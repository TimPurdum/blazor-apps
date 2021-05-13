using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace BlazorApps.BlazorMusicKeyboard.Model
{
    public class Scale
    {
        public string Name { get; set; }
        public List<Pitch> Pitches { get; set; }
    }
    
    public static class Scales
    {
        public static Scale C2Diatonic => new Scale
        {
            Name = "C Major Diatonic",
            Pitches = new List<Pitch>
            {
                Pitches.C2, Pitches.D2, Pitches.E2, Pitches.F2, Pitches.G2, Pitches.A2, Pitches.B2,
                Pitches.C3, Pitches.D3, Pitches.E3, Pitches.F3, Pitches.G3, Pitches.A3
            }
        };
        
        public static Scale C3Diatonic => new Scale
        {
            Name = "C Major Diatonic",
            Pitches = new List<Pitch>
            {
                Pitches.C3, Pitches.D3, Pitches.E3, Pitches.F3, Pitches.G3, Pitches.A3, Pitches.B3,
                Pitches.C4, Pitches.D4, Pitches.E4, Pitches.F4, Pitches.G4, Pitches.A4
            }
        };
        
        public static Scale C4Diatonic => new Scale
        {
            Name = "C Major Diatonic",
            Pitches = new List<Pitch>
            {
                Pitches.C4, Pitches.D4, Pitches.E4, Pitches.F4, Pitches.G4, Pitches.A4, Pitches.B4,
                Pitches.C5, Pitches.D5, Pitches.E5, Pitches.F5, Pitches.G5, Pitches.A5
            }
        };
        
        public static Scale F2Diatonic => new Scale
        {
            Name = "F Major Diatonic",
            Pitches = new List<Pitch>
            {
                Pitches.C2, Pitches.D2, Pitches.E2, Pitches.F2, Pitches.G2, Pitches.A2, Pitches.BFlat2,
                Pitches.C3, Pitches.D3, Pitches.E3, Pitches.F3, Pitches.G3, Pitches.A3
            }
        };
        
        public static Scale F3Diatonic => new Scale
        {
            Name = "F Major Diatonic",
            Pitches = new List<Pitch>
            {
                Pitches.C3, Pitches.D3, Pitches.E3, Pitches.F3, Pitches.G3, Pitches.A3, Pitches.BFlat3,
                Pitches.C4, Pitches.D4, Pitches.E4, Pitches.F4, Pitches.G4, Pitches.A4
            }
        };
        
        public static Scale F4Diatonic => new Scale
        {
            Name = "F Major Diatonic",
            Pitches = new List<Pitch>
            {
                Pitches.C4, Pitches.D4, Pitches.E4, Pitches.F4, Pitches.G4, Pitches.A4, Pitches.BFlat4,
                Pitches.C5, Pitches.D5, Pitches.E5, Pitches.F5, Pitches.G5, Pitches.A5
            }
        };
        
        public static Scale G2Diatonic => new Scale
        {
            Name = "G Major Diatonic",
            Pitches = new List<Pitch>
            {
                Pitches.C2, Pitches.D2, Pitches.E2, Pitches.FSharp2, Pitches.G2, Pitches.A2, Pitches.B2,
                Pitches.C3, Pitches.D3, Pitches.E3, Pitches.FSharp3, Pitches.G3, Pitches.A3
            }
        };
        
        public static Scale G3Diatonic => new Scale
        {
            Name = "G Major Diatonic",
            Pitches = new List<Pitch>
            {
                Pitches.C3, Pitches.D3, Pitches.E3, Pitches.FSharp3, Pitches.G3, Pitches.A3, Pitches.B3,
                Pitches.C4, Pitches.D4, Pitches.E4, Pitches.FSharp4, Pitches.G4, Pitches.A4
            }
        };
        
        public static Scale G4Diatonic => new Scale
        {
            Name = "G Major Diatonic",
            Pitches = new List<Pitch>
            {
                Pitches.C4, Pitches.D4, Pitches.E4, Pitches.FSharp4, Pitches.G4, Pitches.A4, Pitches.B4,
                Pitches.C5, Pitches.D5, Pitches.E5, Pitches.FSharp5, Pitches.G5, Pitches.A5
            }
        };
        
        public static Scale C2Pentatonic => new Scale
        {
            Name = "C-do Pentatonic",
            Pitches = new List<Pitch>
            {
                Pitches.C2, Pitches.D2, Pitches.E2, Pitches.Dummy, Pitches.G2, Pitches.A2, Pitches.Dummy,
                Pitches.C3, Pitches.D3, Pitches.E3, Pitches.Dummy, Pitches.G3, Pitches.A3
            }
        };
        
        public static Scale C3Pentatonic => new Scale
        {
            Name = "C-do Pentatonic",
            Pitches = new List<Pitch>
            {
                Pitches.C3, Pitches.D3, Pitches.E3, Pitches.Dummy, Pitches.G3, Pitches.A3, Pitches.Dummy,
                Pitches.C4, Pitches.D4, Pitches.E4, Pitches.Dummy, Pitches.G4, Pitches.A4
            }
        };
        
        public static Scale C4Pentatonic => new Scale
        {
            Name = "C-do Pentatonic",
            Pitches = new List<Pitch>
            {
                Pitches.C4, Pitches.D4, Pitches.E4, Pitches.Dummy, Pitches.G4, Pitches.A4, Pitches.Dummy,
                Pitches.C5, Pitches.D5, Pitches.E5, Pitches.Dummy, Pitches.G5, Pitches.A5
            }
        };
        
        public static Scale F2Pentatonic => new Scale
        {
            Name = "F-do Pentatonic",
            Pitches = new List<Pitch>
            {
                Pitches.C2, Pitches.D2, Pitches.Dummy, Pitches.F2, Pitches.G2, Pitches.A2, Pitches.Dummy,
                Pitches.C3, Pitches.D3, Pitches.Dummy, Pitches.F3, Pitches.G3, Pitches.A3
            }
        };
        
        public static Scale F3Pentatonic => new Scale
        {
            Name = "F-do Pentatonic",
            Pitches = new List<Pitch>
            {
                Pitches.C3, Pitches.D3, Pitches.Dummy, Pitches.F3, Pitches.G3, Pitches.A3, Pitches.Dummy,
                Pitches.C4, Pitches.D4, Pitches.Dummy, Pitches.F4, Pitches.G4, Pitches.A4
            }
        };
        
        public static Scale F4Pentatonic => new Scale
        {
            Name = "F-do Pentatonic",
            Pitches = new List<Pitch>
            {
                Pitches.C4, Pitches.D4, Pitches.Dummy, Pitches.F4, Pitches.G4, Pitches.A4, Pitches.Dummy,
                Pitches.C5, Pitches.D5, Pitches.Dummy, Pitches.F5, Pitches.G5, Pitches.A5
            }
        };
        
        public static Scale G2Pentatonic => new Scale
        {
            Name = "G-do Pentatonic",
            Pitches = new List<Pitch>
            {
                Pitches.Dummy, Pitches.D2, Pitches.E2, Pitches.Dummy, Pitches.G2, Pitches.A2, Pitches.B2,
                Pitches.Dummy, Pitches.D3, Pitches.E3, Pitches.Dummy, Pitches.G3, Pitches.A3
            }
        };
        
        public static Scale G3Pentatonic => new Scale
        {
            Name = "G-do Pentatonic",
            Pitches = new List<Pitch>
            {
                Pitches.Dummy, Pitches.D3, Pitches.E3, Pitches.Dummy, Pitches.G3, Pitches.A3, Pitches.B3,
                Pitches.Dummy, Pitches.D4, Pitches.E4, Pitches.Dummy, Pitches.G4, Pitches.A4
            }
        };
        
        public static Scale G4Pentatonic => new Scale
        {
            Name = "G-do Pentatonic",
            Pitches = new List<Pitch>
            {
                Pitches.Dummy, Pitches.D4, Pitches.E4, Pitches.Dummy, Pitches.G4, Pitches.A4, Pitches.B4,
                Pitches.Dummy, Pitches.D5, Pitches.E5, Pitches.Dummy, Pitches.G5, Pitches.A5
            }
        };

        public static Scale Chromatic1 => new Scale
        {
            Name = "Chromatic Octaves 1-2",
            Pitches = new List<Pitch>
            {
                Pitches.C1, Pitches.CSharp1, Pitches.D1, Pitches.DSharp1, Pitches.E1, Pitches.F1, Pitches.FSharp1,
                Pitches.G1, Pitches.GSharp1, Pitches.A1, Pitches.ASharp1, Pitches.B1,
                Pitches.C2, Pitches.CSharp2, Pitches.D2, Pitches.DSharp2, Pitches.E2, Pitches.F2, Pitches.FSharp2,
                Pitches.G2, Pitches.GSharp2, Pitches.A2, Pitches.ASharp2, Pitches.B2, Pitches.C3
            }
        };
        
        
        public static Scale Chromatic2 => new Scale
        {
            Name = "Chromatic Octaves 2-3",
            Pitches = new List<Pitch>
            {
                Pitches.C2, Pitches.CSharp2, Pitches.D2, Pitches.DSharp2, Pitches.E2, Pitches.F2, Pitches.FSharp2,
                Pitches.G2, Pitches.GSharp2, Pitches.A2, Pitches.ASharp2, Pitches.B2,
                Pitches.C3, Pitches.CSharp3, Pitches.D3, Pitches.DSharp3, Pitches.E3, Pitches.F3, Pitches.FSharp3,
                Pitches.G3, Pitches.GSharp3, Pitches.A3, Pitches.ASharp3, Pitches.B3, Pitches.C4
            }
        };

        public static Scale Chromatic3 => new Scale
        {
            Name = "Chromatic Octaves 3-4",
            Pitches = new List<Pitch>
            {
                Pitches.C3, Pitches.CSharp3, Pitches.D3, Pitches.DSharp3, Pitches.E3, Pitches.F3, Pitches.FSharp3,
                Pitches.G3, Pitches.GSharp3, Pitches.A3, Pitches.ASharp3, Pitches.B3,
                Pitches.C4, Pitches.CSharp4, Pitches.D4, Pitches.DSharp4, Pitches.E4, Pitches.F4, Pitches.FSharp4,
                Pitches.G4, Pitches.GSharp4, Pitches.A4, Pitches.ASharp4, Pitches.B4, Pitches.C5
            }
        };
    }
}
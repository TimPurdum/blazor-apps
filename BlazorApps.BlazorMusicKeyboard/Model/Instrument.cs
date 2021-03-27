using System.Collections.Generic;

namespace BlazorApps.BlazorMusicKeyboard.Model
{
    public class Instrument
    {
        public string Name { get; set; }
        public string SoundFilePrefix { get; set; }
        public IReadOnlyList<Pitch> Scale { get; set; }
    }


    public static class Instruments
    {
        public static Instrument BassXylophone = new Instrument
        {
            Name = "Bass Xylophone",
            Scale = new List<Pitch>
            {
                Pitches.C2, Pitches.D2, Pitches.E2, Pitches.F2, Pitches.G2, Pitches.A2, Pitches.B2,
                Pitches.C3, Pitches.D3, Pitches.E3, Pitches.F3, Pitches.G3, Pitches.A3
            },
            SoundFilePrefix = "xyl"
        };
        
        
    }
}
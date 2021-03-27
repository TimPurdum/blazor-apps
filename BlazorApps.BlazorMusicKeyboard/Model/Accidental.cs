using System;

namespace BlazorApps.BlazorMusicKeyboard.Model
{
    public class Accidental
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public char Symbol { get; set; }
        
        public string SoundFileMark { get; set; } = String.Empty;
    }
    
    public static class Accidentals
    {
        public static readonly Accidental Natural = new()
        {
            Name = "Natural",
            Symbol = '♮',
            Value = 0
        };
        public static readonly Accidental Sharp = new()
        {
            Name = "Sharp",
            Symbol = '♯',
            Value = 1,
            SoundFileMark = "Sharp"
        };
        public static readonly Accidental Flat = new()
        {
            Name = "Flat",
            Symbol = '♭',
            Value = -1,
            SoundFileMark = "Flat"
        };
    }
}
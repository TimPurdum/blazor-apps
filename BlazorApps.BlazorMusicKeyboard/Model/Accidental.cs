using System;

namespace BlazorApps.BlazorMusicKeyboard.Model
{
    public class Accidental
    {
        public string Name { get; init; } = string.Empty;
        public int Value { get; init; }
        public char Symbol { get; init; } = ' ';
        
        public string SoundFileMark { get; init; } = string.Empty;
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
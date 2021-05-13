namespace BlazorApps.BlazorMusicKeyboard.Model
{
    public class KeyBarModel
    {
        public KeyBarModel(string soundFile, string label, int octave, InstrumentType instrumentType)
        {
            SoundFile = soundFile;
            Label = label;
            Octave = octave;
            InstrumentType = instrumentType;
        }
        public string Label { get; }
        public int Octave { get; }
        public string SoundFile { get; }
        
        public InstrumentType InstrumentType { get; }
        public string BarId => $"{Label.Replace("<br/>", "_")}-{Octave}";
    }
}
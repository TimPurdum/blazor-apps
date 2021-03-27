namespace BlazorApps.BlazorMusicKeyboard.Model
{
    public class KeyBarModel
    {
        public KeyBarModel(string soundFile, string label, int octave)
        {
            SoundFile = soundFile;
            Label = label;
            Octave = octave;
        }
        public string Label { get; }
        public int Octave { get; }
        public string SoundFile { get; }
        public string BarId => $"{Label}-{Octave}";
    }
}
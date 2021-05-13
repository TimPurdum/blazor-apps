namespace BlazorApps.BlazorMusicKeyboard.Model
{
    public class Pitch
    {
        public char LetterName { get; init; } = ' ';
        public Accidental Accidental { get; init; } = Accidentals.Natural;

        public int Octave { get; init; } = 1;

        public string Label => $"{LetterName}{Accidental.Symbol}";
    }


    public static class Pitches
    {
        public static readonly Pitch Dummy = new Pitch();
        
        public static readonly Pitch A1 = new()
        {
            Accidental = Accidentals.Natural,
            LetterName = 'A',
            Octave = 1
        };
        
        public static readonly Pitch ASharp1 = new()
        {
            Accidental = Accidentals.Sharp,
            LetterName = 'A',
            Octave = 1
        };
        
        public static readonly Pitch BFlat1 = new()
        {
            Accidental = Accidentals.Flat,
            LetterName = 'B',
            Octave = 1
        };
        
        public static readonly Pitch B1 = new()
        {
            Accidental = Accidentals.Natural,
            LetterName = 'B',
            Octave = 1
        };
        
        public static readonly Pitch C1 = new()
        {
            Accidental = Accidentals.Natural,
            LetterName = 'C',
            Octave = 1
        };
        
        public static readonly Pitch CSharp1 = new()
        {
            Accidental = Accidentals.Sharp,
            LetterName = 'C',
            Octave = 1
        };
        
        public static readonly Pitch DFlat1 = new()
        {
            Accidental = Accidentals.Flat,
            LetterName = 'D',
            Octave = 1
        };

        public static readonly Pitch D1 = new()
        {
            Accidental = Accidentals.Natural,
            LetterName = 'D',
            Octave = 1
        };
        
        public static readonly Pitch DSharp1 = new()
        {
            Accidental = Accidentals.Sharp,
            LetterName = 'D',
            Octave = 1
        };
        
        public static readonly Pitch EFlat1 = new()
        {
            Accidental = Accidentals.Flat,
            LetterName = 'E',
            Octave = 1
        };
        
        public static readonly Pitch E1 = new()
        {
            Accidental = Accidentals.Natural,
            LetterName = 'E',
            Octave = 1
        };
        
        public static readonly Pitch F1 = new()
        {
            Accidental = Accidentals.Natural,
            LetterName = 'F',
            Octave = 1
        };
        
        public static readonly Pitch FSharp1 = new()
        {
            Accidental = Accidentals.Sharp,
            LetterName = 'F',
            Octave = 1
        };
        
        public static readonly Pitch GFlat1 = new()
        {
            Accidental = Accidentals.Flat,
            LetterName = 'G',
            Octave = 1
        };
        
        public static readonly Pitch G1 = new()
        {
            Accidental = Accidentals.Natural,
            LetterName = 'G',
            Octave = 1
        };
        
        public static readonly Pitch GSharp1 = new()
        {
            Accidental = Accidentals.Sharp,
            LetterName = 'G',
            Octave = 1
        };
        
        public static readonly Pitch AFlat1 = new()
        {
            Accidental = Accidentals.Flat,
            LetterName = 'A',
            Octave = 1
        };
        
        public static readonly Pitch A2 = new()
        {
            Accidental = Accidentals.Natural,
            LetterName = 'A',
            Octave = 2
        };
        
        public static readonly Pitch ASharp2 = new()
        {
            Accidental = Accidentals.Sharp,
            LetterName = 'A',
            Octave = 2
        };
        
        public static readonly Pitch BFlat2 = new()
        {
            Accidental = Accidentals.Flat,
            LetterName = 'B',
            Octave = 2
        };
        
        public static readonly Pitch B2 = new()
        {
            Accidental = Accidentals.Natural,
            LetterName = 'B',
            Octave = 2
        };
        
        public static readonly Pitch C2 = new()
        {
            Accidental = Accidentals.Natural,
            LetterName = 'C',
            Octave = 2
        };
        
        public static readonly Pitch CSharp2 = new()
        {
            Accidental = Accidentals.Sharp,
            LetterName = 'C',
            Octave = 2
        };
        
        public static readonly Pitch DFlat2 = new()
        {
            Accidental = Accidentals.Flat,
            LetterName = 'D',
            Octave = 2
        };

        public static readonly Pitch D2 = new()
        {
            Accidental = Accidentals.Natural,
            LetterName = 'D',
            Octave = 2
        };
        
        public static readonly Pitch DSharp2 = new()
        {
            Accidental = Accidentals.Sharp,
            LetterName = 'D',
            Octave = 2
        };
        
        public static readonly Pitch EFlat2 = new()
        {
            Accidental = Accidentals.Flat,
            LetterName = 'E',
            Octave = 2
        };
        
        public static readonly Pitch E2 = new()
        {
            Accidental = Accidentals.Natural,
            LetterName = 'E',
            Octave = 2
        };
        
        public static readonly Pitch F2 = new()
        {
            Accidental = Accidentals.Natural,
            LetterName = 'F',
            Octave = 2
        };
        
        public static readonly Pitch FSharp2 = new()
        {
            Accidental = Accidentals.Sharp,
            LetterName = 'F',
            Octave = 2
        };
        
        public static readonly Pitch GFlat2 = new()
        {
            Accidental = Accidentals.Flat,
            LetterName = 'G',
            Octave = 2
        };
        
        public static readonly Pitch G2 = new()
        {
            Accidental = Accidentals.Natural,
            LetterName = 'G',
            Octave = 2
        };
        
        public static readonly Pitch GSharp2 = new()
        {
            Accidental = Accidentals.Sharp,
            LetterName = 'G',
            Octave = 2
        };
        
        public static readonly Pitch AFlat2 = new()
        {
            Accidental = Accidentals.Flat,
            LetterName = 'A',
            Octave = 2
        };
        
        public static readonly Pitch A3 = new()
        {
            Accidental = Accidentals.Natural,
            LetterName = 'A',
            Octave = 3
        };
        
        public static readonly Pitch ASharp3 = new()
        {
            Accidental = Accidentals.Sharp,
            LetterName = 'A',
            Octave = 3
        };
        
        public static readonly Pitch BFlat3 = new()
        {
            Accidental = Accidentals.Flat,
            LetterName = 'B',
            Octave = 3
        };
        
        public static readonly Pitch B3 = new()
        {
            Accidental = Accidentals.Natural,
            LetterName = 'B',
            Octave = 3
        };
        
        public static readonly Pitch C3 = new()
        {
            Accidental = Accidentals.Natural,
            LetterName = 'C',
            Octave = 3
        };
        
        public static readonly Pitch CSharp3 = new()
        {
            Accidental = Accidentals.Sharp,
            LetterName = 'C',
            Octave = 3
        };
        
        public static readonly Pitch DFlat3 = new()
        {
            Accidental = Accidentals.Flat,
            LetterName = 'D',
            Octave = 3
        };

        public static readonly Pitch D3 = new()
        {
            Accidental = Accidentals.Natural,
            LetterName = 'D',
            Octave = 3
        };
        
        public static readonly Pitch DSharp3 = new()
        {
            Accidental = Accidentals.Sharp,
            LetterName = 'D',
            Octave = 3
        };
        
        public static readonly Pitch EFlat3 = new()
        {
            Accidental = Accidentals.Flat,
            LetterName = 'E',
            Octave = 3
        };
        
        public static readonly Pitch E3 = new()
        {
            Accidental = Accidentals.Natural,
            LetterName = 'E',
            Octave = 3
        };
        
        public static readonly Pitch F3 = new()
        {
            Accidental = Accidentals.Natural,
            LetterName = 'F',
            Octave = 3
        };
        
        public static readonly Pitch FSharp3 = new()
        {
            Accidental = Accidentals.Sharp,
            LetterName = 'F',
            Octave = 3
        };
        
        public static readonly Pitch GFlat3 = new()
        {
            Accidental = Accidentals.Flat,
            LetterName = 'G',
            Octave = 3
        };
        
        public static readonly Pitch G3 = new()
        {
            Accidental = Accidentals.Natural,
            LetterName = 'G',
            Octave = 3
        };
        
        public static readonly Pitch GSharp3 = new()
        {
            Accidental = Accidentals.Sharp,
            LetterName = 'G',
            Octave = 3
        };
        
        public static readonly Pitch AFlat3 = new()
        {
            Accidental = Accidentals.Flat,
            LetterName = 'A',
            Octave = 3
        };
        
        public static readonly Pitch A4 = new()
        {
            Accidental = Accidentals.Natural,
            LetterName = 'A',
            Octave = 4
        };
        
        public static readonly Pitch ASharp4 = new()
        {
            Accidental = Accidentals.Sharp,
            LetterName = 'A',
            Octave = 4
        };
        
        public static readonly Pitch BFlat4 = new()
        {
            Accidental = Accidentals.Flat,
            LetterName = 'B',
            Octave = 4
        };
        
        public static readonly Pitch B4 = new()
        {
            Accidental = Accidentals.Natural,
            LetterName = 'B',
            Octave = 4
        };
        
        public static readonly Pitch C4 = new()
        {
            Accidental = Accidentals.Natural,
            LetterName = 'C',
            Octave = 4
        };
        
        public static readonly Pitch CSharp4 = new()
        {
            Accidental = Accidentals.Sharp,
            LetterName = 'C',
            Octave = 4
        };
        
        public static readonly Pitch DFlat4 = new()
        {
            Accidental = Accidentals.Flat,
            LetterName = 'D',
            Octave = 4
        };

        public static readonly Pitch D4 = new()
        {
            Accidental = Accidentals.Natural,
            LetterName = 'D',
            Octave = 4
        };
        
        public static readonly Pitch DSharp4 = new()
        {
            Accidental = Accidentals.Sharp,
            LetterName = 'D',
            Octave = 4
        };
        
        public static readonly Pitch EFlat4 = new()
        {
            Accidental = Accidentals.Flat,
            LetterName = 'E',
            Octave = 4
        };
        
        public static readonly Pitch E4 = new()
        {
            Accidental = Accidentals.Natural,
            LetterName = 'E',
            Octave = 4
        };
        
        public static readonly Pitch F4 = new()
        {
            Accidental = Accidentals.Natural,
            LetterName = 'F',
            Octave = 4
        };
        
        public static readonly Pitch FSharp4 = new()
        {
            Accidental = Accidentals.Sharp,
            LetterName = 'F',
            Octave = 4
        };
        
        public static readonly Pitch GFlat4 = new()
        {
            Accidental = Accidentals.Flat,
            LetterName = 'G',
            Octave = 4
        };
        
        public static readonly Pitch G4 = new()
        {
            Accidental = Accidentals.Natural,
            LetterName = 'G',
            Octave = 4
        };
        
        public static readonly Pitch GSharp4 = new()
        {
            Accidental = Accidentals.Sharp,
            LetterName = 'G',
            Octave = 4
        };
        
        public static readonly Pitch AFlat4 = new()
        {
            Accidental = Accidentals.Flat,
            LetterName = 'A',
            Octave = 4
        };
        
        public static readonly Pitch A5 = new()
        {
            Accidental = Accidentals.Natural,
            LetterName = 'A',
            Octave = 5
        };
        
        public static readonly Pitch ASharp5 = new()
        {
            Accidental = Accidentals.Sharp,
            LetterName = 'A',
            Octave = 5
        };
        
        public static readonly Pitch BFlat5 = new()
        {
            Accidental = Accidentals.Flat,
            LetterName = 'B',
            Octave = 5
        };
        
        public static readonly Pitch B5 = new()
        {
            Accidental = Accidentals.Natural,
            LetterName = 'B',
            Octave = 5
        };
        
        public static readonly Pitch C5 = new()
        {
            Accidental = Accidentals.Natural,
            LetterName = 'C',
            Octave = 5
        };
        
        public static readonly Pitch CSharp5 = new()
        {
            Accidental = Accidentals.Sharp,
            LetterName = 'C',
            Octave = 5
        };
        
        public static readonly Pitch DFlat5 = new()
        {
            Accidental = Accidentals.Flat,
            LetterName = 'D',
            Octave = 5
        };

        public static readonly Pitch D5 = new()
        {
            Accidental = Accidentals.Natural,
            LetterName = 'D',
            Octave = 5
        };
        
        public static readonly Pitch DSharp5 = new()
        {
            Accidental = Accidentals.Sharp,
            LetterName = 'D',
            Octave = 5
        };
        
        public static readonly Pitch EFlat5 = new()
        {
            Accidental = Accidentals.Flat,
            LetterName = 'E',
            Octave = 5
        };
        
        public static readonly Pitch E5 = new()
        {
            Accidental = Accidentals.Natural,
            LetterName = 'E',
            Octave = 5
        };
        
        public static readonly Pitch F5 = new()
        {
            Accidental = Accidentals.Natural,
            LetterName = 'F',
            Octave = 5
        };
        
        public static readonly Pitch FSharp5 = new()
        {
            Accidental = Accidentals.Sharp,
            LetterName = 'F',
            Octave = 5
        };
        
        public static readonly Pitch GFlat5 = new()
        {
            Accidental = Accidentals.Flat,
            LetterName = 'G',
            Octave = 5
        };
        
        public static readonly Pitch G5 = new()
        {
            Accidental = Accidentals.Natural,
            LetterName = 'G',
            Octave = 5
        };
        
        public static readonly Pitch GSharp5 = new()
        {
            Accidental = Accidentals.Sharp,
            LetterName = 'G',
            Octave = 5
        };
        
        public static readonly Pitch AFlat5 = new()
        {
            Accidental = Accidentals.Flat,
            LetterName = 'A',
            Octave = 5
        };
        
        public static readonly Pitch A6 = new()
        {
            Accidental = Accidentals.Natural,
            LetterName = 'A',
            Octave = 6
        };
        
        public static readonly Pitch ASharp6 = new()
        {
            Accidental = Accidentals.Sharp,
            LetterName = 'A',
            Octave = 6
        };
        
        public static readonly Pitch BFlat6 = new()
        {
            Accidental = Accidentals.Flat,
            LetterName = 'B',
            Octave = 6
        };
        
        public static readonly Pitch B6 = new()
        {
            Accidental = Accidentals.Natural,
            LetterName = 'B',
            Octave = 6
        };
        
        public static readonly Pitch C6 = new()
        {
            Accidental = Accidentals.Natural,
            LetterName = 'C',
            Octave = 6
        };
        
        public static readonly Pitch CSharp6 = new()
        {
            Accidental = Accidentals.Sharp,
            LetterName = 'C',
            Octave = 6
        };
        
        public static readonly Pitch DFlat6 = new()
        {
            Accidental = Accidentals.Flat,
            LetterName = 'D',
            Octave = 6
        };

        public static readonly Pitch D6 = new()
        {
            Accidental = Accidentals.Natural,
            LetterName = 'D',
            Octave = 6
        };
        
        public static readonly Pitch DSharp6 = new()
        {
            Accidental = Accidentals.Sharp,
            LetterName = 'D',
            Octave = 6
        };
        
        public static readonly Pitch EFlat6 = new()
        {
            Accidental = Accidentals.Flat,
            LetterName = 'E',
            Octave = 6
        };
        
        public static readonly Pitch E6 = new()
        {
            Accidental = Accidentals.Natural,
            LetterName = 'E',
            Octave = 6
        };
        
        public static readonly Pitch F6 = new()
        {
            Accidental = Accidentals.Natural,
            LetterName = 'F',
            Octave = 6
        };
        
        public static readonly Pitch FSharp6 = new()
        {
            Accidental = Accidentals.Sharp,
            LetterName = 'F',
            Octave = 6
        };
        
        public static readonly Pitch GFlat6 = new()
        {
            Accidental = Accidentals.Flat,
            LetterName = 'G',
            Octave = 6
        };
        
        public static readonly Pitch G6 = new()
        {
            Accidental = Accidentals.Natural,
            LetterName = 'G',
            Octave = 6
        };
        
        public static readonly Pitch GSharp6 = new()
        {
            Accidental = Accidentals.Sharp,
            LetterName = 'G',
            Octave = 6
        };
        
        public static readonly Pitch AFlat6 = new()
        {
            Accidental = Accidentals.Flat,
            LetterName = 'A',
            Octave = 6
        };
        
        public static readonly Pitch A7 = new()
        {
            Accidental = Accidentals.Natural,
            LetterName = 'A',
            Octave = 7
        };
        
        public static readonly Pitch ASharp7 = new()
        {
            Accidental = Accidentals.Sharp,
            LetterName = 'A',
            Octave = 7
        };
        
        public static readonly Pitch BFlat7 = new()
        {
            Accidental = Accidentals.Flat,
            LetterName = 'B',
            Octave = 7
        };
        
        public static readonly Pitch B7 = new()
        {
            Accidental = Accidentals.Natural,
            LetterName = 'B',
            Octave = 7
        };
        
        public static readonly Pitch C7 = new()
        {
            Accidental = Accidentals.Natural,
            LetterName = 'C',
            Octave = 7
        };
        
        public static readonly Pitch CSharp7 = new()
        {
            Accidental = Accidentals.Sharp,
            LetterName = 'C',
            Octave = 7
        };
        
        public static readonly Pitch DFlat7 = new()
        {
            Accidental = Accidentals.Flat,
            LetterName = 'D',
            Octave = 7
        };

        public static readonly Pitch D7 = new()
        {
            Accidental = Accidentals.Natural,
            LetterName = 'D',
            Octave = 7
        };
        
        public static readonly Pitch DSharp7 = new()
        {
            Accidental = Accidentals.Sharp,
            LetterName = 'D',
            Octave = 7
        };
        
        public static readonly Pitch EFlat7 = new()
        {
            Accidental = Accidentals.Flat,
            LetterName = 'E',
            Octave = 7
        };
        
        public static readonly Pitch E7 = new()
        {
            Accidental = Accidentals.Natural,
            LetterName = 'E',
            Octave = 7
        };
        
        public static readonly Pitch F7 = new()
        {
            Accidental = Accidentals.Natural,
            LetterName = 'F',
            Octave = 7
        };
        
        public static readonly Pitch FSharp7 = new()
        {
            Accidental = Accidentals.Sharp,
            LetterName = 'F',
            Octave = 7
        };
        
        public static readonly Pitch GFlat7 = new()
        {
            Accidental = Accidentals.Flat,
            LetterName = 'G',
            Octave = 7
        };
        
        public static readonly Pitch G7 = new()
        {
            Accidental = Accidentals.Natural,
            LetterName = 'G',
            Octave = 7
        };
        
        public static readonly Pitch GSharp7 = new()
        {
            Accidental = Accidentals.Sharp,
            LetterName = 'G',
            Octave = 7
        };
        
        public static readonly Pitch AFlat7 = new()
        {
            Accidental = Accidentals.Flat,
            LetterName = 'A',
            Octave = 7
        };
    }
}
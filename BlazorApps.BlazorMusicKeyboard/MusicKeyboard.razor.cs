using BlazorApps.BlazorMusicKeyboard.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorApps.BlazorMusicKeyboard
{
    public partial class MusicKeyboard
    {
        private Lazy<Task<IJSObjectReference>> _moduleTask;

        [Inject]
        private IJSRuntime JsRuntime { get; set; } = null!;
        
        [Parameter]
        public Instrument Instrument { get; set; } = null!;

        private bool MouseIsDown { get; set; }

        private ElementReference _keyboard;
        private double _barWidth;
        private TouchPoint _touchPoint;
        private KeyBarButton _currentBar;
        private double _accidentalBarWidth => _barWidth * 0.75;

        private SoundPlayer SoundPlayer { get; set; } = null!;

        private Dictionary<string, KeyBarButton> _keyBars = new Dictionary<string, KeyBarButton>();
        private CancellationTokenSource _cts = new CancellationTokenSource();
        private double _keyboardWidth;

        public TouchPoint TouchPoint
        {
            get => _touchPoint;
            set
            {
                _touchPoint = value;
                _cts.Cancel();
                _cts = new CancellationTokenSource();
                var token = _cts.Token;
                Task.Run(async () =>
                {
                    if (token.IsCancellationRequested) return;
                    await InvokeAsync(async () =>
                    {
                        var touchedElementId = await
                            (await _moduleTask.Value).InvokeAsync<string>("getElementAtPoint", _touchPoint.ClientX, _touchPoint.ClientY);
                        if (touchedElementId == _currentBar.KeyBarModel.BarId) return;
                        if (token.IsCancellationRequested) return;
                        _currentBar = _keyBars[touchedElementId];
                        if (token.IsCancellationRequested) return;
                        await _currentBar.MouseDown();
                    });
                }, token);
            }
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            _moduleTask = new Lazy<Task<IJSObjectReference>>(async () => await JsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "/_content/CedarRiverTech.BlazorApps.BlazorMusicKeyboard/musicKeyboardJsInterop.js").AsTask());
            SoundPlayer = new SoundPlayer(_moduleTask);
        }


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            var module = await _moduleTask.Value;
            _keyboardWidth = await module.InvokeAsync<double>("getElementWidth", _keyboard);
            var newBarWidth = (_keyboardWidth / Instrument.Naturals.Count) * 0.9;
            if (Math.Abs(_barWidth - newBarWidth) > 0.1)
            {
                _barWidth = newBarWidth;
                StateHasChanged();
            }
            await base.OnAfterRenderAsync(firstRender);
        }

        private KeyBarModel BuildBarModel(Pitch pitch)
        {
            return new KeyBarModel(
                $"{Instrument.SoundFilePrefix}{pitch.LetterName}{pitch.Accidental.SoundFileMark}{pitch.Octave}.mp3",
                BuildPitchLabel(pitch), pitch.Octave, Instrument.InstrumentType);
        }


        private double CalculateAccidentalLeftOffset(Pitch pitch)
        {
            var scale = Instrument.CurrentScale.Pitches.ToList();
            var pitchIndex = scale.IndexOf(pitch);
            if (pitchIndex < 2) return _barWidth * 0.68;

            var previousNatural = scale[pitchIndex - 1];
            var naturalIndex = Instrument.Naturals.ToList().IndexOf(previousNatural);
            return (_barWidth * naturalIndex) + (_barWidth * 0.68);
        }


        private string BuildPitchLabel(Pitch pitch)
        {
            if (pitch.Accidental == Accidentals.Natural)
            {
                return pitch.Label.Replace("♮", "");
            }
            
            if (pitch.Accidental == Accidentals.Flat)
            {
                return $"{pitch.Label}<br/>{EnharmonicLetterName(pitch.LetterName, false)}{Accidentals.Sharp.Symbol}";
            }
            
            return $"{pitch.Label}<br/>{EnharmonicLetterName(pitch.LetterName, true)}{Accidentals.Flat.Symbol}";
        }

        private char EnharmonicLetterName(char letterName, bool up)
        {
            if (up)
            {
                if (letterName == 'G') return 'A';
                return (char) (letterName + 1);
            }

            if (letterName == 'A') return 'G';

            return (char) (letterName - 1);
        }
        
        
        private void OnTouchOnBar(KeyBarButton currentBar)
        {
            _currentBar = currentBar;
        }
    }
}
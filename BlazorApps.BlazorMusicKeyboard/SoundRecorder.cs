using Microsoft.JSInterop;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApps.BlazorMusicKeyboard
{
    public class SoundRecorder : IAsyncDisposable
    {
        public SoundRecorder(Lazy<Task<IJSObjectReference>> moduleTask)
        {
            _moduleTask = moduleTask;
        }

        public bool Playing { get; private set; }

        public bool Recording { get; private set; }

        public List<int> RecordedTracks
        {
            get => _recordedTracks;
            set => _recordedTracks = value;
        }


        public async ValueTask DisposeAsync()
        {
            if (_moduleTask.IsValueCreated)
            {
                var module = await _moduleTask.Value;
                await module.DisposeAsync();
            }
        }

        public void SetCurrentTrack(int track)
        {
            _currentTrack = track;
        }

        public async Task Record()
        {
            Recording = true;
            await (await _moduleTask.Value).InvokeVoidAsync("startRecording", _currentTrack);
            await Playback(false);
        }

        public async Task StopRecording()
        {
            await (await _moduleTask.Value).InvokeVoidAsync("stopRecording");
            await StopPlayback();
            if (!_recordedTracks.Contains(_currentTrack))
            {
                _recordedTracks.Add(_currentTrack);
            }

            Recording = false;
        }

        public async Task Playback(bool includeCurrentTrack)
        {
            Playing = true;
            var tracksToPlayBack = new List<int>(_recordedTracks);
            if (!includeCurrentTrack)
            {
                tracksToPlayBack.Remove(_currentTrack);
            }

            await (await _moduleTask.Value).InvokeVoidAsync("playback", tracksToPlayBack.ToArray());
        }

        public async Task StopPlayback()
        {
            await (await _moduleTask.Value).InvokeVoidAsync("stopPlayback");
            Playing = false;
        }

        public async Task Save()
        {
            await (await _moduleTask.Value).InvokeVoidAsync("save");
        }

        private static Lazy<Task<IJSObjectReference>> _moduleTask;

        private List<int> _recordedTracks = new();
        private int _currentTrack;

        public async Task DeleteTrack(int track)
        {
            _recordedTracks.Remove(track);
            await (await _moduleTask.Value).InvokeVoidAsync("deleteTrack", track);
        }
    }
}
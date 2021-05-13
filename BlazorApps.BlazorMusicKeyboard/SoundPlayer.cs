using Microsoft.JSInterop;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace BlazorApps.BlazorMusicKeyboard
{
    public class SoundPlayer : IAsyncDisposable
    {
        public SoundPlayer(Lazy<Task<IJSObjectReference>> moduleTask)
        {
            _moduleTask = moduleTask;
        }

        public async ValueTask DisposeAsync()
        {
            if (_moduleTask.IsValueCreated)
            {
                var module = await _moduleTask.Value;
                await module.DisposeAsync();
            }
        }

        public async Task Play(string barId)
        {
            Debug.WriteLine($"Playing Audio {barId}");
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("playAudio", barId);
            Debug.WriteLine($"Audio Completed {barId}");
        }


        public async Task Stop(string barId)
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("stopAudio", barId);
        }

        private readonly Lazy<Task<IJSObjectReference>> _moduleTask;
    }
}
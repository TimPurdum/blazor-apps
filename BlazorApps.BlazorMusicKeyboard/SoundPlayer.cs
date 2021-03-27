using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace BlazorApps.BlazorMusicKeyboard
{
    public class SoundPlayer : IAsyncDisposable
    {
        public SoundPlayer(IJSRuntime jsRuntime)
        {
            _moduleTask = new Lazy<Task<IJSObjectReference>>(() => jsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./_content/CedarRiverTech.BlazorApps.BlazorMusicKeyboard/musicKeyboardJsInterop.js").AsTask());
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
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("playAudio", barId);
        }

        private readonly Lazy<Task<IJSObjectReference>> _moduleTask;
    }
}
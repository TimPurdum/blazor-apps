using BlazorApps.BlazorMusicKeyboard.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApps.BlazorMusicKeyboard
{
    public partial class KeyBarButton
    {
        [Parameter]
        public KeyBarModel KeyBarModel { get; set; }
        [Parameter]
        public int Height { get; set; }
        [Parameter]
        public double Width { get; set; }
        [Parameter]
        public double Left { get; set; }
        [Parameter]
        public string BarClass { get; set; }
        [Parameter]
        public bool MouseIsDown { get; set; }
        [Parameter]
        public EventCallback<bool> MouseIsDownChanged { get; set; }
        [Parameter] 
        public TouchPoint TouchPoint { get; set; }
        [Parameter]
        public EventCallback<TouchPoint> TouchPointChanged { get; set; }
        [CascadingParameter(Name = "SoundPlayer")]
        public SoundPlayer SoundPlayer { get; set; }
        
        [CascadingParameter(Name = "ModuleTask")]
        public Lazy<Task<IJSObjectReference>> ModuleTask { get; set; }
        
        [Parameter]
        public EventCallback<KeyBarButton> TouchOnBar { get; set; }

        public ElementReference BarButton;
        
        
        [Parameter]
        public bool IsAccidental { get; set; }


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (KeyBarModel.InstrumentType != InstrumentType.Piano)
            {
                await (await ModuleTask.Value).InvokeVoidAsync("registerBar", 
                    KeyBarModel.BarId, BarAudioId, Height, IsAccidental, IsPiano);    
            }
            
            await base.OnAfterRenderAsync(firstRender);
        }

        public async Task MouseDown()
        {
            if (!MouseIsDown)
            {
                await PlaySound();
                MouseIsDown = true;
            }
            await MouseIsDownChanged.InvokeAsync(true);
        }


        public string BarAudioId => $"{KeyBarModel.BarId}-{KeyBarModel.SoundFile}";

        public bool IsPiano => KeyBarModel.InstrumentType == InstrumentType.Piano;

        private async Task PlaySound()
        {
            await SoundPlayer.Play($"{KeyBarModel.BarId}-{KeyBarModel.SoundFile}");
        }

        private async Task MouseUp()
        {
            if (KeyBarModel.InstrumentType == InstrumentType.Piano)
            {
                await SoundPlayer.Stop($"{KeyBarModel.BarId}-{KeyBarModel.SoundFile}");
            }
            MouseIsDown = false;
            await MouseIsDownChanged.InvokeAsync(false);
        }

        private async Task MouseOver()
        {
            if (MouseIsDown)
            {              
                await PlaySound();
            }
        }

        private async Task MouseOut()
        {
            if (KeyBarModel.InstrumentType == InstrumentType.Piano)
            {
                await SoundPlayer.Stop($"{KeyBarModel.BarId}-{KeyBarModel.SoundFile}");
            }
        }

        private async Task TouchStart()
        {
            await TouchOnBar.InvokeAsync(this);
            MouseIsDown = true;
            await MouseDown();
        }
        
        
        private async Task TouchEnd()
        {
            await MouseUp();
        }
        
        private async Task TouchMove(TouchEventArgs arg)
        {
            if (arg.Touches.Any())
            {
                TouchPoint = arg.Touches.First();
                await TouchPointChanged.InvokeAsync(TouchPoint);
            }
        }
    }
}
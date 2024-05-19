using Microsoft.JSInterop;

namespace BlazorApp8.Services
{
    public class WheelService
    {

        public event EventHandler<int> OnWheel;
        private readonly IJSRuntime _JSRuntime;

        public WheelService(IJSRuntime JSRuntime)
        {
            _JSRuntime = JSRuntime;
            _JSRuntime.InvokeVoidAsync("RegisterWheelService", DotNetObjectReference.Create(this));
        }


        [JSInvokable("JsOnWheel")]
        public void JsOnWheel(int y)
        {
            OnWheel?.Invoke(this, y);
        }
    }
}

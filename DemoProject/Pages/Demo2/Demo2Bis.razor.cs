using Microsoft.AspNetCore.Components;

namespace DemoProject.Pages.Demo2
{
    public partial class Demo2Bis
    {
        [Parameter]
        public int Id { get; set; }

        [Parameter]
        public EventCallback<string> NotifyParent { get; set; }

        public string ValueToParent { get; set; }

        public void InvokeNotifyParent()
        {
            NotifyParent.InvokeAsync(ValueToParent);
        }
    }
}

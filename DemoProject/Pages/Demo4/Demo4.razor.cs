using System.Runtime.CompilerServices;

namespace DemoProject.Pages.Demo4
{
    public partial class Demo4
    {
        public int Counter { get; set; }
        public Demo4()
        {
            Console.WriteLine("Passage dans le constructeur");
        }
        protected override async Task OnInitializedAsync()
        {
            Console.WriteLine("PAssage dans OnInitialized");
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            Console.WriteLine("After Render " + Counter);
        }

        public void Simulate()
        {
            Counter++;
        }
    }
}

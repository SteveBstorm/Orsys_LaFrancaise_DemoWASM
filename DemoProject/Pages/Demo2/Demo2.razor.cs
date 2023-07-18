namespace DemoProject.Pages.Demo2
{
    public partial class Demo2
    {
        public string ValueFromChild { get; set; }

        public void CallBackFromChild(string s)
        {
            ValueFromChild = s;
        }
    }
}

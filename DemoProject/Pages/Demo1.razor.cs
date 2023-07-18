namespace DemoProject.Pages
{
    public partial class Demo1 
    {
        public string MyName { get; set; }
        public bool myBool { get; set; } = true;

        private void SwitchBool()
        {
            myBool = !myBool;
        }

        private void SetMyValue(int x)
        {
            MyValue = x;
        }
    }
}

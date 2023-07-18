namespace DemoProject.Pages.Demo3
{
    public partial class Demo3
    {
        List<Guid> Guids { get; set; }

        public Demo3()
        {
            Guids = new List<Guid>();
            for(int i = 0; i < 50; i++)
            {
                Guids.Add(Guid.NewGuid());
            }
        }
    }
}

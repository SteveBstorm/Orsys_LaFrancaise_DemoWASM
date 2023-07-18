namespace DemoProject.Pages.Exercices.Exo1
{
    public partial class Quizz
    {
        public List<string> Responses { get; set; }
        public bool GameIsFinished { get; set; }
        public string PlayerName { get; set; }
        public Quizz()
        {
            Responses = new List<string>();
        }

        public void SaveResponse(string s)
        {
            Responses.Add(s);
        }

        public void GameFinish()
        {
            GameIsFinished = true;
        }
    }
}

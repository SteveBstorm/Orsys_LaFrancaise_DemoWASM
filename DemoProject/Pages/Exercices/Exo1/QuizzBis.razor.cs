using Microsoft.AspNetCore.Components;

namespace DemoProject.Pages.Exercices.Exo1
{
    public partial class QuizzBis
    {
        [Parameter]
        public string PlayerName { get; set; }
        public List<string> QuestionList { get; set; }

        [Parameter]
        public EventCallback<string> NotifyResponse{ get; set; }
        [Parameter]
        public EventCallback NotifyEndGame{ get; set; }

        public string CurrentQuestion { get; set; }
        public int Counter { get; set; }
        public QuizzBis()
        {
            QuestionList = new List<string>();
            QuestionList.Add("Aimez vous blazor ?");
            QuestionList.Add("Avez vous bien manger ce midi ?");
            QuestionList.Add("Pas trop mal à la tête ?");

            CurrentQuestion = QuestionList[0];
            Counter = 1;
        }

        public void SendResponse(string resp)
        {

            NotifyResponse.InvokeAsync(resp);
            if(Counter < QuestionList.Count)
            {
                CurrentQuestion = QuestionList[Counter++];
            }
            else
            {
                EndGame();
            }
        }

        public void EndGame()
        {
            NotifyEndGame.InvokeAsync();
        }
    }
}

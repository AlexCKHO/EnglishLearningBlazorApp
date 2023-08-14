using Microsoft.AspNetCore.Authorization;
using WeCantSpell.Hunspell;



namespace EnglishLearningBlazorApp.Client.Services
{
    [AllowAnonymous]
    public class WordListService
    {
        public WordList? Dictionary { get; set; }
    }
}

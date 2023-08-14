// DictionaryInitializationService.cs
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using WeCantSpell;
using WeCantSpell.Hunspell;

namespace EnglishLearningBlazorApp.Client.Services
{
    public class DictionaryInitializationService
    {
        private readonly WordListService _wordListService;

        public DictionaryInitializationService(WordListService wordListService)
        {
            _wordListService = wordListService;
        }

        public async Task InitializeDictionaryAsync()
        {
            try
            {
                if (_wordListService.Dictionary == null)
                {
                    using (var dictionaryStream = await GetEmbeddedResourceStream("EnglishLearningBlazorApp.Client.wwwroot.en_GB.dic"))
                    using (var affixStream = await GetEmbeddedResourceStream("EnglishLearningBlazorApp.Client.wwwroot.en_GB.aff"))
                    {
                        _wordListService.Dictionary = WordList.CreateFromStreams(dictionaryStream, affixStream);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions if needed
                Console.WriteLine($"Error loading wordlist: {ex.Message}");
            }
        }

        private async Task<Stream> GetEmbeddedResourceStream(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            return assembly.GetManifestResourceStream(resourceName);
        }
    }
}

using System.Threading.Tasks;
using System;
using System.Web;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Threading;
using System.Web.Security;


namespace Final_app
{
    /*Main site structure
     * 1.'entry-body' - it's holder of all usable information
     * 2.'pr dictionary' - blocks of information, mainly first one is the most usable
     * 3.'link dlink' - непосредственный блок информации
     *      'dpos-h di-head normal-entry' - наименование(слово и часть речи)
     *      'sense-body dsense_b' - значение слова и пример
     */

    /*TODO:
    *   1.Если определения пустые добавлять определения из синей коробки
    *   2.Поиск через переводчик инфинитивов
    *   3.Определять является ли глагол неправильным и следственно добавлять его склонение
    *   4.Если это noun доставать его род и число(мнж и единств)
    *   
    *   wand
    */

    internal class DictionaryManager
    {
        private static string germanApiUrl = $"https://dictionary.cambridge.org/dictionary/german-english/";
        private static string spellcheckApiUrl = $"https://dictionary.cambridge.org/spellcheck/german-english/?q=";
        private static string cambridgeSiteLink = $"https://dictionary.cambridge.org";
        private static string reversoSiteLink = $"https://www.reverso.net/text-translation#sl=ger&tl=rus&text=";
        private static string verbConjugationSite = "https://www.verbformen.de/?w=";
        

        //Settings:
        private static bool writeExamplesOnlyWithTranslation = true;
        private static HttpClient httpClient;
        private static async Task<HtmlDocument> GetDocument(string link)
        {
            try
            {
                Console.WriteLine(link);
                httpClient = httpClient ?? new HttpClient();

                var html = await httpClient.GetStringAsync(link).ConfigureAwait(false);
                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(html);
                return htmlDocument;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
                return null;
            }
        }

        public static async Task<informationDataBlock> FindWordInDictionary(string word)
        {
            var originalSite = GetDocument(germanApiUrl + word).Result;

            informationDataBlock wordInformation = new informationDataBlock();

            wordInformation = await GetWordInformationFromHtml(originalSite);

            try
            {
                if (!wordInformation.isInfoFinished)
                {
                    OnSecondSearchFail(ref wordInformation, word, originalSite);
                }

            }
            catch { }
            try
            {
                if (!wordInformation.isInfoFinished)
                {
                    OnFirstSearchFail(ref wordInformation, word);
                }
            }
            catch { }

            try
            {
                if (!wordInformation.isInfoFinished)
                {
                    OnFirstSearchFail(ref wordInformation, word);
                }
            }
            catch { }

/*            if(wordInformation.word != null)
            {
                string uneditedExamples = Form1.aIAutoSpeaker.SendAndReceiveAsync($"Напиши яркие примеры к слову {wordInformation.word} которые легко запомнить и перевод примера, но не много. Пиши так: Пример использования слова|перевод/Следующий пример|перевод И так далее, не добавляй вступлений и своих выводов или высказываний и обязательно добавляй знаки | и /").Result;

                wordInformation.examples = uneditedExamples.Split('/').ToList();
            }
*/
            return wordInformation;
        }

        private static async Task<informationDataBlock> GetWordInformationFromHtml(HtmlAgilityPack.HtmlDocument htmlDocument)
        {

            informationDataBlock informationDataBlock = new informationDataBlock();
            if (htmlDocument == null) return informationDataBlock;
            var definitionHTMLElements = htmlDocument.DocumentNode.QuerySelectorAll(".entry-body");

            if (definitionHTMLElements.QuerySelectorAll(".pr.dictionary").Count == 0)
            {
                return informationDataBlock;
            }

            var mainInformationHolder = definitionHTMLElements.QuerySelectorAll(".pr.dictionary")[0];
            var informationBlocks = mainInformationHolder.QuerySelectorAll(".link.dlink");

            if (informationBlocks == null)
            {
                Console.WriteLine("Information Blocks are empty");
                return informationDataBlock;
            }

            foreach (var informationBlock in informationBlocks)
            {
                
                informationDataBlock.word = informationBlock.QuerySelector(".di-title").InnerText.Trim();
                if (informationBlock.QuerySelector(".pos.dpos") == null)
                {
                    return informationDataBlock;
                }

                //add partOfSpeech
                string partOfSpeech = informationBlock.QuerySelector(".pos.dpos").InnerText.Trim();

                if (!informationDataBlock.partOfSpeech.Split(' ').Contains(partOfSpeech))
                {
                    informationDataBlock.partOfSpeech += " " + partOfSpeech;

                    if (partOfSpeech == "verb")
                    {
                        informationDataBlock.partOfSpeech += informationBlock.QuerySelector(".dgram").InnerText.Trim();

                        //add conjugation
                        try
                        {
                            informationDataBlock.conjugation += GetVerbConjugation(informationDataBlock.word);
                        }
                        catch { }
                    }

                    if (partOfSpeech == "noun")
                    {
                        var wordGender = informationBlock.QuerySelector(".gcs");

                        string gender = wordGender.InnerText.Trim();
                        switch (gender)
                        {
                            case "masculine":
                                informationDataBlock.word = "der " + informationDataBlock.word;
                                break;
                            case "feminine":
                                informationDataBlock.word = "die " + informationDataBlock.word;
                                break;
                            case "neuter":
                                informationDataBlock.word = "das " + informationDataBlock.word;
                                break;
                        }

                        var formsGroups = informationBlock.QuerySelectorAll(".irreg-infls.hdib.dinfls");
                        if(formsGroups != null && formsGroups.Count > 0)
                        {
                            if (formsGroups.Count == 2)
                            {
                                //informationDataBlock.conjugation += formsGroups[1]

                                //пока добавлять не буду, но суть в том что в этом элементе есть женская версия слова(как я понимаю, например Arzt и Arztin)
                            }

                            var conjugations = formsGroups[0].QuerySelectorAll(".inf-group.dinfg");
                            
                            if (conjugations != null)
                            {
                                if (conjugations.Count > 0)
                                {
                                    informationDataBlock.conjugation += conjugations[conjugations.Count - 1].InnerText.Split(',')[1];
                                    //просто там разеделено так: nominative, plural WORD
                                    //и я избавляюсь от nominative

                                }

                            }
                        }

                    }
                }

                //german meanings:
                try
                {
                    var meanings = informationBlock.QuerySelectorAll(".ddef_d");//it is optional;
                    foreach (var meaning in meanings)
                    {
                        if (!GetClasses(meaning.ParentNode.ParentNode.ParentNode).ToList<string>().Contains("phrase-body"))
                            informationDataBlock.meanings.Add(meaning.InnerText.Trim());
                    }
                }
                catch { }

                var translations = informationBlock.QuerySelectorAll(".trans.dtrans");

                foreach (var translation in translations)
                {
                    var classes = GetClasses(translation.ParentNode);

                    if (classes.Contains("def-body"))
                    {
                        string line = translation.InnerText.Trim();

                        if (GetClasses(translation.ParentNode.ParentNode.ParentNode).ToList<string>().Contains("phrase-body"))
                            continue;

                        if (Char.IsPunctuation(line[0]))
                        {
                            continue;
                        }
                        if (!informationDataBlock.translations.Contains(line))
                            informationDataBlock.translations.Add(line);

                    }
                }


                var examples = informationBlock.QuerySelectorAll(".examp");
                foreach (var example in examples)
                {
                    bool canBeWritten = true;
                    if (writeExamplesOnlyWithTranslation)
                    {
                        var exampleChilren = example.GetChildElements();
                        foreach (var exampleChild in exampleChilren)
                        {
                            canBeWritten = false;
                            var childrenClasses = GetClasses(exampleChild);

                            if (GetClasses(exampleChild).ToList<string>().Contains("hdb"))//contains translation
                            {
                                canBeWritten = true;
                                continue;
                            }
                        }
                    }
                    if (canBeWritten)
                        informationDataBlock.examples.Add(example.InnerText.Trim().Replace("  ", "").Replace("\n", "|"));
                }

            }
            informationDataBlock.isInfoFinished = true;
            return informationDataBlock;
        }

        /*главная задача метода - найти значение слова если не нашло в кембридже
        ход действий:
        1.поиск на сайте оригинальном похожие слова из предложенного списка(.lbt.lp-5.lpl-20)

        */
        private static void OnFirstSearchFail(ref informationDataBlock informationDataBlock, string wordName)
        {
            var htmlDocument = GetDocument(spellcheckApiUrl + wordName).Result;

            //поиск похожего слова из списка .lbt.lp-5.lpl-20
            var similarWords = htmlDocument.DocumentNode.QuerySelectorAll(".lbt.lp-5.lpl-20");
            if (similarWords.Count == 0)
            {
                return;
            }
            string newLink = similarWords[0].QuerySelector("a").Attributes["href"].Value;
            informationDataBlock = GetWordInformationFromHtml(GetDocument(newLink).Result).Result;
        }

        private static void OnSecondSearchFail(ref informationDataBlock informationDataBlock, string wordName, HtmlAgilityPack.HtmlDocument htmlDocument)
        {
            try
            {
                var holder = htmlDocument.QuerySelector(".item.lc.lc1.lpb-10.lpr-10");
                if (holder == null) return;
                var linkHolder = holder.QuerySelector("a");
                if (linkHolder != null)
                {
                    string newLink = holder.QuerySelector("a").Attributes["href"].Value;
                    Console.WriteLine(cambridgeSiteLink + newLink);
                    if (newLink != null)
                    {
                        informationDataBlock = GetWordInformationFromHtml(GetDocument(cambridgeSiteLink + newLink).Result).Result;
                    }
                }
            }catch(Exception ex)
            {
                return;
            }
        }

        private static string GetVerbConjugation(string wordName)
        {
            var htmlDocument = GetDocument(verbConjugationSite + wordName).Result;
            if(htmlDocument == null) return "";
            var conjugations = htmlDocument.DocumentNode.QuerySelector("#stammformen");

            string text = conjugations.InnerText.Replace("\n", "");

            return text;
        }
        static string EncodeSpecialCharacters(string input)
        {
            // Используем HttpUtility.UrlEncode для частичного кодирования
            string encoded = HttpUtility.UrlEncode(input);

            // Декодируем буквенные элементы обратно
            Console.WriteLine(Uri.UnescapeDataString(encoded).Replace("+", "%2520"));
            return Uri.UnescapeDataString(encoded).Replace("+", "%2520");
        }
        public static IEnumerable<string> GetClasses(HtmlNode node)
        {
            var classAttribute = node.GetAttributeValue("class", string.Empty);
            if (string.IsNullOrEmpty(classAttribute))
            {
                return new List<string>();
            }
            return classAttribute.Split(' ');
        }
        static async Task<string> TranslateWord(string word)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = reversoSiteLink + $"{EncodeSpecialCharacters(word)}";
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    // Здесь вы можете добавить логику для извлечения перевода из responseBody.
                    // Это может быть анализ HTML или поиск нужного элемента на странице.
                    return "Здесь будет ваш перевод"; // Замени это на фактический перевод
                }
                else
                {
                    return "Не удалось получить перевод";
                }
            }
        }
        private static void PrintInformationDataBlock(informationDataBlock informationDataBlock)
        {
            Console.WriteLine(informationDataBlock.word);
            Console.WriteLine(informationDataBlock.partOfSpeech);
            Console.WriteLine(informationDataBlock.meanings);
            foreach (string line in informationDataBlock.translations)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine(" ");
            foreach (string line in informationDataBlock.examples)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine("---------------------------");

        }

        public struct informationDataBlock
        {
            public string word;
            public string partOfSpeech = "";
            public string conjugation;
            public List<string> meanings;
            public List<string> translations;
            public List<string> examples;
            public bool isInfoFinished;

            public informationDataBlock()
            {
                meanings = new List<string>();
                translations = new List<string>();
                examples = new List<string>();
            }
        }
    }
}
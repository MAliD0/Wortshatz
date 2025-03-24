using static Final_app.DictionaryManager;
using System.Collections.Generic;
using System;

namespace Final_app
{
    internal class AnkiCardsCreator
    {
        //Пример html карточки
        //Слово [часть речи]	<ol><li>Первое значение на немецком</li><li>Второе значение</li></ol><ol><li>Первый перевод с немецкого</li><li>Второй перевод</li></ol>	<ul><li>Пример один на немецком<br>Перевод значения на англ</li><li>Пример 2<br>Перевод 2</li></ul>

        public static string CreateAnkiCard(informationDataBlock informationDataBlock)
        {
            string result = "";

            result += @$"{informationDataBlock.word} [{informationDataBlock.partOfSpeech}]";
            result += "\t";

            result += ListToHtmlString(informationDataBlock.meanings, "ol");
            result += ListToHtmlString(informationDataBlock.translations, "ol");

            result += "\t";
            result += informationDataBlock.conjugation; 
            result += ListOfExamplesToHtmlString(informationDataBlock.examples, "ul");

            return result;
        }

        private static string ListToHtmlString(List<string> input, string tagType)
        {
            string result = "";

            result += $"<{tagType}>";
            foreach (string meaning in input)
            {
                result += @$"<li>{meaning}</li>";
            }
            result += $"</{tagType}>";

            return result;
        }

        private static string ListOfExamplesToHtmlString(List<string> input, string tagType)
        {
            string result = "";

            string[] example;

            result += $"<{tagType}>";
            foreach (string meaning in input)
            {
                example = meaning.Split(new string[] { "||" }, StringSplitOptions.None);
                result += $"<li>{example[0]}<br><pre> {example[1]}</li>";
            }
            result += $"</{tagType}>";

            return result;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;
using static Final_app.DictionaryManager;

namespace Final_app
{
    internal static class Program
    {
        public static SaveSystem saveSystem { get; private set; }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
        private static VisualRecognition visualRecognition;
        public static IKeyboardMouseEvents _globalHook;
        static DictionaryManager dictionaryManager;
        static SoundManager soundManager;
        static KeyboardWriteRecorder keyboardWriteRecorder;

        [STAThread]
        static void Main()
        {
            saveSystem = new SaveSystem(AppDomain.CurrentDomain.BaseDirectory);
            visualRecognition = new VisualRecognition(@"./tessdata", "deu", 20);

            _globalHook = Hook.GlobalEvents();
            _globalHook.KeyDown += OnShortcutPressed;

            soundManager = new SoundManager(AppDomain.CurrentDomain.BaseDirectory);

            keyboardWriteRecorder = new KeyboardWriteRecorder();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form1 form = new Form1();

            Form1.instance.onCardGenerateCall += CardsGenerationHandler;
            saveSystem.onRequireListSelect += CallListSelect;
            saveSystem.onRequireListSelect += () => { soundManager.PlaySound(SoundTypes.error); };
            saveSystem.onWordAddedToList += () => { soundManager.PlaySound(SoundTypes.confirmation); };

            keyboardWriteRecorder.onRecordingStarted += () => { soundManager.PlaySound(SoundTypes.record); };
            keyboardWriteRecorder.onRecordingStopped += (x) =>
            {
                saveSystem.WriteIntoFileUnique(x);
            };

            Application.Run(form);
        }

        private static void CallListSelect()
        {
            Form1.instance.OpenPage(Form1.instance.ListSelectionMenu);
        }

        private static void CardsGenerationHandler(string listName, string deckName)
        {
            List<string> words = saveSystem.ReadFromFile(listName);

            bool isFailListCreated = false;
            string failedList = deckName + "Failed";

            Console.WriteLine($"{failedList}");
            for (int i = 0; i < words.Count; i++)
            {
                Console.WriteLine(words[i]);
                informationDataBlock informationDataBlock = DictionaryManager.FindWordInDictionary(words[i]).Result;

                if (informationDataBlock.isInfoFinished == false)
                {
                    /*if (informationDataBlock.word.Split(' ').Length > 1)
                    {
                        
                    }*/

                    if (!isFailListCreated && !saveSystem.GetAllDictionarys().Contains(failedList + ".txt"))
                    {
                        saveSystem.CreateNewList(failedList);
                    }
                    saveSystem.WriteIntoFileUnique(words[i], failedList + ".txt");
                    Console.WriteLine("Written: " + words[i]);
                    continue;
                }
                saveSystem.WriteIntoFile(@"Cards\" + deckName + ".txt",
                    AnkiCardsCreator.CreateAnkiCard(informationDataBlock));
            }
            soundManager.PlaySound(SoundTypes.confirmation);
            Form1.instance.ShowMessage("Output", "Cards are successfully generated");
        }

        private static void OnShortcutPressed(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.Alt && e.KeyCode == Keys.Z))
            {
                OnSaveShortcutPressed();
                e.Handled = true;
                return;
            }

            if (e.KeyCode == Keys.F2)
            {
                keyboardWriteRecorder.StartRecording();
                e.Handled = true;
                return;
            }
            if(e.KeyCode == Keys.F3)
            {
                keyboardWriteRecorder.StopRecording();
                e.Handled = true;
                return;
            }
            keyboardWriteRecorder.RecordKeyInput(e);

            // Mark event handled
            e.Handled = false;
            e.SuppressKeyPress = false;
        }

        private static void OnSaveShortcutPressed()
        {

            // Handle clipboard data
            if (Clipboard.ContainsText())
            {
                string clipboardText = Clipboard.GetText();
                if (clipboardText != null)
                {
                    OnWordFoundAsync(clipboardText);
                }
            }
            else if (Clipboard.ContainsImage())
            {
                Image clipboardImage = Clipboard.GetImage();
                if (clipboardImage != null)
                {
                    // Convert image to text using Tesseract
                    string ocrText = visualRecognition.ExtractTextFromImage(clipboardImage);
                    if (ocrText != null)
                        OnWordFoundAsync(ocrText);
                }
            }
            else
            {
                Console.WriteLine("Clipboard doesn't contain text or image.");
            }
        }

        private static async void OnWordFoundAsync(string word)
        {
            Console.WriteLine(word);
            word = RemoveSpecialCharacters(word.Trim().ToLower());
            Console.WriteLine(word);

            Console.WriteLine("Copied word: " + word);

            if (word.Split(' ').Length > 1)
            {
                Console.WriteLine("It is sentence, functionality for this in dev");
                await saveSystem.WriteIntoFile(word);

                //await saveSystem.WriteIntoFileUnique(word);
            }
            else
            {
                Console.WriteLine("Copied word: " + word);
                await saveSystem.WriteIntoFileUnique(word);
            }
        }
        private static async Task<informationDataBlock> MakeReq(string word)
        {
            return await DictionaryManager.FindWordInDictionary(word);
        }
        public static string RemoveSpecialCharacters(string input)
        {
            return String.Join("", input.Split('@', ',', '.', ';', '\''));

        }
    }
}

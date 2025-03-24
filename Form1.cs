using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_app
{
    public partial class Form1 : Form
    {
        public static Form1 instance;
        public static TaskCompletionSource<string> onListSelected;
        public Action<string, string> onCardGenerateCall;
        WindowsManager windowsManager;
        //public static AIAutoSpeaker aIAutoSpeaker;

        public Form1()
        {
            InitializeComponent();
            instance = this;
            windowsManager = new WindowsManager(new List<GroupBox>() { ListCreateMenu, ListSelectionMenu,
                CardGeneratorBox,SaveWordBox, AboutBox });
            Program.saveSystem.onRequireListSelect += () => {

                windowsManager.ShowWindow(ListSelectionMenu);
                listsBox.Items.Clear();
                string[] lists = Program.saveSystem.GetAllDictionarys();
                foreach (var item in lists)
                {
                    listsBox.Items.Add(item);
                }
            };

            //aIAutoSpeaker = new AIAutoSpeaker(@"./chromedriver");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void CreateListButton_Click(object sender, EventArgs e)
        {
            windowsManager.ShowWindow(ListCreateMenu);
        }
        private void CreateListSubmit_Click(object sender, EventArgs e)
        {
            Program.saveSystem.CreateNewList(listNameBox.Text);
        }
        private void ShowListButton_Click(object sender, EventArgs e)
        {

        }
        private void GenerateCardsButton_Click(object sender, EventArgs e)
        {
            windowsManager.ShowWindow(CardGeneratorBox);
            GenerateDeckListBox.Items.Clear();
            string[] lists = Program.saveSystem.GetAllDictionarys();
            foreach (var item in lists)
            {
                GenerateDeckListBox.Items.Add(item);
            }
        }
        private void CardsGenerateButton_Click(object sender, EventArgs e)
        {
            onCardGenerateCall?.Invoke((string)GenerateDeckListBox.SelectedItem, (string)cardDeckNameTextBox.Text);
        }

        private void SelectListButton_Click(object sender, EventArgs e)
        {
            windowsManager.ShowWindow(ListSelectionMenu);
            listsBox.Items.Clear();
            string[] lists = Program.saveSystem.GetAllDictionarys();
            foreach (var item in lists)
            {
                listsBox.Items.Add(item);
            }
        }
        private void SumbitListSelectionButton_Click(object sender, EventArgs e)
        {
            Program.saveSystem.SetListSelection((string)listsBox.SelectedItem);
            windowsManager.ShowWindow(windowsManager.lastOpenedTab);
        }

        public Task<string> WaitForConditionAsync()
        {
            return onListSelected.Task;
        }

        internal void OpenPage(GroupBox groupBox)
        {
            windowsManager.ShowWindow(groupBox);
        }

        private void CopyPathButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(Program.saveSystem.GetPath());
        }

        public void ShowMessage(string title, string message)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SaveWordButton_Click(object sender, EventArgs e)
        {
            windowsManager.ShowWindow(SaveWordBox);
        }
        private void buttonSaveWord_Click(object sender, EventArgs e)
        {
            Program.saveSystem.WriteIntoFileUnique(WordToSave.Text);
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            windowsManager.ShowWindow(AboutBox);
        }
    }
}

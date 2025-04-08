namespace Final_app
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.OptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.MainButtonsLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.CreateListButton = new System.Windows.Forms.Button();
            this.SelectListButton = new System.Windows.Forms.Button();
            this.SaveWordButton = new System.Windows.Forms.Button();
            this.GenerateCardsButton = new System.Windows.Forms.Button();
            this.AboutButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ListSelectionMenu = new System.Windows.Forms.GroupBox();
            this.SumbitListSelectionButton = new System.Windows.Forms.Button();
            this.listsBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.AboutBox = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.CardGeneratorBox = new System.Windows.Forms.GroupBox();
            this.CopyPathButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cardDeckNameTextBox = new System.Windows.Forms.TextBox();
            this.CardsGenerateButton = new System.Windows.Forms.Button();
            this.GenerateDeckListBox = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SaveWordBox = new System.Windows.Forms.GroupBox();
            this.buttonSaveWord = new System.Windows.Forms.Button();
            this.WordToSave = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ListCreateMenu = new System.Windows.Forms.GroupBox();
            this.CreateListSubmit = new System.Windows.Forms.Button();
            this.listNameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.OptionsGroupBox.SuspendLayout();
            this.MainButtonsLayout.SuspendLayout();
            this.ListSelectionMenu.SuspendLayout();
            this.AboutBox.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.CardGeneratorBox.SuspendLayout();
            this.SaveWordBox.SuspendLayout();
            this.ListCreateMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // OptionsGroupBox
            // 
            this.OptionsGroupBox.Controls.Add(this.MainButtonsLayout);
            this.OptionsGroupBox.Controls.Add(this.label1);
            this.OptionsGroupBox.Location = new System.Drawing.Point(12, 12);
            this.OptionsGroupBox.Name = "OptionsGroupBox";
            this.OptionsGroupBox.Size = new System.Drawing.Size(180, 333);
            this.OptionsGroupBox.TabIndex = 0;
            this.OptionsGroupBox.TabStop = false;
            // 
            // MainButtonsLayout
            // 
            this.MainButtonsLayout.Controls.Add(this.CreateListButton);
            this.MainButtonsLayout.Controls.Add(this.SelectListButton);
            this.MainButtonsLayout.Controls.Add(this.SaveWordButton);
            this.MainButtonsLayout.Controls.Add(this.GenerateCardsButton);
            this.MainButtonsLayout.Controls.Add(this.AboutButton);
            this.MainButtonsLayout.Location = new System.Drawing.Point(10, 49);
            this.MainButtonsLayout.Name = "MainButtonsLayout";
            this.MainButtonsLayout.Padding = new System.Windows.Forms.Padding(8);
            this.MainButtonsLayout.Size = new System.Drawing.Size(143, 278);
            this.MainButtonsLayout.TabIndex = 1;
            // 
            // CreateListButton
            // 
            this.CreateListButton.Location = new System.Drawing.Point(11, 11);
            this.CreateListButton.Name = "CreateListButton";
            this.CreateListButton.Size = new System.Drawing.Size(110, 34);
            this.CreateListButton.TabIndex = 1;
            this.CreateListButton.Text = "Create new list";
            this.CreateListButton.UseVisualStyleBackColor = true;
            this.CreateListButton.Click += new System.EventHandler(this.CreateListButton_Click);
            // 
            // SelectListButton
            // 
            this.SelectListButton.Location = new System.Drawing.Point(11, 51);
            this.SelectListButton.Name = "SelectListButton";
            this.SelectListButton.Size = new System.Drawing.Size(110, 34);
            this.SelectListButton.TabIndex = 2;
            this.SelectListButton.Text = "Select list";
            this.SelectListButton.UseVisualStyleBackColor = true;
            this.SelectListButton.Click += new System.EventHandler(this.SelectListButton_Click);
            // 
            // SaveWordButton
            // 
            this.SaveWordButton.Location = new System.Drawing.Point(11, 91);
            this.SaveWordButton.Name = "SaveWordButton";
            this.SaveWordButton.Size = new System.Drawing.Size(110, 34);
            this.SaveWordButton.TabIndex = 3;
            this.SaveWordButton.Text = "Save word";
            this.SaveWordButton.UseVisualStyleBackColor = true;
            this.SaveWordButton.Click += new System.EventHandler(this.SaveWordButton_Click);
            // 
            // GenerateCardsButton
            // 
            this.GenerateCardsButton.Location = new System.Drawing.Point(11, 131);
            this.GenerateCardsButton.Name = "GenerateCardsButton";
            this.GenerateCardsButton.Size = new System.Drawing.Size(110, 34);
            this.GenerateCardsButton.TabIndex = 4;
            this.GenerateCardsButton.Text = "Generate cards";
            this.GenerateCardsButton.UseVisualStyleBackColor = true;
            this.GenerateCardsButton.Click += new System.EventHandler(this.GenerateCardsButton_Click);
            // 
            // AboutButton
            // 
            this.AboutButton.Location = new System.Drawing.Point(11, 171);
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.Size = new System.Drawing.Size(110, 34);
            this.AboutButton.TabIndex = 5;
            this.AboutButton.Text = "About";
            this.AboutButton.UseVisualStyleBackColor = true;
            this.AboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Options menu:";
            // 
            // ListSelectionMenu
            // 
            this.ListSelectionMenu.Controls.Add(this.SumbitListSelectionButton);
            this.ListSelectionMenu.Controls.Add(this.listsBox);
            this.ListSelectionMenu.Controls.Add(this.label3);
            this.ListSelectionMenu.Location = new System.Drawing.Point(198, 22);
            this.ListSelectionMenu.Name = "ListSelectionMenu";
            this.ListSelectionMenu.Size = new System.Drawing.Size(242, 317);
            this.ListSelectionMenu.TabIndex = 3;
            this.ListSelectionMenu.TabStop = false;
            this.ListSelectionMenu.Visible = false;
            // 
            // SumbitListSelectionButton
            // 
            this.SumbitListSelectionButton.Location = new System.Drawing.Point(22, 164);
            this.SumbitListSelectionButton.Name = "SumbitListSelectionButton";
            this.SumbitListSelectionButton.Size = new System.Drawing.Size(76, 22);
            this.SumbitListSelectionButton.TabIndex = 3;
            this.SumbitListSelectionButton.Text = "Select";
            this.SumbitListSelectionButton.UseVisualStyleBackColor = true;
            this.SumbitListSelectionButton.Click += new System.EventHandler(this.SumbitListSelectionButton_Click);
            // 
            // listsBox
            // 
            this.listsBox.FormattingEnabled = true;
            this.listsBox.Location = new System.Drawing.Point(22, 84);
            this.listsBox.Name = "listsBox";
            this.listsBox.Size = new System.Drawing.Size(152, 69);
            this.listsBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label3.Location = new System.Drawing.Point(19, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "Select list to save into:";
            // 
            // AboutBox
            // 
            this.AboutBox.Controls.Add(this.flowLayoutPanel1);
            this.AboutBox.Controls.Add(this.label7);
            this.AboutBox.Location = new System.Drawing.Point(197, 22);
            this.AboutBox.Name = "AboutBox";
            this.AboutBox.Size = new System.Drawing.Size(248, 317);
            this.AboutBox.TabIndex = 3;
            this.AboutBox.TabStop = false;
            this.AboutBox.Visible = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label8);
            this.flowLayoutPanel1.Controls.Add(this.label9);
            this.flowLayoutPanel1.Controls.Add(this.label10);
            this.flowLayoutPanel1.Controls.Add(this.label11);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(22, 60);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(220, 178);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(200, 18);
            this.label8.TabIndex = 3;
            this.label8.Text = "1.Select list to save word into";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label9.Location = new System.Drawing.Point(3, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(160, 18);
            this.label9.TabIndex = 4;
            this.label9.Text = "2.Snippet or copy word";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label10.Location = new System.Drawing.Point(3, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(213, 36);
            this.label10.TabIndex = 5;
            this.label10.Text = "3.Press shortcut (ctrl+alt+z) to save word";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label11.Location = new System.Drawing.Point(3, 72);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(122, 18);
            this.label11.TabIndex = 6;
            this.label11.Text = "4.Generate cards";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label7.Location = new System.Drawing.Point(19, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 18);
            this.label7.TabIndex = 0;
            this.label7.Text = "How to use:";
            // 
            // CardGeneratorBox
            // 
            this.CardGeneratorBox.Controls.Add(this.CopyPathButton);
            this.CardGeneratorBox.Controls.Add(this.label5);
            this.CardGeneratorBox.Controls.Add(this.cardDeckNameTextBox);
            this.CardGeneratorBox.Controls.Add(this.CardsGenerateButton);
            this.CardGeneratorBox.Controls.Add(this.GenerateDeckListBox);
            this.CardGeneratorBox.Controls.Add(this.label4);
            this.CardGeneratorBox.Location = new System.Drawing.Point(192, 16);
            this.CardGeneratorBox.Name = "CardGeneratorBox";
            this.CardGeneratorBox.Size = new System.Drawing.Size(242, 317);
            this.CardGeneratorBox.TabIndex = 4;
            this.CardGeneratorBox.TabStop = false;
            this.CardGeneratorBox.Visible = false;
            // 
            // CopyPathButton
            // 
            this.CopyPathButton.Location = new System.Drawing.Point(117, 222);
            this.CopyPathButton.Name = "CopyPathButton";
            this.CopyPathButton.Size = new System.Drawing.Size(76, 22);
            this.CopyPathButton.TabIndex = 5;
            this.CopyPathButton.Text = "Copy path";
            this.CopyPathButton.UseVisualStyleBackColor = true;
            this.CopyPathButton.Click += new System.EventHandler(this.CopyPathButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label5.Location = new System.Drawing.Point(19, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 18);
            this.label5.TabIndex = 3;
            this.label5.Text = "Write deck name:";
            // 
            // cardDeckNameTextBox
            // 
            this.cardDeckNameTextBox.Location = new System.Drawing.Point(22, 180);
            this.cardDeckNameTextBox.Name = "cardDeckNameTextBox";
            this.cardDeckNameTextBox.Size = new System.Drawing.Size(139, 20);
            this.cardDeckNameTextBox.TabIndex = 3;
            // 
            // CardsGenerateButton
            // 
            this.CardsGenerateButton.Location = new System.Drawing.Point(22, 222);
            this.CardsGenerateButton.Name = "CardsGenerateButton";
            this.CardsGenerateButton.Size = new System.Drawing.Size(76, 22);
            this.CardsGenerateButton.TabIndex = 4;
            this.CardsGenerateButton.Text = "Generate";
            this.CardsGenerateButton.UseVisualStyleBackColor = true;
            this.CardsGenerateButton.Click += new System.EventHandler(this.CardsGenerateButton_Click);
            // 
            // GenerateDeckListBox
            // 
            this.GenerateDeckListBox.FormattingEnabled = true;
            this.GenerateDeckListBox.Location = new System.Drawing.Point(22, 81);
            this.GenerateDeckListBox.Name = "GenerateDeckListBox";
            this.GenerateDeckListBox.Size = new System.Drawing.Size(152, 69);
            this.GenerateDeckListBox.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label4.Location = new System.Drawing.Point(19, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "Select list to create cards";
            // 
            // SaveWordBox
            // 
            this.SaveWordBox.Controls.Add(this.buttonSaveWord);
            this.SaveWordBox.Controls.Add(this.WordToSave);
            this.SaveWordBox.Controls.Add(this.label6);
            this.SaveWordBox.Location = new System.Drawing.Point(196, 24);
            this.SaveWordBox.Name = "SaveWordBox";
            this.SaveWordBox.Size = new System.Drawing.Size(242, 317);
            this.SaveWordBox.TabIndex = 5;
            this.SaveWordBox.TabStop = false;
            this.SaveWordBox.Visible = false;
            // 
            // buttonSaveWord
            // 
            this.buttonSaveWord.Location = new System.Drawing.Point(22, 126);
            this.buttonSaveWord.Name = "buttonSaveWord";
            this.buttonSaveWord.Size = new System.Drawing.Size(76, 22);
            this.buttonSaveWord.TabIndex = 2;
            this.buttonSaveWord.Text = "Save";
            this.buttonSaveWord.UseVisualStyleBackColor = true;
            this.buttonSaveWord.Click += new System.EventHandler(this.buttonSaveWord_Click);
            // 
            // WordToSave
            // 
            this.WordToSave.AcceptsTab = true;
            this.WordToSave.Location = new System.Drawing.Point(22, 100);
            this.WordToSave.Name = "WordToSave";
            this.WordToSave.Size = new System.Drawing.Size(139, 20);
            this.WordToSave.TabIndex = 1;
            this.WordToSave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.WordToSave_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label6.Location = new System.Drawing.Point(19, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 18);
            this.label6.TabIndex = 0;
            this.label6.Text = "Write word to save:";
            // 
            // ListCreateMenu
            // 
            this.ListCreateMenu.Controls.Add(this.CreateListSubmit);
            this.ListCreateMenu.Controls.Add(this.listNameBox);
            this.ListCreateMenu.Controls.Add(this.label2);
            this.ListCreateMenu.Location = new System.Drawing.Point(203, 28);
            this.ListCreateMenu.Name = "ListCreateMenu";
            this.ListCreateMenu.Size = new System.Drawing.Size(242, 317);
            this.ListCreateMenu.TabIndex = 6;
            this.ListCreateMenu.TabStop = false;
            this.ListCreateMenu.Visible = false;
            // 
            // CreateListSubmit
            // 
            this.CreateListSubmit.Location = new System.Drawing.Point(22, 126);
            this.CreateListSubmit.Name = "CreateListSubmit";
            this.CreateListSubmit.Size = new System.Drawing.Size(76, 22);
            this.CreateListSubmit.TabIndex = 2;
            this.CreateListSubmit.Text = "Create";
            this.CreateListSubmit.UseVisualStyleBackColor = true;
            this.CreateListSubmit.Click += new System.EventHandler(this.CreateListSubmit_Click);
            // 
            // listNameBox
            // 
            this.listNameBox.Location = new System.Drawing.Point(22, 100);
            this.listNameBox.Name = "listNameBox";
            this.listNameBox.Size = new System.Drawing.Size(139, 20);
            this.listNameBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label2.Location = new System.Drawing.Point(19, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Write list name:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 401);
            this.Controls.Add(this.CardGeneratorBox);
            this.Controls.Add(this.SaveWordBox);
            this.Controls.Add(this.ListSelectionMenu);
            this.Controls.Add(this.ListCreateMenu);
            this.Controls.Add(this.AboutBox);
            this.Controls.Add(this.OptionsGroupBox);
            this.Name = "Form1";
            this.Text = "DeuCards";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.OptionsGroupBox.ResumeLayout(false);
            this.OptionsGroupBox.PerformLayout();
            this.MainButtonsLayout.ResumeLayout(false);
            this.ListSelectionMenu.ResumeLayout(false);
            this.ListSelectionMenu.PerformLayout();
            this.AboutBox.ResumeLayout(false);
            this.AboutBox.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.CardGeneratorBox.ResumeLayout(false);
            this.CardGeneratorBox.PerformLayout();
            this.SaveWordBox.ResumeLayout(false);
            this.SaveWordBox.PerformLayout();
            this.ListCreateMenu.ResumeLayout(false);
            this.ListCreateMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.GroupBox OptionsGroupBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel MainButtonsLayout;
        private System.Windows.Forms.Button CreateListButton;
        private System.Windows.Forms.Button GenerateCardsButton;
        private System.Windows.Forms.Button SaveWordButton;
        private System.Windows.Forms.Button SelectListButton;
        public System.Windows.Forms.GroupBox ListSelectionMenu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listsBox;
        private System.Windows.Forms.Button SumbitListSelectionButton;
        private System.Windows.Forms.Button AboutButton;
        public System.Windows.Forms.GroupBox AboutBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.GroupBox CardGeneratorBox;
        private System.Windows.Forms.Button CopyPathButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox cardDeckNameTextBox;
        private System.Windows.Forms.Button CardsGenerateButton;
        private System.Windows.Forms.ListBox GenerateDeckListBox;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.GroupBox SaveWordBox;
        private System.Windows.Forms.Button buttonSaveWord;
        private System.Windows.Forms.TextBox WordToSave;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.GroupBox ListCreateMenu;
        private System.Windows.Forms.Button CreateListSubmit;
        private System.Windows.Forms.TextBox listNameBox;
        private System.Windows.Forms.Label label2;
    }
}


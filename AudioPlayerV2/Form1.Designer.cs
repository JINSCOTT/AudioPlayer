namespace AudioPlayerV2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            OutputDeviceSelectBox = new ComboBox();
            SelectFileButton = new Button();
            FileNameBox = new TextBox();
            ProgressBar = new TrackBar();
            PlayButton = new Button();
            PauseButton = new Button();
            EQL10 = new Label();
            EQL9 = new Label();
            EQL8 = new Label();
            EQL7 = new Label();
            EQL6 = new Label();
            EQL5 = new Label();
            EQL4 = new Label();
            EQL3 = new Label();
            EQL2 = new Label();
            EQL1 = new Label();
            EQ10 = new TrackBar();
            EQ9 = new TrackBar();
            EQ8 = new TrackBar();
            EQ7 = new TrackBar();
            EQ6 = new TrackBar();
            EQ5 = new TrackBar();
            EQ4 = new TrackBar();
            EQ3 = new TrackBar();
            EQ2 = new TrackBar();
            EQ1 = new TrackBar();
            Volume = new Label();
            Volumebar = new TrackBar();
            ((System.ComponentModel.ISupportInitialize)ProgressBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EQ10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EQ9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EQ8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EQ7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EQ6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EQ5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EQ4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EQ3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EQ2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EQ1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Volumebar).BeginInit();
            SuspendLayout();
            // 
            // OutputDeviceSelectBox
            // 
            OutputDeviceSelectBox.FormattingEnabled = true;
            OutputDeviceSelectBox.Location = new Point(349, 415);
            OutputDeviceSelectBox.Name = "OutputDeviceSelectBox";
            OutputDeviceSelectBox.Size = new Size(277, 23);
            OutputDeviceSelectBox.TabIndex = 0;
            OutputDeviceSelectBox.SelectedIndexChanged += OutputDeviceSelectBox_SelectedIndexChanged;
            // 
            // SelectFileButton
            // 
            SelectFileButton.Location = new Point(12, 184);
            SelectFileButton.Name = "SelectFileButton";
            SelectFileButton.Size = new Size(75, 23);
            SelectFileButton.TabIndex = 1;
            SelectFileButton.Text = "Select File";
            SelectFileButton.UseVisualStyleBackColor = true;
            SelectFileButton.Click += SelectFileButton_Click;
            // 
            // FileNameBox
            // 
            FileNameBox.Location = new Point(93, 185);
            FileNameBox.Name = "FileNameBox";
            FileNameBox.Size = new Size(100, 23);
            FileNameBox.TabIndex = 2;
            FileNameBox.TextChanged += FileNameBox_TextChanged;
            // 
            // ProgressBar
            // 
            ProgressBar.Location = new Point(135, 279);
            ProgressBar.Name = "ProgressBar";
            ProgressBar.Size = new Size(578, 45);
            ProgressBar.TabIndex = 3;
            ProgressBar.MouseDown += ProgressBar_MouseDown;
            ProgressBar.MouseUp += ProgressBar_MouseUp;
            // 
            // PlayButton
            // 
            PlayButton.Location = new Point(349, 330);
            PlayButton.Name = "PlayButton";
            PlayButton.Size = new Size(75, 23);
            PlayButton.TabIndex = 4;
            PlayButton.Text = "Play";
            PlayButton.UseVisualStyleBackColor = true;
            PlayButton.Click += PlayButton_Click;
            // 
            // PauseButton
            // 
            PauseButton.Location = new Point(430, 330);
            PauseButton.Name = "PauseButton";
            PauseButton.Size = new Size(75, 23);
            PauseButton.TabIndex = 5;
            PauseButton.Text = "Pause";
            PauseButton.UseVisualStyleBackColor = true;
            PauseButton.Click += PauseButton_Click;
            // 
            // EQL10
            // 
            EQL10.AutoSize = true;
            EQL10.Location = new Point(668, 245);
            EQL10.Name = "EQL10";
            EQL10.Size = new Size(40, 15);
            EQL10.TabIndex = 52;
            EQL10.Text = "16KHz";
            // 
            // EQL9
            // 
            EQL9.AutoSize = true;
            EQL9.Location = new Point(618, 245);
            EQL9.Name = "EQL9";
            EQL9.Size = new Size(34, 15);
            EQL9.TabIndex = 51;
            EQL9.Text = "8KHz";
            // 
            // EQL8
            // 
            EQL8.AutoSize = true;
            EQL8.Location = new Point(568, 245);
            EQL8.Name = "EQL8";
            EQL8.Size = new Size(34, 15);
            EQL8.TabIndex = 50;
            EQL8.Text = "4KHz";
            // 
            // EQL7
            // 
            EQL7.AutoSize = true;
            EQL7.Location = new Point(518, 245);
            EQL7.Name = "EQL7";
            EQL7.Size = new Size(34, 15);
            EQL7.TabIndex = 49;
            EQL7.Text = "2KHz";
            // 
            // EQL6
            // 
            EQL6.AutoSize = true;
            EQL6.Location = new Point(468, 245);
            EQL6.Name = "EQL6";
            EQL6.Size = new Size(34, 15);
            EQL6.TabIndex = 48;
            EQL6.Text = "1KHz";
            // 
            // EQL5
            // 
            EQL5.AutoSize = true;
            EQL5.Location = new Point(418, 245);
            EQL5.Name = "EQL5";
            EQL5.Size = new Size(39, 15);
            EQL5.TabIndex = 47;
            EQL5.Text = "500Hz";
            // 
            // EQL4
            // 
            EQL4.AutoSize = true;
            EQL4.Location = new Point(368, 245);
            EQL4.Name = "EQL4";
            EQL4.Size = new Size(39, 15);
            EQL4.TabIndex = 46;
            EQL4.Text = "250Hz";
            // 
            // EQL3
            // 
            EQL3.AutoSize = true;
            EQL3.Location = new Point(318, 245);
            EQL3.Name = "EQL3";
            EQL3.Size = new Size(39, 15);
            EQL3.TabIndex = 45;
            EQL3.Text = "125Hz";
            // 
            // EQL2
            // 
            EQL2.AutoSize = true;
            EQL2.Location = new Point(268, 245);
            EQL2.Name = "EQL2";
            EQL2.Size = new Size(33, 15);
            EQL2.TabIndex = 44;
            EQL2.Text = "64Hz";
            // 
            // EQL1
            // 
            EQL1.AutoSize = true;
            EQL1.Location = new Point(218, 245);
            EQL1.Name = "EQL1";
            EQL1.Size = new Size(33, 15);
            EQL1.TabIndex = 43;
            EQL1.Text = "32Hz";
            // 
            // EQ10
            // 
            EQ10.Location = new Point(668, 10);
            EQ10.Margin = new Padding(1);
            EQ10.Maximum = 30;
            EQ10.Minimum = -30;
            EQ10.Name = "EQ10";
            EQ10.Orientation = Orientation.Vertical;
            EQ10.Size = new Size(45, 234);
            EQ10.TabIndex = 42;
            EQ10.Scroll += EQ10_Scroll;
            // 
            // EQ9
            // 
            EQ9.Location = new Point(618, 10);
            EQ9.Margin = new Padding(1);
            EQ9.Maximum = 30;
            EQ9.Minimum = -30;
            EQ9.Name = "EQ9";
            EQ9.Orientation = Orientation.Vertical;
            EQ9.Size = new Size(45, 234);
            EQ9.TabIndex = 41;
            EQ9.Scroll += EQ9_Scroll;
            // 
            // EQ8
            // 
            EQ8.Location = new Point(568, 10);
            EQ8.Margin = new Padding(1);
            EQ8.Maximum = 30;
            EQ8.Minimum = -30;
            EQ8.Name = "EQ8";
            EQ8.Orientation = Orientation.Vertical;
            EQ8.Size = new Size(45, 234);
            EQ8.TabIndex = 37;
            EQ8.Scroll += EQ8_Scroll;
            // 
            // EQ7
            // 
            EQ7.Location = new Point(518, 10);
            EQ7.Margin = new Padding(1);
            EQ7.Maximum = 30;
            EQ7.Minimum = -30;
            EQ7.Name = "EQ7";
            EQ7.Orientation = Orientation.Vertical;
            EQ7.Size = new Size(45, 234);
            EQ7.TabIndex = 38;
            EQ7.Scroll += EQ7_Scroll;
            // 
            // EQ6
            // 
            EQ6.Location = new Point(468, 10);
            EQ6.Margin = new Padding(1);
            EQ6.Maximum = 30;
            EQ6.Minimum = -30;
            EQ6.Name = "EQ6";
            EQ6.Orientation = Orientation.Vertical;
            EQ6.Size = new Size(45, 234);
            EQ6.TabIndex = 39;
            EQ6.Scroll += EQ6_Scroll;
            // 
            // EQ5
            // 
            EQ5.Location = new Point(418, 10);
            EQ5.Margin = new Padding(1);
            EQ5.Maximum = 30;
            EQ5.Minimum = -30;
            EQ5.Name = "EQ5";
            EQ5.Orientation = Orientation.Vertical;
            EQ5.Size = new Size(45, 234);
            EQ5.TabIndex = 40;
            EQ5.Scroll += EQ5_Scroll;
            // 
            // EQ4
            // 
            EQ4.Location = new Point(368, 10);
            EQ4.Margin = new Padding(1);
            EQ4.Maximum = 30;
            EQ4.Minimum = -30;
            EQ4.Name = "EQ4";
            EQ4.Orientation = Orientation.Vertical;
            EQ4.Size = new Size(45, 234);
            EQ4.TabIndex = 35;
            EQ4.Scroll += EQ4_Scroll;
            // 
            // EQ3
            // 
            EQ3.Location = new Point(318, 10);
            EQ3.Margin = new Padding(1);
            EQ3.Maximum = 30;
            EQ3.Minimum = -30;
            EQ3.Name = "EQ3";
            EQ3.Orientation = Orientation.Vertical;
            EQ3.Size = new Size(45, 234);
            EQ3.TabIndex = 36;
            EQ3.Scroll += EQ3_Scroll;
            // 
            // EQ2
            // 
            EQ2.Location = new Point(268, 10);
            EQ2.Margin = new Padding(1);
            EQ2.Maximum = 30;
            EQ2.Minimum = -30;
            EQ2.Name = "EQ2";
            EQ2.Orientation = Orientation.Vertical;
            EQ2.Size = new Size(45, 234);
            EQ2.TabIndex = 34;
            EQ2.Scroll += EQ2_Scroll;
            // 
            // EQ1
            // 
            EQ1.Location = new Point(218, 10);
            EQ1.Margin = new Padding(1);
            EQ1.Maximum = 30;
            EQ1.Minimum = -30;
            EQ1.Name = "EQ1";
            EQ1.Orientation = Orientation.Vertical;
            EQ1.Size = new Size(45, 234);
            EQ1.TabIndex = 33;
            EQ1.Scroll += EQ1_Scroll;
            // 
            // Volume
            // 
            Volume.AutoSize = true;
            Volume.Location = new Point(146, 309);
            Volume.Name = "Volume";
            Volume.Size = new Size(47, 15);
            Volume.TabIndex = 54;
            Volume.Text = "Volume";
            // 
            // Volumebar
            // 
            Volumebar.Location = new Point(139, 327);
            Volumebar.Maximum = 100;
            Volumebar.Name = "Volumebar";
            Volumebar.Size = new Size(137, 45);
            Volumebar.TabIndex = 53;
            Volumebar.Value = 20;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Volume);
            Controls.Add(Volumebar);
            Controls.Add(EQL10);
            Controls.Add(EQL9);
            Controls.Add(EQL8);
            Controls.Add(EQL7);
            Controls.Add(EQL6);
            Controls.Add(EQL5);
            Controls.Add(EQL4);
            Controls.Add(EQL3);
            Controls.Add(EQL2);
            Controls.Add(EQL1);
            Controls.Add(EQ10);
            Controls.Add(EQ9);
            Controls.Add(EQ8);
            Controls.Add(EQ7);
            Controls.Add(EQ6);
            Controls.Add(EQ5);
            Controls.Add(EQ4);
            Controls.Add(EQ3);
            Controls.Add(EQ2);
            Controls.Add(EQ1);
            Controls.Add(PauseButton);
            Controls.Add(PlayButton);
            Controls.Add(ProgressBar);
            Controls.Add(FileNameBox);
            Controls.Add(SelectFileButton);
            Controls.Add(OutputDeviceSelectBox);
            Name = "Form1";
            Text = "Form1";
            Shown += Form1_Shown;
            ((System.ComponentModel.ISupportInitialize)ProgressBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)EQ10).EndInit();
            ((System.ComponentModel.ISupportInitialize)EQ9).EndInit();
            ((System.ComponentModel.ISupportInitialize)EQ8).EndInit();
            ((System.ComponentModel.ISupportInitialize)EQ7).EndInit();
            ((System.ComponentModel.ISupportInitialize)EQ6).EndInit();
            ((System.ComponentModel.ISupportInitialize)EQ5).EndInit();
            ((System.ComponentModel.ISupportInitialize)EQ4).EndInit();
            ((System.ComponentModel.ISupportInitialize)EQ3).EndInit();
            ((System.ComponentModel.ISupportInitialize)EQ2).EndInit();
            ((System.ComponentModel.ISupportInitialize)EQ1).EndInit();
            ((System.ComponentModel.ISupportInitialize)Volumebar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox OutputDeviceSelectBox;
        private Button SelectFileButton;
        private TextBox FileNameBox;
        private TrackBar ProgressBar;
        private Button PlayButton;
        private Button PauseButton;
        private Label EQL10;
        private Label EQL9;
        private Label EQL8;
        private Label EQL7;
        private Label EQL6;
        private Label EQL5;
        private Label EQL4;
        private Label EQL3;
        private Label EQL2;
        private Label EQL1;
        private TrackBar EQ10;
        private TrackBar EQ9;
        private TrackBar EQ8;
        private TrackBar EQ7;
        private TrackBar EQ6;
        private TrackBar EQ5;
        private TrackBar EQ4;
        private TrackBar EQ3;
        private TrackBar EQ2;
        private TrackBar EQ1;
        private Label Volume;
        private TrackBar Volumebar;
    }
}
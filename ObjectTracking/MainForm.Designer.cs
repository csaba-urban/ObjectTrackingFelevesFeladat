namespace ObjectTracking
{
    partial class MainForm
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
			this.components = new System.ComponentModel.Container();
			this.uiCameraPictureBox = new System.Windows.Forms.PictureBox();
			this.uiSelectedTemplatesGroupBox = new System.Windows.Forms.GroupBox();
			this.uiFoundedTemplatePictureBox2 = new System.Windows.Forms.PictureBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.uiSelectedTemplatePictureBox2 = new System.Windows.Forms.PictureBox();
			this.uiFoundedTemplatePictureBox1 = new System.Windows.Forms.PictureBox();
			this.uiSelectedTemplatePictureBox1 = new System.Windows.Forms.PictureBox();
			this.uiBlockMatchingAlgorithmsGroupBox = new System.Windows.Forms.GroupBox();
			this.uiThreeStepSearchRadioButton3 = new System.Windows.Forms.RadioButton();
			this.uiParalellBlockMatchingRadioButton = new System.Windows.Forms.RadioButton();
			this.uiSerialBlockMatchingRadioButton = new System.Windows.Forms.RadioButton();
			this.uiClearTemplatesButton = new System.Windows.Forms.Button();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.uiEllapsedMilisecToFindObjectsLabel = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.uiEvalMetricsGroupBox = new System.Windows.Forms.GroupBox();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.uiMeanAbbsDiffRadioButton = new System.Windows.Forms.RadioButton();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.uiEvalMetricsSerialRadioButton = new System.Windows.Forms.RadioButton();
			this.uiEvalMetricsParallelRadioButton = new System.Windows.Forms.RadioButton();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			((System.ComponentModel.ISupportInitialize)(this.uiCameraPictureBox)).BeginInit();
			this.uiSelectedTemplatesGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.uiFoundedTemplatePictureBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uiSelectedTemplatePictureBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uiFoundedTemplatePictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uiSelectedTemplatePictureBox1)).BeginInit();
			this.uiBlockMatchingAlgorithmsGroupBox.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.uiEvalMetricsGroupBox.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// uiCameraPictureBox
			// 
			this.uiCameraPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.uiCameraPictureBox.Cursor = System.Windows.Forms.Cursors.Cross;
			this.uiCameraPictureBox.Location = new System.Drawing.Point(12, 12);
			this.uiCameraPictureBox.Name = "uiCameraPictureBox";
			this.uiCameraPictureBox.Size = new System.Drawing.Size(640, 480);
			this.uiCameraPictureBox.TabIndex = 0;
			this.uiCameraPictureBox.TabStop = false;
			this.uiCameraPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.uiCameraPictureBox_Paint);
			this.uiCameraPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.uiCameraPictureBox_MouseDown);
			this.uiCameraPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.uiCameraPictureBox_MouseMove);
			this.uiCameraPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.uiCameraPictureBox_MouseUp);
			// 
			// uiSelectedTemplatesGroupBox
			// 
			this.uiSelectedTemplatesGroupBox.Controls.Add(this.uiFoundedTemplatePictureBox2);
			this.uiSelectedTemplatesGroupBox.Controls.Add(this.label4);
			this.uiSelectedTemplatesGroupBox.Controls.Add(this.label5);
			this.uiSelectedTemplatesGroupBox.Controls.Add(this.label3);
			this.uiSelectedTemplatesGroupBox.Controls.Add(this.label2);
			this.uiSelectedTemplatesGroupBox.Controls.Add(this.uiSelectedTemplatePictureBox2);
			this.uiSelectedTemplatesGroupBox.Controls.Add(this.uiFoundedTemplatePictureBox1);
			this.uiSelectedTemplatesGroupBox.Controls.Add(this.uiSelectedTemplatePictureBox1);
			this.uiSelectedTemplatesGroupBox.Location = new System.Drawing.Point(12, 498);
			this.uiSelectedTemplatesGroupBox.Name = "uiSelectedTemplatesGroupBox";
			this.uiSelectedTemplatesGroupBox.Size = new System.Drawing.Size(640, 129);
			this.uiSelectedTemplatesGroupBox.TabIndex = 1;
			this.uiSelectedTemplatesGroupBox.TabStop = false;
			this.uiSelectedTemplatesGroupBox.Text = "Selected Templates";
			// 
			// uiFoundedTemplatePictureBox2
			// 
			this.uiFoundedTemplatePictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.uiFoundedTemplatePictureBox2.Location = new System.Drawing.Point(454, 44);
			this.uiFoundedTemplatePictureBox2.Name = "uiFoundedTemplatePictureBox2";
			this.uiFoundedTemplatePictureBox2.Size = new System.Drawing.Size(115, 70);
			this.uiFoundedTemplatePictureBox2.TabIndex = 7;
			this.uiFoundedTemplatePictureBox2.TabStop = false;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label4.Location = new System.Drawing.Point(451, 19);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Founded";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label5.Location = new System.Drawing.Point(151, 19);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(57, 13);
			this.label5.TabIndex = 5;
			this.label5.Text = "Selected";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label3.Location = new System.Drawing.Point(312, 19);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Founded";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label2.Location = new System.Drawing.Point(7, 19);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(57, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Selected";
			// 
			// uiSelectedTemplatePictureBox2
			// 
			this.uiSelectedTemplatePictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.uiSelectedTemplatePictureBox2.Location = new System.Drawing.Point(154, 44);
			this.uiSelectedTemplatePictureBox2.Name = "uiSelectedTemplatePictureBox2";
			this.uiSelectedTemplatePictureBox2.Size = new System.Drawing.Size(115, 70);
			this.uiSelectedTemplatePictureBox2.TabIndex = 2;
			this.uiSelectedTemplatePictureBox2.TabStop = false;
			// 
			// uiFoundedTemplatePictureBox1
			// 
			this.uiFoundedTemplatePictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.uiFoundedTemplatePictureBox1.Location = new System.Drawing.Point(314, 44);
			this.uiFoundedTemplatePictureBox1.Name = "uiFoundedTemplatePictureBox1";
			this.uiFoundedTemplatePictureBox1.Size = new System.Drawing.Size(115, 70);
			this.uiFoundedTemplatePictureBox1.TabIndex = 1;
			this.uiFoundedTemplatePictureBox1.TabStop = false;
			// 
			// uiSelectedTemplatePictureBox1
			// 
			this.uiSelectedTemplatePictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.uiSelectedTemplatePictureBox1.Location = new System.Drawing.Point(9, 44);
			this.uiSelectedTemplatePictureBox1.Name = "uiSelectedTemplatePictureBox1";
			this.uiSelectedTemplatePictureBox1.Size = new System.Drawing.Size(115, 70);
			this.uiSelectedTemplatePictureBox1.TabIndex = 0;
			this.uiSelectedTemplatePictureBox1.TabStop = false;
			// 
			// uiBlockMatchingAlgorithmsGroupBox
			// 
			this.uiBlockMatchingAlgorithmsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.uiBlockMatchingAlgorithmsGroupBox.Controls.Add(this.uiThreeStepSearchRadioButton3);
			this.uiBlockMatchingAlgorithmsGroupBox.Controls.Add(this.uiParalellBlockMatchingRadioButton);
			this.uiBlockMatchingAlgorithmsGroupBox.Controls.Add(this.uiSerialBlockMatchingRadioButton);
			this.uiBlockMatchingAlgorithmsGroupBox.Location = new System.Drawing.Point(658, 12);
			this.uiBlockMatchingAlgorithmsGroupBox.Name = "uiBlockMatchingAlgorithmsGroupBox";
			this.uiBlockMatchingAlgorithmsGroupBox.Size = new System.Drawing.Size(264, 128);
			this.uiBlockMatchingAlgorithmsGroupBox.TabIndex = 2;
			this.uiBlockMatchingAlgorithmsGroupBox.TabStop = false;
			this.uiBlockMatchingAlgorithmsGroupBox.Text = "Block matching algorithms";
			// 
			// uiThreeStepSearchRadioButton3
			// 
			this.uiThreeStepSearchRadioButton3.AutoSize = true;
			this.uiThreeStepSearchRadioButton3.Location = new System.Drawing.Point(6, 65);
			this.uiThreeStepSearchRadioButton3.Name = "uiThreeStepSearchRadioButton3";
			this.uiThreeStepSearchRadioButton3.Size = new System.Drawing.Size(111, 17);
			this.uiThreeStepSearchRadioButton3.TabIndex = 2;
			this.uiThreeStepSearchRadioButton3.TabStop = true;
			this.uiThreeStepSearchRadioButton3.Text = "Three step search";
			this.uiThreeStepSearchRadioButton3.UseVisualStyleBackColor = true;
			// 
			// uiParalellBlockMatchingRadioButton
			// 
			this.uiParalellBlockMatchingRadioButton.AutoSize = true;
			this.uiParalellBlockMatchingRadioButton.Location = new System.Drawing.Point(6, 42);
			this.uiParalellBlockMatchingRadioButton.Name = "uiParalellBlockMatchingRadioButton";
			this.uiParalellBlockMatchingRadioButton.Size = new System.Drawing.Size(104, 17);
			this.uiParalellBlockMatchingRadioButton.TabIndex = 1;
			this.uiParalellBlockMatchingRadioButton.TabStop = true;
			this.uiParalellBlockMatchingRadioButton.Text = "Parallel algorithm";
			this.uiParalellBlockMatchingRadioButton.UseVisualStyleBackColor = true;
			// 
			// uiSerialBlockMatchingRadioButton
			// 
			this.uiSerialBlockMatchingRadioButton.AutoSize = true;
			this.uiSerialBlockMatchingRadioButton.Checked = true;
			this.uiSerialBlockMatchingRadioButton.Location = new System.Drawing.Point(6, 19);
			this.uiSerialBlockMatchingRadioButton.Name = "uiSerialBlockMatchingRadioButton";
			this.uiSerialBlockMatchingRadioButton.Size = new System.Drawing.Size(96, 17);
			this.uiSerialBlockMatchingRadioButton.TabIndex = 0;
			this.uiSerialBlockMatchingRadioButton.TabStop = true;
			this.uiSerialBlockMatchingRadioButton.Text = "Serial algorithm";
			this.uiSerialBlockMatchingRadioButton.UseVisualStyleBackColor = true;
			// 
			// uiClearTemplatesButton
			// 
			this.uiClearTemplatesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			this.uiClearTemplatesButton.Enabled = false;
			this.uiClearTemplatesButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.uiClearTemplatesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.uiClearTemplatesButton.Location = new System.Drawing.Point(658, 504);
			this.uiClearTemplatesButton.Name = "uiClearTemplatesButton";
			this.uiClearTemplatesButton.Size = new System.Drawing.Size(264, 123);
			this.uiClearTemplatesButton.TabIndex = 4;
			this.uiClearTemplatesButton.Text = "Clear templates";
			this.toolTip1.SetToolTip(this.uiClearTemplatesButton, "Removes the selected templates and stops the tracking.");
			this.uiClearTemplatesButton.UseVisualStyleBackColor = false;
			this.uiClearTemplatesButton.Click += new System.EventHandler(this.uiClearTemplatesButton_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.uiEllapsedMilisecToFindObjectsLabel);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(658, 337);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(264, 155);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Performance informations";
			// 
			// uiEllapsedMilisecToFindObjectsLabel
			// 
			this.uiEllapsedMilisecToFindObjectsLabel.AutoSize = true;
			this.uiEllapsedMilisecToFindObjectsLabel.Location = new System.Drawing.Point(183, 26);
			this.uiEllapsedMilisecToFindObjectsLabel.Name = "uiEllapsedMilisecToFindObjectsLabel";
			this.uiEllapsedMilisecToFindObjectsLabel.Size = new System.Drawing.Size(10, 13);
			this.uiEllapsedMilisecToFindObjectsLabel.TabIndex = 1;
			this.uiEllapsedMilisecToFindObjectsLabel.Text = "-";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 26);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(181, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Ellapsed time to find the objects (ms):";
			// 
			// uiEvalMetricsGroupBox
			// 
			this.uiEvalMetricsGroupBox.Controls.Add(this.groupBox3);
			this.uiEvalMetricsGroupBox.Controls.Add(this.groupBox2);
			this.uiEvalMetricsGroupBox.Location = new System.Drawing.Point(658, 146);
			this.uiEvalMetricsGroupBox.Name = "uiEvalMetricsGroupBox";
			this.uiEvalMetricsGroupBox.Size = new System.Drawing.Size(264, 185);
			this.uiEvalMetricsGroupBox.TabIndex = 6;
			this.uiEvalMetricsGroupBox.TabStop = false;
			this.uiEvalMetricsGroupBox.Text = "Used evaluation metrics";
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Checked = true;
			this.radioButton1.Location = new System.Drawing.Point(6, 19);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(120, 17);
			this.radioButton1.TabIndex = 0;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "Mean Squared Error";
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// uiMeanAbbsDiffRadioButton
			// 
			this.uiMeanAbbsDiffRadioButton.AutoSize = true;
			this.uiMeanAbbsDiffRadioButton.Location = new System.Drawing.Point(6, 42);
			this.uiMeanAbbsDiffRadioButton.Name = "uiMeanAbbsDiffRadioButton";
			this.uiMeanAbbsDiffRadioButton.Size = new System.Drawing.Size(148, 17);
			this.uiMeanAbbsDiffRadioButton.TabIndex = 3;
			this.uiMeanAbbsDiffRadioButton.TabStop = true;
			this.uiMeanAbbsDiffRadioButton.Text = "Mean Absolute Difference";
			this.uiMeanAbbsDiffRadioButton.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.radioButton1);
			this.groupBox2.Controls.Add(this.uiMeanAbbsDiffRadioButton);
			this.groupBox2.Location = new System.Drawing.Point(6, 19);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(252, 74);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Type";
			// 
			// uiEvalMetricsSerialRadioButton
			// 
			this.uiEvalMetricsSerialRadioButton.AutoSize = true;
			this.uiEvalMetricsSerialRadioButton.Location = new System.Drawing.Point(6, 42);
			this.uiEvalMetricsSerialRadioButton.Name = "uiEvalMetricsSerialRadioButton";
			this.uiEvalMetricsSerialRadioButton.Size = new System.Drawing.Size(51, 17);
			this.uiEvalMetricsSerialRadioButton.TabIndex = 1;
			this.uiEvalMetricsSerialRadioButton.Text = "Serial";
			this.uiEvalMetricsSerialRadioButton.UseVisualStyleBackColor = true;
			// 
			// uiEvalMetricsParallelRadioButton
			// 
			this.uiEvalMetricsParallelRadioButton.AutoSize = true;
			this.uiEvalMetricsParallelRadioButton.Checked = true;
			this.uiEvalMetricsParallelRadioButton.Location = new System.Drawing.Point(6, 19);
			this.uiEvalMetricsParallelRadioButton.Name = "uiEvalMetricsParallelRadioButton";
			this.uiEvalMetricsParallelRadioButton.Size = new System.Drawing.Size(59, 17);
			this.uiEvalMetricsParallelRadioButton.TabIndex = 2;
			this.uiEvalMetricsParallelRadioButton.TabStop = true;
			this.uiEvalMetricsParallelRadioButton.Text = "Parallel";
			this.uiEvalMetricsParallelRadioButton.UseVisualStyleBackColor = true;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.uiEvalMetricsParallelRadioButton);
			this.groupBox3.Controls.Add(this.uiEvalMetricsSerialRadioButton);
			this.groupBox3.Location = new System.Drawing.Point(6, 99);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(252, 73);
			this.groupBox3.TabIndex = 5;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Execution type";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(929, 639);
			this.Controls.Add(this.uiEvalMetricsGroupBox);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.uiClearTemplatesButton);
			this.Controls.Add(this.uiBlockMatchingAlgorithmsGroupBox);
			this.Controls.Add(this.uiSelectedTemplatesGroupBox);
			this.Controls.Add(this.uiCameraPictureBox);
			this.MinimumSize = new System.Drawing.Size(840, 644);
			this.Name = "MainForm";
			this.Text = "Object Tracking - Urbán Csaba";
			((System.ComponentModel.ISupportInitialize)(this.uiCameraPictureBox)).EndInit();
			this.uiSelectedTemplatesGroupBox.ResumeLayout(false);
			this.uiSelectedTemplatesGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.uiFoundedTemplatePictureBox2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uiSelectedTemplatePictureBox2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uiFoundedTemplatePictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uiSelectedTemplatePictureBox1)).EndInit();
			this.uiBlockMatchingAlgorithmsGroupBox.ResumeLayout(false);
			this.uiBlockMatchingAlgorithmsGroupBox.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.uiEvalMetricsGroupBox.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

		private System.Windows.Forms.PictureBox uiCameraPictureBox;
		private System.Windows.Forms.GroupBox uiSelectedTemplatesGroupBox;
		private System.Windows.Forms.PictureBox uiSelectedTemplatePictureBox1;
		private System.Windows.Forms.GroupBox uiBlockMatchingAlgorithmsGroupBox;
		private System.Windows.Forms.RadioButton uiThreeStepSearchRadioButton3;
		private System.Windows.Forms.RadioButton uiParalellBlockMatchingRadioButton;
		private System.Windows.Forms.RadioButton uiSerialBlockMatchingRadioButton;
		private System.Windows.Forms.Button uiClearTemplatesButton;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label uiEllapsedMilisecToFindObjectsLabel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox uiSelectedTemplatePictureBox2;
		private System.Windows.Forms.PictureBox uiFoundedTemplatePictureBox1;
		private System.Windows.Forms.PictureBox uiFoundedTemplatePictureBox2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox uiEvalMetricsGroupBox;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton uiMeanAbbsDiffRadioButton;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.RadioButton uiEvalMetricsParallelRadioButton;
		private System.Windows.Forms.RadioButton uiEvalMetricsSerialRadioButton;
    }
}


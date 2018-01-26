namespace GameTemplate.Screens
{
    partial class InstructionScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstructionScreen));
            this.exitButton = new System.Windows.Forms.Button();
            this.instructionsLabel = new System.Windows.Forms.Label();
            this.instructionsLabel2 = new System.Windows.Forms.Label();
            this.instructions3Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // exitButton
            // 
            resources.ApplyResources(this.exitButton, "exitButton");
            this.exitButton.BackColor = System.Drawing.Color.YellowGreen;
            this.exitButton.Name = "exitButton";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // instructionsLabel
            // 
            resources.ApplyResources(this.instructionsLabel, "instructionsLabel");
            this.instructionsLabel.BackColor = System.Drawing.Color.Transparent;
            this.instructionsLabel.ForeColor = System.Drawing.Color.White;
            this.instructionsLabel.Name = "instructionsLabel";
            // 
            // instructionsLabel2
            // 
            resources.ApplyResources(this.instructionsLabel2, "instructionsLabel2");
            this.instructionsLabel2.BackColor = System.Drawing.Color.Transparent;
            this.instructionsLabel2.ForeColor = System.Drawing.Color.White;
            this.instructionsLabel2.Name = "instructionsLabel2";
            // 
            // instructions3Label
            // 
            resources.ApplyResources(this.instructions3Label, "instructions3Label");
            this.instructions3Label.BackColor = System.Drawing.Color.Transparent;
            this.instructions3Label.ForeColor = System.Drawing.Color.White;
            this.instructions3Label.Name = "instructions3Label";
            // 
            // InstructionScreen
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::GameTemplate.Properties.Resources.colour_splash_background;
            this.Controls.Add(this.instructions3Label);
            this.Controls.Add(this.instructionsLabel2);
            this.Controls.Add(this.instructionsLabel);
            this.Controls.Add(this.exitButton);
            this.Name = "InstructionScreen";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label instructionsLabel;
        private System.Windows.Forms.Label instructionsLabel2;
        private System.Windows.Forms.Label instructions3Label;
    }
}

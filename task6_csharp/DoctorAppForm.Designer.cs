namespace task6_csharp
{
    partial class DoctorAppForm
    {
        private System.ComponentModel.IContainer components = null;

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
            comboBoxTypes = new ComboBox();
            buttonSelectDLL = new Button();
            textBoxFilenameDLL = new TextBox();
            labelSelectedType = new Label();
            textBoxConsole = new TextBox();
            flowLayoutPanelConstructor = new FlowLayoutPanel();
            buttonCreateInstance = new Button();
            flowLayoutPanelMethodParams = new FlowLayoutPanel();
            comboBoxMethods = new ComboBox();
            buttonCallMethod = new Button();
            SuspendLayout();
            // 
            // comboBoxTypes
            // 
            comboBoxTypes.FormattingEnabled = true;
            comboBoxTypes.Location = new Point(12, 70);
            comboBoxTypes.Name = "comboBoxTypes";
            comboBoxTypes.Size = new Size(121, 23);
            comboBoxTypes.TabIndex = 0;
            comboBoxTypes.SelectedIndexChanged += comboBoxTypes_SelectedIndexChanged;
            // 
            // buttonSelectDLL
            // 
            buttonSelectDLL.Location = new Point(12, 12);
            buttonSelectDLL.Name = "buttonSelectDLL";
            buttonSelectDLL.Size = new Size(75, 23);
            buttonSelectDLL.TabIndex = 1;
            buttonSelectDLL.Text = "Select DLL";
            buttonSelectDLL.UseVisualStyleBackColor = true;
            buttonSelectDLL.Click += buttonSelectDLL_Click;
            // 
            // textBoxFilenameDLL
            // 
            textBoxFilenameDLL.Location = new Point(93, 12);
            textBoxFilenameDLL.Name = "textBoxFilenameDLL";
            textBoxFilenameDLL.ReadOnly = true;
            textBoxFilenameDLL.Size = new Size(133, 23);
            textBoxFilenameDLL.TabIndex = 2;
            // 
            // labelSelectedType
            // 
            labelSelectedType.AutoSize = true;
            labelSelectedType.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            labelSelectedType.Location = new Point(12, 113);
            labelSelectedType.Name = "labelSelectedType";
            labelSelectedType.Size = new Size(75, 20);
            labelSelectedType.TabIndex = 3;
            labelSelectedType.Text = "typename";
            // 
            // textBoxConsole
            // 
            textBoxConsole.AcceptsReturn = true;
            textBoxConsole.AcceptsTab = true;
            textBoxConsole.Location = new Point(588, 12);
            textBoxConsole.Multiline = true;
            textBoxConsole.Name = "textBoxConsole";
            textBoxConsole.ReadOnly = true;
            textBoxConsole.ScrollBars = ScrollBars.Both;
            textBoxConsole.Size = new Size(446, 574);
            textBoxConsole.TabIndex = 4;
            // 
            // flowLayoutPanelConstructor
            // 
            flowLayoutPanelConstructor.Location = new Point(12, 136);
            flowLayoutPanelConstructor.Name = "flowLayoutPanelConstructor";
            flowLayoutPanelConstructor.Size = new Size(570, 151);
            flowLayoutPanelConstructor.TabIndex = 5;
            // 
            // buttonCreateInstance
            // 
            buttonCreateInstance.Location = new Point(12, 293);
            buttonCreateInstance.Name = "buttonCreateInstance";
            buttonCreateInstance.Size = new Size(75, 23);
            buttonCreateInstance.TabIndex = 6;
            buttonCreateInstance.Text = "Create instance";
            buttonCreateInstance.UseVisualStyleBackColor = true;
            buttonCreateInstance.Click += buttonCreateInstance_Click;
            // 
            // flowLayoutPanelMethodParams
            // 
            flowLayoutPanelMethodParams.Location = new Point(12, 377);
            flowLayoutPanelMethodParams.Name = "flowLayoutPanelMethodParams";
            flowLayoutPanelMethodParams.Size = new Size(570, 209);
            flowLayoutPanelMethodParams.TabIndex = 7;
            // 
            // comboBoxMethods
            // 
            comboBoxMethods.FormattingEnabled = true;
            comboBoxMethods.Location = new Point(12, 348);
            comboBoxMethods.Name = "comboBoxMethods";
            comboBoxMethods.Size = new Size(121, 23);
            comboBoxMethods.TabIndex = 8;
            comboBoxMethods.SelectedIndexChanged += comboBoxMethods_SelectedIndexChanged;
            // 
            // buttonCallMethod
            // 
            buttonCallMethod.Location = new Point(151, 347);
            buttonCallMethod.Name = "buttonCallMethod";
            buttonCallMethod.Size = new Size(75, 23);
            buttonCallMethod.TabIndex = 9;
            buttonCallMethod.Text = "Call";
            buttonCallMethod.UseVisualStyleBackColor = true;
            buttonCallMethod.Click += buttonCallMethod_Click;
            // 
            // DoctorAppForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1046, 598);
            Controls.Add(buttonCallMethod);
            Controls.Add(comboBoxMethods);
            Controls.Add(flowLayoutPanelMethodParams);
            Controls.Add(buttonCreateInstance);
            Controls.Add(flowLayoutPanelConstructor);
            Controls.Add(textBoxConsole);
            Controls.Add(labelSelectedType);
            Controls.Add(textBoxFilenameDLL);
            Controls.Add(buttonSelectDLL);
            Controls.Add(comboBoxTypes);
            Name = "DoctorAppForm";
            Text = "DoctrorApp";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxTypes;
        private Button buttonSelectDLL;
        private TextBox textBoxFilenameDLL;
        private Label labelSelectedType;
        private TextBox textBoxConsole;
        private FlowLayoutPanel flowLayoutPanelConstructor;
        private Button buttonCreateInstance;
        private FlowLayoutPanel flowLayoutPanelMethodParams;
        private ComboBox comboBoxMethods;
        private Button buttonCallMethod;
    }
}
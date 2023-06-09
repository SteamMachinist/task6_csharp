using System.Reflection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using task6_lib_csharp;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace task6_csharp
{
    public partial class DoctorAppForm : Form
    {
        private List<Type> types = new List<Type>();
        private List<MethodInfo> methods = new List<MethodInfo>();

        Type currentType;
        MethodInfo currentMethod;
        object instance;

        public DoctorAppForm()
        {
            InitializeComponent();

            Console.SetOut(new TextBoxWriter(textBoxConsole));

            textBoxFilenameDLL.Cursor = Cursors.Arrow;
            comboBoxTypes.Enabled = false;
            labelSelectedType.Visible = false;
            flowLayoutPanelConstructor.Enabled = false;
            flowLayoutPanelConstructor.Visible = false;
            buttonCreateInstance.Enabled = false;
            buttonCreateInstance.Visible = false;
            comboBoxMethods.Enabled = false;
            comboBoxMethods.Visible = false;
            buttonCallMethod.Enabled = false;
            buttonCallMethod.Visible = false;
            flowLayoutPanelMethodParams.Enabled = false;
            flowLayoutPanelMethodParams.Visible = false;
            flowLayoutPanelMethodParams.FlowDirection = FlowDirection.TopDown;
        }

        private void buttonSelectDLL_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "DLL files (*.dll)|*.dll";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Assembly assembly = Assembly.LoadFrom(openFileDialog.SafeFileName);
                var typesFromDLL = assembly.GetTypes();
                types.Clear();
                foreach (Type type in typesFromDLL)
                {
                    if (!type.IsInterface && !type.IsAbstract && !type.Name.Contains("Attribute"))
                    {
                        types.Add(type);
                    }
                }
            }
            textBoxFilenameDLL.Text = openFileDialog.SafeFileName;
            UpdateComboBoxTypes();
        }

        private void UpdateComboBoxTypes()
        {
            comboBoxTypes.Items.Clear();
            comboBoxTypes.Enabled = true;
            comboBoxTypes.ResetText();
            comboBoxTypes.SelectedIndex = -1;

            foreach (Type t in types)
            {
                comboBoxTypes.Items.Add(t.Name);
            }
        }

        private void comboBoxTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = comboBoxTypes.Text;
            if (selected == "" || selected == null) return;

            currentType = types.Find((t) => t.Name == selected);

            updateConstructorPanel();
        }

        private void updateConstructorPanel()
        {
            labelSelectedType.Visible = true;
            labelSelectedType.Text = currentType.Name;

            flowLayoutPanelConstructor.Controls.Clear();
            flowLayoutPanelConstructor.Enabled = true;
            flowLayoutPanelConstructor.Visible = true;
            ConstructorInfo ci = currentType.GetConstructors()[0];
            ParameterInfo[] parameters = ci.GetParameters();

            FlowLayoutPanel flowLayoutPanelParamNames = new FlowLayoutPanel();
            flowLayoutPanelParamNames.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelParamNames.WrapContents = false;
            flowLayoutPanelParamNames.AutoSize = true;

            FlowLayoutPanel flowLayoutPanelParamTextBoxes = new FlowLayoutPanel();
            flowLayoutPanelParamTextBoxes.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelParamTextBoxes.WrapContents = false;
            flowLayoutPanelParamTextBoxes.AutoSize = true;

            foreach (ParameterInfo param in parameters)
            {
                Label label = new Label();
                TextBox textBox = new TextBox();
                textBox.Width = 200;
                label.Height = textBox.Height + 8;
                label.Width = (int)(textBox.Width / 1.5);
                label.Text = param.Name;

                flowLayoutPanelParamNames.Controls.Add(label);
                flowLayoutPanelParamTextBoxes.Controls.Add(textBox);
            }
            flowLayoutPanelConstructor.Controls.Add(flowLayoutPanelParamNames);
            flowLayoutPanelConstructor.Controls.Add(flowLayoutPanelParamTextBoxes);

            buttonCreateInstance.Enabled = true;
            buttonCreateInstance.Visible = true;
        }

        private void buttonCreateInstance_Click(object sender, EventArgs e)
        {
            ConstructorInfo ci = currentType.GetConstructors()[0];
            ParameterInfo[] parametersInfo = ci.GetParameters();

            FlowLayoutPanel flowLayoutParams = (FlowLayoutPanel)flowLayoutPanelConstructor.Controls[1];
            Control[] controlsArray = new Control[parametersInfo.Length];
            flowLayoutParams.Controls.CopyTo(controlsArray, 0);
            List<Control> controls = controlsArray.ToList();

            List<Object> parameters = new List<Object>();
            foreach (var (control, paramInfo) in controls.Zip(parametersInfo))
            {
                TextBox textBox = control as TextBox;
                if (textBox == null || textBox.Text == "") return;

                parameters.Add(Convert.ChangeType(textBox.Text, paramInfo.ParameterType));
            }
            instance = Activator.CreateInstance(currentType, parameters.ToArray());

            flowLayoutPanelConstructor.Enabled = false;
            buttonCreateInstance.Enabled = false;

            updateComboBoxMethods();
        }

        private void updateComboBoxMethods()
        {
            methods.Clear();
            foreach (MethodInfo method in currentType.GetMethods())
            {
                methods.Add(method);
            }
            comboBoxMethods.Items.Clear();
            comboBoxMethods.Enabled = true;
            comboBoxMethods.Visible = true;
            comboBoxMethods.ResetText();
            comboBoxMethods.SelectedIndex = -1;

            foreach (MethodInfo methodInfo in methods)
            {
                comboBoxMethods.Items.Add(methodInfo.Name);
            }
        }

        private void comboBoxMethods_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = comboBoxMethods.Text;
            if (selected == "" || selected == null) return;
            currentMethod = methods.Find((m) => m.Name == selected);
            updateMethodPanel();
        }

        private void updateMethodPanel()
        {
            flowLayoutPanelMethodParams.Controls.Clear();
            flowLayoutPanelMethodParams.Enabled = true;
            flowLayoutPanelMethodParams.Visible = true;
            var parameters = currentMethod.GetParameters();
            foreach (ParameterInfo pi in parameters)
            {
                FlowLayoutPanel flowParam = new FlowLayoutPanel();
                flowParam.FlowDirection = FlowDirection.LeftToRight;
                flowParam.WrapContents = false;
                flowParam.AutoSize = true;

                Label label = new Label();
                TextBox textBox = new TextBox();
                textBox.Width = 200;
                label.Height = textBox.Height + 8;
                label.Width = (int)(textBox.Width / 1.5);
                label.Text = pi.Name;

                flowParam.Controls.Add(label);
                flowParam.Controls.Add(textBox);
                flowLayoutPanelMethodParams.Controls.Add(flowParam);
            }
            buttonCallMethod.Enabled = true;
            buttonCallMethod.Visible = true;
        }

        private void buttonCallMethod_Click(object sender, EventArgs e)
        {
            var parameters = currentMethod.GetParameters();
            Control[] paramPanels = new Control[parameters.Length];
            flowLayoutPanelMethodParams.Controls.CopyTo(paramPanels, 0);

            List<Object> parameterValues = new List<object>();
            foreach (var (flowPanel, param) in paramPanels.Zip(parameters))
            {
                FlowLayoutPanel flowLayoutPanel = (FlowLayoutPanel)flowPanel;
                TextBox textBox = (TextBox)flowLayoutPanel.Controls[1];
                if (textBox == null || textBox.Text == "") return;
                parameterValues.Add(Convert.ChangeType(textBox.Text, param.ParameterType));
            }

            Object returned = currentMethod.Invoke(instance, parameterValues.ToArray());
            if (returned != null)
            {
                Console.WriteLine(returned.ToString());
            }
        }
    }
}
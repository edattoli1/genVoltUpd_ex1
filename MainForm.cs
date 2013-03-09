/******************************************************************************
*
* Example program:
*   GenVoltageUpdate
*
* Category:
*   AO
*
* Description:
*   This example demonstrates how to output a single voltage update (sample) to
*   an analog output channel.
*
* Instructions for running:
*   1.  Select the physical channel corresponding to where your signal is output
*       on the DAQ device.
*   2.  Enter the minimum and maximum voltage values.
*
* Steps:
*   1.  Create a new task and an analog output voltage channel.
*   2.  Create a AnalogSingleChannelWriter and call the WriteSingleSample method
*       to output a single sample to your DAQ device.
*   3.  Dispose the Task object to clean-up any resources associated with the
*       task.
*   4.  Handle any DaqExceptions, if they occur.
*
* I/O Connections Overview:
*   Make sure your signal output terminal matches the text in the physical
*   channel text box. In this case the signal will output to the ao0 pin on your
*   DAQ Device.  For more information on the input and output terminals for your
*   device, open the NI-DAQmx Help, and refer to the NI-DAQmx Device Terminals
*   and Device Considerations books in the table of contents.
*
* Microsoft Windows Vista User Account Control
*   Running certain applications on Microsoft Windows Vista requires
*   administrator privileges, 
*   because the application name contains keywords such as setup, update, or
*   install. To avoid this problem, 
*   you must add an additional manifest to the application that specifies the
*   privileges required to run 
*   the application. Some Measurement Studio NI-DAQmx examples for Visual Studio
*   include these keywords. 
*   Therefore, all examples for Visual Studio are shipped with an additional
*   manifest file that you must 
*   embed in the example executable. The manifest file is named
*   [ExampleName].exe.manifest, where [ExampleName] 
*   is the NI-provided example name. For information on how to embed the manifest
*   file, refer to http://msdn2.microsoft.com/en-us/library/bb756929.aspx.Note: 
*   The manifest file is not provided with examples for Visual Studio .NET 2003.
*
******************************************************************************/

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using NationalInstruments.DAQmx;
using System.Windows.Forms.DataVisualization.Charting;


namespace NationalInstruments.Examples.GenVoltageUpdate
{
    /// <summary>
    /// Summary description for MainForm.
    /// </summary>
    public class MainForm : System.Windows.Forms.Form
    {
        public double[] values = { 1, 2 };
        private System.Windows.Forms.Label maximumValueLabel;
        private System.Windows.Forms.Label minimumValueLabel;
        private System.Windows.Forms.Label physicalChannelLabel;
        private System.Windows.Forms.Label voltageOutputLabel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.GroupBox channelParametersGroupBox;
        private System.Windows.Forms.TextBox maximumValue;
        private System.Windows.Forms.TextBox minimumValue;
        private System.Windows.Forms.TextBox voltageOutput;
        private System.Windows.Forms.ComboBox physicalChannelComboBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private IContainer components;

        public MainForm()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            physicalChannelComboBox.Items.AddRange(DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.AO, PhysicalChannelAccess.External));
            if (physicalChannelComboBox.Items.Count > 0)
                physicalChannelComboBox.SelectedIndex = 0;

        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.channelParametersGroupBox = new System.Windows.Forms.GroupBox();
            this.physicalChannelComboBox = new System.Windows.Forms.ComboBox();
            this.maximumValue = new System.Windows.Forms.TextBox();
            this.minimumValue = new System.Windows.Forms.TextBox();
            this.maximumValueLabel = new System.Windows.Forms.Label();
            this.minimumValueLabel = new System.Windows.Forms.Label();
            this.physicalChannelLabel = new System.Windows.Forms.Label();
            this.voltageOutputLabel = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.voltageOutput = new System.Windows.Forms.TextBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.channelParametersGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // channelParametersGroupBox
            // 
            this.channelParametersGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.channelParametersGroupBox.Controls.Add(this.physicalChannelComboBox);
            this.channelParametersGroupBox.Controls.Add(this.maximumValue);
            this.channelParametersGroupBox.Controls.Add(this.minimumValue);
            this.channelParametersGroupBox.Controls.Add(this.maximumValueLabel);
            this.channelParametersGroupBox.Controls.Add(this.minimumValueLabel);
            this.channelParametersGroupBox.Controls.Add(this.physicalChannelLabel);
            this.channelParametersGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.channelParametersGroupBox.Location = new System.Drawing.Point(10, 9);
            this.channelParametersGroupBox.Name = "channelParametersGroupBox";
            this.channelParametersGroupBox.Size = new System.Drawing.Size(541, 148);
            this.channelParametersGroupBox.TabIndex = 0;
            this.channelParametersGroupBox.TabStop = false;
            this.channelParametersGroupBox.Text = "Channel Parameters";
            // 
            // physicalChannelComboBox
            // 
            this.physicalChannelComboBox.Location = new System.Drawing.Point(144, 28);
            this.physicalChannelComboBox.Name = "physicalChannelComboBox";
            this.physicalChannelComboBox.Size = new System.Drawing.Size(101, 24);
            this.physicalChannelComboBox.TabIndex = 1;
            this.physicalChannelComboBox.Text = "Dev1/ao0";
            // 
            // maximumValue
            // 
            this.maximumValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.maximumValue.Location = new System.Drawing.Point(144, 111);
            this.maximumValue.Name = "maximumValue";
            this.maximumValue.ReadOnly = true;
            this.maximumValue.Size = new System.Drawing.Size(211, 22);
            this.maximumValue.TabIndex = 5;
            this.maximumValue.Text = "5";
            // 
            // minimumValue
            // 
            this.minimumValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.minimumValue.Location = new System.Drawing.Point(144, 69);
            this.minimumValue.Name = "minimumValue";
            this.minimumValue.ReadOnly = true;
            this.minimumValue.Size = new System.Drawing.Size(211, 22);
            this.minimumValue.TabIndex = 3;
            this.minimumValue.Text = "0";
            // 
            // maximumValueLabel
            // 
            this.maximumValueLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.maximumValueLabel.Location = new System.Drawing.Point(19, 111);
            this.maximumValueLabel.Name = "maximumValueLabel";
            this.maximumValueLabel.Size = new System.Drawing.Size(135, 18);
            this.maximumValueLabel.TabIndex = 4;
            this.maximumValueLabel.Text = "Maximum Value (V):";
            // 
            // minimumValueLabel
            // 
            this.minimumValueLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.minimumValueLabel.Location = new System.Drawing.Point(19, 72);
            this.minimumValueLabel.Name = "minimumValueLabel";
            this.minimumValueLabel.Size = new System.Drawing.Size(125, 18);
            this.minimumValueLabel.TabIndex = 2;
            this.minimumValueLabel.Text = "Minimum Value (V):";
            // 
            // physicalChannelLabel
            // 
            this.physicalChannelLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.physicalChannelLabel.Location = new System.Drawing.Point(19, 30);
            this.physicalChannelLabel.Name = "physicalChannelLabel";
            this.physicalChannelLabel.Size = new System.Drawing.Size(125, 18);
            this.physicalChannelLabel.TabIndex = 0;
            this.physicalChannelLabel.Text = "Physical Channel:";
            // 
            // voltageOutputLabel
            // 
            this.voltageOutputLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.voltageOutputLabel.Location = new System.Drawing.Point(29, 175);
            this.voltageOutputLabel.Name = "voltageOutputLabel";
            this.voltageOutputLabel.Size = new System.Drawing.Size(125, 19);
            this.voltageOutputLabel.TabIndex = 2;
            this.voltageOutputLabel.Text = "Voltage Output (V):";
            // 
            // startButton
            // 
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.startButton.Location = new System.Drawing.Point(144, 222);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(90, 26);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "&Start";
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // voltageOutput
            // 
            this.voltageOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.voltageOutput.Location = new System.Drawing.Point(154, 175);
            this.voltageOutput.Name = "voltageOutput";
            this.voltageOutput.Size = new System.Drawing.Size(226, 22);
            this.voltageOutput.TabIndex = 3;
            this.voltageOutput.Text = "1";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(65, 285);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.YValueMembers = "0";
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(501, 321);
            this.chart1.TabIndex = 4;
            this.chart1.Text = "chart1";
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(623, 647);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.voltageOutput);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.voltageOutputLabel);
            this.Controls.Add(this.channelParametersGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(720, 800);
            this.MinimumSize = new System.Drawing.Size(307, 295);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generate Voltage Update";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.channelParametersGroupBox.ResumeLayout(false);
            this.channelParametersGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.DoEvents();
            Application.Run(new MainForm());

        }

        private void startButton_Click(object sender, System.EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                using (Task myTask = new Task())
                {
                    myTask.AOChannels.CreateVoltageChannel(physicalChannelComboBox.Text, "aoChannel",
                        Convert.ToDouble(minimumValue.Text), Convert.ToDouble(maximumValue.Text),
                        AOVoltageUnits.Volts);
                    AnalogSingleChannelWriter writer = new AnalogSingleChannelWriter(myTask.Stream);
                    writer.WriteSingleSample(true, Convert.ToDouble(voltageOutput.Text));
                }
            }
            catch (DaqException ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Cursor = Cursors.Default;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Data arrays.
	    int[] seriesArray = {1, 2};
	    int[] pointsArray = { 1, 2 };

	    // Set palette.
	    this.chart1.Palette = ChartColorPalette.SeaGreen;

        

	    // Set title.
	    this.chart1.Titles.Add("Pets");



        chart1.ChartAreas[0].Axes[0].Title = "N";
        chart1.ChartAreas[0].Axes[1].Title = "FIB(N)";
        chart1.Series[0].ChartType = SeriesChartType.Line;
        chart1.Series[0].MarkerStyle = MarkerStyle.Circle;
        chart1.Series[0].LegendText = "Fibonacci numbers";
        Tuple<int,int> t = Tuple.Create(0,1);
            
        for(int i = 1; i <= 30; i++){
          chart1.Series[0].Points.Add(i);
          t = Tuple.Create(t.Item2, t.Item1 + t.Item2);
        }

            /*
	    // Add series.
	    for (int i = 0; i < seriesArray.Length; i++)
	    {
		// Add series.
            Series series = this.chart1.Series.;
            //.Add(seriesArray[i]);

        series.ChartType = SeriesChartType.Point;
        series.Points.

            this.chart1.Series.

		// Add point.
		series.Points.AddY(pointsArray[i]);
	    }
             */
        }
            

    }
}
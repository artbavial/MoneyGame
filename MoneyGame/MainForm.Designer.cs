namespace MoneyGame
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.StackChart = new LiveCharts.WinForms.CartesianChart();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.eventsBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // StackChart
            // 
            this.StackChart.Location = new System.Drawing.Point(270, 12);
            this.StackChart.Name = "StackChart";
            this.StackChart.Size = new System.Drawing.Size(797, 305);
            this.StackChart.TabIndex = 0;
            this.StackChart.Text = "cartesianChart1";
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 3000;
            this.gameTimer.Tick += new System.EventHandler(this.GameTimer);
            // 
            // eventsBox
            // 
            this.eventsBox.Location = new System.Drawing.Point(12, 12);
            this.eventsBox.Name = "eventsBox";
            this.eventsBox.Size = new System.Drawing.Size(252, 545);
            this.eventsBox.TabIndex = 1;
            this.eventsBox.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 569);
            this.Controls.Add(this.eventsBox);
            this.Controls.Add(this.StackChart);
            this.Name = "MainForm";
            this.Text = "Биржа валют. Заработай состояние!";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private LiveCharts.WinForms.CartesianChart StackChart;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.RichTextBox eventsBox;
    }
}


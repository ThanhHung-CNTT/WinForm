
namespace Datagirdview_Sql
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.demoDB_WinformDataSet = new Datagirdview_Sql.DemoDB_WinformDataSet();
            this.demoTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.demoTableTableAdapter = new Datagirdview_Sql.DemoDB_WinformDataSetTableAdapters.DemoTableTableAdapter();
            this.tutorialIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tutorialNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.demoDB_WinformDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.demoTableBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tutorialIDDataGridViewTextBoxColumn,
            this.tutorialNameDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.demoTableBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(35, 148);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(371, 237);
            this.dataGridView1.TabIndex = 0;
            // 
            // demoDB_WinformDataSet
            // 
            this.demoDB_WinformDataSet.DataSetName = "DemoDB_WinformDataSet";
            this.demoDB_WinformDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // demoTableBindingSource
            // 
            this.demoTableBindingSource.DataMember = "DemoTable";
            this.demoTableBindingSource.DataSource = this.demoDB_WinformDataSet;
            // 
            // demoTableTableAdapter
            // 
            this.demoTableTableAdapter.ClearBeforeFill = true;
            // 
            // tutorialIDDataGridViewTextBoxColumn
            // 
            this.tutorialIDDataGridViewTextBoxColumn.DataPropertyName = "TutorialID";
            this.tutorialIDDataGridViewTextBoxColumn.HeaderText = "TutorialID";
            this.tutorialIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.tutorialIDDataGridViewTextBoxColumn.Name = "tutorialIDDataGridViewTextBoxColumn";
            this.tutorialIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // tutorialNameDataGridViewTextBoxColumn
            // 
            this.tutorialNameDataGridViewTextBoxColumn.DataPropertyName = "TutorialName";
            this.tutorialNameDataGridViewTextBoxColumn.HeaderText = "TutorialName";
            this.tutorialNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.tutorialNameDataGridViewTextBoxColumn.Name = "tutorialNameDataGridViewTextBoxColumn";
            this.tutorialNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.demoDB_WinformDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.demoTableBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private DemoDB_WinformDataSet demoDB_WinformDataSet;
        private System.Windows.Forms.BindingSource demoTableBindingSource;
        private DemoDB_WinformDataSetTableAdapters.DemoTableTableAdapter demoTableTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn tutorialIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tutorialNameDataGridViewTextBoxColumn;
    }
}


namespace 驾校
{
    partial class 查看课程时间
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(查看课程时间));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.班级DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.科目DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.日期DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.车辆DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.classBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.testDataSet4 = new 驾校.testDataSet4();
            this.查询 = new System.Windows.Forms.Button();
            this.classTableAdapter = new 驾校.testDataSet1TableAdapters.classTableAdapter();
            this.classTableAdapter1 = new 驾校.testDataSet4TableAdapters.classTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.classBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testDataSet4)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.班级DataGridViewTextBoxColumn,
            this.科目DataGridViewTextBoxColumn,
            this.日期DataGridViewTextBoxColumn,
            this.车辆DataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.classBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(776, 382);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // 班级DataGridViewTextBoxColumn
            // 
            this.班级DataGridViewTextBoxColumn.DataPropertyName = "班级";
            this.班级DataGridViewTextBoxColumn.HeaderText = "班级";
            this.班级DataGridViewTextBoxColumn.MinimumWidth = 6;
            this.班级DataGridViewTextBoxColumn.Name = "班级DataGridViewTextBoxColumn";
            this.班级DataGridViewTextBoxColumn.Width = 125;
            // 
            // 科目DataGridViewTextBoxColumn
            // 
            this.科目DataGridViewTextBoxColumn.DataPropertyName = "科目";
            this.科目DataGridViewTextBoxColumn.HeaderText = "科目";
            this.科目DataGridViewTextBoxColumn.MinimumWidth = 6;
            this.科目DataGridViewTextBoxColumn.Name = "科目DataGridViewTextBoxColumn";
            this.科目DataGridViewTextBoxColumn.Width = 125;
            // 
            // 日期DataGridViewTextBoxColumn
            // 
            this.日期DataGridViewTextBoxColumn.DataPropertyName = "日期";
            this.日期DataGridViewTextBoxColumn.HeaderText = "日期";
            this.日期DataGridViewTextBoxColumn.MinimumWidth = 6;
            this.日期DataGridViewTextBoxColumn.Name = "日期DataGridViewTextBoxColumn";
            this.日期DataGridViewTextBoxColumn.Width = 125;
            // 
            // 车辆DataGridViewTextBoxColumn
            // 
            this.车辆DataGridViewTextBoxColumn.DataPropertyName = "车辆";
            this.车辆DataGridViewTextBoxColumn.HeaderText = "车辆";
            this.车辆DataGridViewTextBoxColumn.MinimumWidth = 6;
            this.车辆DataGridViewTextBoxColumn.Name = "车辆DataGridViewTextBoxColumn";
            this.车辆DataGridViewTextBoxColumn.Width = 125;
            // 
            // classBindingSource
            // 
            this.classBindingSource.DataMember = "class";
            this.classBindingSource.DataSource = this.testDataSet4;
            // 
            // testDataSet4
            // 
            this.testDataSet4.DataSetName = "testDataSet4";
            this.testDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // 查询
            // 
            this.查询.Location = new System.Drawing.Point(361, 400);
            this.查询.Name = "查询";
            this.查询.Size = new System.Drawing.Size(75, 23);
            this.查询.TabIndex = 1;
            this.查询.Text = "查询";
            this.查询.UseVisualStyleBackColor = true;
            this.查询.Click += new System.EventHandler(this.查询_Click);
            // 
            // classTableAdapter
            // 
            this.classTableAdapter.ClearBeforeFill = true;
            // 
            // classTableAdapter1
            // 
            this.classTableAdapter1.ClearBeforeFill = true;
            // 
            // 查看课程时间
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.查询);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "查看课程时间";
            this.Text = "查看课程时间";
            this.Load += new System.EventHandler(this.查看课程时间_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.classBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testDataSet4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button 查询;
        private testDataSet1TableAdapters.classTableAdapter classTableAdapter;
        private testDataSet4 testDataSet4;
        private System.Windows.Forms.BindingSource classBindingSource;
        private testDataSet4TableAdapters.classTableAdapter classTableAdapter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 班级DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 科目DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 日期DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 车辆DataGridViewTextBoxColumn;
    }
}
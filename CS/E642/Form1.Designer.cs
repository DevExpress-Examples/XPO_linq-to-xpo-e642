// Developer Express Code Central Example:
// LINQ to XPO
// 
// LINQ is .NET Language-Integrated Query
// (http://msdn2.microsoft.com/en-us/library/bb308959.aspx). It's included in .NET
// Framework 3.5 and you can use it in Visual Studio 2008 projects.
// XPO officially
// supports LINQ since v7.3. This example provides several sample queries to help
// you get started with LINQ to XPO.
// See
// Also:
// http://www.devexpress.com/scid=K18051
// The LINQ project
// (http://msdn2.microsoft.com/en-us/netframework/aa904594.aspx)
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E642

namespace XpoLinqNorthwindSample {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnSelectWhere = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnAny = new DevExpress.XtraEditors.SimpleButton();
            this.btnGroup = new DevExpress.XtraEditors.SimpleButton();
            this.btnSelectTop = new DevExpress.XtraEditors.SimpleButton();
            this.btnJoin = new DevExpress.XtraEditors.SimpleButton();
            this.btnAggregates = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(135, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(722, 487);
            this.textBox1.TabIndex = 0;
            this.textBox1.WordWrap = false;
            // 
            // btnSelectWhere
            // 
            this.btnSelectWhere.Location = new System.Drawing.Point(5, 34);
            this.btnSelectWhere.Name = "btnSelectWhere";
            this.btnSelectWhere.Size = new System.Drawing.Size(122, 23);
            this.btnSelectWhere.TabIndex = 1;
            this.btnSelectWhere.Text = "&Select With \'Where\'";
            this.btnSelectWhere.Click += new System.EventHandler(this.btnSelectWhere_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(5, 5);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(122, 23);
            this.simpleButton2.TabIndex = 2;
            this.simpleButton2.Text = "&Clear Log";
            this.simpleButton2.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnAny);
            this.panelControl1.Controls.Add(this.btnGroup);
            this.panelControl1.Controls.Add(this.btnSelectTop);
            this.panelControl1.Controls.Add(this.btnJoin);
            this.panelControl1.Controls.Add(this.btnAggregates);
            this.panelControl1.Controls.Add(this.btnSelectWhere);
            this.panelControl1.Controls.Add(this.simpleButton2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(135, 487);
            this.panelControl1.TabIndex = 3;
            // 
            // btnAny
            // 
            this.btnAny.Location = new System.Drawing.Point(5, 182);
            this.btnAny.Name = "btnAny";
            this.btnAny.Size = new System.Drawing.Size(122, 23);
            this.btnAny.TabIndex = 7;
            this.btnAny.Text = "Find An&y";
            this.btnAny.Click += new System.EventHandler(this.btnAny_Click);
            // 
            // btnGroup
            // 
            this.btnGroup.Location = new System.Drawing.Point(5, 152);
            this.btnGroup.Name = "btnGroup";
            this.btnGroup.Size = new System.Drawing.Size(122, 23);
            this.btnGroup.TabIndex = 6;
            this.btnGroup.Text = "&Group By";
            this.btnGroup.Click += new System.EventHandler(this.btnGroup_Click);
            // 
            // btnSelectTop
            // 
            this.btnSelectTop.Location = new System.Drawing.Point(5, 63);
            this.btnSelectTop.Name = "btnSelectTop";
            this.btnSelectTop.Size = new System.Drawing.Size(122, 23);
            this.btnSelectTop.TabIndex = 5;
            this.btnSelectTop.Text = "Select &Top 5";
            this.btnSelectTop.Click += new System.EventHandler(this.btnSelectTop_Click);
            // 
            // btnJoin
            // 
            this.btnJoin.Location = new System.Drawing.Point(5, 93);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.Size = new System.Drawing.Size(122, 23);
            this.btnJoin.TabIndex = 4;
            this.btnJoin.Text = "Group &Join";
            this.btnJoin.Click += new System.EventHandler(this.btnJoin_Click);
            // 
            // btnAggregates
            // 
            this.btnAggregates.Location = new System.Drawing.Point(5, 122);
            this.btnAggregates.Name = "btnAggregates";
            this.btnAggregates.Size = new System.Drawing.Size(122, 23);
            this.btnAggregates.TabIndex = 3;
            this.btnAggregates.Text = "&Aggregates";
            this.btnAggregates.Click += new System.EventHandler(this.btnAggregates_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 487);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panelControl1);
            this.Name = "Form1";
            this.Text = "LINQ to XPO (C#)";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private DevExpress.XtraEditors.SimpleButton btnSelectWhere;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnAggregates;
        private DevExpress.XtraEditors.SimpleButton btnJoin;
        private DevExpress.XtraEditors.SimpleButton btnSelectTop;
        private DevExpress.XtraEditors.SimpleButton btnGroup;
        private DevExpress.XtraEditors.SimpleButton btnAny;
    }
}


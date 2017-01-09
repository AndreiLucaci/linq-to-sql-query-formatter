namespace LinqQueryParser.Win
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
			this.in_query = new ScintillaNET.Scintilla();
			this.out_query = new ScintillaNET.Scintilla();
			this.convert_btn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// in_query
			// 
			this.in_query.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.in_query.Dock = System.Windows.Forms.DockStyle.Top;
			this.in_query.Lexer = ScintillaNET.Lexer.Sql;
			this.in_query.Location = new System.Drawing.Point(0, 0);
			this.in_query.Name = "in_query";
			this.in_query.Size = new System.Drawing.Size(668, 325);
			this.in_query.TabIndex = 0;
			// 
			// out_query
			// 
			this.out_query.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.out_query.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.out_query.Lexer = ScintillaNET.Lexer.Sql;
			this.out_query.Location = new System.Drawing.Point(0, 360);
			this.out_query.Name = "out_query";
			this.out_query.Size = new System.Drawing.Size(668, 305);
			this.out_query.TabIndex = 1;
			// 
			// convert_btn
			// 
			this.convert_btn.Location = new System.Drawing.Point(290, 331);
			this.convert_btn.Name = "convert_btn";
			this.convert_btn.Size = new System.Drawing.Size(75, 23);
			this.convert_btn.TabIndex = 2;
			this.convert_btn.Text = "Convert";
			this.convert_btn.UseVisualStyleBackColor = true;
			this.convert_btn.Click += new System.EventHandler(this.convert_btn_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(668, 665);
			this.Controls.Add(this.convert_btn);
			this.Controls.Add(this.out_query);
			this.Controls.Add(this.in_query);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}

		#endregion

		private ScintillaNET.Scintilla in_query;
		private ScintillaNET.Scintilla out_query;
		private System.Windows.Forms.Button convert_btn;
	}
}


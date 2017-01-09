using System;
using System.Windows.Forms;
using LinqQueryParser.Engine;
using ScintillaNET;

namespace LinqQueryParser.Win
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			in_query.Lexer = out_query.Lexer = Lexer.Sql;
		}

		private void convert_btn_Click(object sender, EventArgs e)
		{
			try
			{
				var engine = new QueryEngineParser();

				var inQueryText = in_query.Text;
				var outQueryText = engine.ParseQuery(inQueryText);

				out_query.Text = outQueryText;
			}
			catch (Exception ex)
			{
				MessageBox.Show(@"Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}

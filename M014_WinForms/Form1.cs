namespace M014_WinForms;

public partial class Form1 : Form
{
	public int Counter = 0;

	public Form1()
	{
		InitializeComponent();
	}

	private void button1_Click(object sender, EventArgs e)
	{
		Counter++;
		label1.Text = Counter.ToString();
	}
}

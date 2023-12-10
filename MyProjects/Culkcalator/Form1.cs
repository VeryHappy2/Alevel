using System.Data;

namespace Culkcalator
{
    public partial class Culcalator : Form
    {
        
        public Culcalator()
        {
            InitializeComponent();
        }
        private static List<string> _userList = new List<string>();
        private void Num1(object sender, EventArgs e) 
        {
            textBox.Text += "1";
            _userList.Add("1");
        }

        private void Num6(object sender, EventArgs e)
        {
            textBox.Text += "6";
            _userList.Add("6");
        }

        private void Num9(object sender, EventArgs e)
        {
            textBox.Text += "9";
            _userList.Add("9");
        }

        private void Num4(object sender, EventArgs e)
        {
            textBox.Text += "4";
            _userList.Add("4");
        }

        private void Num8(object sender, EventArgs e)
        {
            textBox.Text += "8";
            _userList.Add("8");
        }

        private void Num0(object sender, EventArgs e)
        {
            textBox.Text += "0";
            _userList.Add("0");
        }
        private void Num2(object sender, EventArgs e)
        {
            textBox.Text += "2";
            _userList.Add("2");
        }
        private void Num3(object sender, EventArgs e)
        {
            textBox.Text += "3";
            _userList.Add("3");
        }
        private void Num5(object sender, EventArgs e)
        {
            textBox.Text += "5";
            _userList.Add("5");
        }
        private void Num7(object sender, EventArgs e)
        {
            textBox.Text += "7";
            _userList.Add("7");
        }
        private void Num10(object sender, EventArgs e)
        {
            textBox.Text += "10";
            _userList.Add("10");
        }
        private void OperatorPlus(object sender, EventArgs e)
        {
            textBox.Text += "+";
            _userList.Add("+");
        }
        private void OperatorMultiplication(object sender, EventArgs e)
        {
            textBox.Text += "*";
            _userList.Add("*");
        }

        private void OperatorMinus(object sender, EventArgs e)
        {
            textBox.Text += "-";
            _userList.Add("-");
        }

        private void OperatorDivision(object sender, EventArgs e)
        {
            textBox.Text += "/";
            _userList.Add("/");
        }
        private void TextBox(object sender, EventArgs e)
        {

        }

        private void Result(object sender, EventArgs e) 
        {
            try
            {
                string expression = string.Join("", _userList);
                var dataTable = new DataTable();
                var result = dataTable.Compute(expression, "");
                textBox.Text = result.ToString();
                _userList.Clear();
            }
            catch 
            {
                textBox.Text = "Error";
                _userList.Clear();
            }            
        }

        private void TextBoxClear(object sender, EventArgs e)
        {
            textBox.Clear();
            _userList.Clear();
        }
        

    }
}

using System.Data;

namespace Culkcalator
{
    public partial class Culcalator : Form
    {
        private static List<object> _userList = new List<object>();
        public Culcalator()
        {
            InitializeComponent();
        }

        private void Num1(object sender, EventArgs e)
        {
            CheckingWordError();
            textBox.Text += "1";
            _userList.Add("1");
        }

        private void Num6(object sender, EventArgs e)
        {
            CheckingWordError();
            textBox.Text += "6";
            _userList.Add("6");
        }

        private void Num9(object sender, EventArgs e)
        {
            CheckingWordError();
            textBox.Text += "9";
            _userList.Add("9");
        }

        private void Num4(object sender, EventArgs e)
        {
            CheckingWordError();
            textBox.Text += "4";
            _userList.Add("4");
        }

        private void Num8(object sender, EventArgs e)
        {
            CheckingWordError();
            textBox.Text += "8";
            _userList.Add("8");
        }

        private void Num0(object sender, EventArgs e)
        {
            CheckingWordError();
            textBox.Text += "0";
            _userList.Add("0");
        }
        private void Num2(object sender, EventArgs e)
        {
            CheckingWordError();
            textBox.Text += "2";
            _userList.Add("2");
        }
        private void Num3(object sender, EventArgs e)
        {
            CheckingWordError();
            textBox.Text += "3";
            _userList.Add("3");
        }
        private void Num5(object sender, EventArgs e)
        {
            CheckingWordError();
            textBox.Text += "5";
            _userList.Add("5");
        }
        private void Num7(object sender, EventArgs e)
        {
            CheckingWordError();
            textBox.Text += "7";
            _userList.Add("7");
        }
        private void Num10(object sender, EventArgs e)
        {
            CheckingWordError();
            textBox.Text += "10";
            _userList.Add("10");
        }
        private void OperatorPlus(object sender, EventArgs e)
        {
            CheckingWordError();
            textBox.Text += "+";
            _userList.Add("+");
        }
        private void OperatorMultiplication(object sender, EventArgs e)
        {
            CheckingWordError();
            textBox.Text += "*";
            _userList.Add("*");
        }

        private void OperatorMinus(object sender, EventArgs e)
        {
            CheckingWordError();
            textBox.Text += "-";
            _userList.Add("-");
        }

        private void OperatorDivision(object sender, EventArgs e)
        {
            CheckingWordError();
            textBox.Text += "/";
            _userList.Add("/");
        }
        private bool ContainsLetters(string text)
        {
            return text.Any(char.IsLetter);
        }

        private void Result(object sender, EventArgs e)
        {
            try
            {
                if(ContainsLetters(textBox.Text)) 
                {
                    textBox.Text = "Error";

                }
                else
                {
                    string expression = string.Join("", _userList);
                    var dataTable = new DataTable();
                    if (IsValidExpression(expression))
                    {
                        var result = dataTable.Compute(expression, "");
                        double numericResult = Convert.ToInt32(result);
                        var roundResult = Math.Round(numericResult);
                        textBox.Text = roundResult.ToString();
                        _userList.Clear();
                        _userList.Add(roundResult.ToString());
                    }
                    else
                    {
                        textBox.Text = "Error";
                        _userList.Clear();
                    }
                }
                

            }
            catch
            {
                textBox.Text = "Error";
                _userList.Clear();
            }
        }

        private bool IsValidExpression(string expression)
        {
            return expression.Any(char.IsDigit) && !string.IsNullOrWhiteSpace(expression);

        }

        private void CheckingWordError()
        {
            if (textBox.Text == "Error")
            {
                textBox.Clear();
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

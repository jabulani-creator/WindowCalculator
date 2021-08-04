using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace windowsCalculator
{
    public partial class Calculator : Form
    {
        Double Result_value = 0;
        Double Second_value = 0;
        string Operation_performed = "";
       string Full_operation = "";
        bool Is_operation_performed = false;
        bool Is_history_clicked = false;
        public Calculator()
        {
            InitializeComponent();
        }

        private void Button_click(object sender, EventArgs e)
        {
            if ((Results_output.Text == "0") || (Is_operation_performed))
            {
                Results_output.Clear();
            }
            Is_operation_performed = false;
            Button button = (Button)sender;
            if (button.Text == ".")
            {
                if (!Results_output.Text.Contains("."))
                {
                    Results_output.Text += button.Text;
                }

            }
            else
            {
                Results_output.Text += button.Text;
            }

        }

        private void Basic_operation(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if(Result_value != 0)
            {
                Equal_btn.PerformClick();
                Operation_performed = button.Text;
                Current_operation.Text = $"{Result_value} {Operation_performed}";
                Is_operation_performed = true;

            }
            else
            {
                Operation_performed = button.Text;
                Result_value = double.Parse(Results_output.Text);
                Current_operation.Text = $"{Result_value} {Operation_performed}";
                Is_operation_performed = true;
            }

            
            switch (Operation_performed)
            {
                case "²√ x":
                    Current_operation.Text = $"√( {Result_value} )";
                    Result_value = Math.Sqrt(Result_value);
                    break;
                case "x²":
                    Current_operation.Text = $"sqr( {Result_value} )";
                    Result_value = Math.Pow(Result_value, 2);
                    break;
                /*case "%":
                        Result_value /= 100;
                        Current_operation.Text = $"{Result_value}";
                    break;*/
                default:
                    break;


            }

            Results_output.Text = Result_value.ToString();
            Full_operation = Current_operation.Text;


        }

           
            

        private void Clear_entry_Click(object sender, EventArgs e)
        {
            Results_output.Text = "0";
        }

        private void Clear_btn_Click(object sender, EventArgs e)
        {
            Results_output.Text = "0";
            Current_operation.Text = " ";
            Result_value = 0;
        }
        
        private void Equal_btn_Click(object sender, EventArgs e)
        {
             Second_value = Double.Parse(Results_output.Text);
            switch (Operation_performed)
            {
                case "+":
                    Results_output.Text = (Result_value + Double.Parse(Results_output.Text)).ToString();
                    break;
                case "-":
                    Results_output.Text = (Result_value - Double.Parse(Results_output.Text)).ToString();
                    break;
                case "÷":
                    Results_output.Text = (Result_value / Double.Parse(Results_output.Text)).ToString();
                    break;
                case "×":
                    Results_output.Text = (Result_value * Double.Parse(Results_output.Text)).ToString();
                    break;
                default:
                    break; 
            }
           
            Result_value = Double.Parse(Results_output.Text);
                Current_operation.Text = $"{Full_operation} {Second_value} = ";
            
            
         
            //Current_operation.Text = $"";


        }

        private void Backspace_Click(object sender, EventArgs e)
        {
            int index = Results_output.Text.Length;
            index--;
            Results_output.Text = Results_output.Text.Remove(index);

            if(Results_output.Text == "") 
            { 
                Results_output.Text = "0";
            }
        }

       /* private void Percentage_Operation(object sender, EventArgs e)

        {
            if (results_Box.Text.Length > 0 || results_Box.Text == "")
            {
                results_Box.Text = "0";
                current_Operation.Text = "0";
            }
            else
            {
                resultValue = Double.Parse(results_Box.Text);
                results_Box.Text = (resultValue /= 100).ToString();
                current_Operation.Text = $"{resultValue}";
                equal_Btn.PerformClick();
            }
        }*/
        private void Plus_minus_Click(object sender, EventArgs e)
        {
            Result_value = Double.Parse(Results_output.Text);
            Result_value *= -1;
            Results_output.Text = Result_value.ToString();
        }
        private void Divided_by_1_Click(object sender, EventArgs e)
        {
            Result_value = Double.Parse(Results_output.Text);
            Current_operation.Text = $"1 /( {Result_value} )";
            Result_value = (1 / Result_value);
            Results_output.Text = Result_value.ToString();
        }



        /* private void Square_root_Click(object sender, EventArgs e)
         {
             resultValue = Double.Parse(results_Box.Text);
             current_Operation.Text = $"√( {resultValue} )";
             resultValue = Math.Sqrt(resultValue);
             results_Box.Text = resultValue.ToString();

         }

         private void power_of_2_Click(object sender, EventArgs e)
         {
             resultValue = Double.Parse(results_Box.Text);
             current_Operation.Text = $"sqr( {resultValue} )";
             resultValue = Math.Pow(resultValue, 2);
             results_Box.Text = resultValue.ToString();

         }

         private void divided_by_1_Click(object sender, EventArgs e)
         {
             resultValue = Double.Parse(results_Box.Text);
             current_Operation.Text = $"1 /( {resultValue} )";
             resultValue = (1 / resultValue); 
             results_Box.Text = resultValue.ToString();
         }

         private void plus_minus_Click(object sender, EventArgs e)
         {
             resultValue = Double.Parse(results_Box.Text);
             resultValue *= -1;
             results_Box.Text = resultValue.ToString();
         }*/

        private void Percentage_btn_Click(object sender, EventArgs e)
         {
            Result_value = Double.Parse(Results_output.Text);
            Result_value /= 100;
            Current_operation.Text = $"{Result_value}";
            Results_output.Text = Result_value.ToString();

         }

        /*private void Calculator_Load(object sender, EventArgs e)
        {
            Memory.Visible = false;
        }

        private void History_Click(object sender, EventArgs e)
        {
            if (Is_history_clicked) { Memory.Visible = true; } 
            else{ Memory.Visible = false; }
               
               


        }*/

  
    }
}

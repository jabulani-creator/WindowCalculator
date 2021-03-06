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
                    Current_operation.Text = $"√( {Result_value})";
                    Result_value = Math.Sqrt(Result_value);
                    break;
                case "x²":
                    Current_operation.Text = $"sqr( {Result_value})";
                    Result_value = Math.Pow(Result_value, 2);
                    break;
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

 

        private void Percentage_btn_Click(object sender, EventArgs e)
         {
            Result_value = Double.Parse(Results_output.Text);
            Result_value /= 100;
            Current_operation.Text = $"{Result_value}";
            Results_output.Text = Result_value.ToString();

         }


  
    }
}

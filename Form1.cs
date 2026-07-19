using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizza_Project
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
       void UpdateSize()
        {
            UpdateTotalPrice();
            if (rbSmall.Checked)
            {
                lbSize.Text = "Small";
                return;
            }
            else if (rbMedium.Checked)
            {
                lbSize.Text = "Medium";
                return;
            }
            else
            {
                lbSize.Text = "Large";
                return;

            }

        }
        float CalclateuToppingsPrice()

        {
            float totalToppings = 0;
            if (chkExtraChees.Checked)
            {
                totalToppings += Convert.ToSingle(chkExtraChees.Tag);
            }
             if (chkGreenPappers.Checked)
            {
                totalToppings += Convert.ToSingle(chkGreenPappers.Tag);
            }
             if (chkOlives.Checked)
            {
                totalToppings += Convert.ToSingle(chkOlives.Tag);

            }
             if (chkOnion.Checked)
            {
                totalToppings += Convert.ToSingle(chkOnion.Tag);
            }
             if (chkTomatoes.Checked)
            {
                totalToppings += Convert.ToSingle(chkTomatoes.Tag);
            }
             if (chkMushrooms.Checked)
            {
                totalToppings += Convert.ToSingle(chkMushrooms.Tag);
            }


                return totalToppings;
        }
        float GetSelectedCrustPrice()
        {
            if (rbThin.Checked)
            
                return Convert.ToSingle(rbThin.Tag);
            else
            
                return Convert.ToSingle(rbThink.Tag);
            
        }
        float GetSelectedSizePrice()
        {
            if (rbSmall.Checked)
                return Convert.ToSingle(rbSmall.Tag);

            else if (rbMedium.Checked)
                return Convert.ToSingle(rbMedium.Tag);
            
            else
                return Convert.ToSingle(rbLarge.Tag);
            
        }
        float GetSlectedHowManyPizza()
        {
            return  (float)numericUpDown1.Value;
        }
        float CalclateuTotalPrice()
        {

            return (GetSelectedSizePrice() + CalclateuToppingsPrice() + GetSelectedCrustPrice()) * GetSlectedHowManyPizza() ;

        }
        void UpdateTotalPrice()
        {
            lbTotalPrice.Text = "$"+ CalclateuTotalPrice().ToString() ;
        }
       void UpdateCrust()
        {
            UpdateTotalPrice();
            if (rbThin.Checked)
            {
                lbCrustType.Text = "Thin";
                return;
            }
            if(rbThink.Checked)
            {
                lbCrustType.Text = "Think";
                return;
            }
            
        }
        void UpdateToppings()
        {
            UpdateTotalPrice();
            string sTopping = "";
            if (chkExtraChees.Checked)
            {
                sTopping= "Extra Chees";
            }
            if (chkMushrooms.Checked)
            {
                sTopping += ", Mushrooms";
            }
            if (chkTomatoes.Checked)
            {
                sTopping += ", Tomatoes\n";
            }
            if (chkOnion.Checked)
            {
                sTopping += ", Onion";
            }

            if (chkOlives.Checked)
            {
                sTopping += ", Olives";
            }
            if (chkGreenPappers.Checked)
            {
                sTopping += ", Green Pappers";
            }
          
            
           
            if (sTopping.StartsWith(","))
            {
                sTopping = sTopping.Substring(1, sTopping.Length - 1).Trim();
            }
            if (sTopping == "")
            {
                sTopping = "No Toppings";

            }
            lbToppings.Text = sTopping;
        }
        void UpdateWhereToEat()
        {
            if (rbEatIn.Checked)
            {
                lbWhereToEat.Text = "Eat In";
                return;
            }
            if (rbTakeOut.Checked)
            {
                lbWhereToEat.Text = "Take Out";
                return;

            }
        }
        void ResetForm()
        {
            gbSize.Enabled = true;
            gbToppings.Enabled = true;
            gbCrustType.Enabled = true;
            gbWhereToEat.Enabled = true;
            btnOrderPizza.Enabled = true;
            numericUpDown1.Value = 0;
            rbMedium.Checked = true;

            chkExtraChees.Checked = false;
            chkMushrooms.Checked = false;
            chkGreenPappers.Checked = false;
            chkOlives.Checked = false;
            chkOnion.Checked = false;
            chkTomatoes.Checked = false;

            rbThin.Checked = true;

            rbEatIn.Checked = true;

            btnOrderPizza.Enabled = true;

        }
        void UpdateOrderSummary()
        {
            UpdateSize();
            UpdateCrust();
            UpdateToppings();
            UpdateTotalPrice();
            UpdateWhereToEat();

        }


        private void btnOrderPizza_Click(object sender, EventArgs e)
        {
           if( MessageBox.Show("Confirm Order", "Confirm", MessageBoxButtons.OKCancel,MessageBoxIcon.Question)==DialogResult.OK)
            {
                MessageBox.Show("Order Placed SuccessFully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gbSize.Enabled = false;
                gbToppings.Enabled = false;
                gbCrustType.Enabled = false;
                gbWhereToEat.Enabled = false;
                btnOrderPizza.Enabled = false;
                    
            }
            else
            {
                MessageBox.Show("Update Your Order", "Update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void rbSmall_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbMedium_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();

        }

        private void rbLarge_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void gbCrustType_Enter(object sender, EventArgs e)
        {

        }

        private void rbThin_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrust();

        }

        private void rbThink_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrust();

        }

        private void chkExtraChees_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkMushrooms_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkTomatoes_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkOnion_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkOlives_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkGreenPappers_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void rbEatIn_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        private void rbTakeOut_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        private void btnResetForm_Click(object sender, EventArgs e)
        {
            ResetForm();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ResetForm();

            UpdateOrderSummary();
            
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Yahtzee
{
    public partial class Form1 : Form
    {

        private Dices<int> dices;
        private IRandom randomness;

       

        public Form1(IRandom randomness)
        {
            InitializeComponent();
            this.randomness = randomness;
            IntEquality equality = new IntEquality();
            dices = Dices<int>.Build(equality); 

            for(int id = 0; id <= 6; id++)
            {
                var dice = Dice<int>.Build(id, 6, 1, false);
                dices.AddDice(dice); 
            }
           
        }

        private void checkBox_dice_1_in_cup_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox_dice_1_in_cup.Checked)
            {
                dices.MoveToCup(1);
            } 
       
        }

        private void checkBox_dice_2_in_cup_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox_dice_2_in_cup.Checked)
            {
                dices.MoveToCup(2);
            }
            
        }

        private void checkBox_dice_3_in_cup_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox_dice_3_in_cup.Checked)
            {
                dices.MoveToCup(3);
            }
        }

        private void checkBox_dice_4_in_cup_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox_dice_4_in_cup.Checked)
            {
                dices.MoveToCup(4);
            }
        }

        private void checkBox_dice_5_in_cup_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox_dice_5_in_cup.Checked)
            {
                dices.MoveToCup(5);
            }
        }

        private void checkBox_dice_6_in_cup_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox_dice_6_in_cup.Checked)
            {
                dices.MoveToCup(6); 
            }
        }

        private void btnRoll_Click(object sender, EventArgs e)
        {
            dices.Roll(randomness);
            label1.Text = dices.TopOf(1);
            label2.Text = dices.TopOf(2);
            label3.Text = dices.TopOf(3);
            label4.Text = dices.TopOf(4);
            label5.Text = dices.TopOf(5);
            label6.Text = dices.TopOf(6); 
        }
    }
}

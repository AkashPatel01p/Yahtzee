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

        private PointFormula calcAces;
        private PointFormula calcTwos;
        private PointFormula calcThrees;
        private PointFormula calcFours;
        private PointFormula calcFives;
        private PointFormula calcSixes;

        private PointFormula calcThreeOfKind;
        private PointFormula calcFourOfKind;
        private PointFormula calcFullHouse;
        private PointFormula calcSmallStraight;
        private PointFormula calcLargeStraight;
        private PointFormula calcYahzee;
        private PointFormula calcChance;
       

        public Form1(IRandom randomness)
        {
            InitializeComponent();
            this.randomness = randomness;
            var equality =  IntEqualityByLiteral.Build();
            dices = Dices<int>.Build(equality); 

            for(int id = 0; id <= 6; id++)
            {
                var dice = Dice<int>.Build(id, 6, 1, false);
                dices.AddDice(dice); 
            }

            calcAces = Aces.Build();
            calcTwos = Twos.Build();
            calcThrees = Threes.Build();
            calcFours = Fours.Build();
            calcFives = Fives.Build();
            calcSixes = Sixes.Build();

            calcThreeOfKind = ThreeOfKind.Build();
            calcFourOfKind = FourOfKind.Build();
            calcFullHouse = FullHouse.Build();
            calcSmallStraight = SmallStraight.Build();
            calcLargeStraight = LargeStraight.Build();
            calcYahzee = Yahtzee.Build();
            calcChance = Chance.Build();
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
            DisplayDicesTopFaces();
            IndicateDiceAreNotInCup();

        }

        private void IndicateDiceAreNotInCup()
        {
            checkBox_dice_1_in_cup.Checked = false;
            checkBox_dice_2_in_cup.Checked = false;
            checkBox_dice_3_in_cup.Checked = false;
            checkBox_dice_4_in_cup.Checked = false;
            checkBox_dice_5_in_cup.Checked = false;
            checkBox_dice_6_in_cup.Checked = false;
        }

        private void DisplayDicesTopFaces()
        {
            label1.Text = dices.TopOf(1);
            label2.Text = dices.TopOf(2);
            label3.Text = dices.TopOf(3);
            label4.Text = dices.TopOf(4);
            label5.Text = dices.TopOf(5);
            label6.Text = dices.TopOf(6);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        

        private void btnTwos_Click(object sender, EventArgs e)
        {
            
             
            btnTwos.Enabled = false; 
        }

        private void btnThrees_Click(object sender, EventArgs e)
        {
            btnThrees.Enabled = false; 
        }

        private void btnFours_Click(object sender, EventArgs e)
        {
            btnFours.Enabled = false; 
        }

        private void btnFives_Click(object sender, EventArgs e)
        {
            btnFives.Enabled = false; 
        }

        private void btnSixes_Click(object sender, EventArgs e)
        {
            btnSixes.Enabled = false; 
        }

        private void btnThreeOfKind_Click(object sender, EventArgs e)
        {
            btnThreeOfKind.Enabled = false; 
        }

        private void btnFourOfKind_Click(object sender, EventArgs e)
        {
            btnFourOfKind.Enabled = false; 
        }

        private void btnFullHouse_Click(object sender, EventArgs e)
        {
            btnFullHouse.Enabled = false;
        }

        private void btnSmallStraight_Click(object sender, EventArgs e)
        {
            btnSmallStraight.Enabled = false; 
        }

        private void btnLargeStraight_Click(object sender, EventArgs e)
        {
            btnLargeStraight.Enabled = false; 
        }

        private void btnYhatzee_Click(object sender, EventArgs e)
        {
            btnYhatzee.Enabled = false; 
        }

        private void btnChance_Click(object sender, EventArgs e)
        {
            btnChance.Enabled = false; 
        }

        private void btnCalculatePossibleScores_Click(object sender, EventArgs e)
        {
            AmountOfItems<int> frequncy = DiceFrequncy();
            if(btnTwos.Enabled)
            {
                labelTwos.Text = $"{calcTwos.PointsFor(frequncy)}";
            }
            if(btnThrees.Enabled)
            {
                labelThrees.Text = $"{calcThrees.PointsFor(frequncy)}";
            }
            if(btnFours.Enabled)
            {
                labelFours.Text = $"{calcFours.PointsFor(frequncy)}";
            }
            if(btnFives.Enabled)
            {
                labelFives.Text = $"{calcFives.PointsFor(frequncy)}";
            }
            if(btnSixes.Enabled)
            {
                labelSixes.Text = $"{calcSixes.PointsFor(frequncy)}";
            }
            

            if(btnThreeOfKind.Enabled)
            {
                labelThreeOfKind.Text = $"{calcThreeOfKind.PointsFor(frequncy)}";
            }
            if(btnFourOfKind.Enabled)
            {
                labelFourOfKind.Text = $"{calcFourOfKind.PointsFor(frequncy)}";
            }
            if(btnFullHouse.Enabled)
            {
                labelFullHouse.Text = $"{calcFullHouse.PointsFor(frequncy)}";
            }
            if(btnSmallStraight.Enabled)
            {
                labelSmallStraight.Text = $"{calcSmallStraight.PointsFor(frequncy)}";
            }
            if(btnLargeStraight.Enabled)
            {
                labelLargeStraight.Text = $"{calcLargeStraight.PointsFor(frequncy)}";
            }
            if(btnYhatzee.Enabled)
            {
                labelYatzee.Text = $"{calcYahzee.PointsFor(frequncy)}";
            }
            if(btnChance.Enabled)
            {
                labelChance.Text = $"{calcChance.PointsFor(frequncy)}";
            }
            
        }

        //has to come from form
        // very hard to connect two containers 
        private AmountOfItems<int> DiceFrequncy()
        {
            List<int> numbers = new List<int>();
            numbers.Add(int.Parse(label1.Text));
            numbers.Add(int.Parse(label2.Text));
            numbers.Add(int.Parse(label3.Text));
            numbers.Add(int.Parse(label4.Text));
            numbers.Add(int.Parse(label5.Text));
            numbers.Add(int.Parse(label6.Text));

            AmountOfItems<int> items = ListBackedAmountOfItems<int>.Build(numbers);
            return items;
        }
    }
}

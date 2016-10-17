/// Created by Reid Ball
/// October 14, 2016
/// Acts like online shop, you enter the amount of desired product and then it can caluculate the
/// total and the change from the money given
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace storecalculatorsummative
{
    public partial class Form1 : Form
    {
        //declaring all the variables needed
        const double staplePrice = 0.05;
        const double pencilPrice = 0.5;
        const double penPrice = 0.75;
        const double paperPrice = 0.1;
        const double eraserPrice = 0.6;
        const double rulerPrice = 1;
        const double calculatorPrice = 2;
        const double tax = 0.13;
        int stapleAmount;
        int pencilAmount;
        int penAmount;
        int paperAmount;
        int eraserAmount;
        int rulerAmount;
        int calculatorAmount;
        double stapleTotal;
        double pencilTotal;
        double penTotal;
        double paperTotal;
        double eraserTotal;
        double rulerTotal;
        double calculatorTotal;
        double total;
        double subtotal;
        double cashTendered;
        double taxTotal;
        double change;

        public Form1()
        {
            InitializeComponent();
        }

        private void totalButton_Click(object sender, EventArgs e)
        {
            try
            {
                //getting inputs
                stapleAmount = Convert.ToInt32(stapleTextBox.Text);
                pencilAmount = Convert.ToInt32(pencilTextBox.Text);
                penAmount = Convert.ToInt32(penTextBox.Text);
                paperAmount = Convert.ToInt32(paperTextBox.Text);
                eraserAmount = Convert.ToInt32(eraserTextBox.Text);
                rulerAmount = Convert.ToInt32(rulerTextBox.Text);
                calculatorAmount = Convert.ToInt32(calculatorTextBox.Text);

                //calc totals
                stapleTotal = stapleAmount * staplePrice;
                pencilTotal = pencilAmount * pencilPrice;
                penTotal = penAmount * penPrice;
                paperTotal = paperAmount * paperPrice;
                eraserTotal = eraserAmount * eraserPrice;
                rulerTotal = rulerAmount * rulerPrice;
                calculatorTotal = calculatorAmount * calculatorPrice;
                subtotal = stapleTotal + pencilTotal + penTotal + paperTotal
                    + eraserTotal + rulerTotal + calculatorTotal;
                taxTotal = subtotal * tax;
                total = taxTotal + subtotal;

                //displaying the totals 
                subTotalOutputLabel.Text = subtotal.ToString("C");
                taxOutputLabel.Text = taxTotal.ToString("C");
                totalOutputLabel.Text = total.ToString("C");

                //gets rid of label text if all totals have been entered correctly
                productTrayAndCatchLabel.Text = "";
            }
            catch
            {
                productTrayAndCatchLabel.Text = "Please enter a " + "\nnumerical value for " + "\neach item";
            }

        }

        private void tenderedButton_Click(object sender, EventArgs e)
        {
            try
            {
                //takes the tendered money and subtracts the total to calculate the change
                cashTendered = Convert.ToDouble(tenderedTextBox.Text);
                change = cashTendered - total;
                changeOutputLabel.Text = change.ToString("C");
                changeTryCatchLabel.Text = "";
            }
            catch
            {
                changeTryCatchLabel.Text = "Please enter the amount " + "\nof money tendered in numerical form.";
            }
        }

        private void receiptButton_Click(object sender, EventArgs e)
        {
            //generates a graphics and draws receipt to right side of program
            Graphics receiptGraphics = innerBox2Label.CreateGraphics();
            SolidBrush receiptBrush = new SolidBrush(Color.Black);
            Font receiptFont = new Font("Courier New", 9, FontStyle.Bold);
            receiptGraphics.DrawString("Staple Small Business Outlet", receiptFont, receiptBrush, 0, 70);
            Thread.Sleep(200); 
            receiptGraphics.DrawString("Staples x " + stapleAmount.ToString()
                + " = " + stapleTotal.ToString("C"), receiptFont, receiptBrush, 35, 90);
            Thread.Sleep(200);
            receiptGraphics.DrawString("Pencil x " + pencilAmount.ToString() + " = " + stapleTotal.ToString("C"),
                receiptFont, receiptBrush, 35, 105);
            Thread.Sleep(200);
            receiptGraphics.DrawString("Pen x " + penAmount.ToString() + " = " + penTotal.ToString("C"),
                receiptFont, receiptBrush, 35, 120);
            Thread.Sleep(200);
            receiptGraphics.DrawString("Paper x " + paperAmount.ToString() + " = " + paperTotal.ToString("C"),
                receiptFont, receiptBrush, 35, 135);
            Thread.Sleep(200);
            receiptGraphics.DrawString("Eraser x " + eraserAmount.ToString() + " = " + eraserTotal.ToString("C"),
                receiptFont, receiptBrush, 35, 150);
            Thread.Sleep(200);
            receiptGraphics.DrawString("Ruler x " + rulerAmount.ToString() + " = " + rulerTotal.ToString("C"),
                receiptFont, receiptBrush, 35, 165);
            Thread.Sleep(200);
            receiptGraphics.DrawString("Calculator x " + calculatorAmount.ToString() + " = " + calculatorTotal.ToString("C"),
                receiptFont, receiptBrush, 35, 180);
            Thread.Sleep(200);
            receiptGraphics.DrawString("Subtotal = " + subtotal.ToString("C"), receiptFont, receiptBrush, 35, 220);
            Thread.Sleep(200);
            receiptGraphics.DrawString("Tax = " + taxTotal.ToString("C"), receiptFont, receiptBrush, 35, 235);
            Thread.Sleep(200);
            receiptGraphics.DrawString("Total = " + total.ToString("C"), receiptFont, receiptBrush, 35, 250);
            Thread.Sleep(200);
            receiptGraphics.DrawString("Cash Tendered = " + cashTendered.ToString("C"), receiptFont, receiptBrush, 35, 290);
            Thread.Sleep(200);
            receiptGraphics.DrawString("Change = " + change.ToString("C"), receiptFont, receiptBrush, 35, 305);
            Thread.Sleep(200);
            receiptGraphics.DrawString("Thanks for Shopping", receiptFont, receiptBrush, 35, 345);
            Thread.Sleep(200);
            receiptGraphics.DrawString("At Staple!", receiptFont, receiptBrush, 35, 355);
            Thread.Sleep(200); 
            receiptGraphics.DrawString("Have a Nice Day", receiptFont, receiptBrush, 35, 365);
            Thread.Sleep(200);
            receiptGraphics.DrawString("and Come Again!", receiptFont, receiptBrush, 35, 375); 
        }

        private void newOrderButton_Click(object sender, EventArgs e)
        {
            //clears everytextbox, variables, and the receipt
            Graphics clearingtGraphics = innerBox2Label.CreateGraphics();
            clearingtGraphics.Clear(Color.White);
            subTotalOutputLabel.Text = "";
            taxOutputLabel.Text = "";
            totalOutputLabel.Text = "";
            changeOutputLabel.Text = "";
            changeOutputLabel.Text = "";
            stapleTextBox.Text = "";
            pencilTextBox.Text = "";
            penTextBox.Text = "";
            paperTextBox.Text = "";
            eraserTextBox.Text = "";
            rulerTextBox.Text = "";
            calculatorTextBox.Text = "";
            tenderedTextBox.Text = "";
            stapleAmount = 0;
            pencilAmount = 0;
            penAmount = 0;
            paperAmount = 0;
            eraserAmount = 0;
            rulerAmount = 0;
            calculatorAmount = 0;
            stapleTotal = 0;
            pencilTotal = 0;
            penTotal = 0;
            paperTotal = 0;
            eraserTotal = 0;
            rulerTotal = 0;
            calculatorTotal = 0;
            total = 0;
            subtotal = 0;
            cashTendered = 0;
            taxTotal = 0;
            change = 0;
        }
    }
} 

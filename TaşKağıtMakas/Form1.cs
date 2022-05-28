using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaşKağıtMakas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string oSecimi, bSecimi;
        int oPuan, bPuan,oTur,bTur;
        int rastgele;
        Random random = new Random();
        private void btnBTas_Click(object sender, EventArgs e)
        {
            ButonlarıBeyazaCevir();
            oSecimi = "Taş";
            Bilgisayar_Hamle();
            puanlama();
            btnBTas.BackColor = Color.Yellow;
        }
        private void btnBKagit_Click(object sender, EventArgs e)
        {
            ButonlarıBeyazaCevir();
            oSecimi = "Kağıt";
            Bilgisayar_Hamle();
            puanlama();
            btnBKagit.BackColor = Color.Yellow;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnBKagit.Enabled = true;
            btnBTas.Enabled = true;
            btnBMakas.Enabled = true;
            oTur = 0;
            bTur = 0;
            oPuan = 0;
            bPuan = 0;
            lblBTur.Text = oTur.ToString();
            lblRTur.Text = bTur.ToString();
            lblBSkor.Text = oPuan.ToString();
            lblRSkor.Text = bPuan.ToString();
        }

        private void btnBMakas_Click_1(object sender, EventArgs e)
        {
            ButonlarıBeyazaCevir();
            oSecimi = "Makas";
            Bilgisayar_Hamle();
            puanlama();
            btnBMakas.BackColor = Color.Yellow;
        }
        private void ButonlarıBeyazaCevir()
        {
            btnBKagit.BackColor = Color.White;
            btnBTas.BackColor = Color.White;
            btnBMakas.BackColor = Color.White;
            btnRKagit.BackColor = Color.White;
            btnRTas.BackColor = Color.White;
            btnRMakas.BackColor = Color.White;
        }
        private void Bilgisayar_Hamle()
        {
            rastgele = random.Next(1, 4);
            if (rastgele == 1)
                bSecimi = "Taş";
            else if (rastgele == 2)
                bSecimi = "Kağıt";
            else if (rastgele == 3)
                bSecimi = "Makas";
        }
        private void puanlama()
        {
            if (oSecimi == "Taş" && bSecimi == "Kağıt")
            {
                btnRKagit.BackColor = Color.Red;
                bPuan++;
                lblRSkor.Text = bPuan.ToString();
                lblSonuc.Text = "KAYBETTİN";

            }
            else if (oSecimi == "Taş" && bSecimi == "Makas")
            {
                btnRMakas.BackColor = Color.Green;
                oPuan++;
                lblBSkor.Text = oPuan.ToString();
                lblSonuc.Text = "KAZANDIN";
            }
            else if (oSecimi == "Taş" && bSecimi == "Taş")
            {
                btnRTas.BackColor = Color.Yellow;
                lblSonuc.Text = "BERABERE";
            }
            else if (oSecimi == "Kağıt" && bSecimi == "Taş")
            {
                btnRTas.BackColor = Color.Green;
                oPuan++;
                lblBSkor.Text = oPuan.ToString();
                lblSonuc.Text = "KAZANDIN";
            }
            else if (oSecimi == "Kağıt" && bSecimi == "Makas")
            {
                btnRMakas.BackColor = Color.Red;
                bPuan++;
                lblRSkor.Text = bPuan.ToString();
                lblSonuc.Text = "KAYBETTİN";
            }
            else if (oSecimi == "Kağıt" && bSecimi == "Kağıt")
            {
                btnRKagit.BackColor = Color.Yellow;
                lblSonuc.Text = "BERABERE";
            }
            else if (oSecimi == "Makas" && bSecimi == "Taş")
            {
                btnRTas.BackColor = Color.Red;
                bPuan++;
                lblRSkor.Text = bPuan.ToString();
                lblSonuc.Text = "KAYBETTİN";
            }
            else if (oSecimi == "Makas" && bSecimi == "Kağıt")
            {
                btnRKagit.BackColor = Color.Green;
                oPuan++;
                lblBSkor.Text = oPuan.ToString();
                lblSonuc.Text = "KAZANDIN";
            }
            else if (oSecimi == "Makas" && bSecimi == "Makas")
            {
                btnRMakas.BackColor = Color.Yellow;
                lblSonuc.Text = "BERABERE";
            }
            if (bPuan == 5 || oPuan == 5)
            {
                if (bPuan > oPuan)
                {
                    lblSonuc.Text = "TURU BİLGİSAYAR KAZANDI";
                    oPuan = 0;
                    bPuan = 0;
                    bSecimi = null;
                    oSecimi = null;
                    bTur++;
                    lblRTur.Text = bTur.ToString();
                    lblBSkor.Text = oPuan.ToString();
                    lblRSkor.Text = bPuan.ToString();
                }
                else if (oPuan > bPuan)
                {
                    lblSonuc.Text = "TURU SİZ KAZANDINIZ";
                    oPuan = 0;
                    bPuan = 0;
                    bSecimi = null;
                    oSecimi = null;
                    oTur++;
                    lblBTur.Text = oTur.ToString();
                    lblBSkor.Text = oPuan.ToString();
                    lblRSkor.Text = bPuan.ToString();
                }
                if ((oTur == 5 || bTur == 5))
                {
                    if (oTur> bTur)
                    {
                        lblSonuc.Text = "OYUNU KAZANDINIZ";
                        btnBKagit.Enabled = false;
                        btnBTas.Enabled = false;
                        btnBMakas.Enabled = false;
                    }
                    if (oTur < bTur)
                    {
                        lblSonuc.Text = "OYUNU KAYBETTİNİZ";
                        btnBKagit.Enabled = false;
                        btnBTas.Enabled = false;
                        btnBMakas.Enabled = false;
                    }
                }
            }
        }
    }
}

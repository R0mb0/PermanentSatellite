﻿using SatellitePermanente.LogicAndMath;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SatellitePermanente.GUI
{
    public partial class DeletePoint : Form
    {

        private void write()
        {
            FormBridge.returnDatabase.pointList.ForEach(delegate (LogicAndMath.Point myPoint)
            {
                DataGridPoints.Rows.Add(FormBridge.returnDatabase.pointList.IndexOf(myPoint).ToString());
            });
        }
        public DeletePoint()
        {
            InitializeComponent();
            write();
        }

        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            DataGridPoints.Rows.Clear();
            write();
        }

        private void ButtonDelette_Click(object sender, EventArgs e)
        {
            FormBridge.retunrBoolean = false;
            Disclamer disclamer = new Disclamer();
            disclamer.ShowDialog();
        
            if (FormBridge.retunrBoolean)
            {
                FormBridge.returnPoint = FormBridge.returnDatabase.pointList[Convert.ToInt32(DataGridPoints.SelectedCells[0].Value)];
                this.Close();
            }
        }
    }
}

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
        Disclamer disclamer;

        /*this method is usefull for write the DataGrid of this page*/
        private void write()
        {
            FormBridge.returnDatabase.pointList.ForEach(delegate (LogicAndMath.Point myPoint)
            {
                DataGridPoints.Rows.Add(new String[]{ FormBridge.returnDatabase.pointList.IndexOf(myPoint).ToString(), myPoint.name});
            });
        }

        /*This is the method that initialize the gui*/
        public DeletePoint()
        {
            InitializeComponent();
            disclamer = new Disclamer();
            write();
        }

        /*This method serves to refresh the DataGrid, in case of some values is broked (in sense of: the value is difficult to read)*/
        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            DataGridPoints.Rows.Clear();
            write();
        }

        /*This method return the index number of the point that the user want to eliminate*/
        private void ButtonDelette_Click(object sender, EventArgs e)
        {
            FormBridge.retunrBoolean = false;
            
            disclamer.ShowDialog();/*Run the Page to confirm the elimination that must return a positive boolean*/
        
            if (Convert.ToBoolean(FormBridge.retunrBoolean))
            {
                FormBridge.returnInteger = Convert.ToInt32(DataGridPoints.SelectedCells[0].Value);
                this.Close();
            }
        }
    }
}

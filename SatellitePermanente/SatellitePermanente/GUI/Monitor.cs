﻿using SatellitePermanente.GUI;
using SatellitePermanente.LogicAndMath;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SatellitePermanente
{
    public partial class Home : Form
    {
        private DatabaseWithRescue database = new DatabaseWithRescueImpl();

        public Home()
        {
            InitializeComponent();
        }

        private void AddPoint_Click(object sender, EventArgs e)
        {
            AddPoint addPoint = new AddPoint();
            addPoint.ShowDialog();

            if (FormBridge.returnPoint == null)
            {
                return;
            }

            try
            {
                this.database.AddPoint(FormBridge.returnPoint);
            }
            catch (Exception error) 
            {
                MessageBox.Show("DATABASE ERROR!\n"+"Error message:" + error.Message);
                return;
            }
        }

        private void DeletePoint_Click(object sender, EventArgs e)
        {
            FormBridge.returnDatabase = this.database;
            DeletePoint deletePoint = new DeletePoint();
            deletePoint.ShowDialog();
            MessageBox.Show(this.database.pointList.FindIndex(FormBridge.returnPoint))
            if (this.database.DelettePoint(FormBridge.returnPoint))
            {
                MessageBox.Show("Point removed with success!");
            }
            else
            {
                MessageBox.Show("Error while removing!");
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (this.database.SaveDatabase())
            {
                MessageBox.Show("Successfully saved!");
            }
            else
            {
                MessageBox.Show("Error while saving!");
            }
        }

        private void Load_Click(object sender, EventArgs e)
        {
            if (this.database.LoadDatabase())
            {
                MessageBox.Show("Successfully loaded!");
            }
            else
            {
                MessageBox.Show("Error while loading!");
            }
        }

        private void Debug_Click(object sender, EventArgs e)
        {
            FormBridge.returnDatabase = this.database;

            Debug debug = new Debug();
            debug.ShowDialog();
        }
    }
}

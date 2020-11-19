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
    public partial class Debug : Form
    {

        private void write()
        {
            
            FormBridge.returnDatabase.pointList.ForEach(delegate (LogicAndMath.Point myPoint)
            {
                DataGridPoints.Rows.Add(new String[] {FormBridge.returnDatabase.pointList.IndexOf(myPoint).ToString(), myPoint.name,
                    myPoint.latitude.GetString(), 
                    myPoint.longitude.GetString(), myPoint.dateTime.ToString(), myPoint.angle.ToString(), 
                    myPoint.altitude.ToString(),myPoint.meetingPoint.ToString()});
            });

            FormBridge.returnDatabase.nodeList.ForEach(delegate (Node myNode)
            {
                DataGridNodes.Rows.Add(new String[] {FormBridge.returnDatabase.nodeList.IndexOf(myNode).ToString(),

                FormBridge.returnDatabase.pointList.IndexOf(PointUtility.GetCorrespondingPoint(FormBridge.returnDatabase.pointList,myNode.pointA)).ToString(),
                myNode.pointA.name,
                FormBridge.returnDatabase.pointList.IndexOf(PointUtility.GetCorrespondingPoint(FormBridge.returnDatabase.pointList,myNode.pointB)).ToString(),
                myNode.pointB.name,

                myNode.GetDistance().ToString(), myNode.GetDirection().ToString(),
                myNode.GetTimeDiffrence().ToString(), myNode.GetSpeed().ToString(),
                myNode.GetAltitudeDifference().ToString()}) ;
            });

        }

        public Debug()
        {
            InitializeComponent();
            write();
        }

        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            DataGridPoints.Rows.Clear();
            DataGridNodes.Rows.Clear();
            write();
        }
    }
}

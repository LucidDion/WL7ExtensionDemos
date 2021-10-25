﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using WealthLab.Core;
using WealthLab.Indicators;
using WealthLab.WPF;

namespace WL7ExtensionDemos
{
    //This child window will appear when the "Demo" menu item is selected under the WL7 Extensions menu
    public partial class DemoChildWindow : ChildWindow
    {
        //constructor
        public DemoChildWindow()
        {
            InitializeComponent();
        }

        //a "Token" is used for internal tracking of the Child Window, specifically when saving and restoring Workspaces
        public override string Token => "Demo";

        //private members
        private string _indicatorName = "";

        //Inidicator OK button clicked
        private void btnOkClick(object sender, RoutedEventArgs e)
        {
            if (cmbIndicators.SelectedItem == null)
                return;
            _indicatorName = (string)cmbIndicators.SelectedItem;
            PlotIndicator();
        }

        //Plot the selected indicator onto the chart
        private void PlotIndicator()
        {
            if (_indicatorName == "")
                return;

            //make sure chart has data plotted
            BarHistory bars = chart.Core.Bars;
            if (bars == null || bars.Count == 0)
                return;

            //clear old plotted indicator
            chart.Core.ClearStrategyItems();

            //find the selected indicator
            IndicatorBase ib = IndicatorFactory.FindIndicator(_indicatorName);
            if (ib == null)
                return;

            //create a new instance using the data plotted in the chart
            ib = IndicatorFactory.CreateIndicator(_indicatorName, ib.Parameters, bars);

            //add it to the chart's list of strategy-plotted indicators
            List<IndicatorBase> lst = new List<IndicatorBase>();
            lst.Add(ib);
            chart.Core.StrategyIndicators = lst;

            //refresh chart
            chart.Core.Refresh();
        }

        //after new data is loaded into the chart, regenerate the selected indicator
        private void chartBarsAssigned(object sender, EventArgs e)
        {
            PlotIndicator();
        }

        //after the selected indicator changes, refresh the chart
        private void cmbIndChange(object sender, SelectionChangedEventArgs e)
        {
            PlotIndicator();
        }
    }
}
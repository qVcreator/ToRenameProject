using System;
using System.Collections.Generic;
using System.Windows;
using ToRename.BLL;
using ToRename.BLL.OutputModels;

namespace ToRenameUI
{
    public partial class MainWindow : Window
    {
        Controller _controller;
        Dictionary<int, ActionAllInfoOutputModel> CheckListTabOne;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            CheckListTabOne = new Dictionary<int, ActionAllInfoOutputModel>();
            _controller = new Controller();

            List<ActionAllInfoOutputModel> actionList = _controller.GetEmployeeRequestAllInfo();

            InitializeDataGrids(actionList);
        }

        private void ButtonAddOption_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridOptionList.SelectedItem is ActionAllInfoOutputModel)
            {
                var selectedItem = (ActionAllInfoOutputModel)DataGridOptionList.SelectedItem;

                if (!CheckListTabOne.ContainsKey(selectedItem.Id))
                {
                    DataGridToDoList.Items.Add(selectedItem);
                    CheckListTabOne.Add(selectedItem.Id, selectedItem);
                }
            }
            else
            {
                popupNotSelectedActionTabOne.IsOpen = true;
            }
        }

        private void ButtonRemoveOption_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridToDoList.SelectedItem is ActionAllInfoOutputModel)
            {
                var selectedItem = (ActionAllInfoOutputModel)DataGridToDoList.SelectedItem;

                DataGridToDoList.Items.Remove(selectedItem);
                CheckListTabOne.Remove(selectedItem.Id);
            }
            else
            {
                popupNotSelectedActionTabOne.IsOpen = true;
            }
        }


        private void ButtonAddToDeleteList_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridTabOptionOptionList.SelectedItem is ActionAllInfoOutputModel)
            {
                var selectedItem = (ActionAllInfoOutputModel)DataGridTabOptionOptionList.SelectedItem;

                if (!CheckListTabOne.ContainsKey(selectedItem.Id))
                {
                    DataGridDeleteOptionList.Items.Add(selectedItem);
                    CheckListTabOne.Add(selectedItem.Id, selectedItem);
                }
            }
            else
            {
                popupNotSelectedActionTabTwo.IsOpen = true;
            }
        }
        private void ButtonFromRemoveList_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridDeleteOptionList.SelectedItem is ActionAllInfoOutputModel)
            {
                var selectedItem = (ActionAllInfoOutputModel)DataGridDeleteOptionList.SelectedItem;

                DataGridDeleteOptionList.Items.Remove(selectedItem);
                CheckListTabOne.Remove(selectedItem.Id);
            }
            else
            {
                popupNotSelectedActionTabOne.IsOpen = true;
            }
        }
        private void InitializeDataGrids(List<ActionAllInfoOutputModel> source)
        {
            DataGridOptionList.ItemsSource = source;
            DataGridTabOptionOptionList.ItemsSource = source;
        }

    }
}

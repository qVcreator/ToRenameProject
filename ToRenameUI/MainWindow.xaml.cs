using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using ToRename.BLL;
using ToRename.BLL.OutputModels;
using ToRename.BLL.InputModels;


namespace ToRenameUI
{
    public partial class MainWindow : Window
    {
        Controller _controller;
        Dictionary<int, ActionAllInfoOutputModel> CheckListTabOne;
        List<ActionAllInfoOutputModel> _actionList;
        List<OptionOutputModel> _optionList;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            CheckListTabOne = new Dictionary<int, ActionAllInfoOutputModel>();
            _controller = new Controller();

            _actionList = _controller.GetEmployeeRequestAllInfo();
            _optionList = _controller.GetOptions();

            InitializeDataGrids(_actionList);
            InitializeComboBoxOptions(_optionList);
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

        private void ButtonFromRemoveList_Click_1(object sender, RoutedEventArgs e)
        {

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

        private void ButtonChooseSource_Click(object sender, RoutedEventArgs e)
        {
            ChooseFolder(TextBoxSource, new OpenFileDialog());
        }

        private void InitializeDataGrids(List<ActionAllInfoOutputModel> source)
        {
            DataGridOptionList.ItemsSource = source;
            DataGridTabOptionOptionList.ItemsSource = source;
        }
        private void ButtonAddChangeOption_Click(object sender, RoutedEventArgs e)
        {
            if (IsFieldsFilled())
            {
                var newOption = new ActionInfoInputModel 
                {   From = TextBoxOptionFrom.Text,
                    To = TextBoxOptionTo.Text,
                    StartTime = DatePickerStart.SelectedDate,
                    EndTime = DayePickerEnd.SelectedDate,
                    Option = (OptionOutputModel)ComboBoxAddOption.SelectedItem
                };

                var responseOption = _controller.AddAction(newOption);

                _actionList.Add(responseOption);

                DataGridTabOptionOptionList.Items.Refresh();
                DataGridOptionList.Items.Refresh();
            }
        }

        private void ButtonSaveIn_Click(object sender, RoutedEventArgs e)
        {
            ChooseFolder(TextBoxSaveTo, new SaveFileDialog());
        }

        private void ChooseFolder(TextBox textBox, FileDialog dialogWindow)
        {
            dialogWindow.Filter = "Excel(*.xlsx;*.xls)|*.xlsx;*.xls)|Все файлы (*.*)|*.* ";
            dialogWindow.CheckFileExists = true;
            
            if (dialogWindow.ShowDialog() == true)
            {
                textBox.Text = dialogWindow.FileName;
            }
        }
        
        private void InitializeComboBoxOptions(List<OptionOutputModel> optionList)
        {
            ComboBoxAddOption.ItemsSource = optionList;
        }

        private bool IsFieldsFilled()
        {
            bool checker = false;
            if (TextBoxOptionFrom.Text.Length > 0 &&
                TextBoxOptionTo.Text.Length > 0 &&
                ComboBoxAddOption.SelectedIndex != -1 &&
                (DatePickerStart.Text.Length > 0 ||
                DayePickerEnd.Text.Length > 0)) 
                checker = true;
            return checker;                
        }

        private void ButtonToDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedItems = DataGridDeleteOptionList.Items;
            foreach(ActionAllInfoOutputModel item in selectedItems)
            {
                _controller.DeleteACtionById(item);
                _actionList.Remove(item);
            }

            DataGridTabOptionOptionList.Items.Refresh();
            DataGridOptionList.Items.Refresh();
            DataGridDeleteOptionList.Items.Clear();
        }
    }
}

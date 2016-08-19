﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AdministrationPanel.ViewModels;
using AdministrationPanel.Model;

namespace AdministrationPanel.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();

            ParkifyModel model = new ParkifyModel("http://krk.grapeup.com:8080");
            
            model.SendPing((ping, error) =>
            {
                if (error != null)
                {
                    MessageBox.Show(error);
                }
                else
                {
                    MessageBox.Show(ping.date.ToString());
                }
            });
            
            model.GetCards((cards, error) =>
            {
                if (error != null)
                {
                    MessageBox.Show(error);
                }
                else
                {
                    MessageBox.Show(String.Join(", ", cards));
                }
            });

            model.GetDraws((draws, error) =>
            {
                if (error != null)
                {
                    MessageBox.Show(error);
                }
                else
                {
                    MessageBox.Show(String.Join(", ", draws));
                }
            });

            model.GetDraws((draws, error) =>
            {
                if (error != null)
                {
                    MessageBox.Show(error);
                }
                else
                {
                    MessageBox.Show(String.Join(", ", draws));
                }
            }, 1);

			model.GetUsers((users, error) =>
            {
				if (error != null)
				{
					MessageBox.Show(error);
				}
				else
				{
					MessageBox.Show(String.Join(", ", users));
				}
            });
            
            User a = new User();
            a.name = "Krol Lew";
            a.email = "krol@lew.pl";
            a.participate = UserParticipate.Yes;
            a.password = "lion";
            a.removed = false;
            a.type = UserType.Admin;
            a.unreadMsgCounter = 10;

            model.AddUser(a, (user, error) =>
            {
                if (error != null)
                {
                    MessageBox.Show(error);
                }
                else
                {
                    MessageBox.Show(user.ToString());
                }
            });
        }
    }
}

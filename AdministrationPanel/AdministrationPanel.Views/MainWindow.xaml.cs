using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Model;
using Model.DataTypes;

namespace AdministrationPanel.Views
{
    public partial class MainWindow
    {
		private ParkifyModel _model;

        public MainWindow()
        {
            InitializeComponent();

            _model = new ParkifyModel("http://krk.grapeup.com:8080");

			var cred = new Credentials();
			cred.Email = "email@test.com";
			cred.Password = "test_pass";

			_model.OnAuthenticationSucceed += model_OnAuthenticationSucceed;

			_model.Authenticate(cred, (error) =>
			{
				if (error != null)
				{
					MessageBox.Show(error);
				}
				else
				{
					MessageBox.Show("Auth success");
				}
			});
        }

		void model_OnAuthenticationSucceed(object sender, EventArgs e)
		{
			_model.SendPing((ping, error) =>
			{
				if (error != null)
				{
					MessageBox.Show(error);
				}
				else
				{
					MessageBox.Show(ping.Date.ToString());
				}
			});

			_model.GetCards((cards, error) =>
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

			_model.GetDraws((draws, error) =>
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

			_model.GetDraws((draws, error) =>
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

			IEnumerable<User> Users;
			_model.GetUsers((users, error) =>
			{
				if (error != null)
				{
					MessageBox.Show(error);
				}
				else
				{
					MessageBox.Show(String.Join(", ", users));
					Users = users;
					var removeUser = false;

					if (removeUser)
					{
						var userItem = users.ElementAt(2);

						_model.RemoveUser((error2) =>
						{
							if (error != null)
							{
								MessageBox.Show(error2);
							}
							else
							{
								MessageBox.Show("User removed");
							}
						}, userItem.Id);
					}
				}
			});

			var a = new User();
			a.Name = "Krol Lew";
			a.Email = "krol@lew.pl";
			a.Participate = UserParticipate.Yes;
			a.Password = "lion";
			a.Removed = false;
			a.Type = UserType.Admin;
			a.UnreadMsgCounter = 10;
			a.Id = "dupa";

			_model.AddUser(a, (user, error) =>
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

			_model.GetUser("dupa", (user, error) =>
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

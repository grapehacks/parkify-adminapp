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
            
   //         _model = new ParkifyModel();

			//var cred = new Credentials();
			//cred.email = "email@test.com";
			//cred.password = "test_pass";

			//_model.OnAuthenticationSucceed += model_OnAuthenticationSucceed;

			//_model.Authenticate(cred, (error) =>
			//{
			//	if (error != null)
			//	{
			//		MessageBox.Show(error.errorMessage);
			//	}
			//	else
			//	{
			//		MessageBox.Show("Auth success");
			//	}
			//});
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
					MessageBox.Show(ping.date.ToString());
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
						}, userItem._id);
					}
				}
			});

			var a = new User();
			a.name = "Krol Lew";
			a.email = "krol@lew.pl";
			a.participate = UserParticipate.Yes;
			a.password = "lion";
			a.removed = false;
			a.type = UserType.Admin;
			a.unreadMsgCounter = 10;
			a._id = "dupa";

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

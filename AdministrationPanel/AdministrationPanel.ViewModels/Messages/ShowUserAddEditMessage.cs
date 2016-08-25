using AdministrationPanel.ViewModels.UsersTab;
using Model;
using Model.DataTypes;

namespace AdministrationPanel.ViewModels.Messages
{
    public class ShowUserAddEditMessage
    {
        public User User { get; set; }
        public IDataProvider DataProvider { get; set; }
    }
}

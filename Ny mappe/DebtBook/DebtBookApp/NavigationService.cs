using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtBookApp
{
    public class NavigationService
    {
        MainWindow mainWindow => new MainWindow();
        AddWindow addWindow => new AddWindow();

        public void getMainWindow()
        {
            mainWindow.Show();
        }

        public void getAddWindow()
        {
            addWindow.Show();
         
        }


    }
}

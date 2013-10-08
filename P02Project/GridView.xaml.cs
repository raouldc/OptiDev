using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace P02Project
{
    /// <summary>
    /// Interaction logic for GridView.xaml
    /// </summary>
    public partial class GridView : UserControl
    {
        private int numberOfItems;
        private int numberOfRows=1;
        private int numberOfCols;
        //set the max rows and max cols
        private readonly int MAXROWS = 6;
        private readonly int MAXCOLS = 2;


        public GridView(String Xpath)
        {
            InitializeComponent();
            /*first we need to bind the xml and create a grid Layout for that*/
            //dummy data
            numberOfItems = 7;
            if (numberOfItems >= 4)
            {
                numberOfRows = 2;
            }
            numberOfCols = (int)Math.Ceiling((double)numberOfItems / (double)numberOfRows);
            //create a gridView
            Grid g = new Grid();
            //create the column definitions
            for (int i =0; i < numberOfCols;i++){
                ColumnDefinition col = new ColumnDefinition();
                g.ColumnDefinitions.Add(col);
            }

            //if it is an odd number
            //need to span the last column 1 colum
            for (int i = 0; i < numberOfItems; i++)
            {
                PoloroidControl p = new PoloroidControl();
                p.setCaption(i.ToString());
                g.Children.Add(p);
            }

        }
    }
}
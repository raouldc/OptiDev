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
using P02Project.Resources.xml;

namespace P02Project
{
    /// <summary>
    /// Interaction logic for GridView.xaml
    /// </summary>
    public partial class GridView : UserControl
    {
        private int numberOfItems;
        private int numberOfRows = 1;
        private int numberOfCols;
        //set the max rows and max cols
        private readonly int MAXCOLS = 6;
        private readonly int MAXROWS = 2;


        public GridView(String Xpath)
        {
            this.InitializeComponent();
            /*first we need to bind the xml and create a grid Layout for that*/
            //dummy data
            String path = System.IO.Path.Combine(System.IO.Path.GetFullPath("."), Xpath);
            
            PageModelImage[] temp = XMLUtilities.GetContentFromFile(path).ImageList;
           
            numberOfItems  = temp.Count();

            if (numberOfItems >= 4)
            {
                numberOfRows++;
            }
            numberOfCols = (int)Math.Ceiling((double)numberOfItems / (double)numberOfRows);
            int cos = numberOfCols;
            int ros = numberOfRows;
            if ((numberOfCols > MAXCOLS) || (numberOfRows > MAXROWS))
            {
                throw new Exception("There are too many rows or columns");
            }
            Console.WriteLine(numberOfCols);
            //create a gridView
            mainGrid.Height = 870;
            mainGrid.Width = 1600;

            //1630
            Grid g = new Grid();
            //create the column definitions
            for (int i = 0; i < numberOfCols; i++)
            {
                ColumnDefinition col = new ColumnDefinition();
                g.ColumnDefinitions.Add(col);
            }
            //create the row definitions
            for (int i = 0; i < numberOfRows; i++)
            {
                RowDefinition def = new RowDefinition();
                g.RowDefinitions.Add(def);
            }

            int colNum = 0;
            int rowNum = 0;
            for (int i = 0; i < numberOfItems; i++)
            {
                if (colNum >= numberOfCols)
                {
                    rowNum++;
                    colNum = 0;
                }
                PoloroidControl p = new PoloroidControl();
                p.setCaption(temp[i].caption);
                p.setImage(temp[i].Value);
                p.setColour(Util._pageColDict["About"]);
                p.Margin = new Thickness(25);
                Grid.SetColumn(p, colNum);
                Grid.SetRow(p, rowNum);
                /*if there are an add number of things, we must span the last picture in the firstRow for 2 columns */
                //if we are in the second last row and first column
                if ((colNum == numberOfCols - 2) && (rowNum == 0) && ((numberOfItems % 2) == 1))
                {
                    //make the picture span 2 columns
                    Grid.SetColumnSpan(p, 2);
                    colNum++;
                }
                g.Children.Add(p);
                colNum++;
            }
            //if it is an odd number
            //need to span the last column 1 colum

            //for (int i = 0; i < numberOfItems; i++)
            //{
            //    if (colValue >= numberOfCols)
            //    {
            //        rowValue++;
            //    }
            //    PoloroidControl p = new PoloroidControl();
            //    p.setCaption(i.ToString());
            //    mainGrid.Children.Add(p);
            //    Grid.SetColumn(p, colValue);
            //    Grid.SetRow(p, rowValue);
            //    colValue++;
            //}

            mainGrid.Children.Add(g);
            UpdateLayout();
        }
    }
}
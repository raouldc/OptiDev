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
using P02Project.Screens;

namespace P02Project
{
    /// <summary>
    /// Interaction logic for GridView.xaml
    /// </summary>
    public partial class GridView : UserControl
    {
        // set the number of items, rows and columns
        private int numberOfItems;
        private int numberOfRows = 1;
        private int numberOfCols;
        //set the max rows and max cols
        private readonly int MAXCOLS = 6;
        private readonly int MAXROWS = 2;



        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="Xpath"></param>
        public GridView(String Xpath, bool isFunky)
        {
            this.InitializeComponent();
            /*first we need to bind the xml and create a grid Layout for that*/
            //dummy data
            String path = System.IO.Path.Combine(System.IO.Path.GetFullPath("."), Xpath);

            PageModelImage[] temp = XMLUtilities.GetContentFromFile(path).ImageList;

            numberOfItems = temp.Count();

            if (isFunky && numberOfItems == 5)
            {
                numberOfRows = 4;
                numberOfCols = 4;
            }
            else
            {
                if (numberOfItems >= 4)
                {
                    numberOfRows++;
                }
                numberOfCols = (int)Math.Ceiling((double)numberOfItems / (double)numberOfRows);
            }
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
            double rotation = 1.5;
            for (int i = 0; i < numberOfItems; i++)
            {
                if (colNum >= numberOfCols)
                {
                    rowNum = isFunky ? rowNum + 2 : rowNum + 1;
                    colNum = 0;
                }
                PoloroidControl p = new PoloroidControl();
                p.setCaption(temp[i].caption);
                p.setImage(temp[i].Value);
                p.setColour(Util._pageColDict["About"]);
                p.Margin = new Thickness(30);
                p.RenderTransform = new RotateTransform(rotation);
                rotation = rotation * -1;
                p.MouseUp += new MouseButtonEventHandler(Polaroid_MouseUp);
                if (i == 3)
                {
                    Grid.SetColumn(p, 1);
                    Grid.SetRow(p, 1);
                    Grid.SetColumnSpan(p, 2);
                    Grid.SetRowSpan(p, 2);
                }
                else
                {
                    Grid.SetColumn(p, colNum);
                    Grid.SetRow(p, rowNum);
                }

                /*if there are an add number of things, we must span the last picture in the firstRow for 2 columns */
                //if we are in the second last row and first column
                if (!isFunky && (colNum == numberOfCols - 2) && (rowNum == 0) && ((numberOfItems % 2) == 1))
                {
                    //make the picture span 2 columns
                    Grid.SetColumnSpan(p, 2);
                    colNum++;
                }
                g.Children.Add(p);

                colNum = isFunky ? colNum + 2 : colNum + 1;
            }

            mainGrid.Children.Add(g);
            UpdateLayout();
        }



        /// <summary>
        /// this method called when the mouse is released on the polaroid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Polaroid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            // configure the screen and the content
            FrameworkElement objParent = (FrameworkElement)this.Parent;
            while (objParent.GetType() != typeof(TopLevelPage))
            {
                objParent = (FrameworkElement)objParent.Parent;
            }
            TopLevelPage levelpage = (TopLevelPage)objParent;
            String fullname = (sender as PoloroidControl).text;
            String firstName = fullname.Split(' ')[0];

            // set the content and the subtitle
            levelpage.setContent(new SplitGridView("xml/Profiles/" + firstName + ".xml"));
            levelpage.setSubtitle(levelpage.getSubtitle() + ": " + firstName);


        }
    }
}
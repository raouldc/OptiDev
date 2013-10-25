#region

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Animation;
using P02Project.Utils;

#endregion

namespace P02Project.Screens
{
    /// <summary>
    ///     Interaction logic for SplitGridView.xaml
    /// </summary>
    public partial class SplitGridView : UserControl, Animatiable
    {
        private readonly Storyboard sbIn;

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="filename"></param>
        public SplitGridView(PageModel temp)
        {
            InitializeComponent();

            splitContentScrollViewer.Margin = Util.contentMargin;
            splitContentScrollViewer.Background = new SolidColorBrush(Util.contentBgColor);
            ////TODO: Set title and subtitle
            //String path = System.IO.Path.Combine(System.IO.Path.GetFullPath("."), "Resources/" + filename);
            //PageModel temp = XMLUtilities.GetContentFromFile(path);

            // initialize the list to store all the images in this page.
            PageModelImage[] imgList = temp.ImageList;
            int count = 0;
            double rotation = 8;

            // confige each image
            foreach (PageModelImage img in imgList)
            {
                PoloroidControl p = new PoloroidControl();
                p.setImage(img.Value);
                p.Width = 350;
                p.Height = 350;
                p.setCaption(img.caption);
                p.Margin = new Thickness(25);
                p.RenderTransformOrigin.Offset(0.5, 0.5);
                p.RenderTransform = new RotateTransform(rotation);
                p.IsUnclickable = true;
                p.setShadow(10, 0.365, Colors.Black);
                rotation = rotation*-1;
                Grid.SetColumn(p, 0);
                Grid.SetRow(p, count);
                PageContent.Children.Add(p);
                count++;
            }
            PageModelText[] textList = temp.TextList;

            // config all the texts in the page
            TextBlock tb = Util.TextBlockFactory();
            foreach (PageModelText txt in textList)
            {
                if ((txt.id != null) && (txt.id.Equals("bold")))
                {
                    tb.Inlines.Add(new Bold(new Run(txt.Value.Trim() + "\n\n")));
                }
                else
                {
                    tb.Inlines.Add(new Run(txt.Value.Trim() + "\n\n"));
                }
            }

            StackPanel contentStackPanel = new StackPanel();

            contentStackPanel.Children.Add(tb);

            splitContentScrollViewer.Content = contentStackPanel;

            sbIn = new Storyboard();

            foreach (FrameworkElement fElement in contentStackPanel.Children)
            {
                Util.FadeIn(sbIn, fElement);
            }

            foreach (FrameworkElement fElement in PageContent.Children)
            {
                Util.FadeIn(sbIn, fElement);
            }
        }

        public void AnimateIn()
        {
            sbIn.Begin(this);
        }

        public void AnimateOut()
        {
        }

        private void splitContentScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            try
            {
                (Window.GetWindow(this) as TopWindow).ResetTimer();
            }
            catch (NullReferenceException)
            {
            }
        }
    }
}
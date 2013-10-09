﻿using System;
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

namespace P02Project.Screens
{
    /// <summary>
    /// Interaction logic for SplitGridView.xaml
    /// </summary>
    public partial class SplitGridView : UserControl
    {
        public SplitGridView(String filename)
        {
            InitializeComponent();
            String path = System.IO.Path.Combine(System.IO.Path.GetFullPath("."), "Resources/" + filename);
            PageModel temp = XMLUtilities.GetContentFromFile(path);

            PageModelImage[] imgList = temp.ImageList;

            int count = 0;
            double rotation =8;

            foreach (PageModelImage img in imgList)
            {
                PoloroidControl p = new PoloroidControl();
                p.setImage(img.Value);
                p.Width = 350;
                p.Height = 350;
                p.setCaption(img.caption);
                p.Margin = new Thickness(25);
                p.RenderTransformOrigin.Offset(0.5,0.5);
                p.RenderTransform = new RotateTransform(rotation);
                rotation = rotation * -1;
               // p.Margin
                Grid.SetColumn(p, 0);
                Grid.SetRow(p, count);
                PageContent.Children.Add(p);
                count++;
            }
            PageModelText[] textList = temp.TextList;

            TextBlock tb = new TextBlock();
            tb.TextAlignment = TextAlignment.Left;
            tb.FontSize = 24;
            tb.Margin = new Thickness(10);
            tb.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffffffff"));
            foreach (PageModelText txt in textList)
            {
      
                if ((txt.id!=null)&&(txt.id.Equals("bold")))
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
            
  
        }
    }
}

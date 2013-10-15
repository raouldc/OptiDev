﻿using System;
using System.Collections.Generic;
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
using System.Windows.Media.Effects;

namespace P02Project
{
	/// <summary>
	/// Interaction logic for hcihBeads.xaml
	/// </summary>
	public partial class hcihBeads : UserControl
	{
        private SolidColorBrush unsel;
        private SolidColorBrush sel;

        /// <summary>
        /// Constructor
        /// </summary>
        public hcihBeads()
		{
			this.InitializeComponent();
            
            // set image
            donate.setImage("images\\HowCanIHelp\\beads.png");

            //Set button cols
            unsel = new SolidColorBrush(Util._pageColDict["hcihUnSelected"]);
            sel = new SolidColorBrush(Util._pageColDict["hcihSelected"]);

            //set content
            abtBeads_Click(this, null);
		}

        private void SetAllUnsel()
        {
            abtBeads.Background = unsel;
            prgmBeads.Background = unsel;
            aocBeads.Background = unsel;
            contact.Background = unsel;

            abtBeads.Effect = null;
            prgmBeads.Effect = null;
            aocBeads.Effect = null;
            contact.Effect = null;
        }

        private TextBlock TextBlockFactory()
        {
            TextBlock tb = new TextBlock();
            tb.TextAlignment = TextAlignment.Left;
            tb.FontSize = 24;
            tb.Margin = new Thickness(10);
            tb.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffffffff"));

            return tb;
        }

        private StackPanel abtBeadsContent()
        {
            StackPanel content = new StackPanel();

            TextBlock tb = TextBlockFactory();
            tb.Inlines.Add(new Run("The Beads of Courage® programme helps children cope by decreasing their illness-related distress," +
                                   "increases the use of positive coping strategies, helps them to find meaning in their illness and " +
                                   "helps to restore their sense of self through creativity.\n\nThe programme also provides something t" +
                                   "angible that a child can use to tell family and care-givers about their experience during treatme" +
                                   "nt. The beads also help explain to teachers and friends what has happened to them whilst they hav" +
                                   "e been away from school. Parents of younger children enrolled in the programme can use the beads " +
                                   "in the future to explain to their child what they have been through. With each procedure or miles" +
                                   "tone in their treatment, they get a special bead. "));

            content.Children.Add(tb);
            return content;
        }

        private StackPanel PgrmBeadsContent()
        {
            StackPanel content = new StackPanel();

            TextBlock tb = TextBlockFactory();
            tb.Inlines.Add(new Run("These are the vast majority of beads used in the program. These beads are commercially manufactured " +
                                   "due largely to the sheer numbers involved. These beads are the ones that you may have seen on bead g" +
                                   "uides that correspond to specific events in treatment. We don’t ask artists to make programme beads."));

            content.Children.Add(tb);
            return content;
        }

        private StackPanel AocBeadsContent()
        {
            StackPanel content = new StackPanel();

            TextBlock tb = TextBlockFactory();
            tb.Inlines.Add(new Run("These are the artist-made glass beads that are given to acknowledge the milestones in their treatment" +
                                   " journey.\n\nTypes of Act of Courage beads include:"));

            tb.Inlines.Add(new Bold(new Run("\n\nCOURAGE BEADS: ")));
            tb.Inlines.Add(new Run("Given for acts of bravery or courage above what is accounted for within the programme beads. For exa" +
                                   "mple on completion of 6-8 weeks of radiation therapy and to have mastered how to lie as still as pos" +
                                   "sible. For learning how to take tablets, for letting the Doctors and Nurses carry out procedures tha" +
                                   "t they really hate!"));

            tb.Inlines.Add(new Bold(new Run("\n\nBONE MARROW TRANSPLANT: ")));
            tb.Inlines.Add(new Run("Every time a child has a Bone Marrow Transplant they receive an Act of Courage Bead to mark this tre" +
                                   "atment milestone."));

            tb.Inlines.Add(new Bold(new Run("\n\nPARTNER IN COURAGE: ")));
            tb.Inlines.Add(new Run("These beads are given to the Bone Marrow Donor if known to the child, this could be a parent or sibl" +
                                   "ing but other times it could be another extended family member or a family friend."));

            tb.Inlines.Add(new Bold(new Run("\n\nPURPLE HEART: ")));
            tb.Inlines.Add(new Run("Given at Completion of Treatment."));

            tb.Inlines.Add(new Bold(new Run("\n\nBUTTERFLY BEAD: ")));
            tb.Inlines.Add(new Run("One-of-a-kind, handmade butterfly beads that are given to every parent who has experienced the loss o" +
                                   "f their child. Butterflies are well known symbols of peace and hope."));

            tb.Inlines.Add(new Bold(new Run("\n\nPARENT HEART: ")));
            tb.Inlines.Add(new Run("Heart bead presented to a parent at a particularly difficult time to just say “We know it's hard goin" +
                                   "g for you as well!”"));

            content.Children.Add(tb);
            return content;
        }

        private StackPanel ConactContent()
        {
            StackPanel content = new StackPanel();

            TextBlock tb = TextBlockFactory();
            tb.Inlines.Add(new Run("If you have any questions or want more information please don't hestiate to call our coordinator Kari " +
                                   "on (09) 416 5624.\n\nIf you are willing to contribute your beads to Beads of Courage program, please s" +
                                   "end them to:\n\nKari Lindsay-Beale\n5 Dene Court Lane\nGreenhithe 0632\nAuckland"));

            content.Children.Add(tb);
            return content;
        }

        private void abtBeads_Click(object sender, RoutedEventArgs e)
        {
            SetAllUnsel();
            abtBeads.Background = sel;
            abtBeads.Effect = new DropShadowEffect();

            text.Content = abtBeadsContent();
        }

        private void prgmBeads_Click(object sender, RoutedEventArgs e)
        {
            SetAllUnsel();
            prgmBeads.Background = sel;
            prgmBeads.Effect = new DropShadowEffect();

            text.Content = PgrmBeadsContent();
        }

        private void aocBeads_Click(object sender, RoutedEventArgs e)
        {
            SetAllUnsel();
            aocBeads.Background = sel;
            aocBeads.Effect = new DropShadowEffect();

            text.Content = AocBeadsContent();
        }

        private void contact_Click(object sender, RoutedEventArgs e)
        {
            SetAllUnsel();
            contact.Background = sel;
            contact.Effect = new DropShadowEffect();
            text.Content = ConactContent();
        }
	}
}
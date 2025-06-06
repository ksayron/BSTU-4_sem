using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using KNP_Library.Modules.classes;
using KNP_Library.Modules.Hash;
using KNP_Library.Modules.DAL;
using KNP_Library.Modules.View;
using KNP_Library.ViewModels;

namespace KNP_Library.Modules.View
{

    public partial class RatingControl : UserControl
    {
        public RatingControl()
        {
            InitializeComponent();
            MaxRating = 10;
            StarIndices = new int[MaxRating];
            for (int i = 0; i < MaxRating; i++)
            {
                StarIndices[i] = i;
            }
        }

        #region Dependency Properties

        public static readonly DependencyProperty RatingProperty =
            DependencyProperty.Register(
                "Rating",
                typeof(int),
                typeof(RatingControl),
                new PropertyMetadata(0));

        public static readonly DependencyProperty MaxRatingProperty =
            DependencyProperty.Register(
                "MaxRating",
                typeof(int),
                typeof(RatingControl),
                new PropertyMetadata(10, OnMaxRatingChanged));

        private static readonly DependencyPropertyKey PreviewRatingPropertyKey =
            DependencyProperty.RegisterReadOnly(
                "PreviewRating",
                typeof(int),
                typeof(RatingControl),
                new PropertyMetadata(0));

        public static readonly DependencyProperty PreviewRatingProperty =
            PreviewRatingPropertyKey.DependencyProperty;

        #endregion

        #region Properties

        public int Rating
        {
            get => (int)GetValue(RatingProperty);
            set => SetValue(RatingProperty, value);
        }

        public int MaxRating
        {
            get => (int)GetValue(MaxRatingProperty);
            set => SetValue(MaxRatingProperty, value);
        }

        public int PreviewRating
        {
            get => (int)GetValue(PreviewRatingProperty);
            private set => SetValue(PreviewRatingPropertyKey, value);
        }

        public int[] StarIndices { get; private set; }

        #endregion

        #region Methods

        private static void OnMaxRatingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as RatingControl;
            if (control != null)
            {
                control.StarIndices = new int[control.MaxRating];
                for (int i = 0; i < control.MaxRating; i++)
                {
                    control.StarIndices[i] = i;
                }
            }
        }

        private void Star_MouseMove(object sender, MouseEventArgs e)
        {
            var star = sender as Path;
            if (star != null)
            {
                int starIndex = (int)star.Tag;
                PreviewRating = starIndex + 1;
            }
        }

        private void Star_MouseLeave(object sender, MouseEventArgs e)
        {
            PreviewRating = 0;
        }

        private void Star_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var star = sender as Path;
            if (star != null)
            {
                int starIndex = (int)star.Tag;
                Rating = starIndex + 1;
            }
        }

        #endregion

    }
}


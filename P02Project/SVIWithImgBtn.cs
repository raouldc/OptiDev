using System;
using Microsoft.Surface.Presentation.Controls;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

public class SVIWithImgBtn
{
    // ScatterViewItem
    public ScatterViewItem _svi { get; set; }
    // original width and height of the _svi
    public double _sviOrgWidth { get; set; }
    public double _sviOrgHeight { get; set; }

    // image that embedded in the _svi
    public Image _sviImg { get; set; }

    // SurfaceButton that embedded in _svi
    public SurfaceButton _sviBtn { get; set; }
    // original content and background color of the _sviBtn
    public String _sviBtnOrgContent { get; set; }
    public Brush _sviBtnOrgBackground { get; set; }

    public Point _orgCenter { get; set; }
    
    public SVIWithImgBtn()
	{
	}

    public SVIWithImgBtn(ScatterViewItem svi, Image img, SurfaceButton btn) 
    {
        _svi = svi;
        _sviOrgWidth = svi.Width;
        _sviOrgHeight = svi.Height;

        _sviImg = img;

        _sviBtn = btn;
        _sviBtnOrgContent = btn.Content.ToString() ;
        _sviBtnOrgBackground = btn.Background;
    }
}

﻿using System;

public class SVIWithImgBtn
{
    // ScatterViewItem
    private ScatterViewItem _svi { get; set; }
    // original width and height of the _svi
    private int _sviOrgWidth { get; set; }
    private int _sviOrgHeight { get; set; }

    // image that embedded in the _svi
    private Image _sviImg {get; set;}

    // SurfaceButton that embedded in _svi
    private SurfaceButton _sviBtn {get; set;}
    // original content and background color of the _sviBtn
    private String _sviBtnOrgContent { get; set; }
    private SolidColorBrush _sviBtnOrgBackground { get; set; }
    
    private Point _orgCenter { get; set; }
    
    public SVIWithImgBtn()
	{
	}

    public SVIWithImgBtn(ScatterViewItem svi, Image img, SurfaceButton btn) 
    {
        _svi = svi;
        _sviOrgWidth = svi.Width;
        _sviOrgHeight = svi.Height;

        _sviImage = img;

        _sviBtn = btn;
        _sviBtnOrgContent = btn.Content;
        _sviBtnOrgBackground = btn.Background;
    }
}

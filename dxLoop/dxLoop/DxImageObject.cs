using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX.DirectDraw;
using System.Drawing;

namespace dxLoop
{
    public enum BitmapType
    {
        SOLID = 0,
        TRANSPARENT = 1
    }
    public class DxImageObject
    {
        protected double dXPos = 0.0f;
        protected double dYPos = 0.0f;
        protected double dLastXPos = 0.0f;
        protected double dLastYPos = 0.0f;
        protected int iWidth = 0;
        protected int iHeight = 0;
        protected Rectangle objectSizeRect = Rectangle.Empty;
        protected Rectangle rectPosition = Rectangle.Empty;
        protected bool bVisible = true;
        protected Bitmap sourceBitmap;
        protected BitmapType objectType;
        protected Device targetDevice;
        protected SurfaceDescription surfaceDesc;
        protected Surface bitmapSurface;
        protected ColorKey tempKey;
        protected int colKey;

        public double XPosition
        {
            get
            {
                return dXPos;
            }
            set
            {
                dLastXPos = dXPos;
                dXPos = value;
                rectPosition = new Rectangle(new Point(Convert.ToInt32(dXPos), rectPosition.Y), new Size(this.Width, this.Height));
            }
        }
        public double YPosition
        {
            get
            {
                return dYPos;
            }
            set
            {
                dLastYPos = dYPos;
                dYPos = value;
                rectPosition = new Rectangle(new Point(rectPosition.X,Convert.ToInt32(dYPos)), new Size(this.Width,this.Height));
            }
        }
        public int Width
        {
            get
            {
                return iWidth;
            }
        }
        public int Height
        {
            get
            {
                return iHeight;
            }
        }
        public bool Visible
        {
            get
            {
                return bVisible;
            }
            set
            {
                bVisible = value;
            }
        }
        public double LastXPosition
        {
            get
            {
                return dLastXPos;
            }
        }
        public double LastYPosition
        {
            get
            {
                return dLastYPos;
            }
        }
        public Rectangle Position
        {
            get
            {
                return rectPosition;
            }
        }
        public Bitmap BitmapOfObject
        {
            get
            {
                return sourceBitmap;
            }
        }
        public Surface SurfaceOfBitmap
        {
            get
            {
                return bitmapSurface;
            }
        }
        public DxImageObject(Bitmap SourceBitmap, BitmapType
       ObjectType, int cKey, Device TargetDevice)
        {
            sourceBitmap = SourceBitmap;
            objectType = ObjectType;
            targetDevice = TargetDevice;
            objectSizeRect = new Rectangle(0, 0, SourceBitmap.Width,
             SourceBitmap.Height);
            rectPosition = new Rectangle(0, 0, SourceBitmap.Width,
            SourceBitmap.Height);
            iWidth = SourceBitmap.Width;
            iHeight = SourceBitmap.Height;
            initializeSurfaceDescription();
            tempKey = new ColorKey();
            colKey = cKey;
            initializeSurface(cKey);
        }
        public DxImageObject(BitmapType ObjectType, Device
           TargetDevice, int cKey, string AssemblyImageResource)
        {
            sourceBitmap = new Bitmap(GetType().Module.Assembly.
            GetManifestResourceStream(AssemblyImageResource));
            objectType = ObjectType;
            targetDevice = TargetDevice;
            objectSizeRect = new Rectangle(0, 0, sourceBitmap.Width,
            sourceBitmap.Height);
            rectPosition = new Rectangle(0, 0, sourceBitmap.Width,
            sourceBitmap.Height);
            iWidth = sourceBitmap.Width;
            iHeight = sourceBitmap.Height;
            initializeSurfaceDescription();
            tempKey = new ColorKey();
            colKey = cKey;
            initializeSurface(cKey);
        }
        public DxImageObject(string Resource, BitmapType ObjectType,
         int cKey, Device TargetDevice)
        {
            sourceBitmap = new Bitmap(Resource);
            objectType = ObjectType;
            targetDevice = TargetDevice;
            objectSizeRect = new Rectangle(0, 0, sourceBitmap.Width,
            sourceBitmap.Height);
            rectPosition = new Rectangle(0, 0, sourceBitmap.Width,
            sourceBitmap.Height);
            iWidth = sourceBitmap.Width;
            iHeight = sourceBitmap.Height;
            initializeSurfaceDescription();
            tempKey = new ColorKey();
            colKey = cKey;
            initializeSurface(cKey);
        }
        protected void initializeSurfaceDescription()
        {
            surfaceDesc = new SurfaceDescription();
            surfaceDesc.SurfaceCaps.OffScreenPlain = true;
            surfaceDesc.Width = objectSizeRect.Width;
            surfaceDesc.Height = objectSizeRect.Height;
        }
        protected void initializeSurface(int colorkey)
        {
            this.bitmapSurface = new Surface(sourceBitmap,
            surfaceDesc, targetDevice);
            switch (this.objectType)
            {
                case BitmapType.TRANSPARENT:
                    tempKey.ColorSpaceLowValue = colorkey;
                    tempKey.ColorSpaceHighValue = colorkey;
                    bitmapSurface.SetColorKey(ColorKeyFlags.SourceDraw
                     , tempKey);
                    break;
            }
        }
        public void DrawBitmap(Surface TargetSurface, float
          TargetXPos, float TargetYPos)
        {
            this.XPosition = TargetXPos;
            this.YPosition = TargetYPos;
            DrawBitmap(TargetSurface);
        }
        public void DrawBitmap(Surface TargetSurface)
        {
            if (!this.bVisible)
                return;
            if (this.objectType == BitmapType.TRANSPARENT)
                TargetSurface.DrawFast(rectPosition.X,
                                       rectPosition.Y,
                                       bitmapSurface,
                                       objectSizeRect,
                                       DrawFastFlags.SourceColorKey
                                       | DrawFastFlags.Wait);
            else
                TargetSurface.DrawFast(rectPosition.X,
                                       rectPosition.Y,
                                       bitmapSurface,
                                       objectSizeRect,
                                       DrawFastFlags.NoColorKey | DrawFastFlags.Wait);

        }
        public void DrawBitmap(int x, int y, Rectangle rect, Surface TargetSurface)
        {
            if (!this.bVisible)
                return;
            if (this.objectType == BitmapType.TRANSPARENT)
                TargetSurface.DrawFast(x,
                                       y,
                                       bitmapSurface,
                                       rect,
                                       DrawFastFlags.SourceColorKey
                                       | DrawFastFlags.Wait);
            else
                TargetSurface.DrawFast(x,
                                       y,
                                       bitmapSurface,
                                       rect,
                                       DrawFastFlags.NoColorKey | DrawFastFlags.Wait);
        }
        public void RestoreSurface()
        {
            this.initializeSurfaceDescription();
            this.initializeSurface(colKey);
        }
    }
}


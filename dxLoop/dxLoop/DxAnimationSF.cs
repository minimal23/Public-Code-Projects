using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX.DirectDraw;
using System.Drawing;

namespace dxLoop
{
    public class DxAnimationSF
    {
        protected DxTimer t = new DxTimer();
        protected DxImageObject boAnimation;
        protected DxInitGraphics graphics;
        double frameTimeInterval;
        int picsW, picsH;
        int aGridW, aGridH;
        int blitX, blitY, blitW, blitH;
        bool Show = true;
        public DxAnimationSF(string aPathImage, int NoOfFramesW, int
           NoOfFrameRowsH, int fps, DxInitGraphics gHandler)
        {
            graphics = gHandler;
            this.boAnimation = new DxImageObject(aPathImage,
            BitmapType.TRANSPARENT, 0, this.graphics.DDDevice);
            picsW = NoOfFramesW;
            picsH = NoOfFrameRowsH;
            aGridW = this.boAnimation.Width;
            aGridH = this.boAnimation.Height;
            frameTimeInterval = 1000 / fps;
            blitX = 0;
            blitY = 0;
            blitW = aGridW / NoOfFramesW;
            blitH = aGridH / NoOfFrameRowsH;
        }
        public void RestoreSurface(DxInitGraphics gHandler)
        {
            graphics = gHandler;
            this.boAnimation.RestoreSurface();
        }
        public void Play(int x, int y, Animate type)
        {
            if (!Show) return;
            t.markTime();
            if (t.msElapsed() > frameTimeInterval)
            {
                blitX = blitX + blitW;
                if (blitX > aGridW - 1)
                {
                    blitX = 0;
                    blitY = blitY + blitH;
                    if (blitY > aGridH - 1)
                    {
                        blitX = 0;
                        blitY = 0;
                        if (type == Animate.SingleSequence)
                        {
                            Show = false;
                            return;
                        }
                    }
                }
                t.resetTime();
            }
            Rectangle rcRect = new Rectangle(blitX, blitY, blitW,
            blitH);
            graphics.RenderSurface.DrawFast(x, y,
            boAnimation.SurfaceOfBitmap, rcRect,
            DrawFastFlags.SourceColorKey | DrawFastFlags.Wait);
        }
        public void ResetPlay()
        {
            Show = true;
        }
        public bool isPlaying()
        {
            return Show;
        }
    }
}

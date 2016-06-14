using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX.DirectDraw;

namespace dxLoop
{
    public enum Animate
    {
        Continuous = 0,
        SingleSequence = 1
    }
    public class DxAnimationMF
    {
        protected DxTimer t = new DxTimer();
        protected DxImageObject[] boAnimation;
        protected DxInitGraphics graphics;
        double frameTimeInterval;
        int currentFrame;
        int totalFrames;
        bool Show = true;
        public DxAnimationMF(DxImageObject[] frm, int fps,
            DxInitGraphics gHandler)
        {
            graphics = gHandler;
            boAnimation = frm;
            frameTimeInterval = 1000 / fps;
            totalFrames = frm.Length - 1;
            currentFrame = 0;
        }
        public void RestoreSurface(DxInitGraphics gHandler)
        {
            int i;
            graphics = gHandler;
            for (i = 0; i <= totalFrames; i++)
                boAnimation[i].RestoreSurface();
        }
        public void Play(int x, int y, Animate type)
        {
            if (!Show) return;
            t.markTime();
            if (t.msElapsed() > frameTimeInterval)
            {
                if (currentFrame <= totalFrames)
                {
                    currentFrame++;
                    if (type == Animate.SingleSequence && currentFrame
                    > totalFrames)
                    {
                        Show = false;
                        t.resetTime();
                        currentFrame = 0;
                        return;
                    }
                    if (currentFrame > totalFrames)
                    {
                        currentFrame = 0;
                    }
                }
                t.resetTime();
            }
            graphics.RenderSurface.DrawFast(x, y,
            boAnimation[currentFrame].SurfaceOfBitmap,
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


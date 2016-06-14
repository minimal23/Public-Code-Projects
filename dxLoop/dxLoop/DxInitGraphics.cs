using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX.DirectDraw;
using System.Windows.Forms;

namespace dxLoop
{
    public class DxInitGraphics
    {
        protected Control target = null;
        protected Device graphicsDevice = null;
        protected Clipper graphicsClipper = null;
        protected Surface surfacePrimary = null;
        protected Surface surfaceSecondary = null;
        public Device DDDevice
        {
            get
            {
                return graphicsDevice;
            }
        }
        public Surface RenderSurface
        {
            get
            {
                return surfaceSecondary;
            }
        }
        public DxInitGraphics(Control RenderControl)
        {
            this.target = RenderControl;
            graphicsDevice = new Device();
#if DEBUG
            graphicsDevice.SetCooperativeLevel(this.target, CooperativeLevelFlags.Normal);
#else
            graphicsDevice.SetCooperativeLevel(this.target, CooperativeLevelFlags.FullscreenExclusive);
            graphicsDevice.SetDisplayMode(1366, 768, 32, 60, true);
#endif
            this.createSurfaces();
        }
        protected void createSurfaces()
        {
            SurfaceDescription desc = new SurfaceDescription();
            desc.SurfaceCaps.PrimarySurface = true;
#if !DEBUG
            desc.SurfaceCaps.Flip = true;
            desc.SurfaceCaps.Complex = true;
            desc.BackBufferCount = 1;
#endif
            surfacePrimary = new Surface(desc, graphicsDevice);
            desc.Clear();
#if DEBUG
            desc.Width = surfacePrimary.SurfaceDescription.Width;
            desc.Height = surfacePrimary.SurfaceDescription.Height;
            desc.SurfaceCaps.OffScreenPlain = true;
            surfaceSecondary = new Surface(desc, this.graphicsDevice);
#else
            desc.SurfaceCaps.BackBuffer=true;
            surfaceSecondary=surfacePrimary.GetAttachedSurface(desc.SurfaceCaps);
#endif
            graphicsClipper = new Clipper(graphicsDevice);
            graphicsClipper.Window = target;
            surfacePrimary.Clipper = this.graphicsClipper;
        }
        public void Flip()
        {
            if (!this.target.Created)
            {
                return;
            }
            if (surfacePrimary == null || surfaceSecondary == null)
            {
                return;
            }
            try
            {
#if DEBUG
                surfacePrimary.Draw(surfaceSecondary, DrawFlags.Wait);
#else
                surfacePrimary.Flip(surfaceSecondary,FlipFlags.Wait);
#endif
            }
            catch (SurfaceLostException)
            {
                this.createSurfaces();
            }
        }
    }
}

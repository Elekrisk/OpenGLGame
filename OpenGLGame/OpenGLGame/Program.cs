using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace OpenGLGame
{
    sealed class GameWindow : OpenTK.GameWindow
    {
        uint vertexbuffer;

        public GameWindow() : base(1280, 720, GraphicsMode.Default, "HELLO WURLD", GameWindowFlags.Default, DisplayDevice.Default, 3, 0, GraphicsContextFlags.ForwardCompatible)
        {
            Console.WriteLine("OpenGL version: " + GL.GetString(StringName.Version));
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, this.Width, this.Height);
        }

        protected override void OnLoad(EventArgs e)
        {
            GL.GenVertexArrays(1, out uint VertexArrayID);
            GL.BindVertexArray(VertexArrayID);

            float[] g_vertex_buffer_data = {
                -1.0f, -1.0f, 0.0f,
                1.0f, -1.0f, 0.0f,
                0.0f, 1.0f, 0.0f
            };

            GL.GenBuffers(1, out vertexbuffer);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexbuffer);
            GL.BufferData(BufferTarget.ArrayBuffer, g_vertex_buffer_data.Length, g_vertex_buffer_data, BufferUsageHint.StaticDraw);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            GL.EnableVertexAttribArray(0);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexbuffer);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);

            GL.DrawArrays(BeginMode.Triangles, 0, 3);
            GL.DisableVertexAttribArray(0);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.ClearColor(Color4.Purple);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            this.SwapBuffers();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            GameWindow window = new GameWindow();
            window.Run(60);
        }
    }
}

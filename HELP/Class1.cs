using System.Drawing;
using System.Web.UI;
using System.Windows.Forms;
public class SetControlRectangle
{
                public SetControlRectangle(System.Windows.Forms.Control p_Control)
    {
        m_Control = p_Control;
        m_Control.MouseUp += new MouseEventHandler(MyControl_MouseUp);
        m_Control.MouseMove += new MouseEventHandler(MyControl_MouseMove);
        m_Control.MouseDown += new MouseEventHandler(MyControl_MouseDown);
    }
    private System.Windows.Forms.Control m_Control;
    private bool m_MouseIsDown = false;
    private Rectangle m_MouseRect = Rectangle.Empty;
    private void ResizeToRectangle(Point p_Point)
    {
        DrawRectangle();
        m_MouseRect.Width = p_Point.X - m_MouseRect.Left;
        m_MouseRect.Height = p_Point.Y - m_MouseRect.Top;
        DrawRectangle();
    }
    private void DrawRectangle()
    {
        Rectangle _Rect = m_Control.RectangleToScreen(m_MouseRect);
        ControlPaint.DrawReversibleFrame(_Rect, Color.White, FrameStyle.Dashed);
    }
    private void DrawStart(Point p_Point)
    {
        m_Control.Capture = true;
        Cursor.Clip = m_Control.RectangleToScreen(new Rectangle(0, 0, m_Control.Width, m_Control.Height));
        m_MouseRect = new Rectangle(p_Point.X, p_Point.Y, 0, 0);
    }
    private void MyControl_MouseDown(object sender, MouseEventArgs e)
    {
        m_MouseIsDown = true;
        DrawStart(new Point(e.X, e.Y));
    }
    private void MyControl_MouseMove(object sender, MouseEventArgs e)
    {
        if (m_MouseIsDown) ResizeToRectangle(new Point(e.X, e.Y));
    }
    private void MyControl_MouseUp(object sender, MouseEventArgs e)
    {
        m_Control.Capture = false;
        Cursor.Clip = Rectangle.Empty;
        m_MouseIsDown = false;
        DrawRectangle();
        if (m_MouseRect.X == 0 || m_MouseRect.Y == 0 || m_MouseRect.Width == 0 || m_MouseRect.Height == 0)
        {
        }
        else
        {
            if (SetRectangel != null) SetRectangel(m_Control, m_MouseRect);
        }
        m_MouseRect = Rectangle.Empty;
    }
    public delegate void SelectRectangel(object sneder, Rectangle e);
    public event SelectRectangel SetRectangel;
}
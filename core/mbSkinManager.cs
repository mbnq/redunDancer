
/* 

    www.mbnq.pl 2024 
    https://mbnq.pl/
    mbnq00 on gmail

    Usage: MBBackgroundManager.SetBackgroundImage(this);

*/

// using System;
// using System.Drawing;
// using System.IO;
// using System.Windows.Forms;

public class MBBackgroundManager
{
    public static void SetBackgroundImage(Form targetForm)
    {

        string binDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string skinImagePath = Path.Combine(binDirectory, "customskin.png");

        if (File.Exists(skinImagePath))
        {
            try
            {
                Image backgroundImage = Image.FromFile(skinImagePath);

                targetForm.AllowTransparency = true;
                targetForm.BackgroundImage = backgroundImage;
                targetForm.BackgroundImageLayout = ImageLayout.None; // ImageLayout.Stretch

                // Welcome to stupid ideas zone

                // SetDefaultColors(targetForm, Color.Black);
            }
            catch (Exception ex)
            {
                // Console.WriteLine($"Failed to load background image: {ex.Message}");
            }
        }
        else
        {
            // Console.WriteLine("skin.png not found in the bin directory.");
        }

        /*
        static void SetDefaultColors(Control targetControl, Color backColor)
        {
            targetControl.BackColor = backColor;
            targetControl.ForeColor = backColor;

            foreach (Control control in targetControl.Controls)
            {
                SetDefaultColors(control, backColor);
            }
        }
        */
    }
}

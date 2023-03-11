

namespace TreeView;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
       

        // Get an array of file names as strings rather than FileInfo objects.
        // Use this method when storage space is an issue, and when you might
        // hold on to the file name reference for a while before you try to access
        // the file.
        string[] files = System.IO.Directory.GetDirectories("C:\\Users\\timat\\source\\repos\\TreeView\\TreeView", "*");

        foreach (string s in files)
        {
            // Create the FileInfo object only when needed to ensure
            // the information is as current as possible.
            System.IO.FileInfo fi = null;
            try
            {
                fi = new System.IO.FileInfo(s);
            }
            catch (System.IO.FileNotFoundException exp)
            {
                // To inform the user and continue is
                // sufficient for this demonstration.
                // Your application may require different behavior.
                Console.WriteLine(exp.Message);
                continue;
            }
            Shell.Current.DisplayAlert($"{fi.Name}",$"{fi.Extension}" ,$"{fi.DirectoryName}");
        }

       

    }
}

